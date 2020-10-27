using BookStoreAZ.Business.BusinessRules;
using System.Collections.Generic;

namespace BookStoreAZ.Business
{
    public class Book : BusinessObject
    {
        public Book()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateRequired("Name"));
            AddRule(new ValidateLength("Name", 1, 256));

            AddRule(new ValidateRequired("Description"));
            AddRule(new ValidateLength("Description", 1, 256));

            AddRule(new ValidateLength("Image", 1, 256));

            AddRule(new ValidateRequired("Price"));
            AddRule(new ValidatePrice("Price"));

            AddRule(new ValidatePrice("Promotion"));

            AddRule(new ValidateRequired("Quantity"));
            AddRule(new ValidateQuantity("Quantity"));

            AddRule(new ValidateId("CategoryID"));
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Promotion { get; set; }
        public bool Status { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}