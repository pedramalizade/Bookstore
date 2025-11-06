namespace Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreContext _context;
        public BookRepository(BookstoreContext context)
        {
                _context = context;
        }
        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
           => await _context.Books.Include(b => b.Author).Include(b => b.Category).ToListAsync();

        public async Task<Book?> GetBookByIdAsync(int id)
           => await _context.Books.Include(b => b.Author).Include(b => b.Category)
                               .FirstOrDefaultAsync(b => b.Id == id);

    }
}
