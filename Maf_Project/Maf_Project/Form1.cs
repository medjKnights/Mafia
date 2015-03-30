using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Maf_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     

        private void коректориToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_2 FForm = new Form_2();
            //FForm.MdiParent = this;
            //FForm.Text = (sender as ToolStripMenuItem).Text;
            //FForm.person = person;
            //FForm.posada = posada;
            //FForm.Show();
        }

        private void лічильникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_2 FForm = new Form_2();
            FForm.MdiParent = this;
            FForm.Show();
        }

    }
}
