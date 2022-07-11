using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Invocando y usando la clase capaEntidad
using capaEntidad;
using capaNegocio;
namespace capaPresentacion
{
    public partial class frClientes : Form
    {
        CNCliente cnCliente = new CNCliente();
        public frClientes()
        {
            InitializeComponent();
        }

        private void picFoto_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Limpiar los elementos
            txtId.Value = 0;
            txtNombre.Text = "";
            txtApellido.Text = "";
            picFoto.Image = null;

        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Acceder al open Foto
            ofdFoto.FileName = string.Empty;
          

            //Condicion para saber si el usuario selecciono una imagen o no
            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                //Cargar la imagen en el recuadro
                picFoto.Load(ofdFoto.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Creacion de una instancia de la clase CECliente , y pasando los valores que tenemos 
            //en el formulario a sus variables de clase.
            bool Resultado;
            CECliente cECliente = new CECliente();
            cECliente.id = (int)txtId.Value;
            cECliente.Nombre = txtNombre.Text;
            cECliente.Apellido = txtApellido.Text;
            cECliente.Foto = picFoto.ImageLocation;

            Resultado = cnCliente.ValidarDatos(cECliente);
            if(Resultado == false)
            {
                return;

            }
            //cnCliente.ValidarDatos(cECliente);
            if (cECliente.id == 0)
            {
                cnCliente.CrearCliente(cECliente);
            }
            else
            {
                cnCliente.EditarCliente(cECliente);
            }
          //  MessageBox.Show("Todo bien vamos a insertar");
           
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cnCliente.PruebaMysql();
        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void CargarDatos()
        {
            //La siguiente sirve para obtener los datos al nombre del elemento tabla que hemos asignado en CDCliente.
            //Posteriormente la cargamos a la gridData cuando se ejecute la aplicacion.
            gridDatos.DataSource = cnCliente.ObtenerDatos().Tables["tbl"];
        }

        //Este metodo nos ayudara que al momento de seleccionar un campo de nuestra lista de base de datos
        //Se acompleten los espacios para asi llevar acabo la accion de actualizar algun elemento.
        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Las siguientes lineas nos sirves para seleccionar un objeto y establecer los valores en los campos correspondientes.
            txtId.Value = (int)gridDatos.CurrentRow.Cells["id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["apellido"].Value.ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["foto"].Value.ToString());
        }
    }
}
