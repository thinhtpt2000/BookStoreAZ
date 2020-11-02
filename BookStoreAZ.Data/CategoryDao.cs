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
            Mapper.CreateMap<Category, CategoryEntity>();
            Mapper.CreateMap<BookEntity, Book>();
        }

        public IEnumerable<Category> GetCategories()
        {
            using (var context = new Entities())
            {
                var categories = context.CategoryEntities.Where(c => c.Status == true).ToList();
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

        public int InsertCategory(Category category)
        {
            using (var context = new Entities())
            {
                var categoryEntity = Mapper.Map<Category, CategoryEntity>(category);
                context.CategoryEntities.Add(categoryEntity);
                context.SaveChanges();
                category.ID = categoryEntity.ID;
                return category.ID;
            }
        }
    }
}