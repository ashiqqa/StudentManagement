using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public ITskill ITskill { get; set; }
        public bool IsSelected { get; set; }
    }
    public enum ITskill
    {
        [Display(Name = "Basic Computing")]
        [Description("Basic Computing")]
        BasicComputing = 1,
        [Display(Name = "Hardware")]
        Hardware,
        [Display(Name = "Networking")]
        Networking,
        [Display(Name = "Web Design")]
        WebDesign,
        [Display(Name = "Programming")]
        Programming
    }
}
