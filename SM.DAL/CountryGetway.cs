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
    public class CountryGetway
    {
        DbContextSMS _dbContext = new DbContextSMS();

        public bool Add(Country country)
        {
            _dbContext.Countries.Add(country);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var country = _dbContext.Countries.FirstOrDefault(c=>c.Id==id);
            if (country != null)
            {
                _dbContext.Countries.Remove(country);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Country country)
        {
            DbContextSMS db = new DbContextSMS();
            db.Countries.Attach(country);
            db.Entry(country).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public Country GetById(int id)
        {
            var department = _dbContext.Countries.Find(id);
            return department;
        }

        public List<Country> GetAll()
        {
            var countries = _dbContext.Countries.Select(c => c).ToList();
            return countries;
        }

        public IEnumerable<SelectListItem> Lookup()
        {
            var countries = _dbContext.Countries.Select(c => c).Distinct().ToList();
            var lookup = new List<SelectListItem>()
            {
                 new SelectListItem {Text="---Select Country---", Value="", Selected=true }
            };
            lookup.AddRange(countries.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            return lookup;
        }
    }
}
