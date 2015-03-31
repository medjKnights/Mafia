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
    public partial class Form_1 : Form
    {
        
        DataSet dsEmployee = new DataSet();
        DataSetTableAdapters.gamesTableAdapter dagames = new Maf_Project.DataSetTableAdapters.gamesTableAdapter();
        DataSetTableAdapters.gamersTableAdapter dagamers = new Maf_Project.DataSetTableAdapters.gamersTableAdapter();
        DataSetTableAdapters.gameplayTableAdapter dagameplay = new Maf_Project.DataSetTableAdapters.gameplayTableAdapter();
         
     
        BindingManagerBase bmEmployee;
        BindingManagerBase bmEmployee2;


        

        public void EmployeeFill()
        {
            dagames.Fill(dsEmployee.games);

            AddColumsFullName();
            AddListBoxEmployeeDataSource();

            textBox1.DataBindings.Add("Text", dsEmployee, "games.id");
            textBox2.DataBindings.Add("Text", dsEmployee, "games.winer");
            textBox3.DataBindings.Add("Text", dsEmployee, "games.first_kill");
            textBox4.DataBindings.Add("Text", dsEmployee, "games.best_gаmer");
            textBox5.DataBindings.Add("Text", dsEmployee, "games.best_rate");
            textBox6.DataBindings.Add("Text", dsEmployee, "games.date");
        }

        

        public Form_1()
        {
            InitializeComponent();
            bmEmployee = this.BindingContext[dsEmployee,"games"];
            bmEmployee2 = this.BindingContext[dsEmployee, "gameplay"];
        }

        private void AddColumsFullName()
        {
            dsEmployee.games.Columns.Add("FullName", typeof(string),
             "id+' '+date");
        }

        private void AddListBoxEmployeeDataSource()
        {
            listBoxEmployee.DataSource = this.dsEmployee;
            listBoxEmployee.DisplayMember = "games.FullName";
        }

        public void getHistory()
        {

            SqlConnection c = new SqlConnection(Properties.Settings.Default.MafiaConnectionString);
            SqlCommand query = new SqlCommand("SELECT id_gamer as Gamer, position as position, role as Role, at_table as Status, fols as Fols FROM gameplay WHERE id_game=" + textBox1.Text, c);
            c.Open();
            ArrayList w = new ArrayList(0);
            SqlDataReader reader;
            reader = query.ExecuteReader();
            // зчитування даних з бази в масив
            foreach (DbDataRecord t in reader)
            {
                w.Add(t);
            }
            c.Close();
            dataGridView1.DataBindings.Clear();
            // занесення даних з масива в DataGrid View
            dataGridView1.DataSource = w;


        }

       

        private void Form_1_Load(object sender, EventArgs e)
        {
           
            
            EmployeeFill();
           
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
           

          
            
            //comboBox1.DataBindings.Add("SelectedValue", dsEmployee, "gamers.ID");
        }

        public void Undo()
        {
            bmEmployee.EndCurrentEdit();
            dsEmployee.games.RejectChanges();
        }

        public void New()
        {
            DataRow rowEmployee = this.dsEmployee.games.NewgamesRow();

            rowEmployee["winer"] = "default";
            rowEmployee["first_kill"] = "0";
            rowEmployee["best_gamer"] = "0";
            rowEmployee["best_rate"] = "0";
            rowEmployee["date"] = DateTime.Now.ToString();


            dsEmployee.games.Rows.Add(rowEmployee);
            int pos = this.dsEmployee.games.Rows.Count - 1;
            this.BindingContext[dsEmployee, "games"].Position = pos;
            Edit();
            
        }

        public void Edit()
        {
            //textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            
           
            listBoxEmployee.Enabled = false;
            //MessageBox.Show("Edit");
        }

        public void Save()
        {

            bmEmployee.EndCurrentEdit();

            DataSet.gamesDataTable ds2 = (DataSet.gamesDataTable)dsEmployee.games.GetChanges(DataRowState.Added);
            if (ds2 != null)
                try
                {
                    dagames.Update(ds2);
                    ds2.Dispose();
                    dsEmployee.games.AcceptChanges();
                }
                catch (Exception x)
                {
                    string mes2 = x.Message;
                    MessageBox.Show("Ошибка вставки записи в базу данных 'Podatku' " + mes2, "Предупреждение");
                    this.dsEmployee.games.RejectChanges();
                }

            DataSet.gamesDataTable ds1 = (DataSet.gamesDataTable)dsEmployee.games.GetChanges(DataRowState.Modified);
            if (ds1 != null)
                try
                {
                    this.dagames.Update(ds1);
                    ds1.Dispose();
                    dsEmployee.games.AcceptChanges();
                    MessageBox.Show("Збережено");
                }
                catch (Exception x)
                {
                    string mes = x.Message;
                    MessageBox.Show("Ошибка обновления базы данных 'Podatku' " + mes, "Предупреждение");
                    this.dsEmployee.games.RejectChanges();
                }

           
            //MessageBox.Show("Save");
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
          
            listBoxEmployee.Enabled = true;
            
        }

        public void Save2()
        {

            bmEmployee2.EndCurrentEdit();

            DataSet.gameplayDataTable ds2 = (DataSet.gameplayDataTable)dsEmployee.gameplay.GetChanges(DataRowState.Added);
            if (ds2 != null)
                try
                {
                    dagameplay.Update(ds2);
                    ds2.Dispose();
                    dsEmployee.games.AcceptChanges();
                }
                catch (Exception x)
                {
                    string mes2 = x.Message;
                    MessageBox.Show("Ошибка вставки записи в базу данных 'Podatku' " + mes2, "Предупреждение");
                    this.dsEmployee.games.RejectChanges();
                }

            DataSet.gameplayDataTable ds1 = (DataSet.gameplayDataTable)dsEmployee.gameplay.GetChanges(DataRowState.Modified);
            if (ds1 != null)
                try
                {
                    this.dagameplay.Update(ds1);
                    ds1.Dispose();
                    dsEmployee.gameplay.AcceptChanges();
                    MessageBox.Show("Збережено");
                }
                catch (Exception x)
                {
                    string mes = x.Message;
                    MessageBox.Show("Ошибка обновления базы данных 'Podatku' " + mes, "Предупреждение");
                    this.dsEmployee.gameplay.RejectChanges();
                }
            //MessageBox.Show("Save");
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
          
            listBoxEmployee.Enabled = true;

        }

        public void Remove()
        {
            int pos = -1;
            pos = this.BindingContext[dsEmployee, "games"].Position;
            DialogResult result = MessageBox.Show("Видалити данні  \n" + "по "+ textBox2.Text + " ?","Попередження!", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        this.dsEmployee.games.Rows[pos].Delete();
                        if (this.dsEmployee.games.GetChanges(DataRowState.Deleted) != null)
                        {
                            try
                            {
                                this.dagames.Update(dsEmployee.games);
                                this.dsEmployee.games.AcceptChanges();
                            }
                            catch (Exception x)
                            {
                                string er = x.Message.ToString();
                                MessageBox.Show("Ошибка удаления записи в базе данных 'Podatku' " + er, "Предупреждение");
                                this.dsEmployee.games.RejectChanges();
                            }
                        }
 

                        MessageBox.Show("Удаление данных");
                        break;
                    }
                case DialogResult.No:
                    {
                        this.dsEmployee.games.RejectChanges();
                        MessageBox.Show("Отмена удаления данных");
                        break;
                    }
            }

        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            New();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            gameplay gp = new gameplay();
            gp.ShowDialog();
            getHistory();
        }

        private void splitContainerEmployee_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getHistory();
        }

        private void splitContainerEmployee_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }





    }
}
