using EndPoint.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadsClean.Common;
using UploadsClean.Common.Dto;
using UploadsClean.Domain.Entities;
using UploadsClean.Domain.Entities.Users;
using UploadsClean.Persistence.DataBaceContext;

namespace EndPoint.Admin.Utilities
{
	public static class ModelToDto
	{
		public static UserDto AboutEditUser(ApplicationUser? User)
		{
			UserDto dto = new UserDto()
			{
				Id=User.Id,	
				FarsiFirstName = User.FarsiFirstName,
				Password = User.Password,
				FarsiLastName = User.FarsiLastName,
				PhoneNumber = User.PhoneNumber,
				Role = User.Role,
				UserName = User.UserName,
				Email = User.Email


			};
			return dto;
		}

		public static List<CardItemDto> cardItemsModelTODto(List<CardItem> cardItems)
		{
			List<CardItemDto> dtos = new();
			
		    foreach(var item in cardItems)
			{
				dtos.Add(new CardItemDto()
				{
					Id = item.Id,
					ProductId = item.ProductId,
					CreatedTime = Pub.ToPersionDate(item.CreatedTime),
					Quantity = item.Quantity,
					UserId = item.UserId,
				
				});
				
			};

			return dtos;
        }
		public static ProductDto AboutProDuctById(Product ProModel)
		{
			ProductDto dto = new ProductDto()
			{ 
			
				Id = ProModel.Id,	
				Name= ProModel.Name,
				Count= ProModel.Count,
				Price=ProModel.Price,
				CategoryId=ProModel.CategoryId,
				ImageUrl=ProModel.ImageUrl,			
			};
            return dto;
		}

		public static List<OrderDto> AboutOrder(List<Order> orders) 
		{
			List<OrderDto> dtos = new();
			foreach (var item in orders)
			{
				dtos.Add(new OrderDto()
				{
					Id = item.Id,
					orderStatus=item.orderStatus,
					TotalPrice=item.TotalPrice,
					UserId = item.UserId
				});

			};

			return dtos;
		
		}

        public static List<OrderItemDto> AboutOrderItem(List<OrderItem> Items)
        {
            List<OrderItemDto> dtos = new();

            foreach (var item in Items)
            {
                dtos.Add(new OrderItemDto()
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Count = item.Count,
					OrderId=item.OrderId,
                    
                });

            };

            return dtos;
        }

    }
}
