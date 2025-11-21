using Domain.Entities;
using Domain.Interfaces.AppService;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookAppService.GetAllBooksAsync();

            if (books == null || !books.Any())
                return NotFound("هیچ کتابی یافت نشد.");

            return Ok(books);
        }
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
