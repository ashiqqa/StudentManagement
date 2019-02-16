using SM.BLL;
using SM.Models;
using StudentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        UserManager _userManager = new UserManager();
        StudentManager _studentManager = new StudentManager();
        DepartmentManager _deptManager = new DepartmentManager();
        CountryManager _countryManager = new CountryManager();
        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public JsonResult Search(int? deptId, int? countryId, string searchQuery)
        {
            var students = _studentManager.GetBySearch(deptId, countryId, searchQuery);
            string tbody = GetTableBody(students);
            return Json(tbody, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Dashboard()
        {
            if ((string)Session["user"] == "admin")
            {
                StudentVM studentVM = new StudentVM();
                studentVM.DepartmentLookup = _deptManager.Lookup();
                studentVM.CountryLookup = _countryManager.Lookup();
                studentVM.Students = _studentManager.GetAll();
                return View(studentVM);
            }
            else
            {
              return  RedirectToAction("Login");
            }
        }

        public ActionResult GetByBirthDate(DateTime? fromDate, DateTime? toDate)
        {
            var students = _studentManager.GetByBirthDate(fromDate, toDate);
            string tbody = GetTableBody(students);
            return Json(tbody, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByAge(int age)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var students = _studentManager.GetByAge(age);
            string tbody = GetTableBody(students);
            return Json(tbody, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByAgeGreater(int age)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var students = _studentManager.GetByAgeGreater(age);
            string tbody = GetTableBody(students);
            return Json(tbody, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByAgeLess(int age)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var students = _studentManager.GetByAgeLess(age);
            string tbody = GetTableBody(students);
            return Json(tbody, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (_userManager.ExistUser(user) != null)
            {
                Session["user"] = "admin";
                Session["userName"] = _userManager.ExistUser(user).UserNameOrContact;
                return RedirectToAction("Dashboard");
            }
            if (_userManager.ExistStudent(user)!=null)
            {
                Session["user"] = "student";
                Session["userName"] = _userManager.ExistStudent(user).Name;
                Session["studentId"] = _userManager.ExistStudent(user).Id.ToString();
                return RedirectToAction("../Student/Profile", new {id = _userManager.ExistStudent(user).Id });
            }
            else
            {
                ViewBag.NotFound = "User name or password does'nt match!";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }


        //Method for creating student tbody
        public string GetTableBody(List<Student> students)
        {
            string tbody = "";
            int serial = 0;
            foreach (var student in students)
            {
                DateTime zeroTime = new DateTime(1, 1, 1);
                DateTime birthDate = student.DateOfBirth.Value;
                DateTime curdate = DateTime.Now.ToLocalTime();
                TimeSpan span = curdate - birthDate;
                int years = (zeroTime + span).Year - 1;
                int months = (zeroTime + span).Month - 1;
                int days = (zeroTime + span).Day;
                string age = years + " years," + months + " months, " + days + "days";
                serial++;
                tbody += "<tr><td>" + serial + "</td><td>" + student.Name + "</td><td>" + student.StudentIdNo + "</td><td>" + student.City.Name + "</td><td>" + student.DateOfBirth.Value.ToString("dd MMM, yyyy")+"</td><td>" + age + "</td><td>" + student.ContactNo + "</td><td>";
                if (student.Images.Count() > 0)
                {
                    int index = student.Images.Count() - 1;
                    var imgFile = student.Images[index].FileName;
                    if (imgFile != null)
                    {
                        tbody += "<img src = '/images/" + imgFile + "' class='img-responsive' width='50' height='50' />";
                    }
                }
                else
                {
                    tbody += "<img src = '/images/default.png' class='img-responsive img-rounded' height='50' width='50' />";
                }
                string DelCell = "</td><td><button onclick='Delete()' class='btn btn-danger deleteBtn' value='" + student.Id + "'><span class='glyphicon glyphicon-trash'></span></button></td>";
                string editCell = "<td><button class='btn btn-info editBtn' value='" + student.Id + "'><a href = '/Student/Update?id=" + student.Id + "'><span class='glyphicon glyphicon-edit'></span></a></button></td>";
                string viewCell = "<td><button class='btn btn-info viewProfile' value='" + student.Id + "'><a href = '/Student/Profile?id=" + student.Id + "' ><span class='glyphicon glyphicon-eye-open'></span></a></button></td></tr>";
                tbody += DelCell + editCell + viewCell;
            }
            return tbody;
        }
        
    }
}