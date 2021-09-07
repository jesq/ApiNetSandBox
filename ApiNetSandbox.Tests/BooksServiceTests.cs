using ApiNetSandBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiNetSandbox.Tests
{
    public class BooksServiceTests
    {
        [Fact]
        public void ShouldHaveLondonCoordinates()
        {

            // Assume
            var booksService = new BooksService();



            // Act
            booksService.Post(new Book
            {
                Title = "Test Book Nr1",
                Language = "English",
                Author = "Some Author"
            });
            booksService.Delete(2);
            booksService.Post(new Book
            {
                Title = "Test Book Nr2",
                Language = "English",
                Author = "Some Author2"
            });

            // Assert
            Assert.Equal("Test Book Nr1", booksService.Get(3).Title);
        }
    }
}
