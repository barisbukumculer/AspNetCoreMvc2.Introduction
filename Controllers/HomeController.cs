using AspNetCoreMvc2.Introduction.Entities;
using AspNetCoreMvc2.Introduction.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to new AspNet Core Application";
        }


        [HandleException(ViewName = "DivideByZeroError", ExceptionType = typeof(DivideByZeroException))]
        public ViewResult Index2()
        {
            throw new DivideByZeroException();

            return View();
        }

        public ViewResult Index3()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Barış",
                    LastName = "Bükümcüler",
                    CityId = 6,
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Onur",
                    LastName = "Bükümcüler",
                    CityId = 36,
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Ali",
                    LastName = "Bükümcüler",
                    CityId = 75,
                },
            };
            List<string> cities = new List<string> { "İstanbul", "Bursa" };

            var emloyeeListViewModel = new EmployeeListViewModel
            {
                Emloyees = employees,
                cities = cities,
            };

            return View(emloyeeListViewModel);
        }

        public StatusCodeResult Index4()
        {
            //return StatusCode(200);
            return Ok();

        }

        public StatusCodeResult Index5()
        {
            //return StatusCode(400);
            return BadRequest();
        }
        public RedirectResult Index6()
        {
            return Redirect("/Home/Index3");
        }
        public IActionResult Index7()
        {
            return RedirectToAction("Index2");
        }
        public IActionResult Index8()
        {
            return RedirectToRoute("default");
        }
        public JsonResult Index9()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Barış",
                    LastName = "Bükümcüler",
                    CityId = 6,
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Onur",
                    LastName = "Bükümcüler",
                    CityId = 36,
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Ali",
                    LastName = "Bükümcüler",
                    CityId = 75,
                },
            };
            return Json(employees);
        }
        public IActionResult RazorDemo()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Barış",
                    LastName = "Bükümcüler",
                    CityId = 6,
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Onur",
                    LastName = "Bükümcüler",
                    CityId = 36,
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Ali",
                    LastName = "Bükümcüler",
                    CityId = 75,
                },
            };
            List<string> cities = new List<string> { "İstanbul", "Bursa" };

            var emloyeeListViewModel = new EmployeeListViewModel
            {
                Emloyees = employees,
                cities = cities,
            };

            return View(emloyeeListViewModel);
        }

        public JsonResult Index10(string key)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Barış",
                    LastName = "Bükümcüler",
                    CityId = 6,
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Onur",
                    LastName = "Bükümcüler",
                    CityId = 36,
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Ali",
                    LastName = "Bükümcüler",
                    CityId = 75,
                },
            };
            if (String.IsNullOrEmpty(key))
            {
                return Json(employees);
            }
            var result = employees.Where(e => e.FirstName.ToLower().Contains(key));

            return Json(result);
        }
        public ViewResult EmployeeForm()
        {
            return View();
        }

        public string RouteData(int id)
        {
            return id.ToString();
        }
    }
}
