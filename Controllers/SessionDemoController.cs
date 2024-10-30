using AspNetCoreMvc2.Introduction.Entities;
using AspNetCoreMvc2.Introduction.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class SessionDemoController : Controller
    {
        public string Index()
        {
            HttpContext.Session.SetInt32("age", 32);
            HttpContext.Session.SetString("name", "Barış");
            HttpContext.Session.SetObject("student", new Student { Email = "asdasd@gmail.com", FirstName = "asd", LastName = "asd123", Id = 24 });

            return "Session Created";
        }

        public string GetSessions()
        {
            return String.Format("Hello {0}, you are {1}.Student is {2}", HttpContext.Session.GetString("name"), HttpContext.Session.GetInt32("age"), HttpContext.Session.GetObject<Student>("student").Email);
        }
    }
}
