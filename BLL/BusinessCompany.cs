using AutoMapper;
using Common.DtoModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BusinessCompany : BusinessBase
    {
        public int totalCat = 0;
        public int totalEmp = 0;
        public int totalDeprt = 0;
        public List<DtoCategorie> GetListeCategorieDto(int page=0 , int size = 5, bool retAll = false)
        {
            totalCat = context.Categories.Count();
            var list = new List<Categorie>();
            if (retAll)
            {
                list =  context.Categories.OrderBy(item => item.id_cat).ToList();
            }else
            {
                list = context.Categories.OrderBy(item => item.id_cat).Skip(page * size).Take(size).ToList();
            }

            var listDto = AutoMapperConfig.mapper.Map<List<DtoCategorie>>(list);
            return listDto;
        }

        public List<DtoEmployee> GetListeEmployee(string KeyWord, int page = 0,int size = 5)
        {
            var list = new List<Employee>();
            totalCat = context.Employees.Count();
            if (!String.IsNullOrWhiteSpace(KeyWord))
            {
                list = context.Employees.Where(x => x.nom_emp.ToLower().Contains(KeyWord.ToLower()) || x.prenom_emp.ToLower().Contains(KeyWord.ToLower())).
                        OrderBy(item => item.id_emp).Skip(page * size).Take(size).ToList();
            }
            else
            {
                list = context.Employees.OrderBy(item => item.id_emp).Skip(page * size).Take(size).ToList();

            }
            var listDto = list.Select(x => new DtoEmployee { 
                id_emp = x.id_emp,
                nom_emp = x.nom_emp,
                prenom_emp = x.prenom_emp,
                date_recrute_emp = x.date_recrute_emp,
                deprt = x.Departement.nom_dep,
                Salaire_emp = x.Salaire_emp,
                id_dep = x.id_dep,
                tele_emp = x.tele_emp
            }
            ).ToList();
            return listDto;
        }        
        public List<DtoDepartement> GetListeDepartement(int page = 0,int size = 5)
        {
            var list = context.Departements.OrderBy(item => item.nom_dep).Skip(page * size).Take(size).ToList();
            totalDeprt = context.Departements.Count();
            var listDto = list.Select(x => new DtoDepartement {
                id_dep = x.id_dep,
                nom_dep = x.nom_dep,
                Categorie = x.Categorie.description_cat,
                id_cat = x.id_cat
            }
            ).ToList();
            return listDto;
        }
        public void deleteEmployee(int id)
        {
            context.Database.ExecuteSqlCommand("delete * from Employee where id_emp = @id", new SqlParameter("@id" , id));
        }
        public void AjouterDepartement(DtoDepartement deprt)
        {
            Departement dep = new Departement
            {
                
                nom_dep = deprt.nom_dep,
                description_dep = deprt.description_dep,
                Date_creat = deprt.Date_creat,
                id_cat = deprt.id_cat
            };
            Ajouter(dep);
           
        }
        public void ModifierDepartement(DtoDepartement deprt)
        {

            Departement deprtUp = context.Departements.Find(deprt.id_dep);
            deprtUp = new Departement
            {

                nom_dep = deprt.nom_dep,
                description_dep = deprt.description_dep,
                Date_creat = deprt.Date_creat,
                id_cat = deprt.id_cat
            };
            context.SaveChanges();
        }
    }
}
