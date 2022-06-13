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
    public partial class Frm_Curs : Form
    {
        Database data = new Database();
        public Frm_Curs()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dGV_Curs.Columns.Add("id", "id");
            dGV_Curs.Columns.Add("Name", "Name");
            dGV_Curs.Columns.Add("StartDate", "Start");
            dGV_Curs.Columns.Add("EndDate", "End");
            dGV_Curs.Columns.Add("Slaray", "Salary");
            dGV_Curs.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSinglRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0),
                record.GetString(1),
                record.GetDateTime(2),
                record.GetDateTime(3),
                record.GetInt32(4),
                RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT id, Name, StartDate, EndDate, Salary FROM Curs";

            SqlCommand command = new SqlCommand(queryString, data.GetConnection());

            data.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSinglRow(dgw, reader);
            }
            reader.Close();

        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"SELECT * FROM Curses WHERE concat(id, Name, StartDate, EndDate, Salary) LIKE '%" + tCurs1.Text + "%'";
            SqlCommand cmd = new SqlCommand(searchString, data.GetConnection());

            data.openConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSinglRow(dgw, reader);
            }
            reader.Close();

        }

        private void delRow()
        {
            int index = dGV_Curs.CurrentCell.RowIndex;

            dGV_Curs.Rows[index].Visible = false;

            //if(dGV_Student.Rows[index].Cells[0].Value.ToString() == string.Empty)
            //{
            dGV_Curs.Rows[index].Cells[5].Value = RowState.Deleted;
            return;
            //}
        }

        private void update()
        {
            data.openConnection();

            for (int index = 0; index < dGV_Curs.Rows.Count; index++)
            {
                var rowState = (RowState)dGV_Curs.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dGV_Curs.Rows[index].Cells[0].Value);
                    var delQuery = $"DELETE FROM Curses WHERE id = {id}";

                    var cmd = new SqlCommand(delQuery, data.GetConnection());
                    cmd.ExecuteNonQuery();
                }


            }
            data.closeConnection();
        }





        private void btnCurs1_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void btnCurs2_Click(object sender, EventArgs e)
        {
            Frm_Student frm_st = new Frm_Student();
            this.Hide();
            frm_st.ShowDialog();
            this.Close();
        }

        private void btnCurs3_Click(object sender, EventArgs e)
        {
            Frm_Instructor frm_ins = new Frm_Instructor();
            this.Hide();
            frm_ins.ShowDialog();
            this.Close();
        }

        private void btnCurs4_Click(object sender, EventArgs e)
        {
            Frm_Admin frm_admin = new Frm_Admin();
            this.Hide();
            frm_admin.ShowDialog();
            this.Close();
        }

        private void btnCurs7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCurs9_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dGV_Curs);
        }

        private void Frm_Curs_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dGV_Curs);
        }

        private void tCurs1_TextChanged(object sender, EventArgs e)
        {
            Search(dGV_Curs);
        }

        private void btnCurs5_Click(object sender, EventArgs e)
        {
            CursAdd StAdd = new CursAdd();
            StAdd.Show();
        }

        private void btnCurs8_Click(object sender, EventArgs e)
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
