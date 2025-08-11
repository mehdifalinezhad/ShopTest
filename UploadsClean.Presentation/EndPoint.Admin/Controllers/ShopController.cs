using EndPoint.Admin.Utilities;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;
using UploadsClean.Common.Dto;
using UploadsClean.Domain.Entities;
using UploadsClean.Persistence.DataBaceContext;

namespace EndPoint.Admin.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext Db;
        private readonly IToastNotification notishow;

        public ShopController(AppDbContext db, IToastNotification notishow)
        {
            Db = db;
            this.notishow = notishow;
        }

        public ActionResult AddToCart(Guid Id,int Quantity=1)
        {
            // string UserId = CurrentUser.Get(); 
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isSuccess=Db.CardItems.Where(c => c.UserId == UserId && c.ProductId==Id).Any();
            if (isSuccess==false)
            {
                CardItem cart = new CardItem()
                {
                    UserId = UserId,
                    Quantity = Quantity,
                    CreatedTime = DateTime.Now,
                    ProductId = Id,
                };
                Db.CardItems.Add(cart);
                Db.SaveChanges();

            }
            else 
            {
                var cartItemBefore = Db.CardItems.Where(C => C.UserId == UserId).FirstOrDefault();
                cartItemBefore.Quantity= cartItemBefore.Quantity+Quantity;
                Db.CardItems.Update(cartItemBefore);
                Db.SaveChanges();
            }

            return Json(new());
        
        }

        public IActionResult ShowCardItem()
        {
            //it may
            // string UserId = CurrentUser.Get(); 
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cardToShow = Db.CardItems.Where(x => x.UserId == UserId).FirstOrDefault();
            CardItemDto cardItemDto = ModelToDto.cardItemModelTODto(cardToShow);
            cardItemDto.Product = Db.Products.Where(c => c.Id == cardToShow.ProductId).ToList();
            return View(cardItemDto);
        }

	}
}
