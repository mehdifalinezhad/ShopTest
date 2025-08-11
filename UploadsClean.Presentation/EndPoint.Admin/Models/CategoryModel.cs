using System.ComponentModel.DataAnnotations;
namespace EndPoint.Admin.Models
{ 
	public class CategoryModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="این باید پر شود")]
		public string Title { get; set; }
        public string ImageUrl { get; set; }
	
		public string ImageUrlLow { get; set; }
		
        [Required(ErrorMessage = "این باید پر شود")]
		public IFormFile File { get; set; }	
		
	}
}