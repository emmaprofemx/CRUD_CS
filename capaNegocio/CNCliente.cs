using System;
using System.Data;
using System.Windows.Forms;
using capaDatos;
//Uso de la capa entidad
using capaEntidad;
namespace capaNegocio
{
    public class CNCliente
    {
        CDCliente cDCliente = new CDCliente();
        public bool ValidarDatos(CECliente cliente)
        {
            bool resultado = true;
            //En caso de que el nombre o apellido esten vacios , se desplegara un mensaje 
            if (cliente.Nombre == string.Empty)
            {
                resultado = false;
                MessageBox.Show("El nombre es Obligatorio");
            }

            if (cliente.Apellido == string.Empty)
            {
                resultado = false;
                MessageBox.Show("El apellido es Obligatorio");
            }

            if (cliente.Foto == null)
            {
                resultado = false;
                MessageBox.Show("La Foto es Obligatorio");
            }

            return resultado;
        }

        public void PruebaMysql()
        {
            cDCliente.PruebaConexion();
        }

        public void CrearCliente(CECliente cE)
        {
            cDCliente.Crear(cE);
        }

        public void EditarCliente(CECliente cE)
        {
            cDCliente.Editar(cE);
        }
        public DataSet ObtenerDatos()
        {
            return cDCliente.Listar();
        }

    }
}
