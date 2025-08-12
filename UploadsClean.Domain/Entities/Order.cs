

using UploadsClean.Domain.Entities.Users;

namespace UploadsClean.Domain.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public Decimal TotalPrice { get; set; }
		public OrderStatus orderStatus { get; set; }
       
	}


    public enum OrderStatus
    {
        Processing = 1, // در حال پردازش
        Sended = 2,    // ارسال شده
        Delivered = 3   // تحویل داده شده
    }


}
