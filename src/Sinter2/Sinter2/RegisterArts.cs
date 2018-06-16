using System;
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
        string MyConnection = "datasource=10.0.0.100;port=3306;username=develop;password=734m0d3m215";
        public RegisterArts()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "insert into Sinter_DB.GHL_Registros2(" +
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

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao salvar Arquivo \n" + ex.Message);
            }
        }
    }
}
