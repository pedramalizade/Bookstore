namespace Application.AppSrvice
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookAppService _appService;
        public BookAppService(IBookAppService appService)
        {
            _appService = appService;
        }
        /// <summary>
        /// اضافه کردن کتاب جدید.
        /// </summary>
        public Task AddBookAsync(Book book)
        {
            return _appService.AddBookAsync(book);
        }

        /// <summary>
        /// حذف کتاب بر اساس شناسه.
        /// </summary>
        public Task DeleteBookAsync(int id)
        {
            return _appService.DeleteBookAsync(id);
        }
        /// <summary>
        /// دریافت همه کتاب‌ها.
        /// </summary>
        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return _appService.GetAllBooksAsync();
        }
        /// <summary>
        /// دریافت کتاب‌ها به صورت صفحه‌بندی شده.
        /// </summary>
        public Task<IEnumerable<Book>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return _appService.GetAllPagedAsync(pageNumber, pageSize);
        }
        /// <summary>
        /// دریافت کتاب بر اساس شناسه.
        /// </summary>
        public Task<Book?> GetBookByIdAsync(int id)
        {
            return _appService.GetBookByIdAsync(id);
        }

        /// <summary>
        /// به‌روزرسانی کتاب موجود.
        /// </summary>
        public Task UpdateBookAsync(Book book)
        {
            return _appService.UpdateBookAsync(book);
        }
    }
}
