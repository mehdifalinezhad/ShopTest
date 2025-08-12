using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadsClean.Domain.Entities;

namespace UploadsClean.Common.Dto
{
    public class OrderItemDto
    {
      
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public Product product { get; set; }


    }
}
