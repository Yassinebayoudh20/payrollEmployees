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
    public partial class UpdateSalary : Form
    {

        Employee p = new Employee();
        public UpdateSalary()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter A Valid ID");
            }
            else
            {
                /* UtilitiareBD.Connecter();
                 string Mat =textBox1.Text;
                 string sqlSearch = " Select * from Employee_Info where Matricule_Employee =" + Mat;


                 MySqlCommand cmd = new MySqlCommand(sqlSearch, UtilitiareBD.con);

                 MySqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     alw_idtxt.Text = dr["id"].ToString();
                     alw_nametxt.Text = dr["Name"].ToString();
                     alw_lastntext.Text = dr["Last Name"].ToString();
                     alw_contactnbr.Text = dr["ContactNumber"].ToString();
                     alw_datepicker.Text = dr["Date Of Birth"].ToString();
                     alw_bs.Text = dr["Salary"].ToString();
                 }



                 UtilitiareBD.Deconnecter();
             }*/
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

        private void button1_Click(object sender, EventArgs e)
        {
            int salary = Convert.ToInt32(alw_bs.Text);

            if (percen.Checked == true)
            {

                
                int getPercentage = Convert.ToInt32(text_per.Text);
                int calcPercentage = salary / 100 * getPercentage + salary;
                string xP = Convert.ToString(calcPercentage);
                alw_bs.Text = xP;
            }

            else if (amount.Checked == true)
            {
                
                int getAmt = Convert.ToInt32(text_amount.Text);
                int calcAmount = salary + getAmt;
                string xA = Convert.ToString(calcAmount);
                alw_bs.Text=xA;
            }

            //string id = textBox1.Text;
            string Mat = comboBox1.SelectedValue.ToString();


            p.Basicsalary = Convert.ToDouble(alw_bs.Text);
                p.UpdateSalaray(Mat);


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
            text_per.Enabled = false;
            text_per.Text = "";

        }

        private void UpdateSalary_Load(object sender, EventArgs e)
        {
            p.FillDs();
            p.FillCombo(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Mat = comboBox1.SelectedValue.ToString();
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
    }

