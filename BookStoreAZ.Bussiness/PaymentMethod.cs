using BookStoreAZ.Bussiness.BusinessRules;

namespace BookStoreAZ.Bussiness
{
    public class PaymentMethod : BusinessObject
    {
        public PaymentMethod()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateRequired("Name"));
            AddRule(new ValidateLength("Name", 1, 256));
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }
    }
}