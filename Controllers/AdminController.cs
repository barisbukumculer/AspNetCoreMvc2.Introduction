using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc2.Introduction.Controllers
{
	[Route("admin")]
	public class AdminController : Controller
	{
		[Route("")]
		[Route("save")]
		[Route("~/save")]
		public string Save()
		{
			return "Saved";
		}
		[Route("delete")]
		[Route("delete/{id?}")]
		public string Delete(int id = 0)
		{
			return string.Format("Deleted {0}", id);
		}
		[Route("update")]
		public string Update()
		{
			return "Updated";
		}
	}
}
