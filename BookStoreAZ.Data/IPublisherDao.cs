using BookStoreAZ.Business;
using System.Collections.Generic;

namespace BookStoreAZ.Data
{
    public interface IPublisherDao
    {
        IEnumerable<Publisher> GetPublishers();

        int InsertPublisher(Publisher publisher);
    }
}