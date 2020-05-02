using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatallaDePenales.Models
{
    public class ServicioDT
    {
        public static List<DT> listaDT = new List<DT>();
       
        public List<DT> listadoDT()
        {
            return listaDT.OrderBy(o => o.nombreUsuario).ToList();
        }


        public DT obtenerDT(DT dt)
        {
            return listaDT.Find(o => o.id == dt.id);
        }

        public int generarId()
        {
            int max = 1;

            if (listaDT.Count > 0)
            {
                max = listaDT.Count() + 1;

            }

            return max;
        }

        public DT obtenerGanador()
        {
            int valorMaximo = 0;
            DT dtGanador = null;
            foreach (var DT in listaDT)
            {
                int puntajeDt = DT.calcularPuntaje();
                if (puntajeDt > valorMaximo)
                {
                    dtGanador = DT;
                    valorMaximo = puntajeDt;
                }
            }

            dtGanador.puntos = valorMaximo;
            return dtGanador;
        }

        internal void crear(DT dt, int idArquero, int idDelantero1, int idDelantero2)
        {

                ServicioJugador servicioJugador = new ServicioJugador();

                Jugador arquero = servicioJugador.obtenerJugador(idArquero);
                Jugador delantero1 = servicioJugador.obtenerJugador(idDelantero1);
                Jugador delantero2 = servicioJugador.obtenerJugador(idDelantero2);

                List<Jugador> jugadoresDelDT = new List<Jugador>();

                jugadoresDelDT.Add(arquero);
                jugadoresDelDT.Add(delantero1);
                jugadoresDelDT.Add(delantero2);

                //Asigno valores al DT
                dt.nombreUsuario = dt.nombreUsuario;
                dt.listaJugadores = jugadoresDelDT;
                dt.puntos = dt.calcularPuntaje();

                //Guardo el objeto dt en la lista
                listaDT.Add(dt);
            }
        

        public ViewModelDirectorTecnico asignarDatosAlModel(DT dtGanador, ViewModelDirectorTecnico modelDT)
        {
           
            //Guardaremos delanteros y arqueros en estas listas
            List<Jugador> arqueros = new List<Jugador>();
            List<Jugador> delanteros = new List<Jugador>();
            
            List<Jugador> miArquero = new List<Jugador>(); //lista para quedarme con mi arquero
            List<Jugador> misDelanteros = new List<Jugador>(); //lista aparte para quedarme con mis delanteros

            //Asigno todos los jugadores mios a ambas listas por igual para despues remover
            arqueros = dtGanador.listaJugadores;
            delanteros = dtGanador.listaJugadores;

            ServicioJugador servicioJugador = new ServicioJugador();

            //Agrego a la lista aparte los delanteros 
            foreach (var item in arqueros)
            {
                if(item is Delantero)
                {
                    misDelanteros.Add(item);
                }
            }

            //Agrego a la lista aparte los arqueros 
            foreach (var item in delanteros)
            { 
                if (item is Arquero)
                {
                    miArquero.Add(item);
                }
            }

            //Asigno el objeto DT al view Model
            modelDT.directorTecnico = dtGanador;
            modelDT.arqueros = miArquero;
            modelDT.delantero = misDelanteros;
            modelDT.puntos = dtGanador.calcularPuntaje();

            return modelDT;
        }
    }
}