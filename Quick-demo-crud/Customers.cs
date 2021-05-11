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
            populateDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Complete the information");
                return;
            }

            model.FirstName = txtFirstName.Text.Trim();
            model.LastName = txtLastName.Text.Trim();
            model.City = txtCity.Text.Trim();
            model.Address = txtAddress.Text.Trim();

            using (QDCRUDEntities db = new QDCRUDEntities())
            {
                if (model.CustomerID == 0)
                    db.Customer.Add(model);
                else
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Submitted Sussessfully!");
            populateDataGridView();
            Clear();
        }

        void populateDataGridView()
        {
            dgvCustomer.AutoGenerateColumns = false;
            using (QDCRUDEntities db = new QDCRUDEntities())
            {
                dgvCustomer.DataSource = db.Customer.ToList<Customer>();
            }
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow.Index != -1)
            {
                model.CustomerID = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["CustomerID"].Value);

                using (QDCRUDEntities db = new QDCRUDEntities())
                {
                    model = db.Customer.Where(x => x.CustomerID == model.CustomerID).FirstOrDefault();
                    txtFirstName.Text = model.FirstName;
                    txtLastName.Text = model.LastName;
                    txtCity.Text = model.City;
                    txtAddress.Text = model.Address;
                }
                btnAdd.Text = "Update";
                btnDelete.Enabled = true;
            }
        }
    }
}
