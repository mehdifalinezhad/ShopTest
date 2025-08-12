using EndPoint.Admin.Models;
using System.Security.Claims;
using UploadsClean.Common;
using UploadsClean.Common.Dto;
using UploadsClean.Domain.Entities;


namespace EndPoint.Admin.Utilities
{
    public static class DtoToModel
    {


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