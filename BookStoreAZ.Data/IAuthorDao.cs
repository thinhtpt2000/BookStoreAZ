using BookStoreAZ.Business;
using System.Collections.Generic;

namespace BookStoreAZ.Data
{
    public interface IAuthorDao
    {
        IEnumerable<Author> GetAuthors();
    }
}