using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace AccesoData
{
    public class RepositorioInventario : IRepositorio<Inventario>
    {
        public XmlTextWriter archivoxml;
        private XDocument xmlDocument;
        private string filePath;


        public RepositorioInventario(string nameFile)
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
            XDocument nuevoDocumento = new XDocument(new XElement("Inventarios"));
            nuevoDocumento.Save(filePath);
        }

        public void CrearInventario(Inventario inventario)
        {
            inventario.id = ObtenerUltimoIdInventario();
            XElement nuevoInventario = new XElement("Inventario",
                new XElement("Id", inventario.id),
                new XElement("Producto", new XElement("Id", inventario.producto.Id) , new XElement("Nombre", inventario.producto.Nombre), new XElement("Descripcion", inventario.producto.Descripcion)) ,
                new XElement("Cantidad", inventario.cantidad),
                new XElement("Activo", inventario.activo)
                );
            xmlDocument.Root.Add(nuevoInventario);
            xmlDocument.Save(filePath);
        }

        public void getItems()
        {
            throw new NotImplementedException();
        }
        
        public List<Inventario> MostrarInventario()
        {
            var inventarios = xmlDocument.Descendants("Inventario").Select(inventario => new Inventario
            (
                int.Parse(inventario.Element("Id").Value),
                new Producto
                {
                    Id = int.Parse(inventario.Element("Producto").Element("Id").Value),
                    Nombre = inventario.Element("Producto").Element("Nombre").Value,
                    Descripcion = inventario.Element("Producto").Element("Descripcion").Value
                },
                int.Parse(inventario.Element("Cantidad").Value),
                bool.Parse(inventario.Element("Activo").Value)
            )
            ).ToList();

            return inventarios;
        }
        
        public int ObtenerUltimoIdInventario()
        {
            var listaInventario = MostrarInventario().ToList();
            // Verifica si la lista de clientes está vacía
            if (listaInventario.Count == 0)
            {
                // Si la lista está vacía, devuelve 1 como nuevo ID
                return 1;
            }
            else
            {
                // Si la lista no está vacía, obtén el ID del último cliente y suma 1
                return listaInventario.Max(c => c.id) + 1;
            }
        }
        
        public void addItems()
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
