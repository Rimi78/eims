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
    public partial class AddSchedule : MetroFramework.Forms.MetroForm
    {
        public string courseName;
        public string batchName;
        public string seassion;
        public AddSchedule(string course,string batch,string sessionID)
        {
            InitializeComponent();
            courseName = course;
            batchName = batch;
            seassion = sessionID;
            nameLabel.Text = "Course Name = "+course;
            seassionLabel.Text = "seassion = "+sessionID;
            batchLabel.Text ="Batch = "+ batch;

            display();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            //try
            //{
                string constring = db.conString;

                con.ConnectionString = constring;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Schedule where session = '" + seassion + "' and day = '" + day1TextBox1.Text + "' and time = '" + time1ComboBox.Text + "' and room = '" + room1TextBox.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int data1 = 0;
                foreach (DataRow item in dt.Rows)
                {
                    data1 = 1;

                    MetroFramework.MetroMessageBox.Show(this, "This  Schedule is booked for " + item[3].ToString() + " " + item[4].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                if (data1==0) {
                Console.WriteLine("done");
                    SqlCommand sdaa = new SqlCommand("insert into Schedule values('" + day1TextBox1.Text + "','" + time1ComboBox.Text + "','" + room1TextBox.Text + "','" + batchName + "', '"+courseName+"', '"+seassion+"') ", con);
                    sdaa.ExecuteNonQuery();
                    MetroFramework.MetroMessageBox.Show(this, " Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    display();
                }




                



                con.Close();
            //}
            //catch (SqlException ex)
            //{
            //    con.Close();
            //    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //}
        }
        public void display()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                string constring = db.conString;

                con.ConnectionString = constring;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Schedule where batch = '" + batchName + "' and course = '" + courseName + "' and session ='"+seassion+"' ",con);
               

                DataTable dt = new DataTable();
                
               
                sda.Fill(dt);
                scheduleGrid.Rows.Clear();
                
                foreach (DataRow item in dt.Rows)
                {
                    int n = scheduleGrid.Rows.Add();
                    scheduleGrid.Rows[n].Cells[0].Value = item[0].ToString();
                    scheduleGrid.Rows[n].Cells[1].Value = item[1].ToString();
                    scheduleGrid.Rows[n].Cells[2].Value = item[2].ToString();
                    
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
