using Aplication;
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
    public partial class FormClientesRegistrados : Form
    {
        Negocio negocio;

        public FormClientesRegistrados()
        {
            InitializeComponent();

            negocio = new Negocio();
            dataGridViewClientesRegistrados.DataSource = negocio.ListaClientes();
            dataGridViewClientesRegistrados.Columns[dataGridViewClientesRegistrados.Columns.Count - 1].Visible = false;

        }

        private void dataGridViewClientesRegistrados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ActualizarData();
        }

        public void ActualizarData()
        {
            dataGridViewClientesRegistrados.DataSource = negocio.ListaClientes();

        }

    }
}
