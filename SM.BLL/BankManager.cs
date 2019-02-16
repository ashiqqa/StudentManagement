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
    public class BankManager
    {
        BankGetway _bankGetway = new BankGetway();

        public bool Add(Bank bank)
        {
            return _bankGetway.Add(bank);
        }

        public bool Delete(int id)
        {
            return _bankGetway.Delete(id);
        }

        public bool Update(Bank bank)
        {
            return _bankGetway.Update(bank);
        }

        public Bank GetById(int id)
        {
            return _bankGetway.GetById(id);
        }

        public List<Bank> GetAll()
        {
            return _bankGetway.GetAll();
        }

        public IEnumerable<SelectListItem> Lookup()
        {
            return _bankGetway.Lookup();
        }
    }
}
