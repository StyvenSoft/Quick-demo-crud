using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_demo_crud
{
    public partial class Customers : Form
    {

        Customer model = new Customer();

        public Customers()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtCity.Text = txtAddress.Text = "";
            btnAdd.Text = "Save";
            btnDelete.Enabled = false;
            model.CustomerID = 0;
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
