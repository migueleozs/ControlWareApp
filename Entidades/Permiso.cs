using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permiso : PermisosComponente
    {
        public string nombre;
        public bool acceso;

        public Permiso (string nombre, bool acceso)
        {
            this.nombre = nombre;
            this.acceso = acceso;
        }

        public override string ObtenerNombre()
        {
            return nombre;
        }

        public override bool TieneAcceso()
        {
            return acceso;
        }
    }
}
