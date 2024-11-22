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
    public partial class FormVentasTotales : Form
    {
        Negocio negocio;

        public FormVentasTotales()
        {
            InitializeComponent();

            negocio = new Negocio();
            dataGridViewVentasTotales.DataSource = negocio.MostrarVentas();

            dataGridViewVentasTotales.CellFormatting += DataGridViewVentasTotales_CellFormatting;

        }

        private void DataGridViewVentasTotales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewVentasTotales.Columns[e.ColumnIndex].Name == "Comprador")
            {
                object value = e.Value;

                if (value is Entidades.Cliente cliente)
                {
                    e.Value = $"{cliente.Nombre} {cliente.Apellido}";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridViewVentasTotales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ActualizarData()
        {
            dataGridViewVentasTotales.DataSource = negocio.MostrarVentas();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ActualizarData();
        }
    }
}
