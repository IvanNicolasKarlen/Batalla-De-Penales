using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatallaDePenales.Models
{
    public class ViewModelDirectorTecnico
    {
        public string nombreUsuario { get; set; }
        public List<Jugador> arqueros { get; set; }
        public List<Jugador> delantero { get; set; }

        public DT directorTecnico { get; set; }
        public int puntos { get; set; }
    }
}