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
    public class BankGetway
    {
        DbContextSMS _dbContext = new DbContextSMS();
        
        public bool Add(Bank bank)
        {
            _dbContext.Banks.Add(bank);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var bank = _dbContext.Banks.FirstOrDefault(c => c.Id == id);
            if (bank != null)
            {
                _dbContext.Banks.Remove(bank);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Bank bank)
        {
            DbContextSMS db = new DbContextSMS();
            db.Banks.Attach(bank);
            db.Entry(bank).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public Bank GetById(int id)
        {
            var bank = _dbContext.Banks.Find(id);
            return bank;
        }

        public List<Bank> GetAll()
        {
            var banks = _dbContext.Banks.Select(c => c).ToList();
            return banks;
        }

        public IEnumerable<SelectListItem> Lookup()
        {
            var banks = _dbContext.Banks.Select(c => c).Distinct().ToList();
            var lookup = new List<SelectListItem>()
            {
                new SelectListItem {Text="---Select Bank---", Value="", Selected=true }
            };
            lookup.AddRange(banks.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            return lookup;
        }
    }
}
