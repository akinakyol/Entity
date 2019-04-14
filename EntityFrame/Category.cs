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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet dsOrders = DbAccess.ReturnDataSet("Select * From Products Where SupplierID =" + cmbCategory.SelectedValue.ToString());
            dgvOrder.DataSource = dsOrders.Tables[0].DefaultView;
        }

        private void Category_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Clear();
            DataSet dsEmployee = DbAccess.ReturnDataSet("Select * From Suppliers");
            cmbCategory.DataSource = dsEmployee.Tables[0].DefaultView;
            cmbCategory.DisplayMember = "CompanyName";
            cmbCategory.ValueMember = "SupplierID";
        }

        private void dgvOrder_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
            DataSet dsProducts = DbAccess.ReturnDataSet("Select Sum(Quantity) From [Order Details] Where ProductId="
                +dgvOrder.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show(dsProducts.Tables[0].Rows[0][0].ToString());
        }
    }

    
}
