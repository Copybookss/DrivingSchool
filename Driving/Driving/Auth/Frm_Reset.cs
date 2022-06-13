using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Driving.Models;
using System.Data.SqlClient;

namespace Driving.Auth
{
    public partial class Frm_Reset : Form
    {
        public Frm_Reset()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        Database data = new Database();
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var login = tNW1.Text;
            var password = tNW2.Text;

            string newQuery = $"INSERT INTO registr (username, password) VALUES ('{login}', '{password}')";

            SqlCommand cmd = new SqlCommand(newQuery, data.GetConnection());

            data.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан!","Успешно!");
                Frm_Login frm_Login = new Frm_Login();
                this.Hide();
                frm_Login.ShowDialog();
            }
            else
                MessageBox.Show("Аккаунт не создан!", "Ошибка!");
            data.closeConnection();
        }

        private Boolean checUser()
        {
            var loginUser = tNW1.Text;
            var loginPassword = tNW2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"SELECT * FROM registr WHERE username = '{loginUser}' and password = '{loginPassword}'";

            SqlCommand cmd = new SqlCommand(query, data.GetConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
                return false;
        }

        private void Frm_Reset_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
