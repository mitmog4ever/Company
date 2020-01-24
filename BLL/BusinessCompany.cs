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
        public DtoEmployee GetEmployee(int id)
        {
            var x = context.Employees.Find(id);
            return new DtoEmployee
            {
                id_emp = x.id_emp,
                nom_emp = x.nom_emp,
                prenom_emp = x.prenom_emp,
                date_recrute_emp = x.date_recrute_emp,
                deprt = x.Departement.nom_dep,
                Salaire_emp = x.Salaire_emp,
                id_dep = x.id_dep,
                tele_emp = x.tele_emp
            };
        }
        public List<DtoDepartement> GetListeDepartement(int page = 0,int size = 5, bool retAll = false)
        {
            var list = new List<Departement>();
            if (retAll) 
            {
                list = context.Departements.OrderBy(item => item.id_dep).ToList();
            }
            else
            {
                list = context.Departements.OrderBy(item => item.id_dep).Skip(page * size).Take(size).ToList();
            }

           
            totalDeprt = context.Departements.Count();
            var listDto = list.Select(x => new DtoDepartement {
                id_dep = x.id_dep,
                nom_dep = x.nom_dep,
                Categorie = x.Categorie.description_cat,
                id_cat = x.id_cat,
                Date_creat = x.Date_creat,
                description_dep = x.description_dep
                
            }
            ).ToList();
            return listDto;
        }
        public DtoDepartement GetDepartement(int id)
        {
            var x = context.Departements.Find(id);
            var deprtDto =  new DtoDepartement
            {
                id_dep = x.id_dep,
                nom_dep = x.nom_dep,
                Categorie = x.Categorie.description_cat,
                id_cat = x.id_cat,
                Date_creat = x.Date_creat,
                description_dep = x.description_dep
            };
            return deprtDto;
        }
        public DtoCategorie GetCategorie(int id)
        {
            var x = context.Categories.Find(id);
            var catDto = new DtoCategorie
            {
                id_cat = x.id_cat,
                description_cat = x.description_cat
                
            };
            return catDto;
        }
        public void deleteEmployee(int id)
        {
            context.Database.ExecuteSqlCommand("delete from Employee where id_emp = @id", new SqlParameter("@id" , id));
        }
        public void deleteDepartement(int id)
        {
            context.Database.ExecuteSqlCommand("delete from Employees where id_dep = @id", new SqlParameter("@id", id));
            context.Database.ExecuteSqlCommand("delete from Departements where id_dep = @id", new SqlParameter("@id", id));
        }
        public void deleteCategorie(int id)
        {
            context.Database.ExecuteSqlCommand("delete from Employees where id_dep = @id", new SqlParameter("@id", id));
            context.Database.ExecuteSqlCommand("delete from Departements where id_cat = @id", new SqlParameter("@id", id));
            context.Database.ExecuteSqlCommand("delete from Categorie where id_cat = @id", new SqlParameter("@id", id));
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
        public void AjouterCategorie(DtoCategorie dtoCat)
        {
            Categorie dep = new Categorie
            {         
                id_cat = dtoCat.id_cat,
                description_cat = dtoCat.description_cat
            };
            Ajouter(dep);

        }
        public void AjouterEmployee(DtoEmployee emp)
        {
            Employee empl = new Employee
            {
                id_dep = emp.id_dep,
                id_emp = emp.id_emp,
                nom_emp = emp.nom_emp,
                prenom_emp = emp.prenom_emp,
                Salaire_emp = emp.Salaire_emp,
                tele_emp = emp.tele_emp,
                date_recrute_emp = emp.date_recrute_emp

        };
            Ajouter(empl);

        }
        public void ModifierDepartement(DtoDepartement deprt)
        {

            var deprtUp = context.Departements.Find(deprt.id_dep);
            deprtUp.nom_dep = deprt.nom_dep;
            deprtUp.description_dep = deprt.description_dep;
            deprtUp.Date_creat = deprt.Date_creat;
            deprtUp.id_cat = deprt.id_cat;         
            context.SaveChanges();
        }
        public void ModifierCategorie(DtoCategorie cat)
        {

            var catUp = context.Categories.Find(cat.id_cat);
            catUp.description_cat = cat.description_cat;
            catUp.id_cat = cat.id_cat;
            context.SaveChanges();
        }
        public void ModifierEmployee(DtoEmployee emp)
        {

            var empUp = context.Employees.Find(emp.id_emp);
            empUp.id_dep = emp.id_dep;
            empUp.id_emp = emp.id_emp;
            empUp.nom_emp = emp.nom_emp;
            empUp.prenom_emp = emp.prenom_emp;
            empUp.Salaire_emp = emp.Salaire_emp;
            empUp.tele_emp = emp.tele_emp;
            empUp.date_recrute_emp = emp.date_recrute_emp;
            context.SaveChanges();
        }
    }
}
