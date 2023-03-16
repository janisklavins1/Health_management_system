using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Test.Controllers
{
    public class AllergyToPersonControllerTests
    {
        private readonly Mock<IAllergyPersonService> allergyPersonServiceMock;
        private readonly AllergyToPersonController target;
        public AllergyToPersonControllerTests()
        {
            allergyPersonServiceMock = new Mock<IAllergyPersonService>();
            target = new AllergyToPersonController(allergyPersonServiceMock.Object);
        }

        [Fact]
        public async Task AddAllergyToPerson_RequestIsValid_ReturnOkResponseAndAllergyPersonList()
        {
            // Arrange
            var request = new AllergyPersonDto()
            {
                AllergyId = 1,
                PersonId = 1,
                DateDiscovered = DateTime.Now
            };

            // Act
            var actionResult = await target.AddAllergyToPerson(request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddAllergyToPerson_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var request = new AllergyPersonDto()
            {
                AllergyId = Faker.RandomNumber.Next(0),
                PersonId = Faker.RandomNumber.Next(0),
                DateDiscovered = DateTime.Now
            };
            allergyPersonServiceMock.Setup(s => s.AddAllergyToPersonAsync(request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddAllergyToPerson(request);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task GetAllergyForPerson_WithValidPersonId_ReturnsOkResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            var allergyList = new List<AllergyPersonListDto>()
            {
                new AllergyPersonListDto()
                { 
                    AllergyPersonId = Faker.RandomNumber.Next(),
                    DateDiscovered = DateTime.Now,
                    Allergy = new Allergy()
                }
            };
            allergyPersonServiceMock.Setup(s => s.GetAllPersonAllergiesAsync(personId)).ReturnsAsync(allergyList);

            // Act
            var actionResult = await target.GetAllergyForPerson(personId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(allergyList);
        }

        [Fact]
        public async Task GetAllergyForPerson_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int personId = Faker.RandomNumber.Next();
            allergyPersonServiceMock.Setup(s => s.GetAllPersonAllergiesAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetAllergyForPerson(personId);

            // Assert
            var result = actionResult.Result as NotFoundObjectResult;
            result.Should().BeOfType<NotFoundObjectResult>();
            var notFoundResult = result.As<NotFoundObjectResult>();
            notFoundResult.Should().BeOfType<NotFoundObjectResult>();
            notFoundResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task EditAllergyForPerson_WithValidAllergyPersonId_ReturnsOkObjectResult()
        {
            // Arrange
            int allergyPersonId = Faker.RandomNumber.Next();
            var allergyPersonEditDto = new AllergyPersonEditDto()
            {
                AllergyId = Faker.RandomNumber.Next(),
                DateDiscovered = DateTime.Now
            };
            allergyPersonServiceMock.Setup(s => s.EditAllergyToPersonAsync(allergyPersonId, allergyPersonEditDto)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await target.EditAllergyForPerson(allergyPersonId, allergyPersonEditDto);

            // Assert
            var okResult = actionResult.As<OkObjectResult>();
            okResult.Should().BeOfType<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(allergyPersonEditDto);
        }

        [Fact]
        public async Task EditAllergyForPerson_WithInvalidAllergyPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int allergyPersonId = -1;
            var allergyPersonEditDto = new AllergyPersonEditDto 
            {
                AllergyId = Faker.RandomNumber.Next(),
                DateDiscovered = DateTime.Now
            };
            allergyPersonServiceMock.Setup(s => s.EditAllergyToPersonAsync(allergyPersonId, allergyPersonEditDto)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.EditAllergyForPerson(allergyPersonId, allergyPersonEditDto);

            // Assert
            var result = actionResult.As<ActionResult>();
            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}