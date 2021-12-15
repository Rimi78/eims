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
    public partial class UpdateInfo : MetroFramework.Forms.MetroForm
    {
        int dt = 0;
        public UpdateInfo(string textBox, string info, int useDateTime =0)
        {
            InitializeComponent();
            label.Text = textBox;
            InfoTextBox.Text = info;
            dt = useDateTime;
            if (useDateTime == 1) {
                InfoTextBox.Visible = false;
                DateTime.Visible = true;
                DateTime.Text = info;



            
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            StudentInfo.updateValue = InfoTextBox.Text;
            if (dt == 1) {
                StudentInfo.updateValue = DateTime.Text;
            }
            StudentInfo.updateAction = 1;
            this.Hide();


        }

        private void cancellButton_Click(object sender, EventArgs e)
        {
            StudentInfo.updateAction = 0;
            this.Hide();
        }
    }
}
