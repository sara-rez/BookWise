using BookWise.API.Controllers;
using BookWise.API.DataAccess;
using BookWise.API.Models;
using BookWise.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BookWise.UnitTests.Systems.Controllers
{
    public class TestBookController
    {
        [Fact]
        public async void Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockBookDataAcces = new Mock<IBookDataAccess>();

            mockBookDataAcces
                .Setup(da => da.GetAllBooks())
                .ReturnsAsync(BookFixture.GetTestBooks());

            var sut = new BookController(mockBookDataAcces.Object);

            // Act
            var result = (OkObjectResult) await sut.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_Invokes_DataAccess_Exactly_Once()
        {
            // Arrange
            var mockBookDataAcces = new Mock<IBookDataAccess>();

            mockBookDataAcces
                .Setup(da => da.GetAllBooks())
                .ReturnsAsync(new List<Book>());

            var sut = new BookController(mockBookDataAcces.Object);

            // Act
            var result = await sut.Get();

            // Assert
            mockBookDataAcces.Verify
                (mockBookDataAcces => 
                mockBookDataAcces.GetAllBooks(), 
                Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_Returns_List_Of_Books()
        {
            // Arrange
            var mockBookDataAcces = new Mock<IBookDataAccess>();

            mockBookDataAcces
                .Setup(da => da.GetAllBooks())
                .ReturnsAsync(BookFixture.GetTestBooks());

            var sut = new BookController(mockBookDataAcces.Object);

            // Act
            var result = await sut.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Book>>();

        }

        [Fact]
        public async Task Get_OnNoBooksFound_Returns_404()
        {
            // Arrange
            var mockBookDataAcces = new Mock<IBookDataAccess>();

            mockBookDataAcces
                .Setup(da => da.GetAllBooks())
                .ReturnsAsync(new List<Book>());

            var sut = new BookController(mockBookDataAcces.Object);

            // Act
            var result = await sut.Get();

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            ((NotFoundResult)result).StatusCode.Should().Be(404);
        }

    }
}