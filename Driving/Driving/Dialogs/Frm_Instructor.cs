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

namespace Driving.Dialogs
{
    enum RowState
    {
        Existed,
        New,
        Deleted,
        Modified,
        ModifiedNew
    }


    public partial class Frm_Instructor : Form
    {
        Database data = new Database();
        

        public Frm_Instructor()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dGV_Instructor.Columns.Add("id", "id");
            dGV_Instructor.Columns.Add("Name", "Name");
            dGV_Instructor.Columns.Add("Experience", "Experience");
            dGV_Instructor.Columns.Add("Car", "Car");
            dGV_Instructor.Columns.Add("Position", "Position");
            dGV_Instructor.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSinglRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), 
                record.GetString(1),
                record.GetInt32(2),
                record.GetString(3),
                record.GetString(4),
                RowState.ModifiedNew);
        }


        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM Instructors";

            SqlCommand command = new SqlCommand(queryString,data.GetConnection());

            data.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSinglRow(dgw, reader);
            }
            reader.Close(); 

        }

        private void btnInst1_Click(object sender, EventArgs e)
        {
            Frm_Curs frm_curs = new Frm_Curs();
            this.Hide();
            frm_curs.ShowDialog();
            this.Close();
        }

        private void btnInst2_Click(object sender, EventArgs e)
        {
            Frm_Student frm_st = new Frm_Student();
            this.Hide();
            frm_st.ShowDialog();
            this.Close();
        }

        private void btnInst3_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void btnInst4_Click(object sender, EventArgs e)
        {
            Frm_Admin frm_admin = new Frm_Admin();
            this.Hide();
            frm_admin.ShowDialog();
            this.Close();
        }

        private void btnInst7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Instructor_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dGV_Instructor);
            
        }

        private void btnInst9_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dGV_Instructor);
        }

        private void btnInst5_Click(object sender, EventArgs e)
        {
            InstAdd instAdd = new InstAdd();
            instAdd.Show();
        }

        private void Search(DataGridView dgw) 
        {
            dgw.Rows.Clear();

            string searchString = $"SELECT * FROM Instructors WHERE concat(id, Name, Experience, Car, Position) LIKE '%"+ tInst1.Text + "%'";
            SqlCommand cmd = new SqlCommand(searchString, data.GetConnection());

            data.openConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSinglRow(dgw,reader);
            }
            reader.Close();

        }
        private void tInst1_TextChanged(object sender, EventArgs e)
        {
            Search(dGV_Instructor);
        }


        private void delRow()
        {
            int index = dGV_Instructor.CurrentCell.RowIndex;

            dGV_Instructor.Rows[index].Visible = false;

            /*if(dGV_Instructor.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {*/
                dGV_Instructor.Rows[index].Cells[5].Value = RowState.Deleted;
            /*    return;
            }*/
        }

        private void update()
        {
            data.openConnection();

            for(int index = 0; index < dGV_Instructor.Rows.Count; index++)
            {
                var rowState = (RowState)dGV_Instructor.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dGV_Instructor.Rows[index].Cells[0].Value);
                    var delQuery = $"DELETE FROM Instructors WHERE id = {id}";

                    var cmd = new SqlCommand(delQuery, data.GetConnection());
                    cmd.ExecuteNonQuery();
                }
               

            }
            data.closeConnection();
        }
        private void btnInst8_Click(object sender, EventArgs e)
        {
            delRow();
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Dashboard frm1 = new Frm_Dashboard();
            this.Hide();
            frm1.ShowDialog();
            this.Close();
        }
    }
}
