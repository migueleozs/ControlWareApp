using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AccesoData
{
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        public XmlTextWriter archivoxml;
        private XDocument xmlDocument;
        private string filePath;


        public RepositorioCliente(string nameFile)
        {
            
            try
            {
                this.filePath = nameFile;
                if (!File.Exists(filePath))
                {
                    CrearArchivoInicial();
                }
                xmlDocument = XDocument.Load(filePath);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void CrearArchivoInicial()
        {
            XDocument nuevoDocumento = new XDocument(new XElement("Clientes"));
            nuevoDocumento.Save(filePath);
        }

        public void GuardarCliente(Cliente cliente)
        {

            cliente.Id = ObtenerUltimoIdCliente();
            XElement nuevoCliente = new XElement("Cliente",
                new XElement("Id", cliente.Id),
                new XElement("DNI", cliente.DNI),
                new XElement("Nombre", cliente.Nombre),
                new XElement("Apellido", cliente.Apellido),
                new XElement("Email", cliente.Email),
                new XElement("Telefono", cliente.Telefono)
                );
            xmlDocument.Root.Add(nuevoCliente);
            xmlDocument.Save(filePath);
        }

        public List<Cliente> MostrarClientes()
        {
            var clientes = xmlDocument.Descendants("Cliente").Select(cliente => new Cliente
            {
                Id = int.Parse(cliente.Element("Id").Value),
                DNI = int.Parse(cliente.Element("DNI").Value),
                Nombre = cliente.Element("Nombre").Value,
                Apellido = cliente.Element("Apellido").Value,
                Email = cliente.Element("Email").Value,
                Telefono = int.Parse(cliente.Element("Telefono").Value)
            }).ToList();

            return clientes;
        }

        public Cliente ConsultarClientexDNI(int DNI)
        {
            XElement Cliente = xmlDocument.Descendants("Cliente").FirstOrDefault(cliente => int.Parse(cliente.Element("DNI").Value) == DNI);

            if (Cliente != null)
            {
                return new Cliente
                {
                    Id = int.Parse(Cliente.Element("Id").Value),
                    DNI = int.Parse(Cliente.Element("DNI").Value),
                    Nombre = Cliente.Element("Nombre").Value,
                    Apellido = Cliente.Element("Apellido").Value,
                    Email = Cliente.Element("Email").Value,
                    Telefono = int.Parse(Cliente.Element("Telefono").Value)
                };
            }
            return null;
        }

        public int ObtenerUltimoIdCliente()
        {
            var listaClientes = MostrarClientes().ToList();
            // Verifica si la lista de clientes está vacía
            if (listaClientes.Count == 0)
            {
                // Si la lista está vacía, devuelve 1 como nuevo ID
                return 1;
            }
            else
            {
                // Si la lista no está vacía, obtén el ID del último cliente y suma 1
                return listaClientes.Max(c => c.Id) + 1;
            }
        }

        public void addItems()
        {
            throw new NotImplementedException();
        }

        public void getItems()
        {
            throw new NotImplementedException();
        }
        public void removeItems()
        {
            throw new NotImplementedException();
        }

        public void updateItems()
        {
            throw new NotImplementedException();
        }

        public void EliminarCliente(Cliente clienteEscogido)
        {
            // Ruta del archivo XML
            string rutaArchivo = "Clientes.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rutaArchivo);



            string xpath = $"/Clientes/Cliente[Id='{clienteEscogido.Id}']";
            XmlNode nodoCliente = xmlDoc.SelectSingleNode(xpath);

            if (nodoCliente != null)
            {
                nodoCliente.ParentNode.RemoveChild(nodoCliente);

                xmlDoc.Save(rutaArchivo);

                Console.WriteLine("Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}
