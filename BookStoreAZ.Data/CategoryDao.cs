using AutoMapper;
using BookStoreAZ.Business;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAZ.Data
{
    public class CategoryDao : ICategoryDao
    {
        static CategoryDao()
        {
            Mapper.CreateMap<CategoryEntity, Category>();
            Mapper.CreateMap<BookEntity, Book>();
        }

        public IEnumerable<Category> GetCategories()
        {
            using (var context = new Entities())
            {
                var categories = context.CategoryEntities.ToList();
                return Mapper.Map<List<CategoryEntity>, List<Category>>(categories);
            }
        }

        public Category GetCategoryByBook(int bookID)
        {
            using (var context = new Entities())
            {
                var book = context.BookEntities.SingleOrDefault(p => p.ID == bookID);
                var category = context.CategoryEntities.SingleOrDefault(c => c.ID == book.CategoryID);

                return Mapper.Map<CategoryEntity, Category>(category);
            }
        }
    }
}