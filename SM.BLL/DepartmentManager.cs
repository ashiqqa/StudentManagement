using SM.DAL;
using SM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SM.BLL
{
    public class DepartmentManager
    {
        DepartmentGetway _deptGetway = new DepartmentGetway();

        public bool Add(Department department)
        {
            return _deptGetway.Add(department);
        }

        public bool Delete(int id)
        {
            return _deptGetway.Delete(id);
        }

        public bool Update(Department department)
        {
            return _deptGetway.Update(department);
        }

        public Department GetById(int id)
        {
            return _deptGetway.GetById(id);
        }

        public List<Department> GetAll()
        {
            return _deptGetway.GetAll();
        }
        public IEnumerable<SelectListItem> Lookup()
        {
            return _deptGetway.Lookup();
        }

        public bool IsUniqueCode(int Id, string initialDeptCode, string deptCode)
        {
            if (Id == 0 || (Id > 0 && initialDeptCode != deptCode))
            {
                return _deptGetway.IsUniqueCode(deptCode);
            }
            return true;
        }
    }
}
