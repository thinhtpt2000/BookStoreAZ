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

        public Category Category { get; set; }
        public virtual IEnumerable<BookAuthor> BookAuthors { get; set; }
        public virtual IEnumerable<BookPublisher> BookPublishers { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}