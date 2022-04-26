using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAula2_ManuelGuzmán_DavidBohorques.Models
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        private DateTime fechaIngresoSistemaSalud;
        private DateTime fechaIngresoEPS;
        private int edad;
        private string tipoAfiliacion;
        private string regimen;
        private int mesesEps;
        private int id;
        private int numeroEnfermedades;
        private double costosTratamiento;
        private string enfermedadRelevante;
        private string EPS;

        public Persona()
        {
            this.nombre = "";
            this.apellido = "";
            this. id = 0;
        }

        public Persona(string nombre, string apellido, DateTime fechaNacimiento, DateTime fechaIngresoSistemaSalud, DateTime fechaIngresoEPS, int edad, string tipoAfiliacion, string regimen, int mesesEps, int id, int numeroEnfermedades, double costosTratamiento, string enfermedadRelevante, string ePS)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaIngresoSistemaSalud = fechaIngresoSistemaSalud;
            this.FechaIngresoEPS = fechaIngresoEPS;
            this.Edad = edad;
            this.TipoAfiliacion = tipoAfiliacion;
            this.Regimen = regimen;
            this.MesesEps = mesesEps;
            this.Id = id;
            this.NumeroEnfermedades = numeroEnfermedades;
            this.CostosTratamiento = costosTratamiento;
            this.EnfermedadRelevante = enfermedadRelevante;
            EPS1 = ePS;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public DateTime FechaIngresoSistemaSalud { get => fechaIngresoSistemaSalud; set => fechaIngresoSistemaSalud = value; }
        public DateTime FechaIngresoEPS { get => fechaIngresoEPS; set => fechaIngresoEPS = value; }
        public int Edad { get => edad; set => edad = value; }
        public string TipoAfiliacion { get => tipoAfiliacion; set => tipoAfiliacion = value; }
        public string Regimen { get => regimen; set => regimen = value; }
        public int MesesEps { get => mesesEps; set => mesesEps = value; }
        public int Id { get => id; set => id = value; }
        public int NumeroEnfermedades { get => numeroEnfermedades; set => numeroEnfermedades = value; }
        public double CostosTratamiento { get => costosTratamiento; set => costosTratamiento = value; }
        public string EnfermedadRelevante { get => enfermedadRelevante; set => enfermedadRelevante = value; }
        public string EPS1 { get => EPS; set => EPS = value; }
    }

    public class Afiliados
    {

    }
}