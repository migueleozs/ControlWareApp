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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Presentacion
{
    public partial class FormEmpleados : Form
    {
        Negocio negocio;
        Form formNuevoUsuario;
        public event EventHandler DatosActualizados;
        Bitacora bitacora = new Bitacora("Bitacora.xml");


        public enum Roles
        {
            Clientes,
            Venta,
            Productos,
            Compras,
            Reportes,
            Empleados

        }
        private List<Roles> permisosSeleccionados = new List<Roles>();

        public FormEmpleados()
        {
            InitializeComponent();
            negocio = new Negocio();
            formNuevoUsuario = new FormNuevoUsuario();
            CargarDataSource();
        }

        public void CargarDataSource()
        {
               dataGridView1.DataSource = null;
            dataGridView1.DataSource = negocio.MostrarUsuarios();
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }


        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "_rol")
            {
                dataGridView1.Columns[e.ColumnIndex].HeaderText = "Rol";
            }
            dataGridView1.Columns["rol"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRegistroUser_Click(object sender, EventArgs e)
        {
            Form1 formularioPrincipal = this.ParentForm as Form1;

            if (formularioPrincipal != null)
            {
                Form2 form2 = new Form2();
                formularioPrincipal.AbrirFormSec(formNuevoUsuario);
            }
            else
            {
                MessageBox.Show("Error en el formulario.");
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        protected virtual void OnDatosActualizados()
        {
            DatosActualizados?.Invoke(this, EventArgs.Empty);
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            var usuarioEscogido = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
            List<int> indicesSeleccionados = checkedListBoxPermisos.CheckedIndices.Cast<int>().ToList();
            negocio.ModificarPermisos(usuarioEscogido, indicesSeleccionados);
        }

        private void MostrarMensajePermisos()
        {
            string mensaje = "Permisos asignados: " + string.Join(", ", permisosSeleccionados);
            MessageBox.Show(mensaje);
        }


        private void crearBackUp(string backup)
        {

        }



        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (textBoxBackUp.Text != "")
            {
                try
                {
                    negocio.crearBackUp(textBoxBackUp.Text);
                    MessageBox.Show("Respaldo creado exitosamente.");
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                Form1 formularioPrincipal = this.ParentForm as Form1;
                bitacora.RegistrarEvento("Realizo un backup con nombre " + textBoxBackUp.Text, formularioPrincipal.GetSesion().nombre);
                
            }
            else
            {
                MessageBox.Show("Debe asignar un nombre al respaldo.");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (textBoxBackUp.Text != "")
            {
                try
                {
                    negocio.realizarRestore(textBoxBackUp.Text);
                    MessageBox.Show("Restauracion exitosa.");
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            Form1 formularioPrincipal = this.ParentForm as Form1;
            bitacora.RegistrarEvento("Realizo un restore con nombre " + textBoxBackUp.Text, formularioPrincipal.GetSesion().nombre);

            }
            else
            {
                MessageBox.Show("Debe indicar un nombre para poder restaurar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var usuarioEscogido = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
            negocio.EliminarUsuario(usuarioEscogido);
            CargarDataSource();

            Form formularioAux = new FormEmpleados();
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
