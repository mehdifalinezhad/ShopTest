using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadsClean.Domain.Entities
{
    public class CardItem
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; } = 1;
        public DateTime CreatedTime { get; set; } 
    
    }
}
