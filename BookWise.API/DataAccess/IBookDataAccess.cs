using BookWise.API.Models;

namespace BookWise.API.DataAccess
{
    public interface IBookDataAccess
    {
        public Task<List<Book>> GetAllBooks();
    }
}
