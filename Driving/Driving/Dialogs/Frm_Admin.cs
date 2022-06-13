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
    public partial class Frm_Admin : Form
    {
        Database data = new Database();
        public Frm_Admin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dGV_Admin.Columns.Add("id", "id");
            dGV_Admin.Columns.Add("Name", "Name");
            dGV_Admin.Columns.Add("Position", "Position");
            dGV_Admin.Columns.Add("Phone", "Phone");
            dGV_Admin.Columns.Add("Email", "Email");
            dGV_Admin.Columns.Add("IsNew", String.Empty);
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
            string queryString = $"SELECT * FROM Admins";

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

            string searchString = $"SELECT * FROM Admins WHERE concat(id, Name, Position, Phone, Email) LIKE '%" + tAdmin1.Text + "%'";
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
            int index = dGV_Admin.CurrentCell.RowIndex;

            dGV_Admin.Rows[index].Visible = false;

            /*if(dGV_Instructor.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {*/
            dGV_Admin.Rows[index].Cells[5].Value = RowState.Deleted;
            /*    return;
            }*/
        }

        private void update()
        {
            data.openConnection();

            for (int index = 0; index < dGV_Admin.Rows.Count; index++)
            {
                var rowState = (RowState)dGV_Admin.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dGV_Admin.Rows[index].Cells[0].Value);
                    var delQuery = $"DELETE FROM Admins WHERE id = {id}";

                    var cmd = new SqlCommand(delQuery, data.GetConnection());
                    cmd.ExecuteNonQuery();
                }


            }
            data.closeConnection();
        }

        private void btnAdmin1_Click(object sender, EventArgs e)
        {
            Frm_Curs frm_curs = new Frm_Curs();
            this.Hide();
            frm_curs.ShowDialog();
            this.Close();
        }

        private void btnAdmin2_Click(object sender, EventArgs e)
        {
            Frm_Student frm_st = new Frm_Student();
            this.Hide();
            frm_st.ShowDialog();
            this.Close();
        }

        private void btnAdmin3_Click(object sender, EventArgs e)
        {
            Frm_Instructor frm_ins = new Frm_Instructor();
            this.Hide();
            frm_ins.ShowDialog();
            this.Close();
        }

        private void btnAdmin4_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void btnAdmin7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Admin_Load(object sender, EventArgs e)
        {

            CreateColumns();
            RefreshDataGrid(dGV_Admin);
            /*SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Admins", data.GetConnection());

            DataSet db = new DataSet();

            adapter.Fill(db);

            dGV_Admin.DataSource = db.Tables[0];*/
        }

        private void btnAdmin5_Click(object sender, EventArgs e)
        {
            AdminAdd add = new AdminAdd();
           
            add.ShowDialog();
            
        }

        private void btnAdmin8_Click(object sender, EventArgs e)
        {
            delRow();
            update();
        }

        private void btnAdmin9_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dGV_Admin);
        }

        private void dGV_Admin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tAdmin1_TextChanged(object sender, EventArgs e)
        {
            Search(dGV_Admin);
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
