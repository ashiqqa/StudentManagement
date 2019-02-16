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
    public class SemisterManager
    {
        SemisterGetway _semisterGetway = new SemisterGetway();

        public bool Add(Semister semister)
        {
            return _semisterGetway.Add(semister);
        }
        public bool Delete(int id)
        {
            return _semisterGetway.Delete(id);
        }

        public bool Update(Semister semister)
        {
            return _semisterGetway.Update(semister);
        }

        public Semister GetById(int id)
        {
            return _semisterGetway.GetById(id);
        }

        public List<Semister> GetAll()
        {
            return _semisterGetway.GetAll();
        }
        public IEnumerable<SelectListItem> Lookup()
        {
           return _semisterGetway.Lookup();
        }
    }
}
