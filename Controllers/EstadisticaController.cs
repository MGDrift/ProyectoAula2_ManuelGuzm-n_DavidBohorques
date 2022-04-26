using ProyectoAula2_ManuelGuzmán_DavidBohorques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAula2_ManuelGuzmán_DavidBohorques.Controllers
{
    public class EstadisticaController : Controller
    {
        private EPSInfo CreateEPSInfo(string nombreEPS)
        {
            List<Persona> listaAfiliados = Session["Personas"] as List<Persona>;
            var totalCostos = listaAfiliados.Sum(x => x.CostosTratamiento);
            var listaEps = listaAfiliados.Where(x => x.EPS1 == nombreEPS);
            if (listaEps.Count() == 0)
            {
                return new EPSInfo(nombreEPS, 0, 0);
            }
            else
            {
                var costosEps = listaEps.Sum(x => x.CostosTratamiento);
                var porcentajeEps = (costosEps * 100) / totalCostos;
                return new EPSInfo(nombreEPS, costosEps, porcentajeEps);
            }
        }
        public ActionResult Index()
        {
            List<EPSInfo> epsInfo = new List<EPSInfo>();
            epsInfo.Add(CreateEPSInfo("Sura"));
            epsInfo.Add(CreateEPSInfo("Nueva EPS"));
            epsInfo.Add(CreateEPSInfo("Salud Total"));
            epsInfo.Add(CreateEPSInfo("Sanitas"));
            epsInfo.Add(CreateEPSInfo("Savia"));

            ViewBag.EPSs = epsInfo;

            return View();
        }

        public ActionResult Info()
        {
            List<Persona> listaAfiliados = Session["Personas"] as List<Persona>;
            ViewBag.PorcetajeSanos = 0;
            ViewBag.AfiliadoMasCostoso = new Persona();
            ViewBag.TotalPacientesCancer = 0;
            ViewBag.PorcentajeSubsidiado = 0;
            ViewBag.PorcentajeContributivo = 0;
            ViewBag.PorcentajeCotizante = 0;
            ViewBag.PorcentajeBeneficiario = 0;
            ViewBag.Niños = 0;
            ViewBag.Adolecentes = 0;
            ViewBag.Joven = 0;
            ViewBag.Adulto = 0;
            ViewBag.AdultoMayor = 0;
            ViewBag.Anciano = 0;

            if (listaAfiliados != null)
            {
                int cantidadAfiliados = listaAfiliados.Count();
                int cantidadSinEnfermedades = listaAfiliados.Where(p => p.NumeroEnfermedades == 0).Count();
                ViewBag.PorcetajeSanos = (cantidadSinEnfermedades * 100) / cantidadAfiliados;
                ViewBag.AfiliadoMasCostoso = listaAfiliados.OrderByDescending(p => p.CostosTratamiento).First();
                ViewBag.TotalPacientesCancer = listaAfiliados.Where(p => p.EnfermedadRelevante == "CANCER").Count();

                var cantidadSubsidiados = listaAfiliados.Where(x => x.Regimen == "Subsidiado").Count();
                ViewBag.PorcentajeSubsidiado = (cantidadSubsidiados * 100) / cantidadAfiliados;
                var cantidadContributivo = listaAfiliados.Where(x => x.Regimen == "Contributivo").Count();
                ViewBag.PorcentajeContributivo = (cantidadContributivo * 100) / cantidadAfiliados;

                var cantidadCotizante = listaAfiliados.Where(x => x.TipoAfiliacion == "Cotizante").Count();
                ViewBag.PorcentajeCotizante = (cantidadCotizante * 100) / cantidadAfiliados;
                var cantidadBeneficiario = listaAfiliados.Where(x => x.TipoAfiliacion == "Beneficiario").Count();
                ViewBag.PorcentajeBeneficiario = (cantidadBeneficiario * 100) / cantidadAfiliados;

                ViewBag.Niños = (listaAfiliados.Where(x => x.Edad < 12).Count() * 100) / cantidadAfiliados;
                ViewBag.Adolecentes = (listaAfiliados.Where(x => 12 <= x.Edad && x.Edad < 18).Count() * 100) / cantidadAfiliados;
                ViewBag.Joven = (listaAfiliados.Where(x => 18 <= x.Edad && x.Edad < 30).Count() * 100) / cantidadAfiliados;
                ViewBag.Adulto = (listaAfiliados.Where(x => 30 <= x.Edad && x.Edad < 55).Count() * 100) / cantidadAfiliados;
                ViewBag.AdultoMayor = (listaAfiliados.Where(x => 55 <= x.Edad && x.Edad < 75).Count() * 100) / cantidadAfiliados;
                ViewBag.Anciano = (listaAfiliados.Where(x => x.Edad > 75).Count() * 100) / cantidadAfiliados;
            }
            return View();
        }
    }
}
