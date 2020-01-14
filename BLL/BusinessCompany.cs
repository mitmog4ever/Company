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
        
        public List<Categorie> GetListeCategorie()
        {
            var context = new CompanyDBEntities();
            return context.Categories.ToList();
        }
    }
}
