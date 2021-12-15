using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using MetroFramework;
using MetroFramework.Controls;
namespace EIMS
{
    public partial class BatchInfo : MetroFramework.Forms.MetroForm
    {
       public static string batchName;
        public BatchInfo(string batch)
        {
            InitializeComponent();
            Thread loader = new Thread(()=>display(ref IDLabel, ref coOrdinateTextBox,ref startTextBox,ref endTextBox, ref seassionTextBox));
            loader.Start();
            batchName = batch;
            
        }
        public void display( ref MetroLabel l1,ref MetroTextBox cotb,ref MetroTextBox sttb ,ref MetroTextBox endtb,ref MetroTextBox sesstb) {
            try
            {
            
            SqlConnection mra = new SqlConnection();
                mra.ConnectionString = db.conString;
                SqlCommand quary = new SqlCommand("select * from batch where batchName ='" + batchName + "'; ", mra);
                SqlDataReader read;
                mra.Open();
                read = quary.ExecuteReader();
                if (read.Read()) {

                this.IDLabel.Invoke((MethodInvoker)delegate () {
                    IDLabel.Text = read.GetString(read.GetOrdinal("batchID"));
                });
                this.coOrdinateTextBox.Invoke((MethodInvoker)delegate () {
                    coOrdinateTextBox.Text = read.GetString(read.GetOrdinal("coordinator"));
                });
                this.startTextBox.Invoke((MethodInvoker)delegate () {
                    startTextBox.Text = read.GetString(read.GetOrdinal("startDate"));
                });
                this.endTextBox.Invoke((MethodInvoker)delegate () {
                    endTextBox.Text = read.GetString(read.GetOrdinal("EndDate"));
                });
                this.seassionTextBox.Invoke((MethodInvoker)delegate () {
                    seassionTextBox.Text = read.GetString(read.GetOrdinal("seassion"));
                });

               
                }
            this.NameTextBox.Invoke((MethodInvoker)delegate () {
                NameTextBox.Text = batchName;
            });

                read.Close();

                SqlDataAdapter sda = new SqlDataAdapter("select id,name from students where program = '" + batchName + "';", mra);
                SqlDataAdapter sdb = new SqlDataAdapter("select * from courses where batch = '"+batchName+"';", mra);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                

                this.studentGrid.Invoke((MethodInvoker)delegate () {
                    studentGrid.Rows.Clear();

                    foreach (DataRow item in dt.Rows)
                    {
                        int n = studentGrid.Rows.Add();
                        studentGrid.Rows[n].Cells[0].Value = item[0].ToString();
                        studentGrid.Rows[n].Cells[1].Value = item[1].ToString();

                    }
                });


                DataTable dt1 = new DataTable();

                sdb.Fill(dt1);
                

                this.CourseGrid.Invoke((MethodInvoker)delegate () {
                    CourseGrid.Rows.Clear();
                    foreach (DataRow item in dt1.Rows)
                    {
                        int n = CourseGrid.Rows.Add();
                        CourseGrid.Rows[n].Cells[0].Value = item[0].ToString();
                        CourseGrid.Rows[n].Cells[1].Value = item[1].ToString();

                    }
                });

               

                mra.Close();
            }
            catch (Exception ex) {
               MetroMessageBox.Show(this, ex.Message, "error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }
    }
}
