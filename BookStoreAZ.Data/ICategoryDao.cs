using System.Collections.Generic;

namespace BookStoreAZ.Data
{
    public interface ICategoryDao
    {
        List<Business.Category> GetCategories();

        Business.Category GetCategoryByBook(int bookID);
    }
}