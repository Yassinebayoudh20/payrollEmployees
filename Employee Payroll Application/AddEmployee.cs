using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Payroll_Application
{
    public partial class AddEmployee : Form
    {
        Employee emp = new Employee();
        public AddEmployee()
        {
            InitializeComponent();
        }

    

        private void add_button_Click(object sender, EventArgs e)
        {
            emp.Id_Emp = Convert.ToInt32(idtxt.Text);
            emp.NameEmp = fname_txtbox.Text;
            emp.LastnameEmp = lname_txtbox.Text;
            emp.Des = designation_txtbox.Text; ;
            emp.DateBirth=dob_pick.Text;
            emp.Qualification=qualification_txtbox.Text;
            emp.ContactNumber = contact_txtbox.Text;
            if (radioButton1.Checked) { emp.Gender ="Male"; } else { emp.Gender ="Female"; }
            emp.Basicsalary=Convert.ToDouble(basicSalarytext.Text);
            emp.Adresee=address_txtbox.Text;
            emp.AddEmployee();
            emp.FillDs();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            fname_txtbox.Text = "";
            lname_txtbox.Text = "";
            address_txtbox.Text = "";
            designation_txtbox.Text = "";
            qualification_txtbox.Text = "";
            basicSalarytext.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            emp.FillDs();
        }
    }

}
        
    

