using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAula2_ManuelGuzmán_DavidBohorques.Models
{
    public class EPSInfo
    {
        private string nombre;
        private double costosTotal;
        private double porcentajeTotal;
        public EPSInfo(string nombre, double costosTotal, double porcentajeTotal)
        {
            this.Nombre = nombre;
            this.CostosTotal = costosTotal;
            this.PorcentajeTotal = porcentajeTotal;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double CostosTotal { get => costosTotal; set => costosTotal = value; }
        public double PorcentajeTotal { get => porcentajeTotal; set => porcentajeTotal = value; }
    }
}