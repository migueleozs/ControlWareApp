using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entidades;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        Form formP, form2, formCliente, formVenta, formLogin, formVentasTotales, formClientesRegistrados, formBitacora, formEmpleados;
        Sesion sesionPrincipal;
        Bitacora bitacora = new Bitacora("Bitacora.xml");
        FormStock formStock;

        public Form1()
        {
            formP = new FormProducto();
            form2 = new Form2();
            formCliente = new FormRegistrarCliente();
            formVenta = new FormVentas();
            formLogin = new FormLogin();
            formVentasTotales = new FormVentasTotales();
            formStock = new FormStock();
            formClientesRegistrados = new FormClientesRegistrados();
            formEmpleados = new FormEmpleados();
            formBitacora = new FormBitacora();
            sesionPrincipal = new Sesion();
            sesionPrincipal.logueado = false;
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnInicio_Click(null, e);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaxim_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaxim.Visible = false;
            btnRestaure.Visible = true;
        }

        private void btnMinim_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaure_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaxim.Visible = true;
            btnRestaure.Visible = false;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int Msg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void AbrirFormSec(object formSec)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form formularioSec = formSec as Form;
            formularioSec.TopLevel = false;
            formularioSec.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(formularioSec);
            this.PanelContenedor.Tag = formularioSec;
            formularioSec.Show();

            
        }

        public void mostrarPanelO()
        {
            
        }

        public void noMostrarTodosPaneles()
        {
            panelProductos.Visible = false;
            panelClientes.Visible = false;
            panelVentas.Visible = false;
            btnClientes.Visible = false;
            btnVentas.Visible = false;
            btnProducts.Visible = false;
            btnCompras.Visible = false;
            btnReportes.Visible = false;
            btnEmpleados.Visible = false;
        }

        public void mostrarClientes()
        {
           btnClientes.Visible = true;
        }
        public void mostrarVenta()
        {
            btnVentas.Visible = true;
        }
        public void mostrarProductos()
        {
            btnProducts.Visible = true;
        }
        public void mostrarCompras()
        {
            btnCompras.Visible = true;
        }
        public void mostrarReportes()
        {
            btnReportes.Visible = true;
        }
        public void mostrarEmpleados()
        {
            btnEmpleados.Visible = true;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormSec(form2);

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            AbrirFormSec(formStock);
            panelProductos.Visible = false;
            
        }

        private void btnGP_Click(object sender, EventArgs e)
        {
            panelProductos.Visible = false;
            AbrirFormSec(formP);
        }
        private void btnRegistroCliente_Click(object sender, EventArgs e)
        {
            AbrirFormSec(formCliente);
            panelClientes.Visible = false;
        }

        private void btnClientesRegistrados_Click(object sender, EventArgs e)
        {
            AbrirFormSec(formClientesRegistrados);
            panelClientes.Visible = false;
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            AbrirFormSec(formVenta);
            panelVentas.Visible = false;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormSec(formEmpleados);
        }

        private void btnVentasTotales_Click(object sender, EventArgs e)
        {
            AbrirFormSec(formVentasTotales);
            panelVentas.Visible = false;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormSec(formBitacora);
        }

        private void btnSesion_Click(object sender, EventArgs e)
        {

            if (sesionPrincipal.logueado == true)
            {
                sesionPrincipal.logueado = false;
                MessageBox.Show("Ha cerrado sesion.");
            }
            AbrirFormSec(formLogin);
            
        }

        public void SetSesion(Sesion sesion)
        {
            sesionPrincipal = sesion;
        }

        public Sesion GetSesion()
        {
            return sesionPrincipal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelProductos.Visible = true;
            panelClientes.Visible = false;
            panelVentas.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelClientes.Visible = true;
            panelProductos.Visible = false;
            panelVentas.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelVentas.Visible = true;
            panelClientes.Visible = false;
            panelProductos.Visible = false;
        }



        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelProductos_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
