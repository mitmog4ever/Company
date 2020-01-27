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
        public ActionResult ListeEmp(VMListeEmp emp, int page = 0, int size = 5)
        {   if (!String.IsNullOrWhiteSpace(emp.keyWord)){
                
                emp.listEmp = BusComp.GetListeEmployee(emp.keyWord, emp.id_dep, page, size);
                emp.listDeprt = BusComp.GetListeDepartement(0, 0, true);
                DtoDepartement defaultDep = new DtoDepartement
                {
                    id_dep = 0,
                    nom_dep = " ",
                    id_cat = 0
                };

                var value01 = emp.listDeprt.First();
                emp.listDeprt[0] = defaultDep;
                emp.listDeprt.Add(value01);
                emp.keyWord = "";
            }
            else
            {
                if(emp.id_dep ==0)
                    emp.listEmp = BusComp.GetListeEmployee("", 0, page, size);
                else
                    emp.listEmp = BusComp.GetListeEmployee("", emp.id_dep, page, size);
                emp.listDeprt = BusComp.GetListeDepartement(0, 0, true);
                DtoDepartement defaultDep = new DtoDepartement
                {
                    id_dep = 0,
                    nom_dep = " ",
                    id_cat = 0
                };

                var value01 = emp.listDeprt.First();
                emp.listDeprt[0] = defaultDep;
                emp.listDeprt.Add(value01);
                emp.keyWord = "";
            }

            ViewBag.CuerrentPage = page;
            if (BusComp.totalEmp % size != 0)
                ViewBag.TotalPages = 1 + (BusComp.totalEmp / size);
            else
                ViewBag.TotalPages = (BusComp.totalEmp / size);
            return View(emp);
        }
        public ActionResult ListeDeprt(int page = 0, int size = 5)
        {
            VMListeDeprt vmListDeprt = new VMListeDeprt
            {
                listDeprt = BusComp.GetListeDepartement( page, size)
            };
            ViewBag.CuerrentPage = page;
            ViewBag.TotalPages = BusComp.totalDeprt / size;
            if (BusComp.totalDeprt % size != 0) ViewBag.TotalPages++;
            return View(vmListDeprt);
        }
        public ActionResult DeleteEmp(int id)
        {
            BusComp.deleteEmployee(id);
            TempData["SuccessMessageEmp"] = "Done";
            return RedirectToAction("ListeEmp");
        }
        public ActionResult DeleteDeprt(int id)
        {
            BusComp.deleteDepartement(id);
            TempData["SuccessMessageEmp"] = "Done";
            return RedirectToAction("ListeDeprt");
        }
        public ActionResult DeleteCat(int id)
        {
            BusComp.deleteCategorie(id);
            TempData["SuccessMessageEmp"] = "Done";
            return RedirectToAction("ListeCat");
        }

        public ActionResult RedirectToAjouterOrModifierDeprt(int? id )
        {
          
            VMListeDeprt vmDeprt = new VMListeDeprt
            {
                listCat = BusComp.GetListeCategorieDto(0, 0, true)
            };
            if (id != 0)
            {
                 
                var tempDeprt = BusComp.GetDepartement((int) id);
                vmDeprt.id_dep = tempDeprt.id_dep;
                vmDeprt.id_cat = tempDeprt.id_cat;
                vmDeprt.nom_dep = tempDeprt.nom_dep;
                vmDeprt.Date_creat = tempDeprt.Date_creat;
                vmDeprt.description_dep = tempDeprt.description_dep;
             
                var index01 = vmDeprt.listCat.FindIndex(p => p.id_cat == tempDeprt.id_cat);
                var value01 = vmDeprt.listCat.Find(p => p.id_cat == tempDeprt.id_cat);
                vmDeprt.listCat[index01] = vmDeprt.listCat.First();
                vmDeprt.listCat[0] = value01;

            }

            return View("AjouterOrModifierDeprt", vmDeprt);
        }
        public ActionResult RedirectToAjouterOrModifierCat(int? id)
        {

            VMListeCat vmCat = new VMListeCat();
            if (id != 0)
            {

                var tempCat = BusComp.GetCategorie((int)id);
                vmCat.description_cat = tempCat.description_cat;
                vmCat.id_cat= tempCat.id_cat;

            }

            return View("AjouterOrModifierCat", vmCat);
        }
        public ActionResult RedirectToAjouterOrModifierEmp(int? id)
        {

            VMListeEmp vmEmp = new VMListeEmp
            {
                listDeprt = BusComp.GetListeDepartement(0, 0, true)
            };
            if (id != 0)
            {

                var emp = BusComp.GetEmployee((int)id);
                vmEmp.id_dep = emp.id_dep;
                vmEmp.id_emp = emp.id_emp;
                vmEmp.nom_emp = emp.nom_emp;
                vmEmp.prenom_emp = emp.prenom_emp;
                vmEmp.Salaire_emp = emp.Salaire_emp;
                vmEmp.tele_emp = emp.tele_emp;
                vmEmp.date_recrute_emp = emp.date_recrute_emp;

                var index01 = vmEmp.listDeprt.FindIndex(p => p.id_dep == emp.id_dep);
                var value01 = vmEmp.listDeprt.Find(p => p.id_dep == emp.id_dep);
                vmEmp.listDeprt[index01] = vmEmp.listDeprt.First();
                vmEmp.listDeprt[0] = value01;

            }

            return View("AjouterOrModifierEmp", vmEmp);
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
                TempData["SuccessMessageDeprt"] = "Done !";
                return RedirectToAction("ListeDeprt");
            }
            else
            {

                return RedirectToAjouterOrModifierDeprt(vmDeprt.id_dep);
            }

        }
        public ActionResult AjouterOrModifierCat(VMListeCat vmCat)
        {
            if (ModelState.IsValid)
            {
                DtoCategorie dtoCat = new DtoCategorie();
                if (vmCat.id_cat != 0)
                {
                    dtoCat.id_cat = vmCat.id_cat;
                    dtoCat.description_cat = vmCat.description_cat;
                    BusComp.ModifierCategorie(dtoCat);
                }
                else
                {
                    dtoCat.id_cat = vmCat.id_cat;
                    dtoCat.description_cat = vmCat.description_cat;
                    BusComp.AjouterCategorie(dtoCat);
                }
                TempData["SuccessMessageDeprt"] = "Done !";
                return RedirectToAction("ListeCat");
            }
            else
            {

                return RedirectToAjouterOrModifierCat(vmCat.id_cat);
            }

        }
        public ActionResult AjouterOrModifierEmp(VMListeEmp vmEmp)
        {
            if (ModelState.IsValid)
            {
                DtoEmployee dtoEmp = new DtoEmployee();
                if (vmEmp.id_emp != 0)
                {
                    dtoEmp.id_dep = vmEmp.id_dep;
                    dtoEmp.id_emp = vmEmp.id_emp;
                    dtoEmp.nom_emp = vmEmp.nom_emp;
                    dtoEmp.prenom_emp = vmEmp.prenom_emp;
                    dtoEmp.Salaire_emp = vmEmp.Salaire_emp;
                    dtoEmp.tele_emp = vmEmp.tele_emp;
                    dtoEmp.date_recrute_emp = vmEmp.date_recrute_emp;
                    BusComp.ModifierEmployee(dtoEmp);
                }
                else
                {
                    dtoEmp.id_dep = vmEmp.id_dep;
                    dtoEmp.id_emp = vmEmp.id_emp;
                    dtoEmp.nom_emp = vmEmp.nom_emp;
                    dtoEmp.prenom_emp = vmEmp.prenom_emp;
                    dtoEmp.Salaire_emp = vmEmp.Salaire_emp;
                    dtoEmp.tele_emp = vmEmp.tele_emp;
                    dtoEmp.date_recrute_emp = vmEmp.date_recrute_emp;
                    BusComp.AjouterEmployee(dtoEmp);
                }
                TempData["SuccessMessageDeprt"] = "Done !";
                return RedirectToAction("ListeEmp");
            }
            else
            {

                return RedirectToAjouterOrModifierEmp(vmEmp.id_emp);
            }

        }
    }
}