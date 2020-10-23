using BookStoreAZ.Business.BusinessRules;
using System;
using System.Collections.Generic;

namespace BookStoreAZ.Business
{
    public class Category : BusinessObject
    {
        public Category()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateRequired("Name"));
            AddRule(new ValidateLength("Name", 1, 256));

            AddRule(new ValidateLength("Description", 0, 500));
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual IEnumerable<Book> Books { set; get; }
    }
}