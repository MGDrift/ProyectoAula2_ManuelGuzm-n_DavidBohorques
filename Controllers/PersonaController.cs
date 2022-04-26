using ProyectoAula2_ManuelGuzmán_DavidBohorques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAula2_ManuelGuzmán_DavidBohorques.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona

        static List<Persona> personaList = new List<Persona>();
        
        public ActionResult Index()
        {
            return View();
        }

        private Persona CreatePersona()
        {
            string nombre, apellido, tipoAfiliacion, regimen, enfermedadRelevante, EPS;
            int edad, mesesEPS, id, numeroEnfermedades;
            DateTime fechaNacimiento, fechaIngresoSistemaSalud, fechaIngresoEPS;
            double costosTratamiento;

            nombre = Request.Form["nombre"].ToString();
            apellido = Request.Form["apellido"].ToString();
            fechaNacimiento = Convert.ToDateTime(Request.Form["fechaNacimiento"]);
            fechaIngresoSistemaSalud = Convert.ToDateTime(Request.Form["fechaIngresoSistemaSalud"]);
            fechaIngresoEPS = Convert.ToDateTime(Request.Form["fechaIngresoEPS"]);
            edad = Convert.ToInt32(Request.Form["edad"]);
            tipoAfiliacion = Request.Form["tipoAfiliacion"].ToString();
            regimen = Request.Form["regimen"].ToString();
            mesesEPS = Convert.ToInt32(Request.Form["mesesEPS"]);
            id = Convert.ToInt32(Request.Form["id"]);
            numeroEnfermedades = Convert.ToInt32(Request.Form["numeroEnfermedades"]);
            costosTratamiento = Convert.ToDouble(Request.Form["costosTratamiento"]);
            enfermedadRelevante = Request.Form["enfermedadRelevante"].ToString().ToUpper();
            EPS = Request.Form["EPS"].ToString();

            return new Persona(nombre, apellido, fechaNacimiento, fechaIngresoSistemaSalud,
                fechaIngresoEPS, edad, tipoAfiliacion, regimen, mesesEPS, id, numeroEnfermedades, costosTratamiento, enfermedadRelevante, EPS);
        }

        private ActionResult PersonaExist()
        {
            if (Request.Form["id"] != null && personaList.Exists(p => p.Id == Convert.ToInt32(Request.Form["id"])))
            {
                TempData["ErrorMessage"] = "<script>alert('Esta persona ya está afiliada.');</script>";
                return View("Index");
            }
            return new EmptyResult();
        }

        public ActionResult Persona()
        {
            PersonaExist();
            try
            {
                personaList.Add(CreatePersona());
                ViewBag.Personas = personaList;
                Session["Personas"] = personaList;
                return View();
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = "<script>alert('Debes llenar todo el formulario.');</script>";
                return View("Index");
            }
        }
    }
}