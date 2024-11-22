using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public List<Producto> productosVendidos { get; set; }
        public double CostoTotal { get; set; }
        public Cliente Comprador { get; set; }
        public Mediodepago.TIPO tipomediodepago { get; set; }

        public Venta()
        {

        }

        public Venta(int id, List<Producto> productosVendidos, Cliente comprador, Mediodepago.TIPO tipopago)
        {
            Id = id;
            this.productosVendidos = productosVendidos;
            CostoTotal = productosVendidos.Sum(x => x.Precio);
            Comprador = comprador;
            tipomediodepago = tipopago;
        }
    }
}
