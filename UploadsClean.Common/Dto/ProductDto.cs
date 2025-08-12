using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadsClean.Domain.Entities;

namespace UploadsClean.Common.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Category> theCategories { get; set; }
    }
}
