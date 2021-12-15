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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;


using System.IO;
using QRCoder;

namespace EIMS
{
    public partial class panel : MetroFramework.Forms.MetroForm
    {
        string sex;
        string user;
        string programm;
        string bloodGrp;
        string DOB;
        static  System.Drawing.Image resizedImage;
        public int theme;
        public int sessionDropCount = 0;
        public panel(string us,int themeNumber)
        {
            InitializeComponent();
            user = us;
            theme = themeNumber;
            logOutButton.Text = "Logout " + us;
            this.StyleManager = metroStyleManager1;
            if (themeNumber == 0)
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                dataGridView1.BackgroundColor = Color.Black;
                dataGridView1.ForeColor = Color.Violet;
            }
            else {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                dataGridView1.BackgroundColor = Color.White;
            }
            display();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            Form1 l = new Form1();
            this.Hide();
            l.ShowDialog();
        }

        private void Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            resizedImage = Resize(studentPictureBox.Image, 100, 100);
            if (stNameTextBox.Text != "")
            {
                
                MemoryStream ms = new MemoryStream();
                studentPictureBox.Image.Save(ms, studentPictureBox.Image.RawFormat);
                byte[] img = ms.ToArray();
                SqlConnection mraCo = new SqlConnection();
               

                
                int StudentID=0;
                string inserCommandString;
                string studentIdRetriveCommandString = "select * from laststudentid where  lastID > 1;";
                
                mraCo.ConnectionString = db.conString;
                try
                {
                    mraCo.Open();
                    SqlCommand studentIdRetriveCommand = new SqlCommand(studentIdRetriveCommandString, mraCo);
                    SqlDataReader getNameReader;
                    getNameReader = studentIdRetriveCommand.ExecuteReader();
                    if (getNameReader.Read())//get string
                    {
                    //string temp =
                    //MessageBox.Show(temp);
                    StudentID = getNameReader.GetInt32(getNameReader.GetOrdinal("lastID"));
                    getNameReader.Close();
                    }
                    DOB = dobDateTime.Text;

                    string[] d = DOB.Split(',');
                    


                    inserCommandString = "INSERT into students(id , name , phone , pass ,motName,fatName, mothID , fathID , bldGrp ,DOB, program , gender,pic) VALUES('" + StudentID.ToString() + "','" + stNameTextBox.Text + "','" + stPhoneTextBox.Text + "','123456','"+fatNameTextBox.Text+"','"+motNameTextBox.Text+"','" + motNIDTextBox.Text + "','" + fatNIDTextBox.Text + "','" + bloodGrp + "','"+dobDateTime.Text+"' ,'" + classComboBox.Text + "','" + sex + "',@IMG);";
                    //MessageBox.Show(inserCommandString);
                    SqlCommand lastCodeCommand = new SqlCommand(inserCommandString, mraCo);
                    lastCodeCommand.Parameters.Add("@IMG", SqlDbType.Image);
                    lastCodeCommand.Parameters["@IMG"].Value = img;

                    if (lastCodeCommand.ExecuteNonQuery() == 1)
                    { };
                    StudentID++;
                    string lastCodeString = "update laststudentid set lastID = '" + StudentID.ToString() + "' where lastID >1; ";
                    SqlCommand updateLastcodeCommand = new SqlCommand(lastCodeString, mraCo);

                    if (updateLastcodeCommand.ExecuteNonQuery() == 1)
                    {
                        StudentID--;
                    };


                    mraCo.Close();
                    pdfWriter(StudentID);
                    //MySqlCommand insertCommand = new MySqlCommand();
                    MetroFramework.MetroMessageBox.Show(this, stNameTextBox.Text + " Added successfully with ID : " + StudentID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stNameTextBox.Text = "";
                    fatNameTextBox.Text = "";
                    motNameTextBox.Text = "";
                    stPhoneTextBox.Text = "";
                    birthIDTextBox.Text = "";
                    fatNIDTextBox.Text = "";
                    motNIDTextBox.Text = "";
                    studentPictureBox.Image = null;

            }
                catch (Exception EX)
            {
                mraCo.Close();
                MetroFramework.MetroMessageBox.Show(this, EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }







        }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Enter a student name!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private new System.Drawing.Image Resize(System.Drawing.Image image, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            Graphics graphic = Graphics.FromImage(bmp);
            graphic.DrawImage(image, 0, 0, w, h);
            graphic.Dispose();

          //  bmp.Save("yyy.jpeg");
            return bmp;
        }

      


        private void pdfWriter(int ID)
        {
             resizedImage = Resize(studentPictureBox.Image, 100, 100);
             Document abirDoc = new Document();
            PdfWriter.GetInstance(abirDoc, new FileStream("Documents/"+ID.ToString() + ".pdf", FileMode.Create));

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ID.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
           // iTextSharp.text.Image QRIMG = iTextSharp.text.Image.GetInstance(QRIMG, System.Drawing.Imaging.ImageFormat.Bmp);

            iTextSharp.text.Image pdfImg = iTextSharp.text.Image.GetInstance(resizedImage, System.Drawing.Imaging.ImageFormat.Bmp);
            Paragraph softName = new Paragraph(" School Admission system ");
            Paragraph name = new Paragraph("Name           : " + stNameTextBox.Text);
            Paragraph sID =  new Paragraph("Student ID     : " + ID.ToString());
            Paragraph Fname =new Paragraph("Fathers Name   : " + fatNameTextBox.Text);
            Paragraph clas = new Paragraph("Class          : " + programm);
            Paragraph num =  new Paragraph("Contact Number : " + stPhoneTextBox.Text);
            Paragraph Mname =new Paragraph("Mothers Name   : " + motNameTextBox.Text);
            Paragraph copyRight = new Paragraph("\n\n\n\nDesigned and developed by Raycon Lab");
            copyRight.Alignment = Element.ALIGN_BOTTOM;
            copyRight.Alignment = Element.ALIGN_RIGHT;
           // cvCode.Alignment = Element.ALIGN_LEFT;
            pdfImg.Alignment = Element.ALIGN_LEFT;
            softName.Alignment = Element.ALIGN_CENTER;
            name.Alignment = Element.ALIGN_LEFT;
            sID.Alignment = Element.ALIGN_LEFT;
            Fname.Alignment = Element.ALIGN_LEFT;
            Mname.Alignment = Element.ALIGN_LEFT;
            clas.Alignment = Element.ALIGN_LEFT;
            num.Alignment = Element.ALIGN_LEFT;
            abirDoc.Open();
            abirDoc.Add(softName);
            abirDoc.Add(pdfImg);
            abirDoc.Add(name);
            abirDoc.Add(sID);
            abirDoc.Add(clas);
            abirDoc.Add(num);
            abirDoc.Add(Fname);
            abirDoc.Add(Mname);
            //abirDoc.Add(cvCode);
            abirDoc.Add(copyRight);
            abirDoc.Close();
           // System.Diagnostics.Process.Start("Documents/" + ID.ToString() + ".pdf");
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sex = "Male";
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sex = "Female";
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {

                
                studentPictureBox.Image = System.Drawing.Image.FromFile(opf.FileName);
            }
        }

        private void dobDateTime_ValueChanged(object sender, EventArgs e)
        {
           
            

        }

        private void bloadGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bloadGroupComboBox.SelectedIndex)
            {
                case 0:
                    bloodGrp = "A+";
                    break;
                case 1:
                    bloodGrp = "A-"; 
                    break;
                case 2:
                    bloodGrp = "B+"; 
                    break;
                case 3:
                    bloodGrp = "B-"; 
                    break;
                case 4:
                    bloodGrp = "AB+"; 
                    break;
                case 5:
                    bloodGrp = "AB-"; 
                    break;
                case 6:
                    bloodGrp = "O+"; 
                    break;
                case 7:
                    bloodGrp = "O-";
                    break;
                





            }

        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)  //useless
        {
            switch (classComboBox.SelectedIndex)
            {
                case 0:
                    programm = "1";
                    break;
                case 1:
                    programm = "2";
                    break;
                case 2:
                    programm = "3";
                    break;
                case 3:
                    programm = "4";
                    break;
                case 4:
                    programm = "5";
                    break;
                case 5:
                    programm = "6";
                    break;
                case 6:
                    programm = "7";
                    break;
                case 7:
                    programm = "8";
                    break;
                case 8:
                    programm = "9 Science";
                    break;
                case 9:
                    programm = "9 business";
                    break;
                case 10:
                    programm = "9 Arts";
                    break;
                case 11:
                    programm = "10 Science";
                    break;
                case 12:
                    programm = "10 business";
                    break;
                case 13:
                    programm = "10 Arts";
                    break;
                

            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            SqlConnection mraCo = new SqlConnection();
            mraCo.ConnectionString = db.conString;
           string scarchString = "SELECT * from students where id = '"+ stIDTextBox .Text+ "';";
            try
            {
                mraCo.Open();
                SqlCommand sarchCommand = new SqlCommand(scarchString, mraCo);
                SqlDataAdapter ddt;
                ddt = new SqlDataAdapter(sarchCommand);

                DataTable table = new DataTable();
                ddt.Fill(table);
                


                byte[] img = (byte[])table.Rows[0][12];
               
              SqlDataReader adaptData = sarchCommand.ExecuteReader();
                if (adaptData.Read())
                {
                    StudentInfo std = new StudentInfo(

                    adaptData.GetInt32(adaptData.GetOrdinal("id")).ToString(),
                    adaptData.GetString(adaptData.GetOrdinal("name")),
                    adaptData.GetString(adaptData.GetOrdinal("phone")),
                    adaptData.GetString(adaptData.GetOrdinal("pass")),
                    adaptData.GetString(adaptData.GetOrdinal("motName")),
                    adaptData.GetString(adaptData.GetOrdinal("fatname")),
                    adaptData.GetString(adaptData.GetOrdinal("mothID")),
                    adaptData.GetString(adaptData.GetOrdinal("fathID")),
                    adaptData.GetString(adaptData.GetOrdinal("bldGrp")),
                    adaptData.GetString(adaptData.GetOrdinal("DOB")),
                    adaptData.GetString(adaptData.GetOrdinal("program")),
                    adaptData.GetString(adaptData.GetOrdinal("gender")),
                    img,
                    theme
                      );

                    adaptData.Close();



                    mraCo.Close();

                    std.ShowDialog();
                }

            }

            catch (Exception ex)
            {
                mraCo.Close();
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }



        }

       

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
           string  constring = db.conString;
           SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM teachers WHERE (name like'%" + metroTextBox1.Text + "%') or (phone like'%" + metroTextBox1.Text + "%') or (NID like'%" + metroTextBox1.Text + "%') ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[9].ToString();
                
            }
        }

        public void display()
        {   SqlConnection con = new SqlConnection();
            try
            {
                string constring = db.conString;
             
                con.ConnectionString = constring;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM teachers", con);
                SqlDataAdapter batchData = new SqlDataAdapter("select * from batch", con);
                
                DataTable dt = new DataTable();
                DataTable bt = new DataTable();
                batchData.Fill(bt);
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                batchGrid.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[9].ToString();
                }
                foreach (DataRow item in bt.Rows)
                {
                    int n = batchGrid.Rows.Add();
                    batchGrid.Rows[n].Cells[0].Value = item[1].ToString();
                    batchGrid.Rows[n].Cells[1].Value = item[3].ToString();
                    batchGrid.Rows[n].Cells[2].Value = item[2].ToString();
                    batchGrid.Rows[n].Cells[3].Value = item[0].ToString();
                    batchGrid.Rows[n].Cells[5].Value = item[4].ToString();
                    batchGrid.Rows[n].Cells[6].Value = item[5].ToString();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                con.Close();
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               
            }
        }

        private void metroTabPage2_Enter(object sender, EventArgs e)
        {
            display();
        }

       

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            string gg=   dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show(gg);
        }

        private void sessionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            sessionDropCount = 1;

            classComboBox.Items.Clear();

        }

        private void classComboBox_MouseClick(object sender, MouseEventArgs e)
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
                    dataGridView1.Rows.Clear();
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        classComboBox.Items.Add(item[0].ToString());
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
     

        private void batchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BatchInfo b = new BatchInfo(batchGrid.SelectedRows[0].Cells[0].Value.ToString());
            b.ShowDialog();
            
        }

        private void panel_Resize(object sender, EventArgs e)
        {
            //  metroTabControl1
        }

        private void addCoursesButton_Click(object sender, EventArgs e)
        {
            AddCourses a = new AddCourses();
            a.ShowDialog();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                string constring = db.conString;

                con.ConnectionString = constring;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM courses where seassion = "+metroComboBox1.Text+";", con);
               
                DataTable dt = new DataTable();
                
                sda.Fill(dt);
                courseGrid.Rows.Clear();
                
                foreach (DataRow item in dt.Rows)
                {
                    int n = courseGrid.Rows.Add();
                    courseGrid.Rows[n].Cells[0].Value = item[0].ToString();
                    courseGrid.Rows[n].Cells[1].Value = item[1].ToString();
                    courseGrid.Rows[n].Cells[2].Value = item[2].ToString();
                    courseGrid.Rows[n].Cells[3].Value = item[3].ToString();
                }
                
                con.Close();
            }
            catch (SqlException ex)
            {
                con.Close();
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void courseGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AddSchedule a = new AddSchedule(courseGrid.SelectedRows[0].Cells[0].Value.ToString(), courseGrid.SelectedRows[0].Cells[1].Value.ToString(), courseGrid.SelectedRows[0].Cells[2].Value.ToString());
            a.ShowDialog();
        }

        private void addTileButton_Click(object sender, EventArgs e)
        {
            AddBatch ab = new AddBatch();
            ab.ShowDialog();
        }

        private void AddTeacherButton_Click(object sender, EventArgs e)
        {
            newteacher nt = new newteacher(theme, user);
            nt.ShowDialog();
        }
    }
    
}
