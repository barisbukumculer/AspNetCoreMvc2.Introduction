using AspNetCoreMvc2.Introduction.Entities;
using AspNetCoreMvc2.Introduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvc2.Introduction.Pages.Studentp
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _schoolContext;

        public IndexModel(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public List<Student> Students { get; set; }
        public void OnGet(string search)
        {
            Students = string.IsNullOrEmpty(search)
                ? _schoolContext.Students.ToList()
                : _schoolContext.Students.Where(s => s.FirstName.ToLower().Contains(search)).ToList();

        }
        [BindProperty]
        public Student Student { get; set; }
        public IActionResult OnPost()
        {
            _schoolContext.Add(Student);
            _schoolContext.SaveChanges();

            return RedirectToPage("/Studentp/Index");
        }

    }
}
