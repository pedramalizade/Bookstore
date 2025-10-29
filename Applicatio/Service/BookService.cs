using Domain.Entities;
using Domain.Interfaces.Service;

namespace Application.Service
{
    public class BookService : IBookService
    {
        private readonly IBookService _bookService;
        public BookService(IBookService bookService)
        {
            _bookService = bookService;
        }
        public Task AddBookAsync(Book book)
        {
            return _bookService.AddBookAsync(book);
        }

        public Task DeleteBookAsync(int id)
        {
            return _bookService.DeleteBookAsync(id);
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return _bookService.GetAllBooksAsync();
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            return _bookService.GetBookByIdAsync(id);
        }

        public Task UpdateBookAsync(Book book)
        {
            return _bookService.UpdateBookAsync(book);
        }
    }
}
