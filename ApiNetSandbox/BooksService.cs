using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetSandBox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;
        private static int currentId;


        public BooksService()
        {
            books = new List<Book>();
            currentId = 1;
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
        private int GenerateId()
        {
            return currentId++;
        }
        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            CheckId(id);
            return books.Single(_ => _.Id == id);
        }

        private static void CheckId(int id)
        {
            if (id < 1 || id >= currentId)
            {
                throw new Exception("Invalid id !");
            }
        }
        // POST api/<BooksController>
        public void Add(Book value)
        {
            CheckBook(value);
            value.Id = GenerateId();
            books.Add(value);
        }

        // PUT api/<BooksController>/5
        public void Update(int id, Book value)
        {
            CheckBook(value);
            Book bookToBeUpdated = Get(id);
            bookToBeUpdated.Author = value.Author;
            bookToBeUpdated.Title = value.Title;
            bookToBeUpdated.Language = value.Language;
        }

        private static void CheckBook(Book value)
        {
            if (value == null)
            {
                throw new Exception("Book cannot be null !");
            }
            else if (value.Author == null || value.Title == null || value.Language == null)
            {
                throw new Exception("Book fields should not be null !");
            }
        }


        // DELETE api/<BooksController>/5
        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}
