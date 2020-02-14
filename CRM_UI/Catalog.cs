using System;
using System.CodeDom;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows.Forms;
using CRM_BL.Model;
using CRM_BL;

namespace CRM_UI
{
    public partial class Catalog<T> : Form where T : class, new()
    {
        private DbSet<T> set;
        public Catalog(DbSet<T> set)
        {
            this.set = set;
            InitializeComponent();
            catalogDGV.DataSource = set.Local.ToBindingList();
            set.Load();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var id = catalogDGV.SelectedRows[0].Cells[0].Value;
            var productCatalog = new ReflectionForm<T>(set.Find(id));
            productCatalog.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = (int)catalogDGV.SelectedRows[0].Cells[0].Value;
            if (typeof(T) == typeof(Product))
            {
                new SQLProductRepository().Delete(id);
            }
            else if (typeof(T) == typeof(Customer))
            {
                new SQLCustomerRepository().Delete(id);
            }
            else if (typeof(T) == typeof(Customer))
            {
                new SQLSellerRepository().Delete(id);
            }

            catalogDGV.Update();
            catalogDGV.Refresh();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var form = new ReflectionForm<T>(new T());
            if (form.ShowDialog() != DialogResult.OK) return;
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Check))
            {
                addButton.Enabled = false;
                editButton.Enabled = false;
            }
        }
    }
}
