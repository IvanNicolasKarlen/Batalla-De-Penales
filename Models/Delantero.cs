using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatallaDePenales.Models
{
    public class Delantero : Jugador
    {
        public int penalesConvertidos { get; set; }
        
        public override int calcularPuntaje()
        {
            // (*)[Puntos de delantero] = [Cant de penales convertidos] * 75
            // (*) Si el jugador fue expulsado se debe restar 50 puntos

            int puntos = penalesConvertidos * Jugador.PUNTAJE_CONVERTIDO;

            if(expulsado)
            {
                puntos -= Jugador.PUNTAJE_EXPULSADO; 
            }

            return puntos;

        }
    }
}