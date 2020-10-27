using BookStoreAZ.Business.BusinessRules;
using BookStoreAZ.Bussiness.BusinessRules;
using System;

namespace BookStoreAZ.Business
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

            //AddRule(new ValidateGuid("OrderID"));
        }

        public int ID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public long SubTotal { get; set; }
        //public Guid OrderID { get; set; }
        public int BookID { get; set; }

        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }
}