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
    public class SesionController : Controller
    {

        SessionManager _sessionManager = new SessionManager();

        [HttpGet]
        public ActionResult Add()
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            SesionVM sessionVM = new SesionVM();
            sessionVM.Sesions = _sessionManager.GetAll();
            return View(sessionVM);
        }
        [HttpPost]
        public ActionResult Add(SesionVM sessionVM)
        {
            Sesion session = Mapper.Map<Sesion>(sessionVM);
            if (_sessionManager.Add(session))
            {
                TempData["saved"] = "Saved Successfully!";
                return RedirectToAction("Add");
            }
            return View();
        }

        public JsonResult Delete(int id)
        {
            _sessionManager.Delete(id);
            return null;
        }

        [HttpGet]

        public ActionResult Update(int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var session = _sessionManager.GetById(id);
            SesionVM sessionVM = Mapper.Map<SesionVM>(session);
            return View(sessionVM);
        }

        [HttpPost]
        public ActionResult Update(SesionVM sesionVM)
        {
            Sesion session = Mapper.Map<Sesion>(sesionVM);
            if (_sessionManager.Update(session))
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
            var sesion = _sessionManager.GetById(id);
            SesionVM sesionVM = Mapper.Map<SesionVM>(sesion);
            sesionVM.Students = studentManager.GetBySession(id);
            return View(sesionVM);
        }
    }
}