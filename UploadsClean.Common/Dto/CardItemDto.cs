using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadsClean.Domain.Entities;

namespace UploadsClean.Common.Dto
{
	public class CardItemDto
	{
		public int Id { get; set; }
		public string? UserId { get; set; }

		public int ProductId { get; set; }
		public List<Product>? Product { get; set; }
		public string ProductName { get; set; }
		public int ProductPrise { get; set; }
		public string ProductImageUrl { get; set; }
		public int Quantity { get; set; } = 1;
		public string CreatedTime { get; set; }
	}
}
