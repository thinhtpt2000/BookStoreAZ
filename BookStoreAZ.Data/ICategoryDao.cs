using BookStoreAZ.Business;
using System.Collections.Generic;

namespace BookStoreAZ.Data
{
    public interface ICategoryDao
    {
        IEnumerable<Category> GetCategories();

        Category GetCategoryByBook(int bookID);

        int InsertCategory(Category category);
    }
}