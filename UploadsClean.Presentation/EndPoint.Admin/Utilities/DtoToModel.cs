using EndPoint.Admin.Models;
using System.Security.Claims;
using UploadsClean.Common;
using UploadsClean.Common.Dto;
using UploadsClean.Domain.Entities;
using UploadsClean.Domain.Entities.Users;


namespace EndPoint.Admin.Utilities
{
    public static class DtoToModel
    {
        public static ApplicationUser UserModelToDto(UserDto userdto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FarsiFirstName = userdto.FarsiFirstName,
                Password = userdto.Password,
                FarsiLastName = userdto.FarsiLastName,
                PhoneNumber = userdto.PhoneNumber,
                Role = userdto.Role,
                UserName = userdto.UserName,
                Email = userdto.Email

            };
            return user;
        }
	
		public static ApplicationUser UserSignInModelToDto(signInDto signDto)
        {
            ApplicationUser user = new ApplicationUser()
            {

                UserName = signDto.Username,
                Password = signDto.Password,

            };
            return user;
        }
        public static Product AboutAddProduct(ProductDto dto)
        {
            Product product = new Product()
            {
                Name = dto.Name,
                Count = dto.Count,
                Price = dto.Price,
                ImageUrl = (dto.ImageFile == null) ? "" : UploadImages.SaveImage(dto.ImageFile, "ProductImage"),
                CategoryId = dto.CategoryId,

            };
            return product;

        }

        public static List<CardItem> aboutCardsToBuy(List<CardItemDto> dtos)
        {
            List<CardItem> models = new();
            foreach (var item in dtos)
            {
                models.Add(new CardItem()
                {
                    Id =item.Id,
                    ProductId = item.ProductId,
                   
                    Quantity = item.Quantity,
                });
            } 

            
            return models;


        }

	}
}