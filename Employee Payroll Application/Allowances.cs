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
    class Allowances 
    {
        private int id;
        private string medical;
        private string bonus;
        private string other;
        private string overtime;
        private double totalAmount;
        private string name;
        private string lastname;
        private double basicsalary;
        private string Id_Emp;


        public string Bonus { get => bonus; set => bonus = value; }
        public string Other { get => other; set => other = value; }
        public string Medical { get => medical; set => medical = value; }
        public int Id { get => id; set => id = value; }
        public string Overtime { get => overtime; set => overtime = value; }
        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public string Name1 { get => name; set => name = value; }
        public string Lastname1 { get => lastname; set => lastname = value; }
        public double Basicsalary2 { get => basicsalary; set => basicsalary = value; }
        public string Id_Emp1 { get => Id_Emp; set => Id_Emp = value; }

    

        

        public Allowances()
        {
        }

        public void AllowanceInfo(DataGridView dataGrid)
        {

            UtilitiareBD.Connecter();

            string sql = "Select * From allowance";

            MySqlCommand cmd = new MySqlCommand(sql, UtilitiareBD.con);

            UtilitiareBD.adapter.SelectCommand = cmd;

            UtilitiareBD.adapter.Fill(UtilitiareBD.ds, "allowance");

            dataGrid.DataSource = UtilitiareBD.ds.Tables["allowance"];
            UtilitiareBD.ds.Tables["allowance"].PrimaryKey = new DataColumn[] { UtilitiareBD.ds.Tables["allowance"].Columns["id"] };
            UtilitiareBD.ds.Tables["allowance"].Columns["id"].AutoIncrement = true;

            UtilitiareBD.Deconnecter();



        }


        public void FillAllawance()
        {

            UtilitiareBD.Connecter();

            string sql = "Select * From allowance";

            MySqlCommand cmd = new MySqlCommand(sql, UtilitiareBD.con);

            UtilitiareBD.adapter.SelectCommand = cmd;

            UtilitiareBD.adapter.Fill(UtilitiareBD.ds, "allowance");

            UtilitiareBD.ds.Tables["allowance"].PrimaryKey = new DataColumn[] { UtilitiareBD.ds.Tables["allowance"].Columns["id"] };
            UtilitiareBD.ds.Tables["allowance"].Columns["id"].AutoIncrement = true;

            UtilitiareBD.Deconnecter();



        }

        public void AddNewAllowance()
        {
            MySqlCommandBuilder builder = new MySqlCommandBuilder();
            //Creates a new data row
            DataRow row = UtilitiareBD.ds.Tables["allowance"].NewRow();
            row["overtime"] = overtime;
            row["medical"] = medical;
            row["bonus"] = bonus;
            row["other"] = other;
            row["lastname"] = Lastname1;
            row["salary"] = Basicsalary2;
            row["emp_id"] = Id_Emp1;
            row["surname"] = Name1;
            row["total_allowance"] = TotalAmount;

            //Add the data row

            UtilitiareBD.ds.Tables["allowance"].Rows.Add(row);

            // Inserts a new record
            builder.DataAdapter = UtilitiareBD.adapter;
            UtilitiareBD.adapter.Update(UtilitiareBD.ds, "allowance");
        }
    }
}
