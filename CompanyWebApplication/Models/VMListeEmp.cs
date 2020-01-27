using Common.DtoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyWebApplication.Models
{
    public class VMListeEmp
    {
        public List<DtoEmployee> listEmp = new List<DtoEmployee>();
        public List<DtoDepartement> listDeprt = new List<DtoDepartement>();
        public string keyWord { get; set; }
        public int id_emp { get; set; }
        [Required(ErrorMessage ="1*")]
        [StringLength(maximumLength:50)]
        public string nom_emp { get; set; }
        [Required(ErrorMessage = "2*")]
        [StringLength(maximumLength: 50)]
        public string prenom_emp { get; set; }
        [Required(ErrorMessage = "3*")]
        public double Salaire_emp { get; set; }
        [Required(ErrorMessage = "4*")]
        public System.DateTime date_recrute_emp { get; set; }
        [Required(ErrorMessage = "5*")]
        public double tele_emp { get; set; }
        public int id_dep { get; set; }

    }
}