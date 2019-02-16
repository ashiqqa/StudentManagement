using SM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.ViewModel
{
    public class SemisterVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage ="Max length 30 charecter")]
        public string Name { get; set; }
        [Required]
        [StringLength(15, ErrorMessage ="Max length 15 charecter")]
        public string Code { get; set; }
        public IEnumerable<SelectListItem> Lookup { get; set; }
        public List<Semister> Semisters { get; set; }
        public List<Student> Students { get; set;}
    }
}