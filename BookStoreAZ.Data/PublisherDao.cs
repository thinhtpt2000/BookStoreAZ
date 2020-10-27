using AutoMapper;
using BookStoreAZ.Business;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAZ.Data
{
    public class PublisherDao : IPublisherDao
    {
        static PublisherDao()
        {
            Mapper.CreateMap<PublisherEntity, Publisher>();
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            using (var context = new Entities())
            {
                var publishers = context.PublisherEntities.ToList();
                return Mapper.Map<List<PublisherEntity>, List<Publisher>>(publishers);
            }
        }
    }
}