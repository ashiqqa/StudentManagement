using SM.DAL;
using SM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.BLL
{
    public class StudentManager
    {
        StudentGetway _studentGetway = new StudentGetway();

        public bool Add(Student student)
        {
            return _studentGetway.Add(student);
        }

        public bool Delete(int id)
        {
            return _studentGetway.Delete(id);
        }

        public bool Update(Student student)
        {
            return _studentGetway.Update(student);
        }
        public bool ChangePassword(User user)
        {
            return _studentGetway.ChangePassword(user);
        }

        public Student GetById(int id)
        {
            return _studentGetway.GetById(id);
        }

        public List<Student> GetAll()
        {
            return _studentGetway.GetAll();
        }

        public List<Student> GetByDepartment(int? deptId)
        {
            return _studentGetway.GetByDepartment(deptId);
        }

        public List<Student> GetBySemister(int semisterId)
        {
            return _studentGetway.GetBySemister(semisterId);
        }
        public List<Student> GetBySession(int? sessionId)
        {
            return _studentGetway.GetBySession(sessionId);
        }
        public List<Student> GetByCountry(int? countryId)
        {
            return _studentGetway.GetByCountry(countryId);
        }
        public List<Student> GetByCity(int cityId)
        {
            return _studentGetway.GetByCity(cityId);
        }

        public List<BankAccount> GetByBank(int id)
        {
            var bankAcc = _studentGetway.GetByBank(id);
            return bankAcc;
        }

        public List<Student> GetBySearch(int? deptId, int? countryId, string searchQuery)
        {
            List<Student> students = new List<Student>();
            if (deptId != null && countryId != null && searchQuery != "")
            {
                students = _studentGetway.GetByDeptCountrySearch(deptId, countryId, searchQuery);
            }
            else if (deptId != null && countryId != null)
            {
                students = _studentGetway.GetByDeptCountry(deptId, countryId);
            }
            else if (deptId != null && searchQuery != "")
            {
                students = _studentGetway.GetByDeptSearch(deptId, searchQuery);
            }
            else if (countryId != null && searchQuery != "")
            {
                students = _studentGetway.GetByCountrySearch(countryId, searchQuery);
            }
            else if (deptId != null)
            {
                students = _studentGetway.GetByDepartment(deptId);
            }
            else if (countryId != null)
            {
                students = _studentGetway.GetByCountry(countryId);
            }
            else if (searchQuery != null)
            {
                students = _studentGetway.GetBySearchQuery(searchQuery);
            }
            else
            {
                students = _studentGetway.GetAll();
            }
            return students;
        }

        public List<Student> GetByBirthDate(DateTime? fromDate, DateTime? toDate)
        {
            return _studentGetway.GetByBirthDate(fromDate, toDate);
        }

        public List<Student> GetByAge(int age)
        {
            return _studentGetway.GetByAge(age);
        }
        public List<Student> GetByAgeGreater(int age)
        {
            return _studentGetway.GetByAgeGreater(age);
        }
        public List<Student> GetByAgeLess(int age)
        {
            return _studentGetway.GetByAgeLess(age);
        }
        public string GetStudentIdNo(int deptId, int sessionId)
        {
            DepartmentManager _deptManager = new DepartmentManager();
            SessionManager _sessionManager = new SessionManager();

            string deptCode = _deptManager.GetById(deptId).Code;
            string sessionCode = _sessionManager.GetById(sessionId).Name;
            string year = DateTime.Now.Year.ToString();
            string count = _studentGetway.GetAll().Count.ToString("D4");

            string studentIdNo = deptCode + "-" + sessionCode.Substring(0, 2).ToUpper() + "-" + year.Substring(2,2) + "-" + count;
            return studentIdNo;

        }

        public bool IsUniqueStudentId(int Id, string initialStudentId, string StudentIdNo)
        {
            if (Id == 0 || (Id>0 && initialStudentId!=StudentIdNo))
            {
                return _studentGetway.IsUniqueStudentId(StudentIdNo);
            }
            return true;
        }

        public bool IsUniqueContactNo(int Id, string initialContactNo, string ContactNo)
        {
            if (Id == 0 || (Id > 0 && initialContactNo != ContactNo))
            {
                return _studentGetway.IsUniqueContactNo(ContactNo);
            }
            return true;
        }

        public bool IsUniqueEmail(int Id, string initialEmail, string email)
        {
            if (Id == 0 || (Id > 0 && initialEmail != email))
            {
                return _studentGetway.IsUniqueEmail(email);
            }
            return true;
        }

        public bool IsUniqueAccountNo(int Id, string initialAccountNo, string AccountNo)
        {
            if (Id == 0 || (Id > 0 && initialAccountNo != AccountNo))
            {
                return _studentGetway.IsUniqueAccountNo(AccountNo);
            }
            return true;
        }
    }
}
