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
    public partial class FormProducto : Form
    {
        private Negocio negocio;
        Bitacora bitacora = new Bitacora("Bitacora.xml");

        public FormProducto()
        {
            negocio = new Negocio();
            InitializeComponent();
            this.CargarDataGrid();
            dataGridViewProductos.Columns["Cantidad"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!Regex.IsMatch(textBoxNombreP.Text, @"^[A-Z][a-zA-Z]*$"))
                {
                    throw new Exception("El nombre solo admiten letras, debe empezar en mayuscula");
                }
                if (!Regex.IsMatch(textBoxPrecioP.Text, @"^[0-9]*$"))
                {
                    throw new Exception("El precio debe ser numerico");
                }
                var producto = new Producto
                {
                    Nombre = textBoxNombreP.Text,
                    Descripcion = textBoxDescripcionP.Text,
                    Precio = long.Parse(textBoxPrecioP.Text.ToString()),
                    
                };
                if (!Regex.IsMatch(textBoxCantidad.Text, @"^[0-9]*$"))
                {
                    throw new Exception("La cantidad debe ser un numero");
                }
                negocio.AgregarProducto(producto, int.Parse(textBoxCantidad.Text));
                this.CargarDataGrid();
                MessageBox.Show("Producto creado exitosamente.");

                Form1 formularioPrincipal = this.ParentForm as Form1;
                bitacora.RegistrarEvento(formularioPrincipal.GetSesion().nombre + " creó un nuevo producto exitosamente", negocio.GetSesion().nombre);

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
                var productos = negocio.ListaProductos();
                if(productos != null && productos.Any())
                {
                    dataGridViewProductos.DataSource = productos;
                }
                else
                {
                    dataGridViewProductos.DataSource = new List<Producto>();
                    
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al cargar la base de productos");
            }
        }

        private void LimpiarCampos()
        {
            try
            {
                textBoxNombreP.Text = string.Empty;
                textBoxPrecioP.Text = string.Empty;
                textBoxDescripcionP.Text = string.Empty;
                textBoxCantidad.Text = string.Empty;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var productoEscogido = (Producto)dataGridViewProductos.CurrentRow.DataBoundItem;
            negocio.EliminarProducto(productoEscogido);
            CargarDataGrid();

            Form formularioAux = new FormProducto();
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
        /*
        public void CargarDataSource()
        {
            dataGridViewProductos.DataSource = null;
            dataGridViewProductos.DataSource = negocio.MostrarUsuarios();
            //dataGridViewProductos.CellFormatting += DataGridViewProductos_CellFormatting;
        }
        */
    }
}
