using BookStoreAZ.Business.BusinessRules;
using System;
using System.Collections.Generic;

namespace BookStoreAZ.Business
{
    public class Publisher : BusinessObject
    {
        public Publisher()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateRequired("Name"));
            AddRule(new ValidateLength("Name", 1, 256));

            AddRule(new ValidateLength("Description", 0, 500));
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}