﻿using UploadsClean.Domain.Entities;

namespace UploadsClean.Domain.Entities
{
	public class OrderItem
	{
		public Guid Id { get; set; }
		public Order Order { get; set; }
		public Guid OrderId { get; set; }
		public Product Product { get; set; }
		public Guid ProductId { get; set; }
		public int Count { get; set; }

	}
}
