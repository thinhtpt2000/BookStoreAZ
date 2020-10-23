using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAZ.Data
{
    public class CategoryDao : ICategoryDao
    {
        static CategoryDao()
        {
            Mapper.CreateMap<Category, Business.Category>();
            Mapper.CreateMap<Book, Business.Book>();
        }

        public List<Business.Category> GetCategories()
        {
            using (var context = new Entities())
            {
                var categories = context.Categories.ToList();
                return Mapper.Map<List<Category>, List<Business.Category>>(categories);
            }
        }

        public Business.Category GetCategoryByBook(int bookID)
        {
            using (var context = new Entities())
            {
                var book = context.Books.SingleOrDefault(p => p.ID == bookID);
                var category = context.Categories.SingleOrDefault(c => c.ID == book.CategoryID);

                return Mapper.Map<Category, Business.Category>(category);
            }
        }
    }
}