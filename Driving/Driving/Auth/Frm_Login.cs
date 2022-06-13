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

namespace Driving.Auth
{
    public partial class Frm_Login : Form
    {

        Database data = new Database();
        public Frm_Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            tW2.PasswordChar = '*';
            tW1.MaxLength = 50;
            tW2.MaxLength = 50;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginUser = tW1.Text;
            var loginPassword = tW2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"SELECT * FROM registr WHERE username = '{loginUser}' and password = '{loginPassword}'";

            SqlCommand cmd = new SqlCommand(query, data.GetConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Вход выполнен!", "Успешно!" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frm_Main frm_Main = new Frm_Main();
                this.Hide();
                frm_Main.ShowDialog(); 
                //this.Show();
            }
            else
                MessageBox.Show("Ошибка!", "Неверный логин или пароль!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tW1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tW1.ForeColor = Color.White;
               
            }
            catch (Exception ex) { }
        }

        private void tW2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tW1.ForeColor = Color.White;
                
            }
            catch (Exception ex) { }
        }

        private void tW1_Click(object sender, EventArgs e)
        {
            tW1.SelectAll();
        }

        private void tW2_Click(object sender, EventArgs e)
        {
            tW2.SelectAll();
        }

        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            Frm_Reset frm_Reset = new Frm_Reset();
            frm_Reset.Show();
            this.Hide();

        }

        private void btnInst7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
