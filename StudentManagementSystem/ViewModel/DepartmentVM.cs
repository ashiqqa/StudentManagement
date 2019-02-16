using SM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.ViewModel
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max length 50")]
        public string Name { get; set; }
        [Required]
        [StringLength(7, ErrorMessage ="Max length 7")]
        [Remote("IsUniqueCode", "Department", AdditionalFields = "Id, initialCode", ErrorMessage = "Already Exist, Try another Code")]
        public string Code { get; set; }
        public string initialCode { get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
    }
}