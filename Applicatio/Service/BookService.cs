namespace Application.Service
{
    public class BookService : IBookService
    {
        private readonly IBookService _bookService;
        public BookService(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// اضافه کردن کتاب جدید.
        /// </summary>
        public Task AddBookAsync(Book book)
        {
            return _bookService.AddBookAsync(book);
        }

        /// <summary>
        /// حذف کتاب بر اساس شناسه.
        /// </summary>
        public Task DeleteBookAsync(int id)
        {
            return _bookService.DeleteBookAsync(id);
        }

        /// <summary>
        /// دریافت همه کتاب‌ها.
        /// </summary>
        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return _bookService.GetAllBooksAsync();
        }


        /// <summary>
        /// دریافت کتاب‌ها به صورت صفحه‌بندی شده.
        /// </summary>
        public Task<IEnumerable<Book>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return _bookService.GetAllPagedAsync(pageNumber, pageSize);
        }

        /// <summary>
        /// دریافت کتاب بر اساس شناسه.
        /// </summary>
        public Task<Book?> GetBookByIdAsync(int id)
        {
            return _bookService.GetBookByIdAsync(id);
        }


        /// <summary>
        /// به‌روزرسانی کتاب موجود.
        /// </summary>
        public Task UpdateBookAsync(Book book)
        {
            return _bookService.UpdateBookAsync(book);
        }
    }
}
