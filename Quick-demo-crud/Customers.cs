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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            model.FirstName = txtFirstName.Text.Trim();
            model.LastName = txtLastName.Text.Trim();
            model.City = txtCity.Text.Trim();
            model.Address = txtAddress.Text.Trim();

            using (QDCRUDEntities db = new QDCRUDEntities())
            {
                db.Customer.Add(model);
                db.SaveChanges();
            }
            MessageBox.Show("Submitted Sussessfully!");
            Clear();
        }
    }
}
