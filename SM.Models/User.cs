using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SM.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserNameOrContact { get; set; }
        public string Password { get; set; }

        [NotMapped]
        [Remote("ConfirmPassword", "Student", AdditionalFields = "Password", ErrorMessage = "Not matched, Please confirm that you type before!")]
        public string ConfirmPass { get; set; }
    }
}
