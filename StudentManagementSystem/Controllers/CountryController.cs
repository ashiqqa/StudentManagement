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
    public class CountryController : Controller
    {
        CountryManager _countryManager = new CountryManager();
        // GET: Country
        [HttpGet]
        public ActionResult Add()
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            CountryVM countryVM = new CountryVM();
            countryVM.Countries = _countryManager.GetAll();
            return View(countryVM);
        }

        [HttpPost]
        public ActionResult Add(CountryVM countryVM)
        {
            Country country = Mapper.Map<Country>(countryVM);

            if (_countryManager.Add(country))
            {
                TempData["saved"] = "Country added successfully!";
                CountryVM countryView = new CountryVM();
                countryView.Countries = _countryManager.GetAll();
                return View(countryView);

            }
            return RedirectToAction("Add");
        }

        public JsonResult Delete(int id)
        {
            _countryManager.Delete(id);
            return null;
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var country = _countryManager.GetById(id);
            CountryVM countryVM = Mapper.Map<CountryVM>(country);
            return View(countryVM);
        }

        [HttpPost]
        public ActionResult Update(CountryVM countryVM)
        {
            Country country = Mapper.Map<Country>(countryVM);
            if (_countryManager.Update(country))
            {
                TempData["updated"] = "Updated Successfully!";
                return RedirectToAction("Add");
            }
            TempData["failed"] = "Failed to update!";
            return RedirectToAction("Update");
        }

        public ActionResult Details(int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            StudentManager studentManager = new StudentManager();
            var country = _countryManager.GetById(id);
            CountryVM countryVM = Mapper.Map<CountryVM>(country);
            countryVM.Students = studentManager.GetByCountry(id);
            return View(countryVM);
        }
    }
}