using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetSandBox
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

    
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.Get();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(booksService.Get(id));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            booksService.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.Update(id, value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.Delete(id);
        }
    }
}
