using EndPoint.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using UploadsClean.Common;
using UploadsClean.Domain.Entities;
using UploadsClean.Persistence.DataBaceContext;

namespace EndPoint.Admin.Controllers
{
	public class ProductController : Controller
	{
		private readonly AppDbContext Db;
		private readonly IToastNotification notishow;

		public ProductController(AppDbContext db, IToastNotification notishow)
		{
			Db = db;
			this.notishow = notishow;
		}

		public IActionResult AddProduct()
		{
			var categories = Db.Categories.ToList();
            List<Category> theCategories = categories;
            Product model = new Product()
			{
			theCategories= theCategories	
			};
			return View(model);
		}
		[HttpPost]
		public IActionResult AddProduct(Product modelToAdd)
		{
			var addedProduct = Db.Products.Add(modelToAdd);
			Db.SaveChanges();
            notishow.AddSuccessToastMessage(AppMessage.SUCCESS);

            return RedirectToAction(nameof(ListProduct));
		}


        public IActionResult ListProduct()
        {
            List<Product> ListProducts = Db.Products.ToList();
            Db.SaveChanges();
            return View(ListProducts);
        }

		public IActionResult GetproductById(Guid Id)
		{
			var product = Db.Products.Where(x => x.Id == Id).FirstOrDefault();

            return View(product);
		}

		[HttpPost]
        public IActionResult EditProduct(Product producttoUpdate)
        {
			
			var ProductBefore=Db.Products.Update(producttoUpdate);


            return RedirectToAction(nameof(ListProduct));

        }
     
        public IActionResult DelProduct(Guid Id)
        {
			var productToDel = Db.Products.Where(x => x.Id == Id).FirstOrDefault();
			Db.Products.Remove(productToDel);
			
			Db.SaveChanges();
            return RedirectToAction(nameof(ListProduct));
        }



    }
}
