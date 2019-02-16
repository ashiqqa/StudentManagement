using SM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.ViewModel
{
    public class CountryVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage ="Max length 30 charecter")]
        public string Name { get; set; }
        public List<Country> Countries { get; set; }
        public List<Student> Students { get; set; }
    }
}