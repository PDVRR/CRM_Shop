using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CRM_BL;
using CRM_BL.Model;

namespace CRM_UI
{
    public partial class ReflectionForm<T> : Form where T : class
    {
        private T item;
        private Type type;
        private PropertyInfo[] propertyInfos;
        private int x = 0, y = 2;


        public ReflectionForm(T item)
        {
            this.item = item;
            type = item.GetType();
            propertyInfos = type.GetProperties();
            InitializeComponent();
        }

        private void ReflectionForm_Load(object sender, EventArgs e)
        {
            CreateControls(propertyInfos);
            this.Text = type.Name.Split('_')[0] + " Form";
        }

        private void CreateControls(PropertyInfo[] propertys)
        {
            foreach (var propertyInfo in propertys)
            {
                string propertyType = propertyInfo.PropertyType.Name;
                //TODO: skip id and icollection
                if (propertyType == typeof(ICollection<T>).Name || propertyInfo.Name == "Id")
                    continue;

                Label labelForField = new Label()
                {
                    AutoSize = true,
                    Text = propertyInfo.Name,
                    Location = new Point(x, y)
                };
                this.Controls.Add(labelForField);

                switch (propertyType)
                {
                    case "Int32":
                        {
                            NumericUpDown numericUpDown = new NumericUpDown()
                            {
                                Location = new Point(x + 50, y - 2),
                                Value = Convert.ToDecimal(propertyInfo.GetValue(item)),
                                Name = propertyInfo.Name
                            };
                            this.Controls.Add(numericUpDown);
                            break;
                        }
                    case "String":
                        {
                            TextBox textBox = new TextBox()
                            {
                                Location = new Point(x + 50, y - 2)
                            };

                            if (propertyInfo.GetValue(item) != null)
                            {
                                textBox.Text = propertyInfo.GetValue(item).ToString();
                            }
                            this.Controls.Add(textBox);
                            break;
                        }
                    case "Decimal":
                        {
                            NumericUpDown decimalNumericUpDown = new NumericUpDown()
                            {
                                Location = new Point(x + 50, y - 2),
                                DecimalPlaces = 2,
                                Value = Convert.ToDecimal(propertyInfo.GetValue(item))
                            };
                            this.Controls.Add(decimalNumericUpDown);
                            break;
                        }
                }
                y += 27;

            }
            Button button = new Button()
            {
                AutoSize = true,
                Text = "Save changes",
                Location = new Point(x + 25, y - 2)
            };
            button.Click += SaveButton_Click;
            this.Controls.Add(button);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ArrayList controlValues = GetValuesFromControls();

            int id = FillRowWithValues(controlValues);
            FillValuesInDatabase(id);

            DialogResult = DialogResult.OK;
            Close();
        }

        private ArrayList GetValuesFromControls()
        {
            ArrayList fieldValues = new ArrayList();

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    fieldValues.Add(control.Text);
                }
                else if (control is NumericUpDown nud)
                {
                    fieldValues.Add(nud.Value);
                }
            }

            return fieldValues;
        }

        private int FillRowWithValues(ArrayList values)
        {
            int k = 0;
            int id = 0;
            foreach (var propertyInfo in propertyInfos)
            {
                string propertyType = propertyInfo.PropertyType.Name;
                if (propertyType == typeof(ICollection<T>).Name)
                    continue;
                if (propertyInfo.Name == "Id")
                {
                    id = (int)propertyInfo.GetValue(item);
                    continue;
                }

                if (propertyType == "Int32")
                {
                    values[k] = Convert.ToInt32(values[k]);
                }

                propertyInfo.SetValue(item, values[k]);
                k++;
            }

            return id;
        }

        private void FillValuesInDatabase(int id)
        {
            switch (item)
            {
                case Product product when id != 0:
                    new SQLProductRepository().Edit(product, id);
                    break;
                case Product product:
                    new SQLProductRepository().Add(product);
                    break;
                case Customer customer when id != 0:
                    new SQLCustomerRepository().Edit(customer, id);
                    break;
                case Customer customer:
                    new SQLCustomerRepository().Add(customer);
                    break;
                case Seller seller when id != 0:
                    new SQLSellerRepository().Edit(seller, id);
                    break;
                case Seller seller:
                    new SQLSellerRepository().Add(seller);
                    break;
            }
        }


    }
}
