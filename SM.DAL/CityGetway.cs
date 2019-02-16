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
    public class CityGetway
    {
        DbContextSMS _dbContext = new DbContextSMS();

        public bool Add(City city)
        {
            _dbContext.Cities.Add(city);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var city = _dbContext.Cities.FirstOrDefault(c => c.Id == id);
            if (city != null)
            {
                _dbContext.Cities.Remove(city);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(City city)
        {
            DbContextSMS db = new DbContextSMS();
            db.Cities.Attach(city);
            db.Entry(city).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public City GetById(int id)
        {
            var city = _dbContext.Cities.FirstOrDefault(c => c.Id == id);
            return city;
        }

        public List<City> GetByCountry(int countryId)
        {
            var cities = _dbContext.Cities.Where(c => c.CountryId == countryId).ToList();
            return cities;
        }

        public List<City> GetAll()
        {
            var cities = _dbContext.Cities.Select(c => c).ToList();
            return cities;
        }

        public IEnumerable<SelectListItem> Lookup()
        {
            var cities = _dbContext.Cities.Select(c => c).ToList();
            var lookup = new List<SelectListItem>()
            {
                new SelectListItem {Text="---Select City---" , Value="", Selected=true }
            };
            lookup.AddRange(cities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            return lookup;
        }
    }
}
