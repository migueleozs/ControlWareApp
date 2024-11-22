using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inventario
    {
        public int id { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public bool activo { get; set; }

        public Inventario (int id, Producto producto, int cantidad, bool activo)
        {
            this.id = id;
            this.producto = producto;
            this.cantidad = cantidad;
            this.activo = activo;
        }

        public Inventario (Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }
    }
}
