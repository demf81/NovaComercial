﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Controllers
{
    public class RadioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public static List<Models.RadioModel> RadioList(string _metodo)
        {
            List<Models.RadioModel> items = new List<Models.RadioModel>();

            if (_metodo == "EstatusBusqueda")
            {
                items.Add(
                    new Models.RadioModel
                    {
                        Id   = 0,
                        Name = "Activo",
                    }
                );

                items.Add(
                    new Models.RadioModel
                    {
                        Id   = 1,
                        Name = "Inactivo"
                    }
                );

                items.Add(
                    new Models.RadioModel
                    {
                        Id   = -1,
                        Name = "Todos"
                    }
                );
            }

            return items;
        }
    }
}
