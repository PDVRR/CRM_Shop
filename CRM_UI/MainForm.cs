using System;
using System.Data.Entity;
using System.Windows.Forms;
using CRM_BL.Model;

namespace CRM_UI
{
    public partial class MainForm : Form
    {
        private CrmContext db;
        public MainForm()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void CheckTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkCatalog = new Catalog<Check>(db.Checks);
            checkCatalog.Show();
        }

        private void ProductTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productCatalog = new Catalog<Product>(db.Products);
            productCatalog.Show();
        }

        private void SellerTableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sellerCatalog = new Catalog<Seller>(db.Sellers);
            sellerCatalog.Show();
        }

        private void CustomerTableToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var customerCatalog = new Catalog<Customer>(db.Customers);
            customerCatalog.Show();
        }

        private void AddCustomerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new ReflectionForm<Customer>(new Customer());
            if (form.ShowDialog() != DialogResult.OK) return;
        }

        private void AddProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ReflectionForm<Product>(new Product());
            if (form.ShowDialog() != DialogResult.OK) return;
        }

        private void AddSellerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new ReflectionForm<Seller>(new Seller());
            if (form.ShowDialog() != DialogResult.OK) return;
        }
    }
}
