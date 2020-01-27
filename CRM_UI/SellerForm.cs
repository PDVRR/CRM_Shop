using System;
using System.Windows.Forms;
using CRM_BL.Model;

namespace CRM_UI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }

        public SellerForm()
        {
            InitializeComponent();
        }

        private void AddSellerButton_Click(object sender, EventArgs e)
        {
            Seller = new Seller()
            {
                Name = sellerNameTextbox.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
