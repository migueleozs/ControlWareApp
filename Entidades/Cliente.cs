using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public Mediodepago medio { get; set; }

        public Cliente (int dNI, string nombre, string apellido, string email, int telefono)
        {
            DNI = dNI;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
        }

        public Cliente()
        {
        }
    }
}
