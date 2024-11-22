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
using static System.Collections.Specialized.BitVector32;

namespace Presentacion
{
    public partial class FormNuevoUsuario : Form
    {
        Negocio negocio;
        
        Bitacora bitacora = new Bitacora("Bitacora.xml");

        public FormNuevoUsuario()
        {
            InitializeComponent();
            negocio = new Negocio();
        }

        private void btnRegistroUsuario_Click(object sender, EventArgs e)
        {
            string tipoUsuario ="";
            try
            {
                if (textBoxNombreU.Text != "" && textBoxPass.Text != "")
                {
                    if (!Regex.IsMatch(textBoxNombreU.Text, @"^[A-Z][a-zA-Z]*$"))
                    {
                        throw new Exception("El nombre solo admiten letras, debe empezar en mayuscula");
                    }
                    if (!Regex.IsMatch(textBoxPass.Text, @"^[0-9a-zA-Z]*$"))
                    {
                        throw new Exception("La contraseña no puede tener caracteres especiales.");
                    }

                    if (radioButtonAdmin.Checked)
                    {
                        tipoUsuario = "Admin";
                    }
                    else if (radioButtonSuper.Checked)
                    {
                        tipoUsuario = "Supervisor";
                    }
                    else if (radioButtonCajero.Checked)
                    {
                        tipoUsuario = "Cajero";
                    }

                    var usuario = new Usuario()
                    {
                        _rol = tipoUsuario,
                        rol = new Rol(tipoUsuario),
                        Nombre = textBoxNombreU.Text,
                        Password = textBoxPass.Text

                    };
                    negocio.AgregarUsuario(usuario);
                    Form1 formularioPrincipal = this.ParentForm as Form1;

                    bitacora.RegistrarEvento(formularioPrincipal.GetSesion().nombre + " creó un usuario nuevo", negocio.GetSesion().nombre);

                    MessageBox.Show("Usuario creado exitosamente.");
                    LimpiarCampos();


                    if (formularioPrincipal != null)
                    {
                        FormEmpleados formEmpleados = new FormEmpleados();
                        formularioPrincipal.AbrirFormSec(formEmpleados);
                    }
                }
                else
                {
                    MessageBox.Show("Ningun campo puede quedar vacio.");
                }
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

        private void LimpiarCampos()
        {
            try
            {
                textBoxNombreU.Text = string.Empty;
                textBoxPass.Text = string.Empty;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
