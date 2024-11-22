using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Componente
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        //método para obtener todos los hijos
        //IList Iterface predefinida de .NET
        public abstract IList<Componente> permisos { get; }

        //método para agregar hijos
        //public abstract void AgregarPermiso(BETipoPermiso permiso);

        //método para vacias hijos
        public abstract void VaciarPermisos();

        //propiedad Permisos, los permisos simples son estaticos.
        //public BETipoPermiso Permiso { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
