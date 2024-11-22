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
using System.Xml.Linq;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        Form form2, formNuevoUsuario;
        public Sesion sesion;
        Bitacora bitacora = new Bitacora("Bitacora.xml");
        Negocio negocio;
        RepositorioUsuarios _repoUsuarios = new RepositorioUsuarios("Usuarios.xml");

        public FormLogin()
        {
            form2 = new Form2();
            formNuevoUsuario = new FormNuevoUsuario();
            negocio = new Negocio();
            InitializeComponent();
        }

        public string FromXML_UsuarioId = "";
        public string FromXML_Password = "";
        public string FromXML_Nombre = "";
        public string FromXML_Rol = "";

        private void btnRegistroUser_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuarioIngresado, passIngresada, passDesencriptada = null;
            usuarioIngresado = textBoxUser.Text;
            passIngresada = textBoxPassword.Text;
            passDesencriptada = "";
            List<Permiso> permisoSesion = new List<Permiso>();

            try
            {
                if (textBoxUser != null && textBoxPassword != null && textBoxUser.Text != "" && textBoxPassword.Text != "")
                {
                    if (!Regex.IsMatch(textBoxUser.Text, @"^[A-Z][a-zA-Z]*$"))
                    {
                        throw new Exception("El nombre solo admiten letras, debe empezar en mayuscula");
                    }
                    if (!Regex.IsMatch(textBoxPassword.Text, @"^[0-9a-zA-Z]*$"))
                    {
                        throw new Exception("La contraseña no puede tener caracteres especiales.");
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (negocio.BuscarUsuario(usuarioIngresado)!=null)
                {
                    Usuario usuarioSeleccionado = new Usuario();
                    usuarioSeleccionado = negocio.BuscarUsuario(usuarioIngresado);

                    FromXML_UsuarioId = usuarioSeleccionado.Id.ToString();
                    FromXML_Password = passDesencriptada = Encriptacion.Desencriptar(usuarioSeleccionado.Password);
                    FromXML_Nombre = usuarioSeleccionado.Nombre;
                    FromXML_Rol = usuarioSeleccionado.rol.ObtenerNombre();
                    if (usuarioSeleccionado.rol != null)
                    {
                        permisoSesion = usuarioSeleccionado.rol._permisos;
                    }
                    
                }


                if (usuarioIngresado == FromXML_Nombre && FromXML_Nombre != "")
                {
                    if (passDesencriptada == passIngresada)
                    {
                        MessageBox.Show("Ingreso Correctamente!");

                        sesion = new Sesion(FromXML_Nombre, new Rol (FromXML_Rol, permisoSesion) );
                        negocio.actualizarSesion(sesion);

                        Form1 formularioPrincipal = this.ParentForm as Form1;


                        sesion.rol._permisos = _repoUsuarios.ObtenerPermisosUsuario(int.Parse(FromXML_UsuarioId));


                        formularioPrincipal.SetSesion(sesion);

                        bitacora.RegistrarEvento(" Inició Sesión", formularioPrincipal.GetSesion().nombre);

                        if (formularioPrincipal != null)
                        {
                            Form2 form2 = new Form2();
                            formularioPrincipal.AbrirFormSec(form2);
                            formularioPrincipal.mostrarPanelO();

                            formularioPrincipal.noMostrarTodosPaneles();
                            if (sesion.rol._permisos[0].TieneAcceso())
                            {
                                formularioPrincipal.mostrarClientes();
                            }
                            if (sesion.rol._permisos[1].TieneAcceso())
                            {
                                formularioPrincipal.mostrarVenta();
                            }
                            if (sesion.rol._permisos[2].TieneAcceso())
                            {
                                formularioPrincipal.mostrarProductos();
                            }
                            if (sesion.rol._permisos[3].TieneAcceso())
                            {
                                formularioPrincipal.mostrarCompras();
                            }
                            if (sesion.rol._permisos[4].TieneAcceso())
                            {
                                formularioPrincipal.mostrarReportes();
                            }
                            if (sesion.rol._permisos[5].TieneAcceso())
                            {
                                formularioPrincipal.mostrarEmpleados();
                            }
                            
                        }
                        else
                        {
                            throw new ArgumentException("Error en el formulario.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contrasena Erronea. No puede ser vacio o no coincide");
                    }

                }
                else
                {
                    MessageBox.Show("Usuario Erroneo. No puede ser vacio o no existe");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void AbrirFormSec(object formSec)
        {
            if (this.Parent.Controls.Count > 0)
                this.Parent.Controls.RemoveAt(0);
            Form formularioSec = formSec as Form;
            formularioSec.TopLevel = false;
            formularioSec.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(formularioSec);
            this.Parent.Tag = formularioSec;
            formularioSec.Show();


        }

    }
}
