using BookStoreAZ.Business.BusinessRules;
using System;

namespace BookStoreAZ.Business
{
    public class BookPublisher : BusinessObject
    {
        public BookPublisher()
        {
            AddRule(new ValidateId("ID"));

            AddRule(new ValidateId("BookID"));

            AddRule(new ValidateId("PublisherID"));
        }

        public int ID { get; set; }
        public int BookID { get; set; }
        public int PublisherID { get; set; }
        public DateTime PublishedDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}