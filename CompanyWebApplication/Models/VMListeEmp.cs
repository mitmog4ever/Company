using Common.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyWebApplication.Models
{
    public class VMListeEmp
    {
        public List<DtoEmployee> listEmp = new List<DtoEmployee>();
        public string keyWord { get; set; }
    }
}