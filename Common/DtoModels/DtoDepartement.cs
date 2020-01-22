using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DtoModels
{
    public class DtoDepartement
    {
        public int id_dep { get; set; }
        public string nom_dep { get; set; }
        public string description_dep { get; set; }
        public System.DateTime Date_creat { get; set; }
        public int id_cat { get; set; }
        public string Categorie { get; set; }
    }
}
