using Microsoft.AspNetCore.Mvc;
using test2.Services;
using test2.DTOs;

namespace test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookDto newBook)
    {
        var result = _bookService.AddBook(newBook);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Book);
    }
}