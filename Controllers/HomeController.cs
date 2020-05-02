using BatallaDePenales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BatallaDePenales.Controllers
{
    public class HomeController : Controller
    {
        ServicioJugador servicioJugador = new ServicioJugador();
        ServicioDT servicioDT = new ServicioDT();
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarDelantero()
        {
           return View();
        }

        [HttpPost]
        public ActionResult GuardarDelantero(Delantero delantero)
        {
            servicioJugador.crear(delantero);
            return View("Index");
        }

        public ActionResult AgregarArquero()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarArquero(Arquero arquero)
        {
            servicioJugador.crear(arquero);
            return View("Index");
        }

        public ActionResult AgregarDt()
        {
            //obtengo todos los arqueros y aparte los delanteros para que el dt elija cual quiere
            List<Jugador> listadoArqueros = servicioJugador.obtenerArqueros();
            List<Jugador> listadoDelanteros = servicioJugador.obtenerDelanteros();

            //Uso View Model para pasarlos a la vista
            ViewModelDirectorTecnico modelDT = new ViewModelDirectorTecnico();
            
            modelDT.arqueros = listadoArqueros;
            modelDT.delantero = listadoDelanteros;

            return View(modelDT);
        }

        [HttpPost]
        public ActionResult GuardarDt(DT dt) 
        {
            Int32.TryParse(Request["idArquero"], out int idArquero);
            Int32.TryParse(Request["idDelantero1"], out int idDelantero1);
            Int32.TryParse(Request["idDelantero2"], out int idDelantero2);

            servicioDT.crear(dt, idArquero, idDelantero1, idDelantero2); 

            return View("Index");
        }


        public ActionResult ListarDT()
        {
            var listadoDT = servicioDT.listadoDT();
            
            return View(listadoDT);
        }


        public ActionResult Ganador()
        {
            DT dtGanador = servicioDT.obtenerGanador();

            ViewModelDirectorTecnico modelDT = new ViewModelDirectorTecnico();

            modelDT = servicioDT.asignarDatosAlModel(dtGanador, modelDT);
            return View(modelDT);
        }
    }
}
