using Common.DtoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyWebApplication.Models
{
    public class VMListeCat
    {
        public List<DtoCategorie> lisCat = new List<DtoCategorie>();
        [Required]
        public int id_cat { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(maximumLength:250)]
        public string description_cat { get; set; }
    }
}