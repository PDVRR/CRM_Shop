using System;
using System.Windows.Forms;
using CRM_BL.Model;

namespace CRM_UI
{
    public partial class CustomerForm : Form
    {

        public Customer Customer { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = customerNameTextbox.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
