using BookWise.API.DataAccess;

namespace BookWise.UnitTests.Systems.DataAccess
{
    public class TestBookDataAccess
    {
        [Fact]
        public async Task GetAllBooks_WhenCalled_InvokesSqlReader()
        {
            // Arrange
            var sut = new BookDataAccess();

            // Act
            await sut.GetAllBooks();

            // Assert

        }
    }
}
