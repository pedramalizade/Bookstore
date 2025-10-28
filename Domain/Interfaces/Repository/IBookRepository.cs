using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);    
        Task DeleteBookAsync(int id);
    }
}
