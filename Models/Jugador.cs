using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatallaDePenales.Models
{
	public abstract class Jugador : IPuntuar
	{
		//Creo constantes para usarlos en todos lados y que si se cambia el valor solo lo cambias aca y listo
		public const int PUNTAJE_EXPULSADO = 50;
		public const int PUNTAJE_ATAJADOS = 100;
		public const int PUNTAJE_CONVERTIDO = 75;
		public const string REFERENCIA_ARQUERO = "Arquero";
		public const string REFERENCIA_DELANTERO = "Delantero";
		public int id { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }
		public bool expulsado { get; set; }
		public int puntos { get; set; }
		public string rol { get; set; }


		public abstract int calcularPuntaje();

		
	}
}