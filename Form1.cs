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
using System.Data;

namespace ImmigrationIntegration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Connection = "data source=tcp:evening.database.windows.net,1433;Initial Catalog=StudentDB;Persist Security Info=False;User ID=Student$$21;Password=Nash@$2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand("Select * from tbluser where Username='" + txtUser.Text + "' and Password = '" + txtPassword.Text + "'", con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        // to check login page.
                        frmimmigrants frmimg = new frmimmigrants();
                        frmimg.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Your Username and Password is invalid!");
                    }
                }



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
