using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sinter2
{
    public partial class SearchByName : Form
    {
        //String de Conexão
        string MyConnection = "datasource=sql49.main-hosting.eu;port=3306;username=u812598544_prod;password=lEsB2pyTr8vu";
        //string MyConnection = "datasource=10.0.0.100;port=3306;username=develop;password=734m0d3m215";
        public SearchByName()
        {
            InitializeComponent();
        }

        private void SearchByName_Load(object sender, EventArgs e)
        {
            DataGrid();
            this.AcceptButton = btnSearch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DataGridSearch();

        }

        public void DataGrid()
        {
            
            try
            {
                //Display query  
                string Query = "select * from u812598544_sinte.GHL_Registros2 ORDER BY Identificacao DESC;";
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

            DataGridResize();
            
        }

        public void DataGridSearch()
        {
            try
            {
                string Query = "select * from u812598544_sinte.GHL_Registros2 " +
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
            DataGridResize();
        }
        public void DataGridResize()
        {
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 400;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 250;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //DataGridSearch();
        }
    }

}
