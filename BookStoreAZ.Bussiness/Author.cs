using BookStoreAZ.Business.BusinessRules;
using System;
using System.Collections.Generic;

namespace BookStoreAZ.Business
{
    public class Author : BusinessObject
    {
        public Author()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateRequired("Name"));
            AddRule(new ValidateLength("Name", 1, 256));

            AddRule(new ValidateLength("Country", 0, 256));
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}