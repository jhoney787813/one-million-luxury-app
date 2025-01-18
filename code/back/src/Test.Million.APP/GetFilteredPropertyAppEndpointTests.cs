using Application.OwnerProperty.GetFilteredProperty;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;
using Moq;
using Application.Commons;

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
            // Inicializamos el mock del mediador
            _mediatorMock = new Mock<IMediator>();
            _controller = new GetFilteredPropertyAppEndpoint(_mediatorMock.Object);
        }

        // Prueba para el método GetById con filtros
        [Test]
        public async Task GetById_ShouldReturnOk_WhenMediatorReturnsValidResult()
        {
            // Arrange
            var filters = new GetFilteredPropertyQuery
            {
                Name = "Property1",
                Address = "Street 123",
                MinPrice = 100000,
                MaxPrice = 200000
            };

            var expectedResponse = new GetFilteredPropertyQueryResponse(1, "Owner1", "Property1", "Street 123", 150000, "image_url");
            var resultResponse = new List<GetFilteredPropertyQueryResponse> { expectedResponse };

            // Configurar el mock del mediador para devolver un resultado exitoso
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetFilteredPropertyQuery>(), default)).ReturnsAsync(Result<IEnumerable<GetFilteredPropertyQueryResponse>>.Success(resultResponse));

            // Act
            var result = await _controller.GetById(filters);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(resultResponse, okResult.Value);
        }

        // Prueba para el método GetById con filtros cuando el mediador devuelve null
        [Test]
        public async Task GetById_ShouldReturnNotFound_WhenMediatorReturnsNull()
        {
            // Arrange
            var filters = new GetFilteredPropertyQuery
            {
                Name = "NonExistentProperty"
            };

            // Configurar el mock del mediador para devolver un resultado nulo
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetFilteredPropertyQuery>(), default)).ReturnsAsync(Result<IEnumerable<GetFilteredPropertyQueryResponse>>.Failure("No results found"));

            // Act
            var result = await _controller.GetById(filters);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        // Prueba para el método GetTopProperties cuando el mediador devuelve un resultado válido
        [Test]
        public async Task GetTopProperties_ShouldReturnOk_WhenMediatorReturnsValidResult()
        {
            // Arrange
            var top = 5;
            var expectedResponse = new GetTopPropertyQueryResponse(1, "Owner1", "TopProperty", "TopStreet 123", 250000, "top_image_url");
            var resultResponse = new List<GetTopPropertyQueryResponse> { expectedResponse };

            // Configurar el mock del mediador para devolver un resultado exitoso
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTopPropertyQuery>(), default)).ReturnsAsync(Result<IEnumerable<GetTopPropertyQueryResponse>>.Success(resultResponse));

            // Act
            var result = await _controller.GetById(top);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(resultResponse, okResult.Value);
        }

        // Prueba para el método GetTopProperties cuando el mediador devuelve null
        [Test]
        public async Task GetTopProperties_ShouldReturnNotFound_WhenMediatorReturnsNull()
        {
            // Arrange
            var top = 5;

            // Configurar el mock del mediador para devolver un resultado nulo
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTopPropertyQuery>(), default)).ReturnsAsync(Result<IEnumerable<GetTopPropertyQueryResponse>>.Failure("No results found"));

            // Act
            var result = await _controller.GetById(top);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        // Prueba para el método GetById con filtros cuando el mediador lanza una excepción
        [Test]
        public async Task GetById_ShouldReturnInternalServerError_WhenMediatorThrowsException()
        {
            // Arrange
            var filters = new GetFilteredPropertyQuery
            {
                Name = "Property1"
            };

            // Configurar el mock del mediador para que lance una excepción
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetFilteredPropertyQuery>(), default))
                         .ThrowsAsync(new System.Exception("Error de servidor"));

            // Act
            var result = await _controller.GetById(filters);

            // Assert
            var statusCodeResult = result as StatusCodeResult;
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(500, statusCodeResult.StatusCode);  // Internal Server Error
        }

        // Prueba para el método GetTopProperties cuando el mediador lanza una excepción
        [Test]
        public async Task GetTopProperties_ShouldReturnInternalServerError_WhenMediatorThrowsException()
        {
            // Arrange
            var top = 5;

            // Configurar el mock del mediador para que lance una excepción
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTopPropertyQuery>(), default))
                         .ThrowsAsync(new System.Exception("Error de servidor"));

            // Act
            var result = await _controller.GetById(top);

            // Assert
            var statusCodeResult = result as StatusCodeResult;
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(500, statusCodeResult.StatusCode);  
        }
    
    }
}
