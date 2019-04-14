using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EntityFrame
{
    public partial class EmployeeOrder : Form
    {
        public EmployeeOrder()
        {
            InitializeComponent();
        }
        public static string veri;

        public void EmployeeOrder_Load(object sender, EventArgs e)
        {
            cmbEmployee.Items.Clear();
            DataSet dsEmployee = DbAccess.ReturnDataSet("Select * From Employees");
            cmbEmployee.DataSource = dsEmployee.Tables[0].DefaultView;
            cmbEmployee.DisplayMember = "FirstName";
            cmbEmployee.ValueMember = "EmployeeID";
        }

        public void cmbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet dsOrders = DbAccess.ReturnDataSet("Select * From Orders Where EmployeeID =" 
                + cmbEmployee.SelectedValue.ToString());
            dgvOrders.DataSource = dsOrders.Tables[0].DefaultView;
        }

        public void dgvOrders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {                        
            veri = dgvOrders.CurrentRow.Cells[0].Value.ToString();
            OrderDetailsGrid view = new OrderDetailsGrid();
            view.Show();            
        }
    }
}
