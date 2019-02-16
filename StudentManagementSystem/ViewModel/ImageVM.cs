using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.ViewModel
{
    public class ImageVM
    {
        public int Id { get; set; }
        public HttpPostedFileBase File { get; set;}
        public int StuedntId { get; set; }
    }
}