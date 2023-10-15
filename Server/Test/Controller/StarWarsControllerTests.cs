using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Controllers;
using Server.Interfaces;
using Server.Models;
using Moq;

namespace Controller
{
    public class StarWarsControllerTests
    {
        [Fact]
        public async Task GetAsync_ReturnsOkResultWithStarWarsData()
        {
            // Arrange
            var starWarsServiceMock = new Mock<IStarWars>();
            var starWarsImageServiceMock = new Mock<IStarWarsImage>();
            var starWarsDataService = new Mock<IStarWarsDataService>();
            var loggerMock = new Mock<ILogger<StarWarsController>>();
            var controller = new StarWarsController(loggerMock.Object, 
                starWarsServiceMock.Object, 
                starWarsImageServiceMock.Object,
                starWarsDataService.Object);

            var expectedData = ImmutableList.Create(new Character { Name = "Luke Skywalker" });
            starWarsServiceMock.Setup(service => service.GetStarWarsPeopleNamesAsync())
                              .ReturnsAsync(expectedData);
            var expectedStarWarsImageData = ImmutableList.Create(new StarWarsImage { Name = "Luke Skywalker" });
            starWarsImageServiceMock.Setup(x => x.GetStarWarsPeopleNamesWithImagesAsync())
                .ReturnsAsync(expectedStarWarsImageData);

            // Act
            var result = await controller.GetAsync();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
        }
    }
}
