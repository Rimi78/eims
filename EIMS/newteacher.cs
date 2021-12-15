using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;

namespace EIMS
{
    public partial class newteacher : MetroFramework.Forms.MetroForm
    {
        string user;
        int theme;
        public newteacher(int themeNumber, string us, int updateMode = 0,string userName = null)
        {
            InitializeComponent();
            metroButton1.Enabled = false;
            theme = themeNumber;
            user = us;

            this.StyleManager = metroStyleManager1;
            if (themeNumber == 0)
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            }
            else
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            }
            if (updateMode == 1) {
                try
                {
                    SqlConnection mraCo = new SqlConnection();
                    mraCo.ConnectionString = db.conString;
                    SqlCommand retriveCommand = new SqlCommand("select * form teachers where user = '" + user + "' ", mraCo);
                    SqlDataReader reader = retriveCommand.ExecuteReader();
                    if(reader.Read())
                    {

                        nameTextBox.Text = reader.GetInt32(reader.GetOrdinal("name")).ToString();
                        designationTextBox.Text = reader.GetInt32(reader.GetOrdinal("designation")).ToString();
                        addressTextBox.Text = reader.GetInt32(reader.GetOrdinal("address")).ToString();
                        lastEduTextBox.Text = reader.GetInt32(reader.GetOrdinal("lastEdu")).ToString();
                        subjectTextBox.Text = reader.GetInt32(reader.GetOrdinal("subject")).ToString();
                        emailTextBox.Text = reader.GetInt32(reader.GetOrdinal("email")).ToString();
                        phoneTextBox.Text = reader.GetInt32(reader.GetOrdinal("phone")).ToString();
                        nidTextBox.Text= reader.GetInt32(reader.GetOrdinal("NID")).ToString();
                        userTextBox.Text = user;
                        userTextBox.Enabled = false;

                        metroButton1.Enabled = false;
                        metroButton1.Visible = false;
                        updateButton.Enabled = true;
                        updateButton.Visible = true;
                        resetPassButton.Enabled = true;
                        resetPassButton.Visible = true;




                    }


                }
                catch(Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



                }
            }

        }

        private void newteacher_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            zeroitMacOSX1.Visible = true;
            SqlConnection mraCo = new SqlConnection();
            mraCo.ConnectionString = db.conString;
            string inserCommandString = "INSERT into teachers(name , designation , address ,lastEdu,subject, email , phone ,NID ,pass , [user] ) VALUES('" + nameTextBox.Text + "','" + designationTextBox.Text + "','" + addressTextBox.Text + "','" + lastEduTextBox.Text + "','" + subjectTextBox.Text + "','" + emailTextBox.Text + "','" + phoneTextBox.Text + "','" + nidTextBox.Text + "','123456','"+userTextBox.Text+"' );";

            try
            {

                mraCo.Open();
                SqlCommand incertCommand = new SqlCommand(inserCommandString, mraCo);
                if (incertCommand.ExecuteNonQuery() == 1)
                {
                    MetroFramework.MetroMessageBox.Show(this,nameTextBox.Text + " added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mraCo.Close();

                    panel p = new panel(user,theme);
                    p.display();
                    this.Hide();

                }



            }
            catch (Exception EX)
            {
                StreamWriter wri = new StreamWriter("abir.txt");
                wri.WriteLine(EX.Message);
                wri.Close();
                zeroitMacOSX1.Visible = false;
                if (EX.Message.ToString().Contains("The duplicate key value is"))
                {
                    MetroFramework.MetroMessageBox.Show(this, userTextBox.Text + " is taken ,use another user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    mraCo.Close();
                }
                else
                {

                    // MetroFramework.MetroMessageBox.Show(this, EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void newteacher_Shown(object sender, EventArgs e)
        {
            

        }

        private void newteacher_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
        }

        private void nidTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
            else {
                metroButton1.Enabled = false;
            }
        }

        private void phoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
            else
            {
                metroButton1.Enabled = false;
            }

        }

        private void emailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
            else
            {
                metroButton1.Enabled = false;
            }

        }

        private void subjectTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
            else
            {
                metroButton1.Enabled = false;
            }
        }

        private void lastEduTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
            else
            {
                metroButton1.Enabled = false;
            }
        }

        private void addressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
            else
            {
                metroButton1.Enabled = false;
            }
        }

        private void designationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
            else
            {
                metroButton1.Enabled = false;
            }
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.ToString() != "" && designationTextBox.Text.ToString() != "" && addressTextBox.Text.ToString() != "" && lastEduTextBox.Text.ToString() != "" && subjectTextBox.Text.ToString() != "" && emailTextBox.Text.ToString() != "" && phoneTextBox.Text.ToString() != "" && nidTextBox.Text.ToString() != "")
            {
                metroButton1.Enabled = true;
            }
            else
            {
                metroButton1.Enabled = false;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }

        private void resetPassButton_Click(object sender, EventArgs e)
        {

        }

        private void userTextBox_Click(object sender, EventArgs e)
        {

        }
    }
}
