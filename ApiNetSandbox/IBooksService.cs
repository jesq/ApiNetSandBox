using System.Collections.Generic;

namespace ApiNetSandBox
{
    public interface IBooksService
    {
        IEnumerable<Book> Get();
        Book Get(int id);
        void Add(Book value);
        void Delete(int id);
        void Update(int id, Book value);
    }
}