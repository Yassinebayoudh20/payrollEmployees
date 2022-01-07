using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Payroll_Application
{
    class Deductions 
    {
        private int id_Emp;
        private string deductionReason;
        private double deductionAmount;
        private string name;
        private string lastname;
        private double basicsalary;
        private string Id_Emp;


        public string DeductionReason { get => deductionReason; set => deductionReason = value; }
        public double DeductionAmount { get => deductionAmount; set => deductionAmount = value; }
        public int Id_Emp1 { get => id_Emp; set => id_Emp = value; }
        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public double Basicsalary { get => basicsalary; set => basicsalary = value; }
        public string Id_Emp2 { get => Id_Emp; set => Id_Emp = value; }

        public Deductions()
        {


        }

        public void DeductionInfo()
        {
            UtilitiareBD.Connecter();

            string sql = "Select * From deduction";

            MySqlCommand cmd = new MySqlCommand(sql, UtilitiareBD.con);

            UtilitiareBD.adapter.SelectCommand = cmd;

            UtilitiareBD.adapter.Fill(UtilitiareBD.ds, "deduction");


            UtilitiareBD.Deconnecter();
        }

        public void AddnewDedcuction()
        {

            MySqlCommandBuilder builder = new MySqlCommandBuilder();
            //Creates a new data row
            DataRow row = UtilitiareBD.ds.Tables["deduction"].NewRow();
            try { 
            row["name"] = Name;
            row["lastname"] = Lastname;
            row["DeductionAmount"] = DeductionAmount;
            row["salary"] = Basicsalary;
            row["emp_id"] = Id_Emp2;
            row["DeductionReason"] = DeductionReason;


            //Add the data row

            UtilitiareBD.ds.Tables["deduction"].Rows.Add(row);

            // Inserts a new record
            builder.DataAdapter = UtilitiareBD.adapter;
            UtilitiareBD.adapter.Update(UtilitiareBD.ds, "deduction");
            }catch(MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            MessageBox.Show("Deduction Inserted");

        }

    }
}
