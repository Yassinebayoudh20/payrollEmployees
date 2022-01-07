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
using MySql.Data;

namespace Employee_Payroll_Application
{
    public partial class SearchEmployee : Form
    {

        Employee emp = new Employee();

        public SearchEmployee()
        {
            InitializeComponent();

        }



        private void SearchEmployee_Load(object sender, EventArgs e)
        {
            emp.DisplayInfo(EmployeeInfo);
        }



        private void EmployeeInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[0].Value.ToString();
            string Name = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[1].Value.ToString();
            string Last_name = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[2].Value.ToString();
            string ContactNumber = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[3].Value.ToString();
            string DateBirth = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[5].Value.ToString();
            string Qualification = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[6].Value.ToString();
            string Gender = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[7].Value.ToString();
            string BasicSalary = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[8].Value.ToString();
            string Adresse = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[9].Value.ToString();
            string Des = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[4].Value.ToString();
     



            if (Gender == "Male")
            {
                radioMale.Checked = true;
                radioFemale.Checked = false;
            }
            else if (Gender == "Female")
            {
                radioFemale.Checked = true;
                radioMale.Checked = false;
            }

            idText.Text = id;
            fname_txtbox.Text = Name;
            lname_txtbox.Text = Last_name;
            address_txtbox.Text = Adresse;
            designation_txtbox.Text = Des;
            dob_pick.Text = DateBirth;
            QualifText.Text = Qualification;
            basicSalarytxt.Text = BasicSalary;
            contact_txtbox.Text = ContactNumber;



        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            string Mat =EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[4].Value.ToString();

            emp.NameEmp = fname_txtbox.Text;
            emp.LastnameEmp = lname_txtbox.Text;
            emp.Des = designation_txtbox.Text; ;
            emp.DateBirth = dob_pick.Text;
            emp.Qualification = QualifText.Text;
            emp.ContactNumber = contact_txtbox.Text;
            if (radioMale.Checked) { emp.Gender = "Male"; } else { emp.Gender = "Female"; }
            emp.Basicsalary = Convert.ToDouble(basicSalarytxt.Text);
            emp.Adresee = address_txtbox.Text;
            emp.UpdateEmployee(Mat);
            MessageBox.Show("Employee Updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Mat = EmployeeInfo.Rows[EmployeeInfo.CurrentRow.Index].Cells[4].Value.ToString();
            emp.DeleteEmployee(Mat);

        }
    }
}

