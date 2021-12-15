using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.SqlClient;
namespace EIMS
{
    public partial class StudentInfo : MetroFramework.Forms.MetroForm
    {
        public string pubID;
        public static string updateValue;
        public static int updateAction=0;


        public StudentInfo(string ID, string name , string Phone , string pass , string motName, string fatname, string motID , string fatID, string bldgrp, string dob, string programm ,string gender, byte[] img,int themeNumber)
        {
            pubID = ID;
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            if (themeNumber == 0)
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            }
            else
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            }
            NameLabel.Text = name;
            IDLabel.Text = ID;
            phoneLabel.Text = Phone;
            passLabel.Text = pass;
            motNameLabel.Text = motName;
            fatNameLabel.Text = fatname;
            MotNidLabel.Text = motID;
            FatNidLabel.Text = fatID;
            bloodGrpLabel.Text = bldgrp;
            dobLabel.Text = dob;
            programmLabel.Text = programm;
            genderLabel.Text = gender;
            MemoryStream ms = new MemoryStream(img);
            
            studentPictureBox.Image = Image.FromStream(ms);
            nameUpdate.Enabled = false;
            nameUpdate.Visible = false;
            fatNameUpdateButton.Enabled = false;
            fatNameUpdateButton.Visible = false;
            motNameUpdateButton.Enabled = false;
            motNameUpdateButton.Visible = false;
            phoneUpdateButton.Enabled = false;
            phoneUpdateButton.Visible = false;
            passUpdateButton.Enabled = false;
            passUpdateButton.Visible = false;
            FatNidUpdateButton.Enabled = false;
            FatNidUpdateButton.Visible = false;
            MotNIDUpdateButton.Enabled = false;
            MotNIDUpdateButton.Visible = false;
            PicUpdateButton.Enabled = false;
            PicUpdateButton.Visible = false;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void nameUpdate_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo("Enter Student Name :", NameLabel.Text);
            up.ShowDialog();
            if (updateAction == 1) {
              int news =   updater("name", updateValue);
                if (news == 1)
                {
                    NameLabel.Text = updateValue;
                    updateAction = 0;

                }


            }
               

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            nameUpdate.Enabled = true;
            nameUpdate.Visible = true;
            fatNameUpdateButton.Enabled = true;
            fatNameUpdateButton.Visible = true;
            motNameUpdateButton.Enabled = true;
            motNameUpdateButton.Visible = true;
            phoneUpdateButton.Enabled = true;
            phoneUpdateButton.Visible = true;
            passUpdateButton.Enabled = true;
            passUpdateButton.Visible = true;
            updateDateOfBrithButton.Visible = true;
            updateDateOfBrithButton.Enabled = true;

            FatNidUpdateButton.Enabled = true;
            FatNidUpdateButton.Visible = true;
            MotNIDUpdateButton.Enabled = true;
            MotNIDUpdateButton.Visible = true;
            PIcSelectButton.Enabled = true;
            PIcSelectButton.Visible = true;
        }

        private void fatNameUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo("Enter Student Fathers Name :", fatNameLabel.Text);
            up.ShowDialog();
            if (updateAction == 1)
            {
                int news = updater("fatName", updateValue);
                if (news == 1)
                {
                    fatNameLabel.Text = updateValue;
                    updateAction = 0;

                }


            }

        }

        private void motNameUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo("Enter Student Mothers Name :", motNameLabel.Text);
            up.ShowDialog();
            if (updateAction == 1)
            {
                int news = updater("motName", updateValue);
                if (news == 1)
                {
                    motNameLabel.Text = updateValue;
                    updateAction = 0;

                }


            }

        }

        private void phoneUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo("Enter Phone Number :", phoneLabel.Text);
            up.ShowDialog();
            if (updateAction == 1)
            {
                int news = updater("phone", updateValue);
                if (news == 1)
                {
                    phoneLabel.Text = updateValue;
                    updateAction = 0;

                }


            }

        }

        private void passUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo("Enter New Pass Word :", passLabel.Text);
            up.ShowDialog();
            if (updateAction == 1)
            {
                int news = updater("pass", updateValue);
                if (news == 1)
                {
                   passLabel.Text = updateValue;
                    updateAction = 0;

                }


            }
        }

        private void MotNIDUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo("Enter Mothers NID :", MotNidLabel.Text);
            up.ShowDialog();
            if (updateAction == 1)
            {
                int news = updater("mothID", updateValue);
                if (news == 1)
                {
                    MotNidLabel.Text = updateValue;
                    updateAction = 0;

                }


            }
        }

        private void FatNidUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo("Enter Fathers NID :", FatNidLabel.Text);
            up.ShowDialog();
            if (updateAction == 1)
            {
                int news = updater("fathID", updateValue);
                if (news == 1)
                {
                    FatNidLabel.Text = updateValue;
                    updateAction = 0;

                }


            }

        }

        private void PicUpdateButton_Click(object sender, EventArgs e)
        {
            SqlConnection mraCo = new SqlConnection(db.conString);
            try
            {
                mraCo.Open();
                MemoryStream ms = new MemoryStream();
                studentPictureBox.Image.Save(ms, studentPictureBox.Image.RawFormat);
                byte[] img = ms.ToArray();
                string inserCommandString = "update  students set pic = @IMG where id = '" + pubID + "';";
                //MessageBox.Show(inserCommandString);
                SqlCommand lastCodeCommand = new SqlCommand(inserCommandString, mraCo);
                lastCodeCommand.Parameters.Add("@IMG", SqlDbType.Image);
                lastCodeCommand.Parameters["@IMG"].Value = img;

                if (lastCodeCommand.ExecuteNonQuery() == 1)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Update Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
        }
            catch (Exception ex) {
                MetroFramework.MetroMessageBox.Show(this, "Please Try Again Later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 mraCo.Close();
                
            }
}

private int updater(string updateField, string UpdateFieldValue) {
            SqlConnection mraCo = new SqlConnection();
            try
            {
               
                mraCo.ConnectionString = db.conString;
                string lastCodeString = "update students set "+ updateField + " = '" + UpdateFieldValue + "' where id = "+IDLabel.Text+"; ";
                mraCo.Open();
                SqlCommand updateLastcodeCommand = new SqlCommand(lastCodeString, mraCo);

                if (updateLastcodeCommand.ExecuteNonQuery() == 1)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Information Updated Successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mraCo.Close();
                    return 1;
                    
                }
                else {
                    MetroFramework.MetroMessageBox.Show(this, "Please Try Again Later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    mraCo.Close();
                    return 0;
                }



            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                mraCo.Close();
                return 0;

            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Documents/" + pubID + ".pdf");
            //System.Diagnostics.Process.Start("abir.txt");
           System.Diagnostics.Process.Start(@"Documents\" + pubID + ".pdf");
        }

        private void updateDateOfBrithButton_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo("Enter Date of Birth :", dobLabel.Text,1);
            up.ShowDialog();
            if (updateAction == 1)
            {
                int news = updater("DOB", updateValue);
                if (news == 1)
                {
                    dobLabel.Text = updateValue;
                    updateAction = 0;

                }


            }
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {

        }

        private void PIcSelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {


                studentPictureBox.Image = System.Drawing.Image.FromFile(opf.FileName);
            }
            PicUpdateButton.Enabled = true;
            PicUpdateButton.Visible = true;


        }
    }
}
