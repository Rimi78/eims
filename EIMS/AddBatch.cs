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

namespace EIMS
{
    public partial class AddBatch : MetroFramework.Forms.MetroForm
    {
        public AddBatch()
        {
            InitializeComponent();
        }

        private void AddBatch_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            try
            {
                string constring = db.conString;

                con.ConnectionString = constring;
                con.Open();
                SqlCommand sda = new SqlCommand("insert into batch values('" + idTextBox.Text + "','" +sessionTextBox.Text+":"+ nameTextBox.Text + "','" + teacherComboBox.Text + "','" + sessionTextBox.Text + "','" + startTextBox.Text + "','" + endTextBox.Text + "') ", con);
                sda.ExecuteNonQuery();
                MetroFramework.MetroMessageBox.Show(this,nameTextBox.Text+" Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (SqlException ex)
            {
                con.Close();
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        private void teacherComboBox_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection();
                try
                {
                    string constring = db.conString;

                    con.ConnectionString = constring;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT name FROM teachers ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                   // dataGridView1.Rows.Clear();
                    foreach (DataRow item in dt.Rows)
                    {
                       // int n = dataGridView1.Rows.Add();
                        teacherComboBox.Items.Add(item[0].ToString());
                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    con.Close();
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            

        }
    }
}
