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
    public partial class InstAdd : Form
    {

        Database data = new Database();
        public InstAdd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            data.openConnection();
            var name = tNW1.Text;
            int exp;
            var car = textBox2.Text;
            var poss = textBox1.Text;

            if(int.TryParse(tNW2.Text, out exp)) 
            { 
                var addQuery = $"INSERT INTO Instructors (Name, Experience, Car, Position) VALUES ('{name}', '{exp}', '{car}', '{poss}')";

                 var cmd = new SqlCommand(addQuery, data.GetConnection());
                 cmd.ExecuteNonQuery();

                MessageBox.Show("Добавлена запись!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Запись не добавлена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
