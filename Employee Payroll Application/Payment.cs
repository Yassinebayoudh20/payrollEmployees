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
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.IO;


namespace Employee_Payroll_Application
{
    public partial class Payment : Form
    {

        Employee p = new Employee();
        Allowances a = new Allowances();
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            p.FillDs();
            a.FillAllawance();
            /*UtilitiareBD.Connecter();

            string sql = "Select Matricule_Employee From Employee_Info";

            MySqlCommand cmd = new MySqlCommand(sql, UtilitiareBD.con);

            UtilitiareBD.adapter.SelectCommand = cmd;

            UtilitiareBD.adapter.Fill(UtilitiareBD.ds, "Employee_Info");
           // UtilitiareBD.ds.Tables["Employee_Info"].PrimaryKey = new DataColumn[] { UtilitiareBD.ds.Tables["Employee_Info"].Columns["Matricule_Employee"] };
            comboBox1.Items.Add(UtilitiareBD.ds.Tables["Employee_Info"].Columns["Matricule_Employee"].ToString()) ;



            UtilitiareBD.Deconnecter();*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string id;
            MySqlCommandBuilder builder = new MySqlCommandBuilder();
            if (id_txt.Text.Equals(""))
            {
                alw_idtxt.Text = "0";
                alw_nametxt.Text ="";
                alw_lastntext.Text = "";
                alw_datepicker.Text = "";
                alw_bs.Text = "";
                alw_contactnbr.Text = "";
            }
            else { id =id_txt.Text; 

             
            
            DataRow CurrentRow = UtilitiareBD.ds.Tables["Employee_Info"].Rows.Find(id);
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

            Document doc = new Document(PageSize.A4, 7f, 5f, 5f, 0f);
            iTextSharp.text.Font mainFont = FontFactory.GetFont("Segoe UI", 22, new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#999")));
            PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(path.Text+".pdf", FileMode.Create));
            doc.Open();



            //Fonts

            iTextSharp.text.Font TitleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 20, iTextSharp.text.Font.ITALIC,iTextSharp.text.BaseColor.RED);
            iTextSharp.text.Font SubTitleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font InformationFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE);
            iTextSharp.text.Font FileTitle = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 35, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK);



            // Make Table

            Paragraph Title = new Paragraph("Employee Report", FileTitle);
            Title.Alignment = Element.ALIGN_CENTER;
            doc.Add(Title);



            doc.Add(new Paragraph("Employee Information  \n", TitleFont));
            doc.Add(new Paragraph(" \n"));
            doc.Add(new Paragraph(" \n"));




            PdfPTable tableEmployee = new PdfPTable(6);

             PdfPCell ID_Emp = new PdfPCell(new Phrase("ID Employee"));
             PdfPCell Name_Emp = new PdfPCell(new Phrase("Employee Name"));
             PdfPCell LastName_Emp = new PdfPCell(new Phrase("Employee Last Name"));
             PdfPCell DateOfBirth_Emp = new PdfPCell(new Phrase("Employee Date of Birth"));
             PdfPCell Basic_salary = new PdfPCell(new Phrase("Employee Salary"));
             PdfPCell Contact_Emp = new PdfPCell(new Phrase("Employee Contact Number"));


            tableEmployee.AddCell(ID_Emp);
            tableEmployee.AddCell(Name_Emp);
            tableEmployee.AddCell(LastName_Emp);
            tableEmployee.AddCell(DateOfBirth_Emp);
            tableEmployee.AddCell(Basic_salary);
            tableEmployee.AddCell(Contact_Emp);

            tableEmployee.AddCell(alw_idtxt.Text.ToString());
            tableEmployee.AddCell(alw_nametxt.Text.ToString());
            tableEmployee.AddCell(alw_lastntext.Text.ToString());
            tableEmployee.AddCell(alw_datepicker.Text.ToString());
            tableEmployee.AddCell(alw_bs.Text.ToString());
            tableEmployee.AddCell(alw_contactnbr.Text.ToString());

            doc.Add(tableEmployee);


          /*  // Getting Allowance Information 

            doc.Add(new Paragraph("Employee Allawance Info  \n", TitleFont));
            doc.Add(new Paragraph(" \n"));
            doc.Add(new Paragraph(" \n"));


            int id = Convert.ToInt32(id_txt.Text);
            DataRow CurrentRow = UtilitiareBD.ds.Tables["allowance"].Rows.Find(id);


            if (CurrentRow != null) { 
            PdfPTable AllowanceTable = new PdfPTable(5);

            PdfPCell Employee_OvereTime = new PdfPCell(new Phrase("Employee_OvereTime"));
            PdfPCell Employee_bonus = new PdfPCell(new Phrase("Employee_bonus"));
            PdfPCell Employee_medical = new PdfPCell(new Phrase("Employee_medical"));
            PdfPCell Employee_other = new PdfPCell(new Phrase("Employee_other"));
            PdfPCell Employee_total_allowance = new PdfPCell(new Phrase("Employee_total_allowance"));


            AllowanceTable.AddCell(Employee_OvereTime);
            AllowanceTable.AddCell(Employee_bonus);
            AllowanceTable.AddCell(Employee_medical);
            AllowanceTable.AddCell(Employee_other);
            AllowanceTable.AddCell(Employee_total_allowance);


            AllowanceTable.AddCell(CurrentRow["overtime"].ToString());
            AllowanceTable.AddCell(CurrentRow["bonus"].ToString());
            AllowanceTable.AddCell(CurrentRow["medical"].ToString());
            AllowanceTable.AddCell(CurrentRow["other"].ToString());
            AllowanceTable.AddCell(CurrentRow["total_allowance"].ToString());

            doc.Add(AllowanceTable);
            }*/

            doc.Close();



            MessageBox.Show("Generated");



        }

        private void button2_Click(object sender, EventArgs e)
        {
           SaveFileDialog ofd = new SaveFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path.Text = Path.GetFullPath(ofd.FileName);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }
    }
}
