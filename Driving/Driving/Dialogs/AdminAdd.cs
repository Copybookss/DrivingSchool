using Driving.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving.Dialogs
{
    public partial class AdminAdd : Form
    {


        Database data = new Database();
        public AdminAdd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"INSERT INTO [Admins] (Name, Position, Phone, Email) VALUES (@Name, @Position, @Phone, @Email)", data.GetConnection());
            cmd.Parameters.Clear();

           

            cmd.Parameters.AddWithValue("Name", tNW1.Text);
            cmd.Parameters.AddWithValue("Position", tNW2.Text);
            cmd.Parameters.AddWithValue("Phone", textBox2.Text);
            cmd.Parameters.AddWithValue("Email", textBox1.Text);

            data.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
                MessageBox.Show("Админ добавлен!", "Успешно!");
            else
                MessageBox.Show("Админ не добавлен!", "Ошибка!");
            data.closeConnection();

            tNW1.Text = "";
            tNW2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

    }
}

