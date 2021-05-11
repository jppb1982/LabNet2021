using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using EFCapaLogica;
using PagedList;

namespace EFMVC.Controllers
{
    public class PaisController : Controller
    {
        // GET: Pais
        public ActionResult Index(int? page)
        {
            try
            {
                LogicaPais logica = new LogicaPais();

                List<Countries> paises = logica.ObtenerPaisesPorIdioma("es");

                int pageSize = 10;
                int pageNumber = page ?? 1;

                return View(paises.ToPagedList(pageNumber, pageSize));
            }
            catch (ExcepcionPersonalizadaMVC ep)
            {
                TempData["errorMessage"] = "Error: " + ep.Message;
                return RedirectToAction("Index", "Error");
            }
        }

    }

}
