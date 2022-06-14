using System;
using System.Windows.Forms;
//Usando la libreria de Mysql
using MySql.Data.MySqlClient;
using capaDatos;
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


            MessageBox.Show("Conectado!");
        }




    }
}
