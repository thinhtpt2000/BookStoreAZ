using BookStoreAZ.Business.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Book Book { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
