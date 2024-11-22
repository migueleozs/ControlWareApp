using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol : PermisosComponente
    {
        private string nombre;

        public List<Permiso> _permisos = new List<Permiso>();

        public Rol(string nombre)
        {
            this.nombre = nombre;
        }

        public Rol(string nombre, List<Permiso> permisos) : this(nombre)
        {
            _permisos = permisos;
        }   

        public override string ObtenerNombre()
        {
            return nombre;
        }

        public override bool TieneAcceso()
        {
            foreach (var item in _permisos)
            {
                if (!item.TieneAcceso())
                {
                    return false;
                }
            }
            return true;
        }

        public void AgregarPermiso(Permiso permiso)
        {
            _permisos.Add(permiso);
        }

        public void RemoverPermiso(Permiso permiso)
        {
            _permisos.Remove(permiso);
        }
    }
}
