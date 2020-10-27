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

        public IBookDao BookDao
        {
            get
            {
                return new BookDao();
            }
        }

        public IAuthorDao AuthorDao
        {
            get
            {
                return new AuthorDao();
            }
        }

        public IPublisherDao PublisherDao
        {
            get
            {
                return new PublisherDao();
            }
        }
    }
}