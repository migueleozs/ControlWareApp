using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sesion
    {
        // public string rol { get; set; }
        public bool logueado { get; set; }
        public string nombre { get; set; }
        public List<Permiso> items { get; set; }
        public Rol rol { get; set; }

        public Sesion()
        {

        }

        public Sesion(List<Permiso> items, string nombre, Rol rol)
        {
            this.items = items;
            this.nombre = nombre;
            this.rol = rol;
            logueado = true;
        }

        public Sesion(string nombre, Rol rolito)
        {
            this.nombre = nombre;
            rol = rolito;
            logueado = true;
        }

        public void Desloguearse()
        {
            logueado = false;
        }


    }
}
