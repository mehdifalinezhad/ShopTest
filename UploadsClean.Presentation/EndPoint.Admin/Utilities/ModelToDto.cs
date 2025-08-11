using EndPoint.Admin.Models;
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

namespace EndPoint.Admin.Utilities
{
	public static class ModelToDto
	{
         public static ApplicationUser UserModelToDto(UserModel user)
		{
			ApplicationUser userdto = new ApplicationUser() {
				FarsiFirstName = user.FarsiFirstName,
				Password = user.Password,
				FarsiLastName = user.FarsiLastName,
				PhoneNumber = user.PhoneNumber,
				Role = user.Role,
				UserName = user.UserName,
				Email = user.Email
				
			};
			return userdto;
		}


		public static ApplicationUser UserSignInModelToDto(SignInmodelv user)
		{
			ApplicationUser userdto = new ApplicationUser()
			{
				
				UserName = user.Username,
				Password = user.Password,

			};
			return userdto;
		}


		public static CardItemDto cardItemModelTODto (CardItem cardItem)
		{
			CardItemDto dto = new CardItemDto()
			{
				Id = cardItem.Id,
				ProductId = cardItem.ProductId,
				CreatedTime = Pub.ToPersionDate(cardItem.CreatedTime),
				Quantity = cardItem.Quantity,
				UserId = cardItem.UserId
			};

			return dto;
        }


    }
}
