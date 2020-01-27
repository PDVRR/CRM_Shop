using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace CRM_UI
{
    public partial class Catalog<T> : Form where T : class
    {
        public Catalog(DbSet<T> set)
        {
            InitializeComponent();
            catalogDGV.DataSource = set.Local.ToBindingList();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private void catalogDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
