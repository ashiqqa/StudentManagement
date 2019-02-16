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
    public class SessionManager
    {
        SesionGetway _sessionGetway = new SesionGetway();
        public bool Add(Sesion session)
        {
            return _sessionGetway.Add(session);
        }
        public bool Delete(int id)
        {
            return _sessionGetway.Delete(id);
        }

        public bool Update(Sesion session)
        {
            return _sessionGetway.Update(session);
        }

        public Sesion GetById(int id)
        {
            return _sessionGetway.GetById(id);
        }

        public List<Sesion> GetAll()
        {
            return _sessionGetway.GetAll();
        }
        public IEnumerable<SelectListItem> Lookup()
        {
            return _sessionGetway.Lookup();
        }

    }
}
