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
            Mapper.CreateMap<Publisher, PublisherEntity>();
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            using (var context = new Entities())
            {
                var publishers = context.PublisherEntities.ToList();
                return Mapper.Map<List<PublisherEntity>, List<Publisher>>(publishers);
            }
        }

        public int InsertPublisher(Publisher publisher)
        {
            using (var context = new Entities())
            {
                var publisherEntity = Mapper.Map<Publisher, PublisherEntity>(publisher);
                context.PublisherEntities.Add(publisherEntity);
                context.SaveChanges();
                return publisherEntity.ID;
            }
        }
    }
}