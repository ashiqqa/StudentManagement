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
    public class BankController : Controller
    {
        BankManager _bankManager = new BankManager();

        [HttpGet]
        public ActionResult Add()
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            BankVM bankVM = new BankVM();
            bankVM.Banks = _bankManager.GetAll();
            return View(bankVM);
        }

        [HttpPost]
        public ActionResult Add(BankVM bankVM)
        {
            Bank bank = Mapper.Map<Bank>(bankVM);
            if (_bankManager.Add(bank))
            {
                TempData["saved"] = "Bank added successfully!";
                return RedirectToAction("Add");
            }
            TempData["failed"] = "Failed to add";
            return View();
        }

        public JsonResult Delete(int id)
        {
            _bankManager.Delete(id);
            return null;
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var bankVM = Mapper.Map<BankVM>(_bankManager.GetById(id));
            return View(bankVM);
        }

        [HttpPost]
        public ActionResult Update(BankVM bankVM)
        {
            Bank bank = Mapper.Map<Bank>(bankVM);
            if (_bankManager.Update(bank))
            {
                TempData["updated"] = "Updated successfully";
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
            var bank = _bankManager.GetById(id);
            BankVM bankVM = Mapper.Map<BankVM>(bank);
            bankVM.BankAccounts = studentManager.GetByBank(id);
            return View(bankVM);
        }

    }
}