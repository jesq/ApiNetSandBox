using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetSandBox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;

        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "Az isteni formula",
                Language = "Hungarian",
                Author = "Jose Rodrigues dos Santos"
            });

            books.Add(new Book
            {
                Id = 2,
                Title = "Deep Work",
                Language = "English",
                Author = "Cal Newport"
            });
        }
        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.Single(book => book.Id == id);
        }

        // POST api/<BooksController>
        public void Post(Book value)
        {
            int id = books.Count + 1;
            value.Id = id;
            books.Add(value);
        }

        // PUT api/<BooksController>/5
        public void Put(int id, string value)
        {

        }

        // DELETE api/<BooksController>/5
        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}
