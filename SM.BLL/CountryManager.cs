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
    public class CountryManager
    {
        CountryGetway _countryGetway = new CountryGetway();

        public bool Add(Country country)
        {
            return _countryGetway.Add(country);
        }

        public bool Delete(int id)
        {
            return _countryGetway.Delete(id);
        }

        public bool Update(Country country)
        {
            return _countryGetway.Update(country);
        }

        public Country GetById(int id)
        {
            return _countryGetway.GetById(id);
        }

        public List<Country> GetAll()
        {
            return _countryGetway.GetAll();
        }

        public IEnumerable<SelectListItem> Lookup()
        {
            return _countryGetway.Lookup();
        }
    }
}
