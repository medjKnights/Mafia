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
    public partial class Form_2 : Form
    {
        DataSet dsEmployee = new DataSet();
        DataSetTableAdapters.gamersTableAdapter dagamers = new Maf_Project.DataSetTableAdapters.gamersTableAdapter();
             
        BindingManagerBase bmEmployee;


        

        public void EmployeeFill()
        {
            dagamers.Fill(dsEmployee.gamers);

            AddListBoxEmployeeDataSource();

            textBox1.DataBindings.Add("Text", dsEmployee, "gamers.id");
            textBox2.DataBindings.Add("Text", dsEmployee, "gamers.name");
            textBox3.DataBindings.Add("Text", dsEmployee, "gamers.nik");
            textBox4.DataBindings.Add("Text", dsEmployee, "gamers.tel");
        
        }

        

        public Form_2()
        {
            InitializeComponent();
            bmEmployee = this.BindingContext[dsEmployee,"gamers"];
        }

       
        private void AddListBoxEmployeeDataSource()
        {
            listBoxEmployee.DataSource = this.dsEmployee;
            listBoxEmployee.DisplayMember = "gamers.nik";
        }

 

        private void Form_1_Load(object sender, EventArgs e)
        {
            EmployeeFill();
           
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;

                    
        }

        public void Undo()
        {
            bmEmployee.EndCurrentEdit();
            dsEmployee.gamers.RejectChanges();
        }

        public void New()
        {
            DataRow rowEmployee = this.dsEmployee.gamers.NewgamersRow();

            dsEmployee.gamers.Rows.Add(rowEmployee);
            int pos = this.dsEmployee.gamers.Rows.Count - 1;
            this.BindingContext[dsEmployee, "gamers"].Position = pos;
            Edit();
            
        }

        public void Edit()
        {

            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
                    
            listBoxEmployee.Enabled = false;

        }

        public void Save()
        {

            bmEmployee.EndCurrentEdit();

            DataSet.gamersDataTable ds2 = (DataSet.gamersDataTable)dsEmployee.gamers.GetChanges(DataRowState.Added);
            if (ds2 != null)
                try
                {
                    dagamers.Update(ds2);
                    ds2.Dispose();
                    dsEmployee.gamers.AcceptChanges();
                }
                catch (Exception x)
                {
                    string mes2 = x.Message;
                    MessageBox.Show("Ошибка вставки записи в базу данных 'Podatku' " + mes2, "Предупреждение");
                    this.dsEmployee.gamers.RejectChanges();
                }

            DataSet.gamersDataTable ds1 = (DataSet.gamersDataTable)dsEmployee.gamers.GetChanges(DataRowState.Modified);
            if (ds1 != null)
                try
                {
                    this.dagamers.Update(ds1);
                    ds1.Dispose();
                    dsEmployee.gamers.AcceptChanges();
                    MessageBox.Show("Збережено");
                }
                catch (Exception x)
                {
                    string mes = x.Message;
                    MessageBox.Show("Ошибка обновления базы данных 'Gamers' " + mes, "Предупреждение");
                    this.dsEmployee.gamers.RejectChanges();
                }
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            listBoxEmployee.Enabled = true;
            
        }

        public void Remove()
        {
            int pos = -1;
            pos = this.BindingContext[dsEmployee, "gamers"].Position;
            DialogResult result = MessageBox.Show("Видалити данні  \n" + "по "+ textBox2.Text + " ?","Попередження!", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        this.dsEmployee.gamers.Rows[pos].Delete();
                        if (this.dsEmployee.gamers.GetChanges(DataRowState.Deleted) != null)
                        {
                            try
                            {
                                this.dagamers.Update(dsEmployee.gamers);
                                this.dsEmployee.gamers.AcceptChanges();
                            }
                            catch (Exception x)
                            {
                                string er = x.Message.ToString();
                                MessageBox.Show("Ошибка удаления записи в базе данных 'Gamers' " + er, "Предупреждение");
                                this.dsEmployee.gamers.RejectChanges();
                            }
                        }
 

                        MessageBox.Show("Удаление данных");
                        break;
                    }
                case DialogResult.No:
                    {
                        this.dsEmployee.gamers.RejectChanges();
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



    }
}
