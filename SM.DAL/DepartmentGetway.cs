using SM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SM.DAL
{
    public class DepartmentGetway
    {
        DbContextSMS _dbContext = new DbContextSMS();

        public bool Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var department = _dbContext.Departments.Find(id);
            if (department != null)
            {
                _dbContext.Departments.Remove(department);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Department department)
        {
            DbContextSMS db = new DbContextSMS();
            db.Departments.Attach(department);
            db.Entry(department).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public Department GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }

        public List<Department> GetAll()
        {
            var departments = _dbContext.Departments.Select(c => c).OrderByDescending(c=>c.Id).ToList();
            return departments;
        }
        public IEnumerable<SelectListItem> Lookup()
        {
            var departments = _dbContext.Departments.Select(c=>c).Distinct().ToList();
            var lookup = new List<SelectListItem>()
            {
                new SelectListItem {Text="---Select Department---", Value="", Selected=true }
            };
            lookup.AddRange(departments.Select(dept => new SelectListItem { Text = dept.Name, Value = dept.Id.ToString() }));
            return lookup;
        }

        public bool IsUniqueCode(string deptCode)
        {
            if (_dbContext.Departments.Any(c => c.Code == deptCode))
            {
                return false;
            }
            return true;
        }
    }
   
}
