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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            SearchEmployee SE = new SearchEmployee();
            SE.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee AE = new AddEmployee();
            AE.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Allowance a = new Allowance();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateSalary s = new UpdateSalary();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Deduction d = new Deduction();
            d.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
        }
    }
}
