using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM_BL.Model;

namespace CRM_UI
{
    public partial class MainForm : Form
    {
        private CrmContext db;
        private Cart cart;
        private Customer customer;
        private CashRegister cashRegister;
        public MainForm()
        {
            InitializeComponent();
            db = new CrmContext();
            cart = new Cart(customer);
            cashRegister = new CashRegister(1, db.Sellers.FirstOrDefault(), db)
            {
                IsModel = false
            };
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

        private void ModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModelForm();
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                productListBox.Invoke((Action) UpdateListBoxes);
            });
        }

        private void productListBox_DoubleClick(object sender, EventArgs e)
        {
            if (!(productListBox.SelectedItem is Product product)) return;
            cart.Add(product);
            cartListBox.Items.Add(product);
            totalSumLabel.Text = cart.Price.ToString();
        }

        private void UpdateListBoxes()
        {
            var products = db.Products.ToArray();
            productListBox.Items.AddRange(products);
            cartListBox.Items.AddRange(cart.GetAll().ToArray());
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var tempCustomer = db.Customers.FirstOrDefault(c => c.Name.Equals(form.Customer.Name));
                if (tempCustomer != null)
                {
                    customer = tempCustomer;
                }
                else
                {
                    db.Customers.Add(form.Customer);
                    db.SaveChanges();
                    customer = form.Customer;
                }
                cart.Customer = customer;

                loginLabel.Text = $"Welcome, {customer.Name}.";
                loginButton.Text = "Log Out";
            }
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            if (customer != null && cartListBox.Items != null)
            {
                cashRegister.Enqueue(cart);
                var price = cashRegister.Dequeue();
                MessageBox.Show($"You bought {cart.Count} products with a totall value of {price}");
                cart = new Cart(customer);
                cartListBox.Items.Clear();
                totalSumLabel.Text = "0";
            }
            else
            {
                MessageBox.Show("You are not authorized!");
            }
        }
    }
}
