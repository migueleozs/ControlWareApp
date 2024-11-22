using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Data;

namespace Entidades
{
    public class Bitacora
    {
        private readonly string rutaArchivo;
        private readonly DataTable dataTable;
        

        public Bitacora(string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;

            // Crear el archivo XML si no existe
            if (!File.Exists(rutaArchivo))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);
                XmlElement root = xmlDoc.CreateElement("Bitacora");
                xmlDoc.AppendChild(root);
                xmlDoc.Save(rutaArchivo);
            }

            // Inicializar el DataTable
            dataTable = new DataTable();
            dataTable.Columns.Add("FechaHora", typeof(string));
            dataTable.Columns.Add("Mensaje", typeof(string));
            dataTable.Columns.Add("Usuario", typeof(string));

            // Cargar los eventos existentes en el archivo XML al DataTable
            CargarEventos();
        }

        public void RegistrarEvento(string mensaje, string nombre)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(rutaArchivo);

                XmlElement eventoElement = xmlDoc.CreateElement("Evento");
                eventoElement.SetAttribute("FechaHora", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                eventoElement.InnerText = mensaje;
                eventoElement.SetAttribute("Usuario", nombre);

                xmlDoc.DocumentElement?.AppendChild(eventoElement);
                xmlDoc.Save(rutaArchivo);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error al intentar registrar en la bitácora
                Console.WriteLine($"Error al registrar en la bitácora: {ex.Message}");
            }
        }

        private void CargarEventos()
        {
            // Limpiar el DataTable antes de cargar eventos
            dataTable.Clear();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(rutaArchivo);

                foreach (XmlNode eventoNode in xmlDoc.SelectNodes("/Bitacora/Evento"))
                {
                    string fechaHora = eventoNode.Attributes?["FechaHora"]?.Value ?? string.Empty;
                    string mensaje = eventoNode.InnerText;
                    string usuario = eventoNode.Attributes?["Usuario"]?.Value ?? string.Empty;

                    dataTable.Rows.Add(fechaHora, mensaje, usuario);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error al intentar cargar eventos desde el archivo XML
                Console.WriteLine($"Error al cargar eventos desde la bitácora: {ex.Message}");
            }
        }

        public DataTable ObtenerDataTable()
        {
            // Devolver el DataTable para enlazarlo al DataGridView
            return dataTable;
        }
    }
}
