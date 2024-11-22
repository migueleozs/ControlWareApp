using AccesoData;
using Aplication;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormRegistrarCliente : Form
    {
        private Negocio negocio;
        Bitacora bitacora = new Bitacora("Bitacora.xml");

        public FormRegistrarCliente()
        {
            negocio = new Negocio();
            InitializeComponent();
            this.CargarDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!Regex.IsMatch(textBoxDNIC.Text, @"^[0-9]{8}$"))
                {
                    throw new Exception("El DNI debe ser numerico y tener 8 cifras");
                }
                if (!Regex.IsMatch(textBoxNombreC.Text, @"^[A-Z][a-zA-Z]*$"))
                {
                    throw new Exception("El nombre empieza con una mayuscula y no debe tener numeros o caracteres especiales");
                }
                if (!Regex.IsMatch(textBoxApellidoC.Text, @"^[A-Z][a-zA-Z]*$"))
                {
                    throw new Exception("El apellido empieza con una mayuscula solo admiten letras");
                }
                if (!Regex.IsMatch(textBoxTelefonoC.Text, @"^[0-9]{10}$"))
                {
                    throw new Exception("El numero de telefono debe tener 10 cifras");
                }
                if (!Regex.IsMatch(textBoxEmailC.Text, @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.[a-zA-Z]{2,3})+$"))
                {
                    throw new Exception("El texto no corresponde a una direccion de correo valida. ejm:a@a.com");
                }
                var cliente = new Cliente
                {
                    Nombre = textBoxNombreC.Text,
                    Apellido = textBoxApellidoC.Text,
                    DNI = (int)long.Parse(textBoxDNIC.Text.ToString()),
                    Email = textBoxEmailC.Text,
                    Telefono = (int)long.Parse(textBoxTelefonoC.Text.ToString()),
                    
            };

                negocio.AgregarCliente(cliente);
                this.CargarDataGrid();

                Form1 formularioPrincipal = this.ParentForm as Form1;
                bitacora.RegistrarEvento(formularioPrincipal.GetSesion().nombre + " registró un nuevo producto", negocio.GetSesion().nombre);

                MessageBox.Show("Cliente creado exitosamente.");
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void CargarDataGrid()
        {
            try
            {
                var clientes = negocio.ListaClientes();
                if(clientes != null && clientes.Any())
                {
                    dataGridViewClientes.DataSource = clientes;
                }
                else
                {
                    dataGridViewClientes.DataSource = new List<Cliente>();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al cargar la base de clientes");
            }
        }

        private void LimpiarCampos()
        {
            try
            {
                textBoxDNIC.Text = string.Empty;
                textBoxEmailC.Text = string.Empty;
                textBoxNombreC.Text = string.Empty;
                textBoxApellidoC.Text = string.Empty;
                textBoxTelefonoC.Text = string.Empty;
                textBoxEmailC.Text = string.Empty;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void MostrarOcultarBotones(bool ocultar = false)
        {
            try
            {
                button2.Visible = ocultar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxIDC_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombreC_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var clienteEscogido = (Cliente)dataGridViewClientes.CurrentRow.DataBoundItem;
            negocio.EliminarCliente(clienteEscogido);
            CargarDataGrid();

            Form formularioAux = new FormRegistrarCliente();
            Form1 formularioPrincipal = this.ParentForm as Form1;

            if (formularioPrincipal != null)
            {
                Form2 form2 = new Form2();
                formularioPrincipal.AbrirFormSec(formularioAux);
            }
            else
            {
                MessageBox.Show("Error en el formulario.");
            }
        }
    }
}
