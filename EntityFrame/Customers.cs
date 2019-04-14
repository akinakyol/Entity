using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrame
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void cmbOrders_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet dsOrders = DbAccess.ReturnDataSet("Select * From Orders Where CustomerID ='" + cmbOrders.SelectedValue.ToString()+"'");
            dgvCustomers.DataSource = dsOrders.Tables[0].DefaultView;
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            cmbOrders.Items.Clear();
            DataSet dsEmployee = DbAccess.ReturnDataSet("Select * From Customers");
            cmbOrders.DataSource = dsEmployee.Tables[0].DefaultView;
            cmbOrders.DisplayMember = "CompanyName";
            cmbOrders.ValueMember = "CustomerID";
        }
    }
}
