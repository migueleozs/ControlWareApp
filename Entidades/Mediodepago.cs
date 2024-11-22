using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mediodepago
    {
        public int id;
        public TIPO tipo ; 
        public string descripcion;
        public double monto;


        public enum TIPO { efectivo, debito, credito }

        public Mediodepago()
        {

        }

        public Mediodepago(string descrip, double costo, TIPO tipe)
        {
            descripcion = descrip;
            monto = costo;
            tipo = tipe;
        }

        public TIPO GetTIPO(string tipo)
        {
            if (tipo == "efectivo")
            {
                return TIPO.efectivo;
            }
            else if(tipo == "debito")
            {
                return TIPO.debito;
            }
            else if(tipo == "credito")
            {
                return TIPO.credito;
            }
            return TIPO.efectivo;
        }
    }
}
