using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EntityFrame
{
    class DbAccess
    {
        static SqlConnection cn = new SqlConnection();
        private static void Open()
        {
            cn.ConnectionString = "Data Source = COSANOSTRA; Initial Catalog = Northwind; Integrated Security=True;";
            cn.Open();
        }
        private static void Close()
        {
            cn.Close();
        }

        public static DataSet ReturnDataSet(string SQL)
        {
            SqlDataAdapter da = new SqlDataAdapter(SQL, cn);
            DataSet ds = new DataSet();
            Open();
            da.Fill(ds);
            Close();
            return ds;
        }        
    }
}
