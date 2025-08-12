using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadsClean.Domain.Entities;

namespace UploadsClean.Common.Dto
{
	public class OrderDto
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string Customer { get; set; }
		public Decimal TotalPrice { get; set; }
		public OrderStatus orderStatus { get; set; }
		public int statusId { get; set; }

	}
}
