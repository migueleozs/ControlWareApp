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

namespace Presentacion
{
    public partial class FormBitacora : Form
    {

        Bitacora bitacora;
        //Negocio negocio;

        public FormBitacora()
        {
            InitializeComponent();
            bitacora = new Bitacora("Bitacora.xml");
            CargarDataSource();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void Refrescar()
        {
            CargarDataSource();

            Form formularioAux = new FormBitacora();
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

        public void CargarDataSource()
        {
            dataGridView1.DataSource = bitacora.ObtenerDataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            // Agregar DataGridView al formulario
            this.Controls.Add(dataGridView1);

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }
    }
}
