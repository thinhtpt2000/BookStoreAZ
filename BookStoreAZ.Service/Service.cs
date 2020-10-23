using BookStoreAZ.Data;
using System.Collections.Generic;

namespace BookStoreAZ.ActionService
{
    public class Service : IService
    {
        private static readonly IDaoFactory factory = new DaoFactory();

        private static readonly ICategoryDao categoryDao = factory.CategoryDao;

        public List<Business.Category> GetCategories()
        {
            return categoryDao.GetCategories();
        }

        public Business.Category GetCategoryByBook(int bookID)
        {
            return categoryDao.GetCategoryByBook(bookID);
        }
    }
}