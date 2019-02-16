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
    public class CityController : Controller
    {
        CityManager _cityManager = new CityManager();
        CountryManager _countryManager = new CountryManager();
        
        [HttpGet]
        public ActionResult Add()
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            CityVM cityVM = new CityVM();
            cityVM.Cities = _cityManager.GetAll();
            cityVM.CountryLookup = _countryManager.Lookup();
            return View(cityVM);
        }

        [HttpPost]
        public ActionResult Add(CityVM cityVM)
        {
            City city = Mapper.Map<City>(cityVM);
            if (_cityManager.Add(city))
            {
                TempData["saved"] = "Saved Successfully";
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }

        public JsonResult Delete(int id)
        {
            _cityManager.Delete(id);
            return null;
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            var city = _cityManager.GetById(id);
            CityVM cityVM = Mapper.Map<CityVM>(city);
            cityVM.CountryLookup = _countryManager.Lookup();
            return View(cityVM);
        }

        [HttpPost]
        public ActionResult Update(CityVM cityVM)
        {
            City city = Mapper.Map<City>(cityVM);
            if (_cityManager.Update(city))
            {
                TempData["updated"] = "Updated sauccessfully!";
                return RedirectToAction("Add");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            if ((string)Session["user"] != "admin")
            {
                return RedirectToAction("../Home/Login");
            }
            StudentManager studentManager = new StudentManager();
            var city = _cityManager.GetById(id);
            CityVM cityVM = Mapper.Map<CityVM>(city);
            cityVM.Students = studentManager.GetByCity(id);
            return View(cityVM);
        }
    }
}