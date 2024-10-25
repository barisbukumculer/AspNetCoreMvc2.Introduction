using AspNetCoreMvc2.Introduction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreMvc2.Introduction.ViewComponents
{
    public class StudentListViewComponent : ViewComponent
    {
        private readonly SchoolContext _schoolContext;

        public StudentListViewComponent(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public IViewComponentResult Invoke(string filter)
        {
            filter = HttpContext.Request.Query[filter];

            return View(new StudentListViewModel
            {
                Students = _schoolContext.Students.Where(s => s.FirstName.ToLower().Contains(filter)).ToList()
            });
        }
    }
}
