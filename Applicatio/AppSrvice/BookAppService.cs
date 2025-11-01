using Domain.Entities;
using Domain.Interfaces.AppService;

namespace Application.AppSrvice
{
    public class BookAppService : IAppService
    {
        private readonly IAppService _appService;
        public BookAppService(IAppService appService)
        {
                _appService = appService;
        }
        public Task AddBookAsync(Book book)
        {
            return _appService.AddBookAsync(book);
        }

        public Task DeleteBookAsync(int id)
        {
            return _appService.DeleteBookAsync(id);
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return _appService.GetAllBooksAsync();
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            return _appService.GetBookByIdAsync(id);
        }

        public Task UpdateBookAsync(Book book)
        {
            return _appService.UpdateBookAsync(book);
        }
    }
}
