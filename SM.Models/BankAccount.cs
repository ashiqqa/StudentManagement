using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string AccNumber { get; set; }
    }
}
