using EndPoint.Admin.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public ActionResult AddToCart(int Id, int Quantity = 1)
        {
            var UserId = CurrentUser.Get();
            //if (UserId == null)
            //   {
            //  return Json(new { success = false, redirect = Url.Action("Index", "Home"), message = "هنوز لاگین نکردی" });

            // }
            // var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isSuccess = Db.CardItems.Where(c => c.UserId == UserId && c.ProductId == Id).Any();
            if (isSuccess == false)
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
                return Json(new { success = true,message = "در سبد خرید درج شد" });


            }
            else
            {
                var cartItemBefore = Db.CardItems.Where(C => C.UserId == UserId).FirstOrDefault();
                cartItemBefore.Quantity = cartItemBefore.Quantity + Quantity;
                Db.CardItems.Update(cartItemBefore);
                Db.SaveChanges();
             
                return Json(new { success = true, message = "در سبد خریدتون ویرایش شد" });
            }



        }

        public IActionResult ShowCardItem()
        {
            var UserId = CurrentUser.Get();
            if (UserId == null)
            {
                notishow.AddErrorToastMessage("هنوز لاگین نکردی");
                return RedirectToAction("Index", "Home");
            }
            //var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cardToShow = Db.CardItems.Where(x => x.UserId == UserId).ToList();
            List<CardItemDto> cardItemDto = ModelToDto.cardItemsModelTODto(cardToShow);
            foreach (var item in cardItemDto)
            {
                item.ProductName = Db.Products.Where(c => c.Id == item.ProductId).FirstOrDefault().Name;
                item.ProductPrise = Db.Products.Where(x => x.Id == item.ProductId).FirstOrDefault().Price;
                item.ProductImageUrl = Db.Products.Where(m => m.Id == item.ProductId).FirstOrDefault().ImageUrl;

            }
            return View(cardItemDto);
        }
        [HttpPost]
        public IActionResult BuyProduct(List<CardItemDto> dtos)
        {
            //  List<CardItem> cardItems = DtoToModel.aboutCardsToBuy(dtos);
            var UserId = CurrentUser.Get();
            if (UserId == null)
            {
                notishow.AddErrorToastMessage("هنوز لاگین نکردی");
                return RedirectToAction("Index", "Home");
            }
            //var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            decimal TotalPrice = 0;
            foreach (var item in dtos)
            {
                TotalPrice += item.Quantity * item.ProductPrise;
            }
            Order order = new Order()
            {
                TotalPrice = TotalPrice,
                orderStatus = OrderStatus.Processing,
                UserId = UserId
            };
            Db.Orders.Add(order);
            Db.SaveChanges();
            //this get ScopeIdentity in Order
            var orderId = order.Id;
            
            List<OrderItem> orderItems = new();
            foreach (var item in dtos)
            {
                orderItems.Add(new()
                {
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Count = item.Quantity,
                });
            }
            foreach(var item in  orderItems) 
            {
            Db.OrderItems.Add(item);
                Db.SaveChanges();
            }
            notishow.AddSuccessToastMessage("خرید این اقلام انجام شدو در حال پردازش هست ");
            return RedirectToAction(nameof(ShowCardItem));
        }


        public IActionResult cartDel(int Id)
        {
            var CartToDelete = Db.CardItems.Where(q => q.Id == Id).FirstOrDefault();
            Db.CardItems.Remove(CartToDelete);
            Db.SaveChanges();

            notishow.AddSuccessToastMessage("این ی قلم جنس حذف شد");
            return RedirectToAction(nameof(ShowCardItem));
        }
  
        public IActionResult ChangeCount(int Id,int NewCount)
        {   

            var CartToChangeCount = Db.CardItems.Where(q => q.Id == Id).FirstOrDefault();
            CartToChangeCount.Quantity=NewCount;
            
            Db.CardItems.Update(CartToChangeCount);
            Db.SaveChanges();
            notishow.AddSuccessToastMessage("این ی قلم جنس مقدارش تغییر کرد");
            return RedirectToAction(nameof(ShowCardItem));
        }
    
    
       




    }
}
