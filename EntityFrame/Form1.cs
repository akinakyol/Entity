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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {                              
            DataSet dsCategories = DbAccess.ReturnDataSet("Select CategoryId, CategoryName From Categories");           
            cmbCategory.DataSource = dsCategories.Tables[0].DefaultView;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";           
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {                           
            DataSet dsProducts = DbAccess.ReturnDataSet("Select * From Products Where  CategoryId =" + cmbCategory.SelectedValue.ToString()); 
            dgvProducts.DataSource = dsProducts.Tables[0].DefaultView;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
