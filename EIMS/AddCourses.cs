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
    public partial class AddCourses : MetroFramework.Forms.MetroForm
    {
        public int sessionDropCount = 1;
        public int sessionDropCount1 = 1;
        public AddCourses()
        {
            InitializeComponent();
        }

        private void metroComboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (sessionDropCount == 1)
            {
                SqlConnection con = new SqlConnection();
                try
                {
                    string constring = db.conString;

                    con.ConnectionString = constring;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT batchName FROM batch where seassion = '" + sessionTextBox.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    
                    foreach (DataRow item in dt.Rows)
                    {

                        metroComboBox2.Items.Add(item[0].ToString());
                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    con.Close();
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
            sessionDropCount = 0;
        }

        private void instructorComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sessionDropCount1 == 1)
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
                    
                    foreach (DataRow item in dt.Rows)
                    {
                       
                        instructorComboBox.Items.Add(item[0].ToString());
                    }
                    con.Close();
                    sessionDropCount1++;
                }
                catch (SqlException ex)
                {
                    con.Close();
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
           
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                con.ConnectionString =db.conString;
                con.Open();
                   
                    SqlCommand sdaa = new SqlCommand("insert into courses values('"+nameTextBox.Text+ "','"+metroComboBox2.Text+ "','"+sessionTextBox.Text+ "','"+instructorComboBox.Text+ "', 'Un Scheduled') ", con);
                    sdaa.ExecuteNonQuery();
                    MetroFramework.MetroMessageBox.Show(this, nameTextBox.Text + " Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                AddSchedule ss = new AddSchedule(nameTextBox.Text, metroComboBox2.Text, sessionTextBox.Text);
                ss.ShowDialog();


                con.Close();
            }
            catch (SqlException ex)
            {
                con.Close();
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

        }

        private void sessionTextBox_TextChanged(object sender, EventArgs e)
        {
            metroComboBox2.Items.Clear();
            sessionDropCount = 1;
        }
    }
}
