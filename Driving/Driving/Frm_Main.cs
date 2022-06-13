using Driving.Auth;
using Driving.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Curs frm_curs = new Frm_Curs();
            this.Hide();
            frm_curs.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Student frm_st = new Frm_Student();
            this.Hide();
            frm_st.ShowDialog();
            this.Close();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Instructor frm_ins = new Frm_Instructor();
            this.Hide();
            frm_ins.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_Admin frm_admin = new Frm_Admin();
            this.Hide();
            frm_admin.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_Dashboard frm1 = new Frm_Dashboard();
            this.Hide();
            frm1.ShowDialog();
            this.Close();
        }
    }
}
