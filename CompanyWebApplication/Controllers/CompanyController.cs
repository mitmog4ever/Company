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
        BusinessCompany BusComp = new BusinessCompany();
        // GET: Company
        public ActionResult ListeCat(int page = 0,int size=5)
        {

            VMListeCat vmListCat = new VMListeCat { lisCat = BusComp.GetListeCategorieDto(page,size) };
            ViewBag.CuerrentPage = page;
            ViewBag.TotalPages = BusComp.totalCat / size;
            return View(vmListCat);
        }
        public ActionResult ListeEmp(int page = 0, int size = 5)
        {
            VMListeEmp vmListEmp = new VMListeEmp {
                listEmp = BusComp.GetListeEmployee("", page, size),
                keyWord = ""                
            };
            ViewBag.CuerrentPage = page;
            ViewBag.TotalPages = BusComp.totalEmp / size;
            return View(vmListEmp);
        }
        public ActionResult ListeDeprt(int page = 0, int size = 5)
        {
            VMListeDeprt vmListDeprt = new VMListeDeprt
            {
                listDeprt = BusComp.GetListeDepartement( page, size)
            };
            ViewBag.CuerrentPage = page;
            ViewBag.TotalPages = BusComp.totalEmp / size;
            return View(vmListDeprt);
        }
    }
}