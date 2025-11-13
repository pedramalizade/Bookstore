namespace Application.AppSrvice
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookAppService _appService;
        public BookAppService(IBookAppService appService)
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

        public Task<IEnumerable<Book>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return _appService.GetAllPagedAsync(pageNumber, pageSize);  
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
