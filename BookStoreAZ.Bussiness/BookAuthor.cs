using BookStoreAZ.Business.BusinessRules;
using System;
using System.Net;

namespace BookStoreAZ.Business
{
    public class BookAuthor : BusinessObject
    {
        public BookAuthor()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateId("BookID"));

            AddRule(new ValidateId("AuthorID"));
        }

        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}