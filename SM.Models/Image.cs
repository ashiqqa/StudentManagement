using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
