using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class MunicipioController : Controller
    {
        // GET: Municipio
        public ActionResult Index()
        {
            List<Municipio> municipio = Municipio.GetALL();
            return View(municipio);
        }
    }
}