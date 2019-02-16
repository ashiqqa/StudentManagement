using AutoMapper;
using SM.BLL;
using SM.Models;
using StudentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();
        DepartmentManager _deptManager = new DepartmentManager();
        SessionManager _sesionManager = new SessionManager();
        SemisterManager _semisterManager = new SemisterManager();
        CountryManager _countryManager = new CountryManager();
        CityManager _cityManager = new CityManager();
        BankManager _bankManager = new BankManager();
        UserManager _userManager = new UserManager();
        ImageManager _imgManager = new ImageManager();


        [HttpGet]
        public ActionResult Add()
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            StudentVM studentVM = new StudentVM();
            studentVM.DepartmentLookup = _deptManager.Lookup();
            studentVM.SesionLookup = _sesionManager.Lookup();
            studentVM.SemisterLookup = _semisterManager.Lookup();
            studentVM.CountryLookup = _countryManager.Lookup();
            studentVM.BankLookup = _bankManager.Lookup();

            studentVM.Skills = new List<Skill>();
            studentVM.Skills.Add(new Skill { ITskill = ITskill.BasicComputing, IsSelected=false });
            studentVM.Skills.Add(new Skill { ITskill = ITskill.Hardware, IsSelected = false });
            studentVM.Skills.Add(new Skill { ITskill = ITskill.Networking, IsSelected = false });
            studentVM.Skills.Add(new Skill { ITskill = ITskill.WebDesign, IsSelected = false });
            studentVM.Skills.Add(new Skill { ITskill = ITskill.Programming, IsSelected = false });

            return View(studentVM);
        }
      
        public JsonResult GetCityByCountry(int countryId)
        {
            var cities = _cityManager.GetByCountry(countryId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentIdNo(int deptId, int sessionId)
        {
            string studentIdNo = _studentManager.GetStudentIdNo(deptId, sessionId);
            return Json(studentIdNo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
           try
            {
                Student student = Mapper.Map<Student>(studentVM);
                if (studentVM.Files.Count > 0)
                {
                    foreach (var imgFile in studentVM.Files)
                    {
                        if (imgFile != null)
                        {
                            if (imgFile.ContentLength > (1024 * 512) || !(imgFile.ContentType == "image/jpg" || imgFile.ContentType == "image/jpeg" || imgFile.ContentType == "image/png"))
                            {
                                throw new Exception("Image size or format not valid");
                            }
                            Image img = new Image();
                            img.FileName = student.StudentIdNo + "_" + Path.GetFileNameWithoutExtension(imgFile.FileName) + Path.GetExtension(imgFile.FileName);
                            student.Images.Add(img);
                        }
                    }
                }
                if (_studentManager.Add(student))
                {
                    if (studentVM.Files.Count > 0)
                    {
                        foreach (var imgFile in studentVM.Files)
                        {
                            if (imgFile != null)
                            {
                                string fileName = student.StudentIdNo + "_" + Path.GetFileNameWithoutExtension(imgFile.FileName) + Path.GetExtension(imgFile.FileName);
                                string filePath = Path.Combine(Server.MapPath("~/images/"), fileName);
                                imgFile.SaveAs(filePath);
                            }
                        }
                    }

                    TempData["saved"] = "Added successfully";
                    return RedirectToAction("Add");
                }
            }
            catch(Exception e)
            {
                TempData["failed"] = "Failed to Add";
                TempData["exception"] = e.Message;
            }
            studentVM.DepartmentLookup = _deptManager.Lookup();
            studentVM.SesionLookup = _sesionManager.Lookup();
            studentVM.SemisterLookup = _semisterManager.Lookup();
            studentVM.CountryLookup = _countryManager.Lookup();
            studentVM.BankLookup = _bankManager.Lookup();
            return View(studentVM);

        }

        public JsonResult Delete(int id)
        {
            var imgList = _studentManager.GetById(id).Images;
            if (imgList.Count > 0)
            {
                foreach (var img in imgList)
                {
                    var path = Server.MapPath("~/images/" + img.FileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }
            }
            _studentManager.Delete(id);
            return null;
        }
        [HttpGet]
        public ActionResult Profile(int id)
        {
            if (Session["user"] == null || ((string)Session["user"] == "student" && (string)Session["studentId"] != id.ToString()))
            {
                return RedirectToAction("../Home/Login");
            }

             var student = _studentManager.GetById(id);
            StudentVM studentVM = Mapper.Map<StudentVM>(student);
            TempData["StudentId"] = studentVM.Id;
            return View(studentVM);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (Session["user"]==null || ((string)Session["user"] == "student" && (string)Session["studentId"] != id.ToString() ))
            {
                return RedirectToAction("../Home/Login");
            }
            var student = _studentManager.GetById(id);
            StudentVM studentVM = Mapper.Map<StudentVM>(student);
            studentVM.DepartmentLookup = _deptManager.Lookup();
            studentVM.SesionLookup = _sesionManager.Lookup();
            studentVM.SemisterLookup = _semisterManager.Lookup();
            studentVM.CityLookup = _cityManager.Lookup();
            studentVM.CountryLookup = _countryManager.Lookup();
            studentVM.CountryId = student.City.CountryId;
            studentVM.BankLookup = _bankManager.Lookup();

            studentVM.initialStudentId = student.StudentIdNo;
            studentVM.initialContactNo = student.ContactNo;
            studentVM.initialEmail = student.Email;
            studentVM.ConfirmPass = student.Password;
            TempData["StudentId"] = id;
            return View(studentVM);
        }
        [HttpPost]
        public ActionResult Update(StudentVM studentVM,HttpPostedFileBase StudentImage)
        {
            try
            {
                Student student = Mapper.Map<Student>(studentVM);
                if (studentVM.Files.Count > 0)
                {
                    foreach (var imgFile in studentVM.Files)
                    {
                        if (imgFile != null)
                        {
                            if (imgFile.ContentLength > (1024 * 512) || !(imgFile.ContentType == "image/jpg" || imgFile.ContentType == "image/jpeg" || imgFile.ContentType == "image/png"))
                            {
                                throw new Exception("Image size or format not valid");
                            }

                            Image img = new Image();
                            img.FileName = student.StudentIdNo + "_" + Path.GetFileNameWithoutExtension(imgFile.FileName) + Path.GetExtension(imgFile.FileName);
                            student.Images.Add(img);
                        }
                    }
                }

                if (_studentManager.Update(student))
                {
                    if (studentVM.Files.Count > 0)
                    {
                        foreach (var imgFile in studentVM.Files)
                        {
                            if (imgFile != null)
                            {
                                string fileName = student.StudentIdNo + "_" + Path.GetFileNameWithoutExtension(imgFile.FileName) + Path.GetExtension(imgFile.FileName);
                                string filePath = Path.Combine(Server.MapPath("~/images/"), fileName);
                                imgFile.SaveAs(filePath);
                            }
                        }
                    }
                    TempData["updated"] = "Updated Successfully!";
                    return RedirectToAction("Profile", new { id = student.Id });
                }
            }
            catch(Exception e)
            {
                TempData["exception"] = e.Message;
                TempData["failed"] = "Failed to Update";
            }
            return RedirectToAction("Update", new { id=studentVM.Id});
        }

        public ActionResult ConfirmPassword(string Password, string ConfirmPass)
        {
            bool confirmed = true;
            if (Password != ConfirmPass)
            {
                confirmed = false;
            }
            return Json(confirmed, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChangePassword(int id)
        {
            if (Session["user"] == null || ((string)Session["user"] == "student" && (string)Session["studentId"] != id.ToString()))
            {
                return RedirectToAction("../Home/Login");
            }
            var student = _studentManager.GetById(id);
            User user = new User()
            {
                Id = student.Id,
                Password = student.Password
            };
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangePassword(User user)
        {
            if (_studentManager.ChangePassword(user))
            {
                return RedirectToAction("Profile", new { id = user.Id });
            }
            return View();
        }

        public ActionResult IsUniqueStudentId(int Id, string initialStudentId, string StudentIdNo)
        {
            bool isUnique = _studentManager.IsUniqueStudentId(Id, initialStudentId, StudentIdNo);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsUniqueContactNo(int Id, string initialContactNo, string ContactNo)
        {
            if(!(_studentManager.IsUniqueContactNo(Id, initialContactNo, ContactNo)))
            {
                return Json("Already Exist, Try another ContactNo", JsonRequestBehavior.AllowGet);
            }
            if (!(new Regex(@"^([01]|\+88)?\d{11}").IsMatch(ContactNo)))
            {
                return Json("ContactNo not valid", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUniqueEmail(int Id, string initialEmail, string Email)
        {
            bool isUnique = _studentManager.IsUniqueEmail
                (Id, initialEmail, Email);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsUniqueAccountNo(int Id, string initialAccountNo, string AccountNo)
        {
            bool isUnique = _studentManager.IsUniqueAccountNo(Id, initialAccountNo, AccountNo);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }
    }
}