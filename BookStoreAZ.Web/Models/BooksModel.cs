using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAZ.MVC.Models
{
    public class BooksModel
    {
        public string Message { get; set; }

        // sortable list of members

        public IEnumerable<BookModel> Books { get; set; }
    }
}