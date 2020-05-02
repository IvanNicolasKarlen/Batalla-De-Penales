using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatallaDePenales.Models
{
    public class Arquero : Jugador
    {
    
        public int penalesAtajados { get; set; }


        public override int calcularPuntaje()
        {
            //(*)[Puntos de arquero] = [Cant de penales atajados] * 100
            //(*) Si el jugador fue expulsado se debe restar 50 puntos

            int resultado = penalesAtajados * Jugador.PUNTAJE_ATAJADOS;

            if(expulsado)
            {
                resultado -= Jugador.PUNTAJE_EXPULSADO;
            }

            // Otra forma de hacer el if
            //int total = resultado - (expulsado ? Jugador.PUNTAJE_EXPULSADO : 0);

            return resultado;
        }

    }
}