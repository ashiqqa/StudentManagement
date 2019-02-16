using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Models
{
    public class Student
    {
        public Student()
        {
            Parent Parent = new Parent();
            Image Image = new Image();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentIdNo { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int SemisterId { get; set; }
        public virtual Semister Semister { get; set; }
        public int SesionId { get; set; }
        public virtual Sesion Sesion { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [NotMapped]
        public string Age { get; set; }
        public Genders Gender { get; set; }
        public Religions Religion {get;set;}
        public virtual List<Skill> Skills { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public virtual BankAccount BankAccount { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }
        [NotMapped]
        public Image Image { get; set; }
        public virtual List<Image> Images { get; set; }
        
    }

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
