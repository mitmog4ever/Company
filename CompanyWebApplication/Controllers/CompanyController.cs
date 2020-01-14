using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyWebApplication.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var BusComp = new BusinessCompany();
            var list = BusComp.GetListeCategorie();
            return View();
        }
    }
}