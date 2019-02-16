using AutoMapper;
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
    public class SemisterController : Controller
    {
        SemisterManager _semisterManager = new SemisterManager();

        [HttpGet]
        public ActionResult Add()
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            SemisterVM semisterVM = new SemisterVM();
            semisterVM.Semisters = _semisterManager.GetAll();
            return View(semisterVM);
        }
        [HttpPost]
        public ActionResult Add(SemisterVM semisterVM)
        {
            Semister semister = Mapper.Map<Semister>(semisterVM);
            if (_semisterManager.Add(semister))
            {
                TempData["saved"] = "Saved Successfully!";
                return RedirectToAction("Add");
            }
            return View();
        }

        public JsonResult Delete(int id)
        {
            _semisterManager.Delete(id);
            return null;
        }

        [HttpGet]
        public ActionResult Update( int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var semister = _semisterManager.GetById(id);
            SemisterVM semisterVM = Mapper.Map<SemisterVM>(semister);
            return View(semisterVM);
        }

        [HttpPost]
        public ActionResult Update(SemisterVM semisterVM)
        {
            Semister semister = Mapper.Map<Semister>(semisterVM);
            if (_semisterManager.Update(semister))
            {
                TempData["updated"] = "Updated successfully!";
                return RedirectToAction("Add");
            }
            TempData["failed"] = "Failed to update";
            return View();
        }

        public ActionResult Details(int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            StudentManager studentManager = new StudentManager();
            var semester = _semisterManager.GetById(id);
            SemisterVM semesterVM = Mapper.Map<SemisterVM>(semester);
            semesterVM.Students = studentManager.GetBySemister(id);
            return View(semesterVM);
        }
    }
}