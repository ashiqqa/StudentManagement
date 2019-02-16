using SM.DAL;
using SM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.BLL
{
    public class UserManager
    {
        UserGetway _userGetway = new UserGetway();

        public bool Add(User user)
        {
            return _userGetway.Add(user);
        }

        public User ExistUser(User user)
        {
            return _userGetway.ExistUser(user);
        }
        public Student ExistStudent(User user)
        {
            return _userGetway.ExistStudent(user);
        }
    }
}
