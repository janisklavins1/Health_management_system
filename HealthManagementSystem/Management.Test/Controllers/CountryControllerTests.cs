using Management.Application.Services;
using Management.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Test.Controllers
{
    public class CountryControllerTests
    {
        private readonly Mock<ICountryService> _mockCountryService;
        private readonly CountryController _controller;

        public CountryControllerTests()
        {
            _mockCountryService = new Mock<ICountryService>();
            _controller = new CountryController(_mockCountryService.Object);
        }

        [Fact]
        public async Task GetCountries_ReturnsOkObjectResult_WithListOfCountries()
        {
            // Arrange
            var expectedCountries = new List<Country>
            {
                new Country { Id = 1, Name = "USA" },
                new Country { Id = 2, Name = "Canada" }
            };
            _mockCountryService.Setup(s => s.GetAllCountriesAsync()).ReturnsAsync(expectedCountries);

            // Act
            var actionResult = await _controller.GetCountries();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(expectedCountries);
        }

        [Fact]
        public async Task GetCountry_ReturnsOkObjectResult_WithMatchingCountry()
        {
            // Arrange
            var countryName = "USA";
            var expectedCountry = new Country { Id = 1, Name = countryName };
            _mockCountryService.Setup(s => s.GetCountryByNameAsync(countryName)).ReturnsAsync(expectedCountry);

            // Act
            var actionResult = await _controller.GetCountry(countryName);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(expectedCountry);
        }

        [Fact]
        public async Task GetCountry_ReturnsBadRequestObjectResult_WhenCountryNotFound()
        {
            // Arrange
            var countryName = "USA";
            _mockCountryService.Setup(s => s.GetCountryByNameAsync(countryName)).ReturnsAsync((Country)null);

            // Act
            var actionResult = await _controller.GetCountry(countryName);

            // Assert
            actionResult.Value.Should().BeNull();
        }
    }
}
