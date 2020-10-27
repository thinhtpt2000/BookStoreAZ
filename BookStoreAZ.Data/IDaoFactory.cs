namespace BookStoreAZ.Data
{
    public interface IDaoFactory
    {
        ICategoryDao CategoryDao { get; }
        IBookDao BookDao { get;  }
        IAuthorDao AuthorDao { get; }
        IPublisherDao PublisherDao { get; }
    }
}