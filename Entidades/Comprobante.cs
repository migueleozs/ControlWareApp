using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comprobante
    {
        public int Id { get; set; }
        public List<Producto> Items { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }


    }
}
