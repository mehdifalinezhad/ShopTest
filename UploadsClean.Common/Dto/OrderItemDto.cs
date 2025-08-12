using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadsClean.Common.Dto
{
    public class OrderItemDto
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }


    }
}
