using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApPBeneficiarios.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult CreateGenero()
        {
            return View();
        }

        public ActionResult GetAllGeneros()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CreateBenficiario()
        {
            return View();
        }

        public ActionResult GetAllBeneficiarios()
        {
            return View();

        }
    }
}