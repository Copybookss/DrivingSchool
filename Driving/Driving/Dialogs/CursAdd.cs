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
    public partial class CursAdd : Form
    {
        Database data = new Database();
        public CursAdd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CursAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand($"INSERT INTO [Curses] (Name, StartDate, EndDate, Salary) VALUES (@Name, @StartDate, @EndDate, @Salary)", data.GetConnection());
            cmd.Parameters.Clear();

            DateTime date1 = DateTime.Parse(tNW2.Text);
            DateTime date2 = DateTime.Parse(textBox2.Text);

            cmd.Parameters.AddWithValue("Name", tNW1.Text);
            cmd.Parameters.AddWithValue("StartDate", $"{date1.Month}/{date1.Day}/{date1.Year}");
            cmd.Parameters.AddWithValue("EndDate", $"{date2.Month}/{date2.Day}/{date2.Year}");
            cmd.Parameters.AddWithValue("Salary", textBox1.Text);

            data.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
                MessageBox.Show("Группа добавлена!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Не удалсь добавить группу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            data.closeConnection();

            tNW1.Text = "";
            tNW2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
