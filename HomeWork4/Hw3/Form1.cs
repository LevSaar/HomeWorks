using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hw3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder connect =
                new SqlConnectionStringBuilder();
            connect.InitialCatalog = "MyDB";
            connect.DataSource = @"(local)\MSSQLSERVER01";
            connect.ConnectTimeout = 30;
            connect.IntegratedSecurity = true;
            
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = connect.ConnectionString;
                cn.Open();
                label1.Enabled = true;
                cn.Close();
            }
        }
    }
}
