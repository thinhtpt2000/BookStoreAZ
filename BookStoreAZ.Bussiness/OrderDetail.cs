using BookStoreAZ.Bussiness.BusinessRules;

namespace BookStoreAZ.Bussiness
{
    public class OrderDetail : BusinessObject
    {
        public OrderDetail()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateQuantity("Quantity"));

            AddRule(new ValidatePrice("Price"));

            AddRule(new ValidatePrice("SubTotal"));

            AddRule(new ValidateId("BookID"));

            AddRule(new ValidateId("OrderID"));
        }

        public int ID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public long SubTotal { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}