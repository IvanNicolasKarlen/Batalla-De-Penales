using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatallaDePenales.Models
{
    public class ServicioJugador
    {
        public static List<Jugador> listaJugador = new List<Jugador>();

        public List<Jugador> listadoJugadores()
        {
            return listaJugador;
        }

        public Jugador obtenerJugador(int id)
        {
            return listaJugador.Find(o => o.id == id);
        }


        public int generarId()
        {
            int max = 1;

            if (listaJugador.Count > 0)
            {
                max = listaJugador.Count() + 1;


                //Sino tambien asi:
                //max = listaJugador.Max(o => o.id + 1);

                /*O hacer el if asi
                 max = (listaJugador.Count > 0 ? listaJugador.Max(o => o.id + 1));
                 */
            }

            return max;
        }


        public void crear(Jugador jugador)
        {
            jugador.id = generarId();

            jugador.puntos = jugador.calcularPuntaje();

            listaJugador.Add(jugador);
        }




        //Metodo para obtener solo los arqueros y que el DT pueda elegir cual quiere
        public List<Jugador> obtenerArqueros()
        {
            //Lista de Jugadores para identificar posibles arqueros
             List<Jugador> arqueros = new List<Jugador>();

             foreach(var item in listaJugador)
            {   //Si jugador es arquero
                if(item is Arquero)
                {
                    arqueros.Add(item);
                }
            }
             //Retorno solo los "ARQUEROS"
            return arqueros;
        }

        //Metodo para obtener solo los delanteros y que el DT pueda elegir cual quiere
        public List<Jugador> obtenerDelanteros()
        {
            //Lista de Jugadores para identificar posibles delanteros
            List<Jugador> delanteros = new List<Jugador>();

            foreach (var item in listaJugador)
            {   //Si jugador es Delantero
                if (item is Delantero)
                {
                    delanteros.Add(item);
                }
            }
            //Retorno solo los "DELANTEROS"
            return delanteros;
        }
    }
}