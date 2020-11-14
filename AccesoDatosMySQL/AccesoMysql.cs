using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesoDatosMySQL
{
    public partial class AccesoMysql : Form
    {
        static MySqlConnection Conex = new MySqlConnection();
        static string serv = "Server=localhost;";
        static string db = "Database=agenda;";
        static string usuario = "UID=root;";
        static string pwd = "Furipapa86jo";
        string CadenaDeConexion = (serv + "port=3306;" + usuario + pwd + db + "pooling=false;" +
            "Allow Zero Datetime=False;Convert Zero Datetime=True");
        static DataTable tabla;
        static MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM contactos",Conex);
        static MySqlCommandBuilder comandoSQL = new MySqlCommandBuilder(dataAdapter);
        public void Conectar()
        {
            try
            {
                Conex.ConnectionString = CadenaDeConexion;
                Conex.Open();
                MessageBox.Show("La BD está ahora conectada");
                
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al conectar la BD");
                
            }
        }
        public static void Desconectar()
        {
            Conex.Close();
        }
        private void obtenerBaseDatosMySQL()
        {
            MySqlDataReader registrosObtenidos = null;

            MySqlCommand cmd = new MySqlCommand("SELECT id_contacto FROM contactos", Conex);
            try
            {
                registrosObtenidos = cmd.ExecuteReader();
                while (registrosObtenidos.Read())
                {
                    dataGridView.Rows.Add(1);
                    for (int j = 0; j < 6; j++)
                    {
                          

                    }
                } 
            }
            catch(Exception e)
            {


            }
        }
        public AccesoMysql()
        {
            Conectar();
            InitializeComponent();
            dataAdapter.Fill(tabla);
            dataGridView.DataSource = tabla;
            
        }
    }
}
