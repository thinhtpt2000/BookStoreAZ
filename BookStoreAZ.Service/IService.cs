using BookStoreAZ.Business;
using System.Collections.Generic;

namespace BookStoreAZ.Service
{
    public interface IService
    {
        List<Category> GetCategories();

        Category GetCategoryByBook(int bookID);
    }
}