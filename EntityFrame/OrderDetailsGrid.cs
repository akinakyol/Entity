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
    public partial class OrderDetailsGrid : Form
    {
        public OrderDetailsGrid()
        {
            InitializeComponent();
        }

        private void OrderDetailsGrid_Load(object sender, EventArgs e)
        {
            DataSet dsProducts = DbAccess.ReturnDataSet("Select * From [Order Details] Where OrderID="
                 + EmployeeOrder.veri);
            dgvOrderDetails.DataSource = dsProducts.Tables[0].DefaultView;
            
        }
    }
}
