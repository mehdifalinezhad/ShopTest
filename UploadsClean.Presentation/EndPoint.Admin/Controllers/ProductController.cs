using EndPoint.Admin.Models;
using EndPoint.Admin.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using UploadsClean.Common;
using UploadsClean.Common.Dto;
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
            ProductDto model = new ProductDto()
			{
			theCategories= theCategories	
			};
			return View(model);
		}
		[HttpPost]
		public IActionResult AddProduct(ProductDto DtoToAdd)
		{
			Product productToAdd = DtoToModel.AboutAddProduct(DtoToAdd);
			var addedProduct = Db.Products.Add(productToAdd);
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

		public IActionResult GetproductById(int Id)
		{
            string UserId = CurrentUser.Get();
            if (UserId == null)
            {
                notishow.AddErrorToastMessage("هنوز لاگین نکردی");
                return RedirectToAction("Index", "Home");
            }
            var product = Db.Products.Where(x => x.Id == Id).FirstOrDefault();
			ProductDto dto = ModelToDto.AboutProDuctById(product);
			dto.theCategories = Db.Categories.ToList();
            return View(dto);
		}

		[HttpPost]
        public IActionResult EditProduct(ProductDto producttoUpdate)
        {
			var productBefore = Db.Products.Where(x => x.Id == producttoUpdate.Id).FirstOrDefault();
				productBefore.Name= producttoUpdate.Name;
				productBefore.Count = producttoUpdate.Count;
				productBefore.Price = producttoUpdate.Price;
			if (producttoUpdate.ImageFile != null)
			{
				productBefore.ImageUrl = UploadImages.SaveImage(producttoUpdate.ImageFile, "ProductImage");
			}

			productBefore.CategoryId = producttoUpdate.CategoryId;
				
			
			var ProductUpdate=Db.Products.Update(productBefore);
			Db.SaveChanges();
			notishow.AddSuccessToastMessage("محصول ویرایش شد");

			return RedirectToAction(nameof(ListProduct));

        }
     
        public IActionResult DelProduct(int Id)
        {
			var productToDel = Db.Products.Where(x => x.Id == Id).FirstOrDefault();
			Db.Products.Remove(productToDel);
			
			Db.SaveChanges();

            notishow.AddSuccessToastMessage("جنس حذف شد");
            return RedirectToAction(nameof(ListProduct));
        }



    }
}
