using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace AccesoData
{
    public class RepositorioVentas : IRepositorio<Venta>
    {
        public XmlTextWriter archivoxml;
        private XDocument xmlDocument;
        private string filePath;

        public RepositorioVentas(string nameFile)
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
            XDocument nuevoDocumento = new XDocument(new XElement("Ventas"));
            nuevoDocumento.Save(filePath);
        }

        public void GuardarVenta(Venta venta)
        {

            venta.Id = ObtenerUltimoIdVenta();
            XElement nuevaVenta = new XElement("Venta",
                new XElement("Id", venta.Id),
                new XElement("ProductosVendidos", 
                
                venta.productosVendidos.Select(product => new XElement("Producto", 
                new XElement ("Id",product.Id),
                new XElement ("Nombre",product.Nombre),
                new XElement("Precio", product.Precio),
                new XElement ("Descripcion",product.Descripcion)
                ) )),
                new XElement("CostoTotal", venta.CostoTotal),
                new XElement("Comprador", 
                new XElement ("Id",venta.Comprador.Id),
                new XElement ("Nombre", venta.Comprador.Nombre),
                new XElement ("Apellido", venta.Comprador.Apellido),
                new XElement("DNI", venta.Comprador.DNI),
                new XElement("Telefono", venta.Comprador.Telefono),
                new XElement("Email", venta.Comprador.Email)
                ),
                new XElement("Mediodepago", venta.tipomediodepago.ToString())
                );
            xmlDocument.Root.Add(nuevaVenta);
            xmlDocument.Save(filePath);
        }

        public List<Venta> MostrarVentas()
        {
            var mediodepago = new Mediodepago();
            List<Venta> ventas = xmlDocument.Descendants("Venta").Select(venta => new Venta
                (
                int.Parse(venta.Element("Id").Value),
                venta.Element("ProductosVendidos").Elements("Producto").Select(producto => new Producto()
                {
                    Id = int.Parse(producto.Element("Id").Value),
                    Nombre = producto.Element("Nombre").Value,
                    Descripcion = producto.Element("Descripcion").Value,
                    Precio = double.Parse(producto.Element("Precio").Value)
                }).ToList(),
                new Cliente
                {
                    Id = int.Parse(venta.Element("Comprador").Element("Id").Value),
                    Nombre = venta.Element("Comprador").Element("Nombre").Value,
                    DNI = int.Parse(venta.Element("Comprador").Element("DNI").Value),
                    Apellido = venta.Element("Comprador").Element("Apellido").Value,
                    Email = venta.Element("Comprador").Element("Email").Value,
                    Telefono = int.Parse(venta.Element("Comprador").Element("Telefono").Value)
                },
                 mediodepago.GetTIPO(venta.Element("Mediodepago").Value)
                )
            ).ToList();

            return ventas;
        }

        public int ObtenerUltimoIdVenta()
        {
            var listaVentas = MostrarVentas().ToList();
            if (listaVentas.Count == 0)
            {
                return 1;
            }
            else
            {
                return listaVentas.Max(c => c.Id) + 1;
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
