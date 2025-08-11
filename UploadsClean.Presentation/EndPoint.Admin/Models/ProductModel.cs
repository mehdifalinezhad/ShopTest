using EndPoint.Admin.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
       public string Title {get;set;}
       public string ImageUrl {get; set;}
       public IFormFile File {get;set;}
       public int Count {get;set;}
        public string CategoryName { get; set; }
        public string prise {get;set;}
       public int CategoryId { get;set;}

 
    }
}
