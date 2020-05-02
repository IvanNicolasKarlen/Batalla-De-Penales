using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatallaDePenales.Models
{
	public class DT : IPuntuar
	{
		public int id { get; set; }
		public string nombreUsuario { get; set; }
		public List<Jugador> listaJugadores { get; set; }
		public int puntos { get; set; }

		public DT()
		{
			listaJugadores = new List<Jugador>();
		}

		/*public int calcularPuntaje(DT dt) //Metodo mio: funciona -> usado en: linea 48 y 165 servicioDT
		{
			ServicioDT servicioDT = new ServicioDT();
			int total = 0;
			//Guardar los jugadores del dt
			List<Jugador> jugadoresDelDt = new List<Jugador>();


			foreach (var item in dt.listaJugadores)
			{
				jugadoresDelDt.Add(item);
			}



			//[Puntos batalla de los penales] = [Puntos de arquero] + [Puntos de delantero1] + [Puntos de delantero2]
			foreach (var item in jugadoresDelDt)
			{
				total += item.calcularPuntaje();	
			}

			return total;
		}
		*/


		public int calcularPuntaje()
		{
			//[Puntos batalla de los penales] = [Puntos de arquero] + [Puntos de delantero1] + [Puntos de delantero2]
			int puntajeTotal = 0;
			foreach (Jugador jug in listaJugadores)
			{
				puntajeTotal += jug.calcularPuntaje();
			}

			//forma resumida usando la expresion lambda Sum
			//int puntajeTotal = Jugadores.Sum(o => o.CalcularPuntaje());

			return puntajeTotal;
		}


	}
}