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
        public async Task<IActionResult> GetAll() => Ok(await _bookAppService.GetAllBooksAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookAppService.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);    
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _bookAppService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            await _bookAppService.UpdateBookAsync(book);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookAppService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
