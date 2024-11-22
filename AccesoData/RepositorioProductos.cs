using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AccesoData
{
    public class RepositorioProductos : IRepositorio<Producto>
    {
        public XmlTextWriter archivoxml;
        private XDocument xmlDocument;
        private string filePath;


        public RepositorioProductos(string nameFile)
        {
            this.filePath = nameFile;
            if (!File.Exists(filePath))
            {
                CrearArchivoInicial();
            }
            xmlDocument = XDocument.Load(filePath);
        }

        public void CrearArchivoInicial()
        {
            XDocument nuevoDocumento = new XDocument(new XElement("Productos"));
            nuevoDocumento.Save(filePath);
        }

        public void CrearProducto(Producto producto)
        {
            producto.Id = ObtenerUltimoIdProducto();
            XElement nuevoProducto = new XElement("Producto",
                new XElement("Id", producto.Id),
                new XElement("Nombre", producto.Nombre),
                new XElement("Descripcion", producto.Descripcion),
                new XElement("Precio", producto.Precio)
                );
            xmlDocument.Root.Add(nuevoProducto);
            xmlDocument.Save(filePath);
        }

        public List<Producto> MostrarProductos()
        {
            var productos = xmlDocument.Descendants("Producto").Select(producto => new Producto
            {
                Id = int.Parse(producto.Element("Id").Value),
                Nombre = producto.Element("Nombre").Value,
                Descripcion = producto.Element("Descripcion").Value,
                Precio = double.Parse(producto.Element("Precio").Value)
            }).ToList();

            return productos;
        }

        public int ObtenerUltimoIdProducto()
        {
            var listaProductos = MostrarProductos().ToList();
            // Verifica si la lista de clientes está vacía
            if (listaProductos.Count == 0)
            {
                // Si la lista está vacía, devuelve 1 como nuevo ID
                return 1;
            }
            else
            {
                // Si la lista no está vacía, obtén el ID del último cliente y suma 1
                return listaProductos.Max(c => c.Id) + 1;
            }
        }

        public Producto ConsultarProductoxId(int Id)
        {
            XElement Producto = xmlDocument.Descendants("Producto").FirstOrDefault(producto => int.Parse(producto.Element("Id").Value) == Id);

            if (Producto != null)
            {
                return new Producto
                {
                    Id = int.Parse(Producto.Element("Id").Value),
                    Precio = int.Parse(Producto.Element("Precio").Value),
                    Nombre = Producto.Element("Nombre").Value,
                    Descripcion = Producto.Element("Descripcion").Value
                };
            }
            return null;
        }

        public Producto ConsultarProductoxNombre(string nombre)
        {
            XElement Producto = xmlDocument.Descendants("Producto").FirstOrDefault(producto => producto.Element("Nombre").Value == nombre);

            if (Producto != null)
            {
                return new Producto
                {
                    Id = int.Parse(Producto.Element("Id").Value),
                    Nombre = Producto.Element("Nombre").Value,
                    Descripcion = Producto.Element("Descripcion").Value,
                    Precio = int.Parse(Producto.Element("Precio").Value)
                };
            }
            return null;
        }


        public void EliminarProducto(Producto producto)
        {
            // Ruta del archivo XML
            string rutaArchivo = "Productos.xml";

            // Crear un objeto XmlDocument y cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rutaArchivo);



            string xpath = $"/Productos/Producto[Id='{producto.Id}']";
            XmlNode nodoProducto = xmlDoc.SelectSingleNode(xpath);

            if (nodoProducto != null)
            {
                // Obtener el nodo padre del usuario y eliminar el nodo del usuario
                nodoProducto.ParentNode.RemoveChild(nodoProducto);

                // Guardar los cambios en el archivo XML
                xmlDoc.Save(rutaArchivo);

                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
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

       
    }
}
