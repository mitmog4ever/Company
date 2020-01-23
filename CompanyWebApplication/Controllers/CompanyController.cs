using BLL;
using Common.DtoModels;
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

            VMListeCat vmListCat = new VMListeCat { lisCat = BusComp.GetListeCategorieDto(page,size,false) };
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
            ViewBag.TotalPages = BusComp.totalDeprt / size;
            return View(vmListDeprt);
        }
        public ActionResult DeleteEmp(int id)
        {
            BusComp.deleteEmployee(id);
            TempData["SuccessMessageEmp"] = "Done";
            return RedirectToAction("ListeEmp");
        }
        
        public ActionResult RedirectToAjouterOrModifierDeprt()
        {
            VMListeDeprt vmDeprt = new VMListeDeprt
            {
                listCat = BusComp.GetListeCategorieDto(0, 0, true)
            };
            return View("AjouterOrModifierDeprt", vmDeprt);
        }
        [HttpPost]
        public ActionResult AjouterOrModifierDeprt (VMListeDeprt vmDeprt)
        {
            if (ModelState.IsValid)
            {
                DtoDepartement dtoDeprt = new DtoDepartement();
                if (vmDeprt.id_dep != 0)
                {
                    dtoDeprt.id_dep = vmDeprt.id_dep;
                    dtoDeprt.nom_dep = vmDeprt.nom_dep ;
                    dtoDeprt.description_dep = vmDeprt.description_dep;
                    dtoDeprt.Date_creat = vmDeprt.Date_creat;
                    dtoDeprt.id_cat = vmDeprt.id_cat;
                    BusComp.ModifierDepartement(dtoDeprt);
                }
                else
                {
                    dtoDeprt.id_dep = vmDeprt.id_dep;
                    dtoDeprt.nom_dep = vmDeprt.nom_dep;
                    dtoDeprt.description_dep = vmDeprt.description_dep;
                    dtoDeprt.Date_creat = vmDeprt.Date_creat;
                    dtoDeprt.id_cat = vmDeprt.id_cat;
                    BusComp.AjouterDepartement(dtoDeprt);
                }
            }           
            return RedirectToAction("ListeDeprt");
        }
    }
}