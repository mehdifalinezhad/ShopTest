namespace EndPoint.Admin.Models
{

    public class GetPROductByIdmodel
    {   

        public int Id { set; get; }
        public string Name { set; get; }
        public string Prise { set; get; }
        public int DisCoutFkey { set; get;}
        public string imageUrl { set; get;}
        public string Discount { set; get;}
        public int CategoryId { set; get;}
        public string percentage { set; get; }
        public string OcationName { set; get; }
        public int Count { set; get; }
        public string CategotyName { set; get; }
    }
}   