namespace BookStoreAZ.Data
{
    public interface IDaoFactory
    {
        ICategoryDao CategoryDao { get; }
    }
}