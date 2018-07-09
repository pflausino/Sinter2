﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinter2
{
    public partial class RegisterArts : Form
    {
        //String de Conexão
        string MyConnection = "datasource=sql49.main-hosting.eu;port=3306;username=u812598544_prod;password=lEsB2pyTr8vu";
        //string MyConnection = "datasource=10.0.0.100;port=3306;username=develop;password=734m0d3m215";
        public RegisterArts()
        {
            InitializeComponent();
            txtDate.Mask = "00/00/0000";

            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtName.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "insert into u812598544_sinte.GHL_Registros2(" +
                        "Nome,Firma,Tipo_de_Arquivo,N_do_Arquivo,Data" +
                    ") values('" +
                        this.txtName.Text + "','" + 
                        this.txtFirma.Text + "','" + 
                        this.cbType.Text + "','" + 
                        this.numType.Text + "','" + 
                        this.txtDate.Text + 
                    "');";

                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                MessageBox.Show("Salvo");
                while (MyReader.Read())
                {

                }

                MyConn.Close();

                txtName.Clear();
                txtFirma.Clear();

                txtName.Focus();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao salvar Arquivo \n" + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "select `Identificacao`,`Nome`,`Firma`,`Tipo_de_Arquivo`,`N_do_Arquivo`,`Data`  from u812598544_sinte.GHL_Registros2 " +
                    "WHERE Nome LIKE '" + "%" + this.txtSearch.Text + "%" + "' ORDER BY Identificacao DESC;";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                                                   // MyConn2.Close();  

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RegisterArts_Load(object sender, EventArgs e)
        {
            DataGrid();
        }

        public void DataGrid()
        {
            try
            {
                //Display query  
                string Query = "select `Identificacao`,`Nome`,`Firma`,`Tipo_de_Arquivo`,`N_do_Arquivo`,`Data` from u812598544_sinte.GHL_Registros2 ORDER BY Identificacao DESC;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                                                   // MyConn2.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtFirma.Clear();

        }
    }
}
