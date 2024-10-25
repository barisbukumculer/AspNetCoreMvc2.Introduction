using AspNetCoreMvc2.Introduction.Entities;
using AspNetCoreMvc2.Introduction.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspNetCoreMvc2.Introduction.Controllers
{
	public class EmployeeController : Controller
	{
		private ICalculator _calculator;

		public EmployeeController(ICalculator calculator)
		{
			_calculator = calculator;
		}

		public IActionResult Add()
		{
			var employeeAddViewModel = new EmployeeAddViewModel
			{
				Employee = new Employee(),
				Cities = new List<SelectListItem>
				{
				   new SelectListItem{Text="Ankara",Value="6"},
					new SelectListItem{Text="Istanbul",Value="34"},
				}
			};
			return View(employeeAddViewModel);
		}
		[HttpPost]
		public IActionResult Add(Employee employee)
		{
			return View();
		}
		public string Calculate()
		{
			_calculator.Calculate(100);
			return _calculator.Calculate(100).ToString();
		}
	}
}
