using System;
using System.Windows.Forms;
using CRM_BL.Model;

namespace CRM_UI
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }

        public ProductForm()
        {
            InitializeComponent();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            Product = new Product()
            {
                Name = productNameTextbox.Text,
                Price = productPriceNUD.Value,
                Count = Convert.ToInt32(productCountNUD.Value)
            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
