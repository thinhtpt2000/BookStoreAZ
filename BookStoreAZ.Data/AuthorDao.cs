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
            Mapper.CreateMap<Author, AuthorEntity>();
        }

        public IEnumerable<Business.Author> GetAuthors()
        {
            using (var context = new Entities())
            {
                var authors = context.AuthorEntities.ToList();
                return Mapper.Map<List<AuthorEntity>, List<Author>>(authors);
            }
        }

        public int InsertAuthor(Author author)
        {
            using (var context = new Entities())
            {
                if (author.DateOfBirth == default(System.DateTime))
                {
                    author.DateOfBirth = null;
                }
                var authorEntity = Mapper.Map<Author, AuthorEntity>(author);
                context.AuthorEntities.Add(authorEntity);
                context.SaveChanges();
                return authorEntity.ID;
            }
        }
    }
}