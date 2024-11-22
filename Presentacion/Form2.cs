using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace Presentacion
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
            CrearGrafica(true, SeriesChartType.Doughnut);
            CrearGrafica2(true, SeriesChartType.Pie);
            CrearGrafica3(true, SeriesChartType.Column);
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 formularioPrincipal = this.ParentForm as Form1;
            labelBien.Text = "Dashboard  " + formularioPrincipal.GetSesion().nombre;
        }
        private void CrearGrafica(bool orden, SeriesChartType tipoDeGrafico)
        {
            chart3.Series.Clear();

            // Crear una nueva serie
            var series = chart3.Series.Add("Productos");
            series.ChartType = tipoDeGrafico;
            int contadorProductos = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Inventarios.xml");
            // Acceder a los nodos y leer datos
            XmlNodeList dataNodes = xmlDoc.SelectNodes("//Inventarios/Inventario");

            // Crear una lista para almacenar los datos
            List<KeyValuePair<string, int>> data = new List<KeyValuePair<string, int>>();

            // Agregar puntos de datos a la lista
            foreach (XmlNode node in dataNodes)
            {
                string etiqueta = node.SelectSingleNode("Producto").SelectSingleNode("Nombre").InnerText;
                int valor = int.Parse(node.SelectSingleNode("Cantidad").InnerText);
                contadorProductos++;
                data.Add(new KeyValuePair<string, int>(etiqueta, valor));
            }
            label11.Text = contadorProductos.ToString();
            // Ordenar la lista por valor de forma descendente
            data.Sort((x, y) => y.Value.CompareTo(x.Value));

            // Tomar solo los 5 valores más altos
            var top5Data = data.Take(5);

            var sortedSales = data.OrderBy(kvp => kvp.Value);

            // Tomar solo los 5 valores más bajos
            var bottom5Sales = sortedSales.Take(5);

            

            if (orden)
            {
                // Agregar puntos de datos a la serie
                foreach (var item in top5Data)
                {
                    // Agregar etiqueta con el nombre del producto y la cantidad
                    series.Points.AddXY($"{item.Key} {item.Value}", item.Value);
                }
            }
            else
            {

                // Agregar puntos de datos a la serie
                foreach (var item in bottom5Sales)
                {
                    // Agregar etiqueta con el nombre del cliente y el costo total
                    series.Points.AddXY($"{item.Key} ${item.Value}", item.Value);
                }
            }
        }


        private void CrearGrafica2(bool orden, SeriesChartType tipoDeGrafico)
        {
            chart1.Series.Clear();

            // Crear una nueva serie
            var series = chart1.Series.Add("Productos");
            series.ChartType = tipoDeGrafico; // Cambiado a Doughnut para mostrar un gráfico de dona

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Ventas.xml");
            // Acceder a los nodos y leer datos
            XmlNodeList dataNodes = xmlDoc.SelectNodes("//Ventas/Venta");

            // Crear una lista para almacenar los datos
            List<KeyValuePair<string, double>> data = new List<KeyValuePair<string, double>>();

            int contadorVentas = 0;
            // Agregar puntos de datos a la lista
            foreach (XmlNode node in dataNodes)
            {
                string cliente = node.SelectSingleNode("Comprador").SelectSingleNode("Nombre").InnerText;
                double costo = double.Parse(node.SelectSingleNode("CostoTotal").InnerText);
                contadorVentas = contadorVentas + 1;
                data.Add(new KeyValuePair<string, double>(cliente, costo));
            }
            label5.Text = contadorVentas.ToString();
            // Ordenar la lista por valor de forma descendente
            data.Sort((x, y) => y.Value.CompareTo(x.Value));

            // Tomar solo los 5 valores más altos
            var top5Data = data.Take(5);

            var sortedSales = data.OrderBy(kvp => kvp.Value);

            // Tomar solo los 5 valores más bajos
            var bottom5Sales = sortedSales.Take(5);

            if (orden)
            {
                foreach (var item in top5Data)
                {
                    // Agregar etiqueta con el nombre del cliente y el costo total
                    series.Points.AddXY($"{item.Key} ${item.Value}", item.Value);
                }
            }
            else
            {

                // Agregar puntos de datos a la serie
                foreach (var item in bottom5Sales)
                {
                    // Agregar etiqueta con el nombre del cliente y el costo total
                    series.Points.AddXY($"{item.Key} ${item.Value}", item.Value);
                }
            }

        }

        private void CrearGrafica3(bool orden, SeriesChartType tipoDeGrafico)
        {
            chart2.Series.Clear();

            // Crear una nueva serie
            var series = chart2.Series.Add("Productos");
            series.ChartType = tipoDeGrafico; // Cambiado a Doughnut para mostrar un gráfico de dona

            

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Ventas.xml");
            // Acceder a los nodos y leer datos
            XmlNodeList dataNodes = xmlDoc.SelectNodes("//Ventas/Venta");

            // Crear un diccionario para almacenar las ventas por cliente
            Dictionary<string, double> salesByClient = new Dictionary<string, double>();

            int contadorClientes = 0;
            // Calcular la suma de ventas por cliente
            foreach (XmlNode node in dataNodes)
            {
                string cliente = node.SelectSingleNode("Comprador").SelectSingleNode("Nombre").InnerText;
                double costo = double.Parse(node.SelectSingleNode("CostoTotal").InnerText);

                if (salesByClient.ContainsKey(cliente))
                {
                    salesByClient[cliente] += costo;
                }
                else
                {
                    salesByClient.Add(cliente, costo);
                    contadorClientes ++;
                }
            }
            label14.Text = contadorClientes.ToString();
            // Tomar solo los 5 valores más altos
            var top5Data = salesByClient.Take(5);

            var sortedSales = salesByClient.OrderBy(kvp => kvp.Value);

            // Tomar solo los 5 valores más bajos
            var bottom5Sales = sortedSales.Take(5);

            if (orden)
            {

                // Agregar puntos de datos a la serie
                foreach (var kvp in salesByClient)
                {
                    // Agregar etiqueta con el nombre del cliente y la suma de ventas
                    series.Points.AddXY($"{kvp.Key} (${kvp.Value})", kvp.Value);
                }
            }
            else
            {

                // Agregar puntos de datos a la serie
                foreach (var item in bottom5Sales)
                {
                    // Agregar etiqueta con el nombre del cliente y el costo total
                    series.Points.AddXY($"{item.Key} ${item.Value}", item.Value);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            CrearGrafica(true, ObtenerTipoDeGrafico(chart3));
            CrearGrafica2(true, ObtenerTipoDeGrafico(chart1));
            CrearGrafica3(true, ObtenerTipoDeGrafico(chart2));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CrearGrafica(false, ObtenerTipoDeGrafico(chart3));
            CrearGrafica2(false, ObtenerTipoDeGrafico(chart1));
            CrearGrafica3(false, ObtenerTipoDeGrafico(chart2));
        }

        public SeriesChartType ObtenerTipoDeGrafico(Chart chart)
        {
            // Si el gráfico tiene al menos una serie
            if (chart.Series.Count > 0)
            {
                // Devuelve el tipo de gráfico de la primera serie
                return chart.Series[0].ChartType;
            }
            else
            {
                // Si no hay series, devuelve un valor predeterminado o indica que no hay tipo de gráfico definido
                return SeriesChartType.Column; // Por ejemplo, podrías devolver el tipo Column como valor predeterminado
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            CrearGrafica(true, SeriesChartType.Pie);
            CrearGrafica2(true, SeriesChartType.Pie);
            CrearGrafica3(true, SeriesChartType.Pie);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            CrearGrafica(true, SeriesChartType.Doughnut);
            CrearGrafica2(true, SeriesChartType.Doughnut);
            CrearGrafica3(true, SeriesChartType.Doughnut);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            CrearGrafica(true, SeriesChartType.FastLine);
            CrearGrafica2(true, SeriesChartType.FastLine);
            CrearGrafica3(true, SeriesChartType.FastLine);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            CrearGrafica(true, SeriesChartType.Area);
            CrearGrafica2(true, SeriesChartType.Area);
            CrearGrafica3(true, SeriesChartType.Area);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            CrearGrafica(true, SeriesChartType.Column);
            CrearGrafica2(true, SeriesChartType.Column);
            CrearGrafica3(true, SeriesChartType.Column);
        }
    }
}
