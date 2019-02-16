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
    public class DepartmentController : Controller
    {
        DepartmentManager _deptManager = new DepartmentManager();
        // GET: Department
        [HttpGet]
        public ActionResult Add()
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            DepartmentVM department = new DepartmentVM();
            department.Departments = _deptManager.GetAll();
            return View(department);
        }

        [HttpPost]
        public ActionResult Add(DepartmentVM departmentVM)
        {
            Department department = Mapper.Map<Department>(departmentVM);
            if (_deptManager.Add(department))
            {
               TempData["saved"] = "Saved Successfully!";
                DepartmentVM dept = new DepartmentVM();
                dept.Departments = _deptManager.GetAll();
                return View(dept);
            }
            return RedirectToAction("Add");
        }

        public JsonResult Delete(int id)
        {
            _deptManager.Delete(id);
            return null;
        }

        [HttpGet]
        public ActionResult Update( int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var department = _deptManager.GetById(id);
            DepartmentVM deptVM = Mapper.Map<DepartmentVM>(department);
            deptVM.initialCode = department.Code;
            return View(deptVM);
        }
        [HttpPost]
        public ActionResult Update(DepartmentVM deptVM)
        {
            Department department = Mapper.Map<Department>(deptVM);
            if (_deptManager.Update(department))
            {
                TempData["updated"] = "Updated Successfully";
                return RedirectToAction("Add");
            }
            TempData["failed"] = "Failed to update";
            return RedirectToAction("Update");
        }

        public ActionResult Details(int deptId)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            StudentManager studentManager = new StudentManager();
            var department = _deptManager.GetById(deptId);
            DepartmentVM deptVM = Mapper.Map<DepartmentVM>(department);
            deptVM.Students = studentManager.GetByDepartment(deptId);
            return View(deptVM);
        }

        public ActionResult IsUniqueCode(int Id, string initialCode, string Code)
        {
            bool isUnique = _deptManager.IsUniqueCode(Id, initialCode, Code);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }
    }
}