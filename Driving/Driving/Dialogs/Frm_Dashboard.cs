using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Driving.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace Driving.Dialogs
{
    public partial class Frm_Dashboard : Form
    {
        Database data = new Database();
        public Frm_Dashboard()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /* private void CreateColumns()
         {
             dataGridView1.Columns.Add("id", "ID");
             dataGridView1.Columns.Add("Name", "Name");
             dataGridView1.Columns.Add("Email", "Email");
             dataGridView1.Columns.Add("Phone", "Phone");
             dataGridView1.Columns.Add("Address", "Address");
             dataGridView1.Columns.Add("Address", "Address");
             dataGridView1.Columns.Add("Address", "Address");
             dataGridView1.Columns.Add("Address", "Address");

         }

         private void ReadSinglRow(DataGridView dgv, IDataRecord record)
         {
             dgv.Rows.Add(record.GetInt32(0),
                 record.GetString(1),
                 record.GetString(2),
                 record.GetString(3),
                 record.GetString(4),
                 record.GetString(5),
                 record.GetString(6),
                 record.GetString(7)
                 );
         }

         private void RefreshDataGrid(DataGridView dgw)
         {
             dgw.Rows.Clear();
             string queryString = $"SELECT    dbo.Curses.id AS CursID, dbo.Curses.Name AS CursName, dbo.Instructors.Name AS Instructor, dbo.Students.Name AS Student, dbo.Instructors.Car AS CarName, dbo.Curses.Salary AS CursSalary," 
                       +"dbo.Curses.StartDate AS Start, dbo.Curses.EndDate AS End"
                       +"FROM         dbo.Curses INNER JOIN"
                       +"dbo.Instructors ON dbo.Curses.Name = dbo.Instructors.Name INNER JOIN"
                       + "dbo.Students ON dbo.Curses.id = dbo.Students.Name";

             SqlCommand command = new SqlCommand(queryString, data.GetConnection());

             data.openConnection();

             SqlDataReader reader = command.ExecuteReader();

             while (reader.Read())
             {
                 ReadSinglRow(dgw, reader);
             }
             reader.Close();

         }*/



        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Curs");
            dataGridView1.Columns.Add("Name", "Instructor");
            dataGridView1.Columns.Add("NameOfGroup", "Group");
            dataGridView1.Columns.Add("StartDate", "SartDate");
            dataGridView1.Columns.Add("EndDate", "EndDate");
            dataGridView1.Columns.Add("Salary", "Salary");
           
        }


        private void ReadSinglRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0),
                record.GetString(1),
                record.GetString(2),
                record.GetString(3),
                record.GetDateTime(4),
                record.GetDateTime(5),
                record.GetInt32(6),
                RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            /*string queryString = $"SELECT c.id, c.Name, i.Name, sg.NameOfGroup, c.StartDate, c.EndDate, c.Salary  FROM Curs AS c, Instructors AS i, StudentGroup AS sg";*/

            string queryString = $"SELECT    dbo.Curs.id, dbo.Curs.Name AS Curs, dbo.Instructors.Name AS Instructor, dbo.StudentGroup.NameOfGroup AS [Group], dbo.Curs.StartDate AS Start, dbo.Curs.EndDate AS [End], dbo.Curs.Salary " +
                $" FROM dbo.Curs INNER JOIN" +
                $" dbo.Instructors ON dbo.Curs.InstId = dbo.Instructors.id INNER JOIN" +
                $" dbo.StudentGroup ON dbo.Curs.GroupId = dbo.StudentGroup.id";

            SqlCommand command = new SqlCommand(queryString, data.GetConnection());

            data.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSinglRow(dgw, reader);
            }
            reader.Close();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM Students", data.GetConnection());
            SqlCommand commd = new SqlCommand($"SELECT COUNT(*) FROM Instructors", data.GetConnection());
            SqlCommand comd = new SqlCommand($"SELECT SUM(Salary) FROM" +
                $" Curs, Students WHERE Curs.GroupId = Students.GroupId", data.GetConnection());

            data.openConnection();
            label7.Text = Convert.ToString(commd.ExecuteScalar());
            label6.Text = Convert.ToString(cmd.ExecuteScalar());



            label8.Text = Convert.ToString(comd.ExecuteScalar());
            
            data.closeConnection();

            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStd1_Click(object sender, EventArgs e)
        {
            Frm_Curs frm_curs = new Frm_Curs();
            this.Hide();
            frm_curs.ShowDialog();
            this.Close();
        }

        private void btnStd2_Click(object sender, EventArgs e)
        {
            Frm_Student frm_st = new Frm_Student();
            this.Hide();
            frm_st.ShowDialog();
            this.Close();
        }

        private void btnStd3_Click(object sender, EventArgs e)
        {
            Frm_Instructor frm_ins = new Frm_Instructor();
            this.Hide();
            frm_ins.ShowDialog();
            this.Close();
        }

        private void btnStd4_Click(object sender, EventArgs e)
        {
            Frm_Admin frm_admin = new Frm_Admin();
            this.Hide();
            frm_admin.ShowDialog();
            this.Close();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.raspisaniyeTableAdapter.FillBy(this.sRSDataSet.Raspisaniye);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            for(int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for(int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j,i].Value.ToString();
                }
            }

            exApp.Visible = true;
        }

        private void btnStd7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
