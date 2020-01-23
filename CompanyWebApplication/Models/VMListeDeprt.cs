using Common.DtoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyWebApplication.Models
{
    public class VMListeDeprt
    {
        public List<DtoDepartement> listDeprt = new List<DtoDepartement>();
        public List<DtoCategorie> listCat = new List<DtoCategorie>();

        public int id_dep { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Nom")]
        public string nom_dep { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(maximumLength: 250)]
        [Display(Name = "Description")]
        public string description_dep { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Date Création")]
        public System.DateTime Date_creat { get; set; }
        [Required(ErrorMessage = "*")]
        public int id_cat { get; set; }
       
    }
}