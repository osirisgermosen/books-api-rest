using AutoMapper;
using books_library_api_net.DTOs;
using books_library_api_net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_library_api_net.Controllers
{
    [ApiController]
    [Route("v1/api/books")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext context;
        private readonly IMapper mapper;

        public BooksController(LibraryDbContext dbContext, IMapper mapper)
        {
            context = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Index()
        {
            return await context.Books.ToListAsync();
        }


        [HttpGet("{bookId:int}")]
        public async Task<ActionResult<Book>> Get(int bookId)
        {
            return await context.Books.Include(x => x.Pages).FirstOrDefaultAsync(x => x.Id == bookId);
        }

        [HttpGet("{bookId:int}/page/{number:int}/{format}")]
        public async Task<ActionResult<PageDto>> Get(int bookId, int number, string format)
        {
            return await context.Pages.Where(p => p.Id == bookId && p.PageNumber == number).Select(p => new PageDto()
            {
                Id = p.Id,
                Chapter = p.Chapter,
                Topic = p.Topic,
                PageNumber = p.PageNumber,
                Content = format == "html" ? p.Html : p.Text
            }).SingleAsync();

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookCreateDto bookCreateDto)
        {
            var book = mapper.Map<Book>(bookCreateDto);

            context.Add(book);
            await context.SaveChangesAsync();
            return Ok();
        }



        [HttpPut("{bookId:int}")]
        public async Task<ActionResult> Put(Book book, int bookId)
        {
            if (book.Id != bookId)
                return BadRequest("Book Id does not match URL Id");

            bool exist = await context.Books.AnyAsync(x => x.Id == bookId);

            if (!exist)
                return NotFound("No Book found with that ID");

            context.Update(book);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{bookId:int}")]
        public async Task<ActionResult> Delete(int bookId)
        {
            bool exist = await context.Books.AnyAsync(x => x.Id == bookId);

            if (!exist)
                return NotFound("No Book found with that ID");

            context.Remove(new Book() { Id = bookId });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
