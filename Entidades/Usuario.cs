using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string _rol { get; set; }
        public Rol rol { get; set; }

        public Usuario(string rol)
        {
            _rol = rol;
        }
        public Usuario(int id, string tipo, string nombre, string password)
        {
            Id = id;
            _rol = tipo;
            Nombre = nombre;
            Password = password;
        }


        public Usuario()
        {

        }
        public string ObtenerTipo()
        {
            return rol.ObtenerNombre();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            throw new NotImplementedException("No se puede agregar un usuario");
        }




        /*

        List<Componente> _permisos;


        //Intancio la lista de componentes q puede tener el usuario puer ser familia o patentes
        public Usuario()
        {
            _permisos = new List<Componente>();
        }

        //SOlo se lee los permisos que posee el Usuario
        public List<Componente> Permisos
        {
            get
            {
                return _permisos;
            }
        }

        public override string ToString()
        {
            return Nombre;
        }
        */
    }
}
