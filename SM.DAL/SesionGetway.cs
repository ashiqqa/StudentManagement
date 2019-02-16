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
    public class SesionGetway
    {
        DbContextSMS _dbContext = new DbContextSMS();
        public bool Add(Sesion session)
        {
            _dbContext.Sessions.Add(session);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var session = _dbContext.Sessions.FirstOrDefault(c => c.Id == id);
            if (session != null)
            {
                _dbContext.Sessions.Remove(session);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Sesion session)
        {
            DbContextSMS db = new DbContextSMS();
            db.Sessions.Attach(session);
            db.Entry(session).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public Sesion GetById(int id)
        {
            var session = _dbContext.Sessions.Find(id);
            return session;
        }

        public List<Sesion> GetAll()
        {
            var session = _dbContext.Sessions.Select(c => c).ToList();
            return session;
        }
        public IEnumerable<SelectListItem> Lookup()
        {
            var sesions = _dbContext.Sessions.Select(c => c).Distinct().ToList();
            var lookup = new List<SelectListItem>()
            {
                new SelectListItem {Text="---Select Session---", Value="", Selected=true }
            };
            lookup.AddRange(sesions.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            return lookup;
        }
    }
}
