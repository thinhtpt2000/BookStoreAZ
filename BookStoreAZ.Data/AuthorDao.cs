using AutoMapper;
using BookStoreAZ.Business;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAZ.Data
{
    public class AuthorDao : IAuthorDao
    {
        static AuthorDao()
        {
            Mapper.CreateMap<AuthorEntity, Author>();
        }

        public IEnumerable<Business.Author> GetAuthors()
        {
            using (var context = new Entities())
            {
                var authors = context.AuthorEntities.ToList();
                return Mapper.Map<List<AuthorEntity>, List<Author>>(authors);
            }
        }
    }
}