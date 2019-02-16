using SM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.ViewModel
{
    public class CityVM
    {
        public int Id { get; set;}
        [Required(ErrorMessage ="Select Country")]
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> CountryLookup { get; set; }
        [Required]
        [StringLength(30, ErrorMessage ="Max length 30 charecter")]
        public string Name { get; set; }
        public List<City> Cities { get; set; }
        public List<Student> Students { get; set; }

    }
}