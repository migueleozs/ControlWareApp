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
    public partial class FormStock : Form
    {
        Negocio negocio;

        public FormStock()
        {
            InitializeComponent();

            negocio = new Negocio();

            this.ActualizarData();
            dataGridViewStock.CellFormatting += DataGridViewVentasTotales_CellFormatting;
        }

        


    private void DataGridViewVentasTotales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridViewStock.Columns[e.ColumnIndex].Name == "producto")
        {
            object value = e.Value;

            if (value is Entidades.Producto producto)
            {
                e.Value = $"{producto.Nombre} {producto.Descripcion}";
                e.FormattingApplied = true;
            }
        }
    }

    private void FormStock_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ActualizarData()
        {
            dataGridViewStock.DataSource = negocio.ListaInventario();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ActualizarData();
        }
    }
}
