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
    
    public partial class Frm_Student : Form
    {

        Database data = new Database();
        public Frm_Student()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dGV_Student.Columns.Add("id", "id");
            dGV_Student.Columns.Add("Name", "Name");
            dGV_Student.Columns.Add("Email", "Email");
            dGV_Student.Columns.Add("Phone", "Phone");
            dGV_Student.Columns.Add("Address", "Address");
            dGV_Student.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSinglRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0),
                record.GetString(1),
                record.GetString(2),
                record.GetString(3),
                record.GetString(4),
                RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM Students";

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

            string searchString = $"SELECT * FROM Students WHERE concat(id, Name, Email, Phone, Address) LIKE '%" + tStd1.Text + "%'";
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
            int index = dGV_Student.CurrentCell.RowIndex;

            dGV_Student.Rows[index].Visible = false;

            //if(dGV_Student.Rows[index].Cells[0].Value.ToString() == string.Empty)
            //{
            dGV_Student.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            //}
        }

        private void update()
        {
            data.openConnection();

            for (int index = 0; index < dGV_Student.Rows.Count; index++)
            {
                var rowState = (RowState)dGV_Student.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dGV_Student.Rows[index].Cells[0].Value);
                    var delQuery = $"DELETE FROM Students WHERE id = {id}";

                    var cmd = new SqlCommand(delQuery, data.GetConnection());
                    cmd.ExecuteNonQuery();
                }


            }
            data.closeConnection();
        }

        private void Frm_Student_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dGV_Student);
        }

        private void button6_Click(object sender, EventArgs e)
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
            this.Update();
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

        private void btnStd7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStd5_Click(object sender, EventArgs e)
        {
            StudentAdd StAdd = new StudentAdd();
            StAdd.Show();
        }

        private void btnStd8_Click(object sender, EventArgs e)
        {
            delRow();
            update();
        }

        private void btnStd9_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dGV_Student);
        }

        private void tStd1_TextChanged(object sender, EventArgs e)
        {
            Search(dGV_Student);
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
