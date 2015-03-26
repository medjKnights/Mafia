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

        int person;
        string posada = "user not found";

        private void Form1_Load(object sender, EventArgs e)
        {


        }

       

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void вихідToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Вихід із програми";
        }

        private void вихідToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = "";
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AboutBox1 about = new AboutBox1();
            //about.Show();
        }

        private void доступДоАІСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_1 FForm = new Form_1();
            //FForm.MdiParent = this;
            //FForm.Text = (sender as ToolStripMenuItem).Text;
            //FForm.posada = posada;
            //FForm.Show();
            
        }

        private void доступДоАІСToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Відкрити форму для роботи з таблицею " + "'" + (sender as ToolStripMenuItem).Text + "'";
        }

        private void доступДоАІСToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = "";
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoginForm LForm = new LoginForm();
            //LForm.ShowDialog();
            //posada = LForm.posada;
            //userToolStripMenuItem.Text = posada;
            //if (posada != "user not found")
            //{
            //    logInToolStripMenuItem.Enabled = false;
            //    logOutToolStripMenuItem.Enabled = true;
            //    posadaUpDate(posada);
            //    person = LForm.person;
            //}

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //posada = "user not found";
            //userToolStripMenuItem.Text = posada;
            //logInToolStripMenuItem.Enabled = true;
            //logOutToolStripMenuItem.Enabled = false;
            //posadaUpDate(posada);
            //for(int i = 0;i<MdiChildren.Count();i++)
            //MdiChildren.ElementAt(i).Close();
        }

        private void лічильникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_4 FForm = new Form_4();
            //FForm.MdiParent = this;
            //FForm.Text = (sender as ToolStripMenuItem).Text;
            //FForm.posada = posada;
            //FForm.person = person;
            //FForm.Show();
        }

        private void графікПовірокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_3 FForm = new Form_3();
            //FForm.MdiParent = this;
            //FForm.Text = (sender as ToolStripMenuItem).Text;
            //FForm.posada = posada;
            //FForm.Show();
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

    }
}
