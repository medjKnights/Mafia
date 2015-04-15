using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.Data.Common;
using System.Threading;
using System.Data.SqlClient;

namespace Maf_Project
{
    public partial class gameplay : Form
    {
        public gameplay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(Properties.Settings.Default.MafiaConnectionString);
            SqlCommand query = new SqlCommand("INSERT INTO gameplay (id_game, id_gamer, role, at_table, fols, position)" +
            "values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + numericUpDown1.Text + "', '" + numericUpDown2.Text +  "')", c);
            c.Open();
            try
            {
                query.BeginExecuteNonQuery();

            }
            catch
            {

            }
        }
    }
}
