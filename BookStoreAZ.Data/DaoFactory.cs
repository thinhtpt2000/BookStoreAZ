namespace BookStoreAZ.Data
{
    public class DaoFactory : IDaoFactory
    {
        public ICategoryDao CategoryDao
        {
            get
            {
                return new CategoryDao();
            }
        }
    }
}