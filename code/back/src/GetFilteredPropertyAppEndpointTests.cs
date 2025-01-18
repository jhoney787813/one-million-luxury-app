using Application.OwnerProperty.GetFilteredProperty;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using API.Controllers;
using System.Threading.Tasks;

namespace Test.Million.APP
{
    [TestFixture]
    public class GetFilteredPropertyAppEndpointTests
    {
        private Mock<IMediator> _mediatorMock;
        private GetFilteredPropertyAppEndpoint _controller;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new GetFilteredPropertyAppEndpoint(_mediatorMock.Object);
        }

        [Test]
        public async Task GetById_ShouldReturnOk_WhenMediatorReturnsResult()
        {
            // Arrange
            var filters = new GetFilteredPropertyQuery(); // Agrega los filtros según sea necesario
            var expectedResponse = new GetFilteredPropertyQueryResponse(); // Define el tipo adecuado de respuesta
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetFilteredPropertyQuery>(), default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetById(filters);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(expectedResponse, okResult.Value);
        }

        [Test]
        public async Task GetById_ShouldReturnNotFound_WhenMediatorReturnsNull()
        {
            // Arrange
            var filters = new GetFilteredPropertyQuery();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetFilteredPropertyQuery>(), default)).ReturnsAsync((GetFilteredPropertyQueryResponse)null);

            // Act
            var result = await _controller.GetById(filters);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        [Test]
        public async Task GetTopProperties_ShouldReturnOk_WhenMediatorReturnsResult()
        {
            // Arrange
            var top = 5;
            var expectedResponse = new GetTopPropertyQueryResponse(); // Define el tipo adecuado de respuesta
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTopPropertyQuery>(), default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetById(top);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(expectedResponse, okResult.Value);
        }

        [Test]
        public async Task GetTopProperties_ShouldReturnNotFound_WhenMediatorReturnsNull()
        {
            // Arrange
            var top = 5;
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTopPropertyQuery>(), default)).ReturnsAsync((GetTopPropertyQueryResponse)null);

            // Act
            var result = await _controller.GetById(top);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }
    }
}
