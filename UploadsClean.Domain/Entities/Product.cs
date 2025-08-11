namespace UploadsClean.Domain.Entities
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Count { get; set; }
		public int Price { get; set; }
		public string ImageUrl { get; set; }
		public Category Category { get; set; }
		public Guid CategoryId { get; set; }
		public List<Category> theCategories { get; set; }


	}
}
