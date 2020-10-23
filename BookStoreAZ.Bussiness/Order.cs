using BookStoreAZ.Business.BusinessRules;
using BookStoreAZ.Bussiness.BusinessRules;
using System;
using System.Collections.Generic;

namespace BookStoreAZ.Business
{
    public class Order : BusinessObject
    {
        public Order()
        {
            AddRule(new ValidateGuid("ID"));

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

        public Guid ID { get; set; }
        public int UserID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerNote { get; set; }
        public DateTime CreatedDate { get; set; }
        public long Total { get; set; }
        public int PaymentMethodID { get; set; }

        public virtual User User { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}