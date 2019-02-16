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
    public class SemisterGetway
    {
        DbContextSMS _dbContext = new DbContextSMS();
        public bool Add(Semister semister)
        {
            _dbContext.Semisters.Add(semister);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var semister = _dbContext.Semisters.FirstOrDefault(c => c.Id == id);
            if (semister != null)
            {
                _dbContext.Semisters.Remove(semister);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Semister semister)
        {
            DbContextSMS db = new DbContextSMS();
            db.Semisters.Attach(semister);
            db.Entry(semister).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public Semister GetById(int id)
        {
            var semister = _dbContext.Semisters.Find(id);
            return semister;
        }

        public List<Semister> GetAll()
        {
            var semisters = _dbContext.Semisters.Select(c => c).ToList();
            return semisters;
        }
        public IEnumerable<SelectListItem> Lookup()
        {
            var semisters = _dbContext.Semisters.Select(c => c).Distinct().ToList();
            var lookup = new List<SelectListItem>()
            {
                new SelectListItem {Text="---Select Semister---", Value="", Selected=true }
            };
            lookup.AddRange(semisters.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            return lookup;
        }
    }
}
