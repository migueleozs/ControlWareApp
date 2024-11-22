using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Encriptacion

    {

        public static string EncriptarClave(string rawData)

        {

            byte[] encryted = Encoding.Unicode.GetBytes(rawData);

            string result = Convert.ToBase64String(encryted);

            return result;

        }



        public static string Desencriptar(this string _cadenaAdesencriptar)

        {

            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);

            string result = Encoding.Unicode.GetString(decryted);

            return result;

        }

    }
}
