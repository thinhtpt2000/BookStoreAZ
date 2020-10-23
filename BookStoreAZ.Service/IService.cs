using BookStoreAZ.Business;
using System.Collections.Generic;

namespace BookStoreAZ.ActionService
{
    public interface IService
    {
        List<Category> GetCategories();

        Category GetCategoryByBook(int bookID);
    }
}