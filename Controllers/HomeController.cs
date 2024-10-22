using AspNetCoreMvc2.Introduction.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to new AspNet Core Application";
        }

        public ViewResult Index2()
        {
            return View();
        }
        public ViewResult Index3()
        {
            List<Employee> emloyees = new List<Employee>
            {
                new Employee{Id=1, FirstName="Barış" , LastName="Bükümcüler" , CityId=6},
                new Employee{Id=2, FirstName="Onur" , LastName="Bükümcüler" , CityId=36},
                new Employee{Id=3, FirstName="Ali" , LastName="Bükümcüler" , CityId=75}
            };
            List<string> cities = new List<string> { "İstanbul", "Bursa" };

            var emloyeeListViewModel = new EmployeeListViewModel
            {
                Emloyees = emloyees,
                cities=cities
            };

            return View(emloyeeListViewModel);
        }
    }
}
