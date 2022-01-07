using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Employee_Payroll_Application
{
    class Employee
    {

        private int id;
        private string name;
        private string lastname;
        private string adresee;
        private string des;
        private string dateBirth;
        private string qualification;
        private string gender;
        private double basicsalary;
        private string contactNumber;


        public Employee(int id, string name, string lastname, double salary)
        {
            id = Id_Emp;
            name = NameEmp;
            lastname = LastnameEmp;
            salary = Basicsalary;
        }

        public Employee()
        {
        }

        public int Id_Emp { get => id; set => id = value; }
        public string NameEmp { get => name; set => name = value; }
        public string LastnameEmp { get => lastname; set => lastname = value; }
        public string Adresee { get => adresee; set => adresee = value; }
        public string DateBirth { get => dateBirth; set => dateBirth = value; }
        public string Qualification { get => qualification; set => qualification = value; }
        public string Gender { get => gender; set => gender = value; }
        public double Basicsalary { get => Basicsalary1; set => Basicsalary1 = value; }
        public string Des { get => des; set => des = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public double Basicsalary1 { get => basicsalary; set => basicsalary = value; }

        public void DisplayInfo(DataGridView dataGrid)
        {

            UtilitiareBD.Connecter();

            string sql = "Select * From Employee_Info";

            MySqlCommand cmd = new MySqlCommand(sql, UtilitiareBD.con);

            UtilitiareBD.adapter.SelectCommand = cmd;

            UtilitiareBD.adapter.Fill(UtilitiareBD.ds, "Employee_Info");
            UtilitiareBD.ds.Tables["Employee_Info"].PrimaryKey = new DataColumn[] { UtilitiareBD.ds.Tables["Employee_Info"].Columns["Matricule_Employee"] };
            UtilitiareBD.ds.AcceptChanges();
            dataGrid.DataSource = UtilitiareBD.ds.Tables["Employee_Info"];
            //UtilitiareBD.ds.Tables["Employee_Info"].Columns["id"].AutoIncrement = true;



            UtilitiareBD.Deconnecter();



        }



        public void FillCombo(ComboBox comboBox)
        {

            string query = "select Matricule_Employee from Employee_Info";
            UtilitiareBD.Connecter();
            MySqlCommand cmd = new MySqlCommand(query, UtilitiareBD.con);
            UtilitiareBD.adapter.SelectCommand = cmd;
            UtilitiareBD.adapter.Fill(UtilitiareBD.ds, "Matricule_Employee");
            comboBox.DisplayMember = "Matricule_Employee";
            comboBox.ValueMember = "Matricule_Employee";
            comboBox.DataSource = UtilitiareBD.ds.Tables["Matricule_Employee"];


            
        }






        public void AddEmployee()
        {

            MySqlCommandBuilder builder = new MySqlCommandBuilder();
            //Creates a new data row
            DataRow row = UtilitiareBD.ds.Tables["Employee_Info"].NewRow();
            row["id"] = this.Id_Emp;
            row["Name"] = NameEmp;
            row["Last Name"] = LastnameEmp;
            row["Matricule_Employee"] = Des;
            row["Date Of Birth"] = DateBirth;
            row["Qualifications"] = Qualification;
            row["Gender"] = Gender;
            row["Salary"] = Basicsalary;
            row["Adresse"] = Adresee;
            row["ContactNumber"] = ContactNumber;



            UtilitiareBD.ds.Tables["Employee_Info"].Rows.Add(row);
            


            builder.DataAdapter = UtilitiareBD.adapter;
            UtilitiareBD.adapter.Update(UtilitiareBD.ds, "Employee_Info");
            UtilitiareBD.ds.AcceptChanges();

            MessageBox.Show("Employee Inserted");

        }


        public void FillDs()
        {

            UtilitiareBD.Connecter();

            string sql = "Select * From Employee_Info";

            MySqlCommand cmd = new MySqlCommand(sql, UtilitiareBD.con);

            UtilitiareBD.adapter.SelectCommand = cmd;

            UtilitiareBD.adapter.Fill(UtilitiareBD.ds, "Employee_Info");
            UtilitiareBD.ds.Tables["Employee_Info"].PrimaryKey = new DataColumn[] { UtilitiareBD.ds.Tables["Employee_Info"].Columns["Matricule_Employee"] };
            UtilitiareBD.ds.AcceptChanges();


            UtilitiareBD.Deconnecter();

        }



        public void UpdateEmployee(string id)
        {

            MySqlCommandBuilder builder = new MySqlCommandBuilder();


            DataRow CurrentRow = UtilitiareBD.ds.Tables["Employee_Info"].Rows.Find(id);
            if (CurrentRow != null)
            {

                CurrentRow.BeginEdit();
                CurrentRow["Name"] = NameEmp;
                CurrentRow["Last Name"] = lastname;
                CurrentRow["Matricule_Employee"] = des;
                CurrentRow["Date Of Birth"] = dateBirth;
                CurrentRow["Qualifications"] = qualification;
                CurrentRow["Gender"] = gender;
                CurrentRow["Salary"] = Basicsalary1;
                CurrentRow["Adresse"] = adresee;
                CurrentRow["ContactNumber"] = contactNumber;
                CurrentRow.EndEdit();

                builder.DataAdapter = UtilitiareBD.adapter;
                UtilitiareBD.adapter.Update(UtilitiareBD.ds, "Employee_Info");
                UtilitiareBD.ds.AcceptChanges();


            }
        }

        public void DeleteEmployee(string Mat)
        {
            try { 
            MySqlCommandBuilder builder = new MySqlCommandBuilder();

            DataRow drCurrent = UtilitiareBD.ds.Tables["Employee_Info"].Rows.Find(Mat);
            drCurrent.Delete();

            builder.DataAdapter = UtilitiareBD.adapter;
            UtilitiareBD.adapter.Update(UtilitiareBD.ds, "Employee_Info");
            UtilitiareBD.ds.AcceptChanges();

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }

        }


        public void UpdateSalaray(string mat)
        {
            MySqlCommandBuilder builder = new MySqlCommandBuilder();

            DataRow CurrentRow = UtilitiareBD.ds.Tables["Employee_Info"].Rows.Find(mat);
            if (CurrentRow != null)
            {

                CurrentRow.BeginEdit();
                CurrentRow["Salary"] = basicsalary;
                CurrentRow.EndEdit();


                builder.DataAdapter = UtilitiareBD.adapter;
                UtilitiareBD.adapter.Update(UtilitiareBD.ds, "Employee_Info");
                UtilitiareBD.ds.AcceptChanges();


                MessageBox.Show("Salary Updated");


            }

        }
    }
}