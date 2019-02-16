using SM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DAL
{
    public class UserGetway
    {
        DbContextSMS _dbContext = new DbContextSMS();

        public bool Add(User user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges() > 0;
        }

        public User ExistUser(User userInfo)
        {
            var user = _dbContext.Users.FirstOrDefault(c => c.UserNameOrContact == userInfo.UserNameOrContact && c.Password == userInfo.Password);
            return user;
        }

        public Student ExistStudent(User userInfo)
        {
            var student = _dbContext.Students.FirstOrDefault(c => c.ContactNo == userInfo.UserNameOrContact && c.Password == userInfo.Password);
            return student;
        }
    }
}
