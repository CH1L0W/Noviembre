﻿using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class TramiteController : Controller
    {
        // GET: Tramite
        public ActionResult Index()
        {
            List<Tramite> tramite = Tramite.GetALL();
            return View(tramite);
        }
    }
}