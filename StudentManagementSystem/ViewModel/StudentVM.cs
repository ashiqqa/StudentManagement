using SM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.ViewModel
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="Max Length 50 Charecter")]
        public string Name { get; set; }

        [Required]
        [StringLength(18, ErrorMessage ="Max length 18 charecter")]
        [Remote("IsUniqueStudentId", "Student", AdditionalFields = "Id, initialStudentId", ErrorMessage = "Already Exist, Try another StudentIdNo")]
        public string StudentIdNo { get; set; }
        public string initialStudentId { get; set; }

        [Required(ErrorMessage ="Select Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentLookup { get; set; }

        [Required(ErrorMessage = "Select Session")]
        [Display(Name="Session")]
        public int SesionId { get; set; }
        public IEnumerable<SelectListItem> SesionLookup { get; set; }

        [Required(ErrorMessage ="Select semister")]
        [Display(Name="Semister")]
        public int SemisterId { get; set; }
        public IEnumerable<SelectListItem> SemisterLookup { get; set; }

        [Required(ErrorMessage ="Select Country")]
        [Display(Name="Country")]
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> CountryLookup { get; set; }

        [Required(ErrorMessage ="Select City")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> CityLookup {get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Select Gender")]
        public Genders Gender { get; set; }
        [Required(ErrorMessage = "Select Religion")]
        public Religions Religion { get; set; }
        public List<Skill> Skills { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage ="Contact number is required")]
        [Remote("IsUniqueContactNo", "Student", AdditionalFields = "Id, initialContactNo")]
        public string ContactNo { get; set; }
        public string initialContactNo { get; set; }
        [Required]
        [EmailAddress]
        [Remote("IsUniqueEmail", "Student", AdditionalFields = "Id, initialEmail", ErrorMessage = "Already Exist, Try another Email")]
        public string Email { get; set; }
        public string initialEmail { get; set; }

        [Display(Name = "Bank")]
        public int BankId { get; set; }
        public IEnumerable<SelectListItem> BankLookup { get; set; }

        [Required(ErrorMessage ="AccountNo required")]
        [Remote("IsUniqueAccountNo", "Student", AdditionalFields = "Id, initialAccountNo", ErrorMessage = "Already Exist, Try another AccountNo")]
        public string AccNumber { get; set; }
        public string initialAccountNo { get; set; }

        public BankAccount BankAccount { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }
        public string initialPassword { get; set; }
        [Required(ErrorMessage ="Confirm password")]
        [Display(Name="Confirm Password")]
        [Remote("ConfirmPassword", "Student", AdditionalFields = "Password", ErrorMessage = "Not matched, Please confirm that you type before!")]
        public string ConfirmPass { get; set; }
        public string SearchQuery { get; set; }

        public Parent Parent { get; set; }
        public Department Department { get; set; }
        public Sesion Sesion { get; set; }
        public Semister Semister { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public Bank Bank { get; set; }
        [Remote("ImageValidation", "Student", ErrorMessage = "Image size or format not valid")]
        public List<HttpPostedFileBase> Files { get; set; }

        public List<Department> Departments { get; set; }
        public List<Semister> Semisters { get; set; }
        public List<Country> Countries { get; set; }
        public List<City> CIties { get; set; }
        public List<Bank> Banks { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
        public List<Student> Students { get; set; }
        public List<Image> Images { get; set; }
        
    }
    //Gender list
    public enum Genders
    {
        Male = 1,
        Female,
        Other
    }
    public enum Religions
    {
        Islam=1,
        Hinduism,
        Buddism,
        Christians,
        Atheist
    }
   
}