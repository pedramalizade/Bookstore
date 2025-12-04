namespace Endpoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookAppService _bookAppService;
        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        /// <summary>
        /// دریافت تمام کتاب‌ها
        /// </summary>
        /// <returns>لیست کتاب‌ها</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookAppService.GetAllBooksAsync();

            if (books == null || !books.Any())
                return NotFound("هیچ کتابی یافت نشد.");

            return Ok(books);
        }


        /// <summary>
        /// دریافت کتاب بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه کتاب</param>
        /// <returns>اطلاعات کتاب</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("شناسه کتاب معتبر نیست.");

            var book = await _bookAppService.GetBookByIdAsync(id);

            if (book == null)
                return NotFound("کتابی با این شناسه پیدا نشد.");

            return Ok(book);
        }

        /// <summary>
        /// دریافت کتاب‌ها به صورت صفحه‌بندی شده
        /// </summary>
        /// <param name="pageNumber">شماره صفحه</param>
        /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
        /// <returns>لیست صفحه‌بندی‌شده‌ی کتاب‌ها</returns>
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest("شماره صفحه و تعداد آیتم باید بزرگ‌تر از صفر باشند.");

            var books = await _bookAppService.GetAllPagedAsync(pageNumber, pageSize);

            if (!books.Any())
                return NotFound("برای این صفحه هیچ رکوردی یافت نشد.");

            return Ok(books);
        }

        /// <summary>
        /// ایجاد کتاب جدید
        /// </summary>
        /// <param name="book">اطلاعات کتاب</param>
        /// <returns>نتیجه عملیات ایجاد</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (book == null)
                return BadRequest("اطلاعات کتاب صحیح نیست.");

            try
            {
                await _bookAppService.AddBookAsync(book);
                return CreatedAtAction(nameof(GetById), new { id = book.Id },
                    new { message = "کتاب با موفقیت ثبت شد.", data = book });
            }
            catch (Exception)
            {
                return StatusCode(500, "خطا در ثبت کتاب. لطفاً دوباره تلاش کنید.");
            }
        }

        /// <summary>
        /// بروزرسانی اطلاعات کتاب
        /// </summary>
        /// <param name="id">شناسه کتاب</param>
        /// <param name="book">اطلاعات جدید کتاب</param>
        /// <returns>نتیجه عملیات بروزرسانی</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest("شناسه کتاب با اطلاعات ارسال‌شده همخوانی ندارد.");

            var isExist = await _bookAppService.GetBookByIdAsync(id);
            if (isExist == null)
                return NotFound("کتاب موردنظر برای بروزرسانی یافت نشد.");

            try
            {
                await _bookAppService.UpdateBookAsync(book);
                return Ok("کتاب با موفقیت بروزرسانی شد.");
            }
            catch (Exception)
            {
                return StatusCode(500, "خطا در بروزرسانی کتاب.");
            }
        }


        /// <summary>
        /// حذف کتاب بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه کتاب</param>
        /// <returns>نتیجه عملیات حذف</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("شناسه کتاب معتبر نیست.");

            var book = await _bookAppService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound("کتاب موردنظر برای حذف پیدا نشد.");

            try
            {
                await _bookAppService.DeleteBookAsync(id);
                return Ok("کتاب با موفقیت حذف شد.");
            }
            catch (Exception)
            {
                return StatusCode(500, "خطا در حذف کتاب.");
            }
        }
    }
}
