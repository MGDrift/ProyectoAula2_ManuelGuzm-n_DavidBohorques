﻿using System.Web;
using System.Web.Mvc;

namespace ProyectoAula2_ManuelGuzmán_DavidBohorques
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
