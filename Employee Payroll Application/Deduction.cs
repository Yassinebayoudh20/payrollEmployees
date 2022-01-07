using MySql.Data.MySqlClient;
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
    public partial class Deduction : Form
    {

        Deductions d = new Deductions();
        Employee p = new Employee();
        public Deduction()
        {
            InitializeComponent();
            p.FillDs();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int salary = Convert.ToInt32(alw_bs.Text);


            if (percen.Checked == true)
            {
                int percentage = Convert.ToInt32(text_per.Text);
                int total_percentage_deduction = salary / 100 * percentage;
                string x = Convert.ToString(total_percentage_deduction);
                int sal = salary - total_percentage_deduction;
                Total_deduc.Text = x;
                sad.Text = Convert.ToString(sal);
            }

            if (amount.Checked == true)
            {
                int deduction = Convert.ToInt32(text_amount.Text);
                int total_amount_deduction = salary - deduction;
                string s = Convert.ToString(total_amount_deduction);
                sad.Text = s;
                Total_deduc.Text = Convert.ToString(deduction);


            }



          

        
        }

        private void Deduction_Load(object sender, EventArgs e)
        {
            d.DeductionInfo();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter A Valid ID");
            }
            else
            {
                string Mat = textBox1.Text;

                
                DataRow CurrentRow = UtilitiareBD.ds.Tables["Employee_Info"].Rows.Find(Mat);
                if (CurrentRow != null)
                {
                    alw_idtxt.Text = CurrentRow["id"].ToString();
                    alw_nametxt.Text = CurrentRow["Name"].ToString();
                    alw_lastntext.Text = CurrentRow["Last Name"].ToString();
                    alw_datepicker.Text = CurrentRow["Date Of Birth"].ToString();
                    alw_bs.Text = CurrentRow["Salary"].ToString();
                    alw_contactnbr.Text = CurrentRow["ContactNumber"].ToString();

                }

            }
        }







        private void percen_CheckedChanged(object sender, EventArgs e)
        {
            text_amount.Enabled = false;
            text_amount.Text = "";
            text_per.Enabled = true;
        }

        private void amount_CheckedChanged(object sender, EventArgs e)
        {
            text_amount.Enabled = true;
            text_per.Text = "";
            text_per.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d.Name = alw_nametxt.Text;
            d.Lastname = alw_lastntext.Text;
            d.DeductionAmount = Convert.ToDouble(Total_deduc.Text);
            d.DeductionReason = ReasonText.Text;
            d.Basicsalary = Convert.ToDouble(alw_bs.Text);
            d.Id_Emp2 = alw_idtxt.Text;
            try
            {
                int id = Convert.ToInt32(alw_idtxt.Text);
                UtilitiareBD.Connecter();
                string updatecmd = " Update  Employee_Info Set Salary="+ sad.Text + " where id =" + id;
                MySqlCommand cmd = new MySqlCommand(updatecmd, UtilitiareBD.con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            d.AddnewDedcuction();
        }
    }
}
