using System;
using System.Windows.Forms;
//Usando la libreria de Mysql
using MySql.Data.MySqlClient;
using capaDatos;
using capaEntidad;
using System.Data;

namespace capaDatos
{
   
    public class CDCliente
    {
        //  CDCliente cDCliente = new CDCliente();
        string CadenaConexion = "Server=127.0.0.1;User=root;Password=123456;Port=3308;database=curso_cs;";

        //Verificando la conexxxion


        public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Conectarse " + ex.Message);
                return;
              //  throw;
            }

            mySqlConnection.Close();
            MessageBox.Show("Conectado!");
        }

        //Creacion de metodo paara la creacion del elemento
        public void Crear(CECliente cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `clientes` (`nombre`, `apellido`, `foto`) VALUES ('" + cE.Nombre + "', '" + cE.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query , mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro creado");
        }

        //Este metodo nos ayudara a mostrar el contenido de nuestra base de datos en el gridData.
        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `clientes` LIMIT 1000;";
            MySqlDataAdapter Adaptador;
            DataSet dataset = new DataSet();

            Adaptador = new MySqlDataAdapter(Query , mySqlConnection);
            //Establecemos nombre a la tabla que vamos a ocupar...
            Adaptador.Fill(dataset, "tbl");

            return dataset;


        }

    }
}
