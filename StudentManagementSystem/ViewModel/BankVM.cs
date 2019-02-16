using SM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.ViewModel
{
    public class BankVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="Max length 100 charecter")]
        public string Name { get; set; }
        public List<Bank> Banks { get; set; }
        public List<Student> Students { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
    }
}