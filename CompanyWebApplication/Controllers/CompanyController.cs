using BLL;
using CompanyWebApplication.Models;
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
        public ActionResult Index(int? page = 0,int size=5)
        {
            var BusComp = new BusinessCompany();
            VMIndex vmIndex = new VMIndex { lisCat = BusComp.GetListeCategorieDto(page*size) };
            ViewBag.CuerrentPage = page;
            ViewBag.TotalPages = BusComp.totalCat / size;
            return View(vmIndex);
        }
    }
}