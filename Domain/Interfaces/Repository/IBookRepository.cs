namespace Domain.Interfaces.Repository
{
    public interface IBookRepository
    {
        /// <summary>
        /// دریافت کتاب‌ها به صورت صفحه‌بندی شده.
        /// </summary>
        Task<IEnumerable<Book>> GetAllPagedAsync(int pageNumber, int pageSize);
        /// <summary>
        /// دریافت همه کتاب‌ها.
        /// </summary>
        Task<IEnumerable<Book>> GetAllBooksAsync();
        /// <summary>
        /// دریافت کتاب بر اساس شناسه.
        /// </summary>
        Task<Book?> GetBookByIdAsync(int id);
        /// <summary>
        /// اضافه کردن کتاب جدید.
        /// </summary>
        Task AddBookAsync(Book book);
        /// <summary>
        /// به‌روزرسانی کتاب موجود.
        /// </summary>
        Task UpdateBookAsync(Book book);
        /// <summary>
        /// حذف کتاب بر اساس شناسه.
        /// </summary>
        Task DeleteBookAsync(int id);
    }
}
