using AutoMapper;
using Common.DtoModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BusinessCompany
    {
        public int totalCat = 0; 
        public List<DtoCategorie> GetListeCategorieDto(int page=0 , int size = 5)
        {
            var context = new CompanyDBEntities();
            totalCat = context.Categories.Count();
            var list = context.Categories.OrderBy(item => item.id_cat).Skip(page*size).Take(size).ToList();
            var listDto = AutoMapperConfig.mapper.Map<List<DtoCategorie>>(list);
            return listDto;
        }

        public List<Categorie> GetListeCategorie()
        {
            var context = new CompanyDBEntities();
            return context.Categories.ToList();
        }
    }
}
