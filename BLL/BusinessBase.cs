using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BusinessBase
    {
        protected CompanyDBEntities context = new CompanyDBEntities();
        public void Ajouter<T>(T entity) where T : class
        {

            
            context.Set<T>().Add(entity);

            context.SaveChanges();


        }

        public void Supprimer<T>(params object[] key) where T : class
        {

            var entity = context.Set<T>().Find(key);

            context.Set<T>().Remove(entity);

            context.SaveChanges();


        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return context.Set<T>();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
