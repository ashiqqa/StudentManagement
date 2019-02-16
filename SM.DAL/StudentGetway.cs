using SM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DAL
{
    public class StudentGetway
    {
        DbContextSMS _dbContext = new DbContextSMS();

        public bool Add(Student student)
        {
            bool isAdded = false;
            _dbContext.Parents.Add(student.Parent);
            bool isParentAdd = _dbContext.SaveChanges()>0;
            if (isParentAdd == true)
            {
                BankAccount bankAcc = new BankAccount()
                {
                    BankId = student.BankAccount.BankId,
                    AccNumber = student.BankAccount.AccNumber
                };
                student.ParentId = student.Parent.Id;
                student.Parent = null;
                student.BankAccount = null;
                _dbContext.Students.Add(student);
                bankAcc.StudentId = student.Id;
                
                _dbContext.BankAccounts.Add(bankAcc);
                isAdded = _dbContext.SaveChanges() > 0;
            }
            return isAdded;
        }

        public bool Delete(int id)
        {
            var student = _dbContext.Students.Find(id);
            var parent = _dbContext.Parents.Find(student.ParentId);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.Parents.Remove(parent);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Student student)
        {
            DbContextSMS db = new DbContextSMS();
            db.Parents.Attach(student.Parent);
            db.Entry(student.Parent).State = EntityState.Modified;
            bool isUpdate = db.SaveChanges() > 0;

            db.BankAccounts.Attach(student.BankAccount);
            db.Entry(student.BankAccount).State = EntityState.Modified;
            isUpdate = db.SaveChanges() > 0;

            List<Image> imgList = student.Images;
            student.Images = null;
            student.BankAccount = null;

            foreach(var skl in student.Skills)
            {
                DbContextSMS dbCon = new DbContextSMS();
                dbCon.Skills.Attach(skl);
                dbCon.Entry(skl).State = EntityState.Modified;
                dbCon.SaveChanges();
            }
            student.Skills = null;
            db.Students.Attach(student);
            db.Entry(student).State = EntityState.Modified;
            
            isUpdate = db.SaveChanges() > 0;

            //add all images
            if (imgList.Count > 0)
            {
                foreach(var img in imgList)
                {
                    Image imgObj = new Image()
                    {
                        StudentId = student.Id,
                        FileName = img.FileName
                    };
                    db.Images.Add(imgObj);
                    db.SaveChanges();
                }
            }
            
            return isUpdate;
        }
        
        public bool ChangePassword(User user)
        {
           _dbContext.Students.Where(c => c.Id == user.Id).FirstOrDefault().Password=user.Password;
            return _dbContext.SaveChanges() > 0;
        }

        public Student GetById(int id)
        {
            var student = _dbContext.Students.Find(id);
            var bankAcc = _dbContext.BankAccounts.FirstOrDefault(c => c.StudentId == id);
            student.BankAccount = bankAcc;
            return student;
        }

        public List<Student> GetAll()
        {
            var students = _dbContext.Students.Select(c => c).ToList();
            return students;
        }

        public List<Student> GetByDepartment(int? deptId)
        {
            var students = _dbContext.Students.Where(c => c.DepartmentId == deptId).ToList();
            return students;
        }

        public List<Student> GetBySemister(int semisterId)
        {
            var students = _dbContext.Students.Where(c => c.SemisterId == semisterId).ToList();
            return students;
        }
        public List<Student> GetBySession(int? sessionId)
        {
            var students = _dbContext.Students.Where(c => c.SesionId == sessionId).ToList();
            return students;
        }
        
        public List<Student> GetByCountry(int? countryId)
        {
            var students = _dbContext.Students.Where(c => c.City.CountryId == countryId).ToList();
            return students;
        }

        public List<Student> GetByCity(int cityId)
        {
            var students = _dbContext.Students.Where(c => c.CityId == cityId).ToList();
            return students;
        }
        public List<Student> GetByDeptCountrySearch(int? deptId, int? countryId, string search)
        {
            var students = _dbContext.Students.Where(c => c.DepartmentId == deptId && c.City.CountryId == countryId && (c.Name.Contains(search) || c.ContactNo.Contains(search))).ToList();
            return students;
        }
        public List<Student> GetByDeptCountry(int? deptId, int? countryId)
        {
            var students = _dbContext.Students.Where(c => c.DepartmentId == deptId && c.City.CountryId == countryId).ToList();
            return students;
        }
        public List<Student> GetByDeptSearch(int? deptId, string search)
        {
            var students = _dbContext.Students.Where(c => c.DepartmentId == deptId && (c.Name.Contains(search) || c.ContactNo.Contains(search))).ToList();
            return students;
        }
        public List<Student> GetByCountrySearch(int? countryId, string search)
        {
            var students = _dbContext.Students.Where(c =>c.City.CountryId == countryId && (c.Name.Contains(search) || c.ContactNo.Contains(search))).ToList();
            return students;
        }
        public List<Student> GetBySearchQuery(string searchQuery)
        {
            var students = _dbContext.Students.Where(c => c.Name.Contains(searchQuery) || c.ContactNo.Contains(searchQuery)).ToList();
            return students;
        }
        public List<Student> GetByBirthDate(DateTime? fromDate, DateTime? toDate)
        {
            var students = _dbContext.Students.Where(c => c.DateOfBirth >= fromDate && c.DateOfBirth <= toDate).ToList();
            return students;
        }
        public List<Student> GetByAge(int age)
        {
            string birthDate = DateTime.Now.AddYears(-age).ToString("yyyy/MM/dd");
            var students = _dbContext.Students.Where(c => c.DateOfBirth.ToString().Contains(birthDate)).ToList();

            var allStudent = _dbContext.Students.Select(c => c).ToList();
            //if (age == null) { return allStudent; }
            return students;
        }
        public List<Student> GetByAgeGreater(int age)
        {
            DateTime birthDate = DateTime.Now.AddYears(-age);
            var students = _dbContext.Students.Where(c => c.DateOfBirth < birthDate).ToList();

            var allStudent = _dbContext.Students.Select(c => c).ToList();
            //if (age == null) { return allStudent; }
            return students;
        }

        public List<Student> GetByAgeLess(int age)
        {
            DateTime birthDate = DateTime.Now.AddYears(-age);
            var students = _dbContext.Students.Where(c => c.DateOfBirth > birthDate).ToList();

            var allStudent = _dbContext.Students.Select(c => c).ToList();
            //if (age == null) { return allStudent; }
            return students;
        }
        public bool IsUniqueStudentId(string studentId)
        {
            if(_dbContext.Students.Any(c => c.StudentIdNo == studentId))
            {
                return false;
            }
            return true;
        }

        public List<BankAccount> GetByBank(int id)
        {
            var bankAcc = _dbContext.BankAccounts.Where(c => c.BankId == id).ToList();
            return bankAcc;
        }

        public bool IsUniqueContactNo(string ContactNo)
        {
            if (_dbContext.Students.Any(c => c.ContactNo == ContactNo))
            {
                return false;
            }
            return true;
        }
        public bool IsUniqueEmail(string email)
        {
            if (_dbContext.Students.Any(c => c.Email == email))
            {
                return false;
            }
            return true;
        }
        public bool IsUniqueAccountNo(string AccountNo)
        {
            if (_dbContext.BankAccounts.Any(c => c.AccNumber == AccountNo))
            {
                return false;
            }
            return true;
        }

    }
}
