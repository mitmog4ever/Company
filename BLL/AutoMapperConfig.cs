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
    public class AutoMapperConfig
    {
        public static Mapper mapper;
        
        public static void init()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Categorie, DtoCategorie>());
            mapper = new Mapper(config);
            
        }
    }
}
