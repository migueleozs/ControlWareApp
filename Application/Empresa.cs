using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa
    {
        public int Id { get; set; }
        public List<Cliente> clientesRegistrados { get; set; }
        public List<Venta> ventas { get; set; }
        public List<Inventario> inventario { get; set; }
        

        public void AgregarCliente(Cliente cliente)
        {
            var lista = clientesRegistrados.Where(x => x.DNI == cliente.DNI).ToList();
            if(lista.Count < 1)
            {
                var cantidadClientes = clientesRegistrados.Count;
                cliente.Id = cantidadClientes + 1;
                clientesRegistrados.Add(cliente);
            }
        }

        public void AgregarProducto(Producto producto)
        {
            var lista = inventario.Where(x => x.producto.Id == producto.Id).ToList();
            if (lista.Count < 1)
            {
                ModificarInventario(producto, 1);
            }
        }

        public void EliminarCliente(Cliente cliente)
        {
            clientesRegistrados.Remove(cliente);
        }

        public void Vender(Cliente cliente, List<Producto> producto)
        {
            if (!EsCliente(cliente))
            {
                AgregarCliente(cliente);
            }

            if (EnEfectivo(cliente.medio))
            {

                var ventaNueva = new Venta(0, producto, cliente, cliente.medio.tipo);
                ventas.Add(ventaNueva);
            }
            else
            {
                Promociones(cliente.medio);
                var importetotal = producto.Sum(x => x.Precio);
                if (!Aprobaciondepago(cliente.medio, importetotal))
                {
                    throw new Exception("No fue aprobado el pago");
                }
                var ventaNueva = new Venta(0, producto, cliente, cliente.medio.tipo);
                ventas.Add(ventaNueva);
            }

        }

        public void ModificarInventario(Producto producto, int cantidad)
        {
            var stockProducto = inventario.Where(x => x.producto == producto).FirstOrDefault();
            inventario.Remove(stockProducto);
            stockProducto.cantidad = cantidad;
            inventario.Add(stockProducto);
        }

        public Boolean EnEfectivo(Mediodepago medio)
        {
            return medio.tipo == Mediodepago.TIPO.efectivo;
        }

        public Boolean EsCliente(Cliente cliente)
        {
            return clientesRegistrados.Contains(cliente);
        }

        public void Promociones (Mediodepago medio)
        {
            
        }

        public Boolean Aprobaciondepago(Mediodepago medio, double montototal)
        {
            return true;
        }
    }
}
