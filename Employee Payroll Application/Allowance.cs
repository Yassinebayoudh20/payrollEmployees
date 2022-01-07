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

namespace Employee_Payroll_Application
{
    public partial class Allowance : Form
    {
        Allowances a = new Allowances();
        Employee e = new Employee();

        public Allowance()
        {
            InitializeComponent();
            e.FillDs();
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
                 int id = Convert.ToInt32(textBox1.Text);
                 string sqlSearch = " Select * from Employee_Info where id =" + id;


                 MySqlCommand cmd = new MySqlCommand(sqlSearch, UtilitiareBD.con);

                 MySqlDataReader dr = cmd.ExecuteReader();

                 while(dr.Read())
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

        private void button2_Click(object sender, EventArgs e)
        {
            int salary = Convert.ToInt32(alw_bs.Text);
            int overtime = Convert.ToInt32(overtimetxt.Text);

            double eight = 8;
            double days = 25;
            double dbop = 0;
            double overtimeRate = 1.5;

            //calculate the total hours of overtime
            double Total_Overtime = overtime * overtimeRate;
            string x = Convert.ToString(Total_Overtime);
            totalovertime.Text = x ;

            //calculate overall overtime 
            dbop = salary / days / eight;
            string s = Convert.ToString(dbop);
            textper.Text=s;

            int med = Convert.ToInt32(medicaltext.Text);
            int bonus = Convert.ToInt32(bonustext.Text);
            int other = Convert.ToInt32(othertext.Text);
            int f = med + bonus + other;
            double calc = Total_Overtime * dbop + f;
            string c = Convert.ToString(calc);
            TotalRes.Text = c;
        }

        private void Allowance_Load(object sender, EventArgs e)
        {
            a.AllowanceInfo(dgvAllowance);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(alw_idtxt.Text);
            string medical = medicaltext.Text;
            string bonus = bonustext.Text;
            string other = othertext.Text;
            string name = alw_nametxt.Text;
            string lastname = alw_lastntext.Text;
            double basicSalary = Convert.ToDouble(alw_bs.Text);
            double totalamount = Convert.ToDouble(TotalRes.Text);
            string overtime = overtimetxt.Text;

            a.Id = id;
            a.Medical = medical;
            a.Bonus = bonus;
            a.Other = other;
            a.Name1 = name;
            a.Lastname1 = lastname;
            a.Basicsalary2 = basicSalary;
            a.Overtime = overtime;
            a.TotalAmount = totalamount;
            a.Id_Emp1 = alw_idtxt.Text;



            a.AddNewAllowance();

            MessageBox.Show("Inserted");
        }

        private void TotalRes_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }



    }

