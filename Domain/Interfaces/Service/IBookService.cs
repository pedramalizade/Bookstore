namespace Domain.Interfaces.Service
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllPagedAsync(int pageNumber, int pageSize)
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
