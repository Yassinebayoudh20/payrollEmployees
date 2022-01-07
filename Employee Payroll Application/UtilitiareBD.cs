using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace Employee_Payroll_Application
{
    class UtilitiareBD
    {


        public static MySqlConnection con = new MySqlConnection();
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter adapter = new MySqlDataAdapter();
        public static void Connecter()
        {
            if (con.State == ConnectionState.Closed)
            {
                string conString = "server = localhost; user id = root; database = employee_payroll_database";
                con.ConnectionString = conString;
                con.Open();
            }
        }
        public static void Deconnecter()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
