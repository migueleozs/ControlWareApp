using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Entidades
{
    public class UsuarioCompuesto
    {

        private readonly List<Usuario> _usuarios = new List<Usuario>();

        private readonly string _tipo;
        

        public UsuarioCompuesto()
        {
        }

        public UsuarioCompuesto(string tipo)
        {
            _tipo = tipo;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public string ObtenerTipo()
        {
            return _tipo;
        }

        public List<Usuario> ListaUsuarios()
        {
            return _usuarios;
        }

    }
}
