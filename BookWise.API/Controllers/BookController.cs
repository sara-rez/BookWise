using BookWise.API.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookDataAccess _bookDataAccess;

        public BookController(IBookDataAccess bookDataAccess)
        {
            _bookDataAccess = bookDataAccess;
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<IActionResult> Get()
        {
            var books = await _bookDataAccess.GetAllBooks();

            if(books.Any())
            {
                return Ok(books);
            }

            return NotFound();
        }
    }
}