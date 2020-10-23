using BookStoreAZ.Business.BusinessRules;
using System;
using System.Collections.Generic;

namespace BookStoreAZ.Business
{
    public class Order : BusinessObject
    {
        public Order()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateRequired("CustomerName"));
            AddRule(new ValidateLength("CustomerName", 1, 256));

            AddRule(new ValidateRequired("CustomerAddress"));
            AddRule(new ValidateLength("CustomerAddress", 1, 256));

            AddRule(new ValidateRequired("CustomerPhone"));
            AddRule(new ValidateLength("CustomerPhone", 1, 10));
            AddRule(new ValidatePhone("CustomerPhone"));

            AddRule(new ValidateRequired("CustomerNote"));
            AddRule(new ValidateLength("CustomerNote", 0, 256));

            AddRule(new ValidateRequired("Total"));
            AddRule(new ValidatePrice("Total"));

            AddRule(new ValidateId("PaymentMethodID"));
        }

        public int ID { get; set; }
        public int CustomerID { get; set; }
        public User User { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerNote { get; set; }
        public DateTime CreatedDate { get; set; }
        public long Total { get; set; }
        public int PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}