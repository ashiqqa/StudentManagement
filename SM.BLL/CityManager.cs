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
    public class CityManager
    {
        CityGetway _cityGetway = new CityGetway();
        public bool Add(City city)
        {
            return _cityGetway.Add(city);
        }

        public bool Delete(int id)
        {
            return _cityGetway.Delete(id);
        }

        public bool Update(City city)
        {
            return _cityGetway.Update(city);
        }

        public City GetById(int id)
        {
            return _cityGetway.GetById(id);
        }

        public List<City> GetByCountry(int countryId)
        {
            return _cityGetway.GetByCountry(countryId);
        }

        public List<City> GetAll()
        {
            return _cityGetway.GetAll();
        }

        public IEnumerable<SelectListItem> Lookup()
        {
            return _cityGetway.Lookup();
        }
    }
}
