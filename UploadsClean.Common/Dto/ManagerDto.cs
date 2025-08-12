using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadsClean.Common.Dto
{
	public class ManagerDto
	{
		public int AllUsers {get; set;}
		public List<OrderDto> ordersDto {get; set;}
		public int OrderCount {get; set;}
		public int AllSellCount {get; set;}
		public decimal AllSellPrice {get; set;}
	}
}
