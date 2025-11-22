namespace Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreContext _context;
        public BookRepository(BookstoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// اضافه کردن کتاب جدید.
        /// </summary>
        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// حذف کتاب بر اساس شناسه.
        /// </summary>
        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// به‌روزرسانی کتاب موجود.
        /// </summary>
        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// دریافت کتاب‌ها به صورت صفحه‌بندی شده.
        /// </summary>
        public async Task<IEnumerable<Book>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه کتاب‌ها.
        /// </summary>
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
           => await _context.Books.Include(b => b.Author).Include(b => b.Category).ToListAsync();

        /// <summary>
        /// دریافت کتاب بر اساس شناسه.
        /// </summary>
        public async Task<Book?> GetBookByIdAsync(int id)
           => await _context.Books.Include(b => b.Author).Include(b => b.Category)
                               .FirstOrDefaultAsync(b => b.Id == id);

    }
}
