

using UploadsClean.Domain.Entities.Users;

namespace UploadsClean.Domain.Entities
{
	public class Order
	{
		public Guid Id { get; set; }
		public ApplicationUser User { get; set; }
		public Guid UserId { get; set; }
		public int TotalPrice { get; set; }
		public DateTime CreationDate { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }
	}
}
