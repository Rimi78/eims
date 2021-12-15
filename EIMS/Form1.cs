using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIMS
{

    


    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        //public static Theme t;

        public Form1()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            passTextBox.UseSystemPasswordChar = true;
            metroComboBox1.SelectedIndex = 1;
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.SelectedIndex)
            {
                case 0:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                    
                    break;
                case 1:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Default;
                    break;

                    
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            string user = userTextBox.Text;
            string pass = passTextBox.Text;
            if (user == "rayuser" && pass == "raypass")
            {
                panel p = new panel(user, metroComboBox1.SelectedIndex);
                this.Hide();
                p.ShowDialog();
            }
            else {
                MetroFramework.MetroMessageBox.Show(this,"Wrong user or password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
                    
                    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void userTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                passTextBox.Focus();
            }
        }

        private void passTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                metroTile1.PerformClick();
            }

        }
    }
}
