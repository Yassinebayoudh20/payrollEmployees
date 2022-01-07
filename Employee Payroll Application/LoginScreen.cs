using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Payroll_Application
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
           


        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( AdminLogin.Text == "admin" && AdminPAssword.Text == "iset2018")
            {
                MainMenu mm = new MainMenu();
                mm.Show();
                Hide();
            }else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AdminPAssword_TextChanged(object sender, EventArgs e)
        {
            AdminPAssword.PasswordChar = '*';
        }
    }
}
