using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplication;
using Entidades;

namespace Presentacion
{
    public partial class FormVentas : Form
    {
        Bitacora bitacora = new Bitacora("Bitacora.xml");
        private Negocio negocio;
        Form formRegistrarCliente;

        public FormVentas()
        {
            InitializeComponent();
            this.DesactivarLabel();
            Empresa empresa = new Empresa();
            negocio = new Negocio();
            radioButtonEfectivo.CheckedChanged += new EventHandler(radioButtonEfectivo_CheckedChanged);
            textBoxMontoPagado.Enabled = false;
            formRegistrarCliente = new FormRegistrarCliente();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            negocio.AgregarProductoACarrito(RetornarProductoBuscado());
            //this.CargaInicialProducto();
            CargarDataGrid();
            MessageBox.Show("Producto asignado exitosamente.");
            Form1 formularioPrincipal = this.ParentForm as Form1;
            bitacora.RegistrarEvento("Asignó un producto a una venta", formularioPrincipal.GetSesion().nombre);
        }

        private void DesactivarLabel()
        {
            textBoxCodigoP.Enabled = false;
            textBoxNombreP.Enabled = false;
        }

        private void ActivarLabel()
        {
            textBoxCodigoP.Enabled = true;
            textBoxNombreP.Enabled = true;
        }
        private void CargarDataGrid()
        {
            try
            {
                var productosEnCarrito = negocio.ProductosEnCarrito();
                if (productosEnCarrito != null && productosEnCarrito.Any())
                {
                    dataGridView1.DataSource = productosEnCarrito;
                }
                else
                {
                    dataGridView1.DataSource = new List<Producto>();
                }
                lblMontoTotal.Text = "$ "+ negocio.CostoTotal;
            }
            catch (Exception)
            {
                throw new Exception("Error al cargar los producto a la venta.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                textBoxNombreP.Text = string.Empty;
                textBoxCodigoP.Text = string.Empty;
                textBoxDNI.Text = string.Empty;
                textBoxMontoPagado.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void RadioButtonTipo_Checked(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonEfectivo.Checked)
                {
                    radioButtonDebito.Checked = false;
                    radioButtonCredito.Checked = false;
                }
                else if (radioButtonDebito.Checked)
                {
                    radioButtonEfectivo.Checked = false;
                    radioButtonCredito.Checked = false;
                }
                else if (radioButtonCredito.Checked)
                {
                    radioButtonDebito.Checked = false;
                    radioButtonEfectivo.Checked = false;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int DNI = int.Parse(textBoxDNI.Text);

                if (negocio.ExisteClientexDNI(DNI))
                {
                    var cliente = negocio.BuscarClientexDNI(DNI);
                    MessageBox.Show("El cliente está registrado. Nombre: " + cliente.Nombre + " " + cliente.Apellido);
                    this.ActivarLabel();
                }
                else
                {
                    MessageBox.Show("No existe el cliente registrado con el DNI " + DNI);
                }

                Form1 formularioPrincipal = this.ParentForm as Form1;
                bitacora.RegistrarEvento("Buscó un cliente para la venta.", formularioPrincipal.GetSesion().nombre);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = int.Parse(textBoxCodigoP.Text);
                string nombre = textBoxNombreP.Text;

                if (negocio.ExisteProductoxId(Id) || negocio.ExisteProductoxNombre(nombre))
                {
                    if (negocio.ExisteProductoxNombre(nombre))
                    {
                        var producto = negocio.BuscarProductoxNombre(nombre);
                        MessageBox.Show("El producto está registrado. Nombre: " + producto.Nombre);
                    }
                    else if (negocio.ExisteProductoxId(Id))
                    {
                        var producto = negocio.BuscarProductoxId(Id);
                        MessageBox.Show("El producto está registrado. Id: " + producto.Id);
                    }
                }
                else
                {
                    MessageBox.Show("No existe el producto registrado con el Id o nombre solicitado. " + Id + nombre);
                }

                Form1 formularioPrincipal = this.ParentForm as Form1;
                bitacora.RegistrarEvento("Buscó un producto.", formularioPrincipal.GetSesion().nombre);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message);
            }
        }

        private Producto RetornarProductoBuscado()
        {
            var Id = 0;

            // Intenta convertir el texto de textBoxCodigoP.Text a un número entero
            if (!int.TryParse(textBoxCodigoP.Text, out Id))
            {
                // Si la conversión falla, muestra un mensaje de error y retorna null
                MessageBox.Show("El valor en el campo de código no es un número válido.");
                return null;
            }

            var nombre = textBoxNombreP.Text;

            if (negocio.ExisteProductoxId(Id) || negocio.ExisteProductoxNombre(nombre))
            {
                if (negocio.ExisteProductoxNombre(nombre))
                {
                    var producto = negocio.BuscarProductoxNombre(nombre);

                    return producto;
                }
                else if (negocio.ExisteProductoxId(Id))
                {
                    var producto = negocio.BuscarProductoxId(Id);
                    return producto;
                }
            }

            return null;
        }


        private void CargaInicialProducto()
        {
            dataGridView1.DataSource = negocio.ProductosEnCarrito();
        }


        private void radioButtonEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEfectivo.Checked)
            {
                textBoxMontoPagado.Enabled = true;
            }
            else
            {
                textBoxMontoPagado.Enabled = false;
                textBoxMontoPagado.Text = " ";
            }

        }

