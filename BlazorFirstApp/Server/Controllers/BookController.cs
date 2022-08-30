using BlazorFirstApp.Server.Repository;
using BlazorFirstApp.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorFirstApp.Shared.Models;

namespace BlazorFirstApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _bookRepository.GetBooks();
                if (data != null)
                    return Ok(data);
                return NotFound();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetBooksById/{bookId}")]
        public async Task<IActionResult> GetBooksById(int bookId)
        {
            try
            {
                var data =await _bookRepository.GetBookById(bookId);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("PostBooks")]
        public async Task<IActionResult> PostBook(MasterBook masterBook)
        {            
            try
            {
                int result = 0;
                result = await _bookRepository.PostBooks(masterBook);
                
                if(result>0)
                    return Ok(result);
                
                return NotFound(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateBooks")]
        public async Task<IActionResult> UpdateBooks(MasterBook masterBook)
        {
            try
            {
                int result = 0;
                result = await _bookRepository.UpdateBook(masterBook);

                if (result > 0)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeteleBooks/{bookId}")]
        public async Task<IActionResult> DeteleBooks(int bookId)
        {
            try
            {
                int result = 0;
                result = await _bookRepository.DeleteBook(bookId);

                if (result > 0)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
