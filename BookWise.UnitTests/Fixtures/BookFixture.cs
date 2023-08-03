using BookWise.API.Models;

namespace BookWise.UnitTests.Fixtures
{
    public static class BookFixture
    {
        public static List<Book> GetTestBooks() =>
            new()
            {
                 new()
                    {
                        Id = 1,
                        Title = "Book1",
                        Author = new()
                        {
                            Id = 1,
                            Name = "Author1"
                        },
                        PublicationDate = DateTime.Now
                    },
                  new()
                    {
                        Id = 2,
                        Title = "Book2",
                        Author = new()
                        {
                            Id = 2,
                            Name = "Author2"
                        },
                        PublicationDate = DateTime.Now
                    },
            };

    }
}
