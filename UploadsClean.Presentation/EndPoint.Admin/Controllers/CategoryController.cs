using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using UploadsClean.Domain.Entities;
using UploadsClean.Persistence.DataBaceContext;

namespace EndPoint.Admin.Controllers
{
	public class CategoryController : Controller
	{
		private readonly AppDbContext Db;
		private readonly IToastNotification notishow;

		public CategoryController(AppDbContext db, IToastNotification notishow)
		{
			Db = db;
			this.notishow = notishow;
		}

		public IActionResult AddCategory()
		{
			
			return View(new Category()); 
		
		}
		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			Db.Categories.Add(category);
			Db.SaveChanges();
			return View(category);
		}
	}
}
