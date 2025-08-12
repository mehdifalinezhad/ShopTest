using EndPoint.Admin.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NToastNotify;
using System.Drawing.Text;
using System.Net;
using UploadsClean.Common.Dto;
using UploadsClean.Domain.Entities;
using UploadsClean.Domain.Entities.Users;
using UploadsClean.Persistence.DataBaceContext;

namespace EndPoint.Admin.Controllers
{
	public class ManagerController : Controller
	{
		private readonly AppDbContext Db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IToastNotification notishow;

		public ManagerController(AppDbContext db, IToastNotification notishow, UserManager<ApplicationUser> userManager)
		{
			Db = db;
			this.notishow = notishow;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var orders = Db.Orders.ToList();
		    List<OrderDto> orderDtos = ModelToDto.AboutOrder(orders);
			foreach (var item in orderDtos)
			{
               item.Customer= _userManager.Users.Where(c=>c.Id==item.UserId).FirstOrDefault().UserName;
            }

            decimal AllOrdersSell = 0;
			foreach (var item in orders)
			{
				AllOrdersSell += item.TotalPrice;
			}
			ManagerDto mainDto = new ManagerDto() 
		    {

			AllUsers= _userManager.Users.Count(),
			ordersDto= orderDtos,
			OrderCount=orders.Count(),
			AllSellPrice= AllOrdersSell
			};
		     return View(mainDto);
		}
        public IActionResult OrderItemByOrderId(int OrderId)
        {
            List<OrderItem> items = Db.OrderItems.Where(q => q.OrderId == OrderId).ToList();
			List<OrderItemDto> orderItemDto = ModelToDto.AboutOrderItem(items);
			foreach (var item in orderItemDto)
			{
				item.product = Db.Products.Where(z => z.Id == item.ProductId).FirstOrDefault();			
			    
			}
            return View(orderItemDto);
        }

		public IActionResult UpdateStatus(int OrderId, int Status)
		{
			var orderbefore=Db.Orders.Where(q => q.Id==OrderId).FirstOrDefault();
			switch(Status)
		    {
				case 1:
                orderbefore.orderStatus = UploadsClean.Domain.Entities.OrderStatus.Processing;
			    break;
                case 2:
                    orderbefore.orderStatus = UploadsClean.Domain.Entities.OrderStatus.Sended;
                    break;
                case 3:
                    orderbefore.orderStatus = UploadsClean.Domain.Entities.OrderStatus.Delivered;
                    break;
            }
			Db.Orders.Update(orderbefore);
			Db.SaveChanges();
			
            notishow.AddAlertToastMessage("وضعیت تغعیر کرد");
			return RedirectToAction(nameof(Index));
		}
    }
}