        private void textBoxMontoPagado_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxMontoPagado.Text, out int numero))
            {
                double resultado = numero - negocio.CostoTotal;
                labelVuelto.Text = "$ "+ resultado.ToString();
            }
            else
            {
                labelVuelto.Text = "Monto insuficiente.";
            }
            
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void formVentas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ventaNueva = new Venta();

            var DNI = int.Parse(textBoxDNI.Text);
            if (negocio.ExisteClientexDNI(DNI) && negocio.ProductosEnCarrito().Count > 0)
            {
                var cliente = negocio.BuscarClientexDNI(DNI);
                ventaNueva.Comprador = cliente;
                ventaNueva.productosVendidos = negocio.ProductosEnCarrito();
                ventaNueva.CostoTotal = ventaNueva.productosVendidos.Sum(x => x.Precio);

                if (radioButtonEfectivo.Checked)
                {
                    ventaNueva.tipomediodepago = Mediodepago.TIPO.efectivo;
                }
                else if (radioButtonDebito.Checked)
                {
                    ventaNueva.tipomediodepago = Mediodepago.TIPO.debito;
                }
                else if (radioButtonCredito.Checked)
                {
                    ventaNueva.tipomediodepago = Mediodepago.TIPO.credito;
                }

                MessageBox.Show("Venta finalizada correctamente");
                Form1 formularioPrincipal = this.ParentForm as Form1;
                bitacora.RegistrarEvento("Creó una nueva venta exitosamente", formularioPrincipal.GetSesion().nombre);
            }
            else
            {
                Form1 formularioPrincipal = this.ParentForm as Form1;
                MessageBox.Show("Venta no finalizada correctamente");
                bitacora.RegistrarEvento("Falló al crear una nueva venta", formularioPrincipal.GetSesion().nombre);
            }

            negocio.AgregarVenta(ventaNueva);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Acceder al formulario principal
            Form1 formularioPrincipal = this.ParentForm as Form1;

            // Verificar si el formulario principal es válido
            if (formularioPrincipal != null)
            {
                // Crear e mostrar el formulario "formRegistrarCliente" en el panel contenedor
                FormRegistrarCliente formRegistrarCliente = new FormRegistrarCliente();
                formularioPrincipal.AbrirFormSec(formRegistrarCliente);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void labelVuelto_Click(object sender, EventArgs e)
        {

        }

        
    }
}
