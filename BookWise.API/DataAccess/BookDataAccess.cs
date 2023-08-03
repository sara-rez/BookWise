using BookWise.API.Models;

namespace BookWise.API.DataAccess
{
    public class BookDataAccess : IBookDataAccess
    {
        public Task<List<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }
    }
}
