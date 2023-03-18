using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Test.Controllers
{
    public class VaccinationToPersonControllerTests
    {
        private readonly Mock<IVaccinationPersonService> _vaccinationPersonServiceMock;
        private readonly VaccinationToPersonController target;

        public VaccinationToPersonControllerTests()
        {
            _vaccinationPersonServiceMock = new Mock<IVaccinationPersonService>();
            target = new VaccinationToPersonController(_vaccinationPersonServiceMock.Object);
        }

        [Fact]
        public async Task AddVaccinationToPerson_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var request = new VaccinationPersonDto()
            {
                PersonId = Faker.RandomNumber.Next(),
                EndDate = DateTime.MaxValue,
                StartDate = DateTime.MinValue,
                VaccinationId = Faker.RandomNumber.Next()
            };

            // Act
            var actionResult = await target.AddVaccinationToPerson(request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddVaccinationToPerson_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            _vaccinationPersonServiceMock.Setup(s => s.AddVaccinationToPersonAsync(null)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddVaccinationToPerson(null);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task GetVaccinationForPerson_WithValidPersonId_ReturnsOkResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            var response = new List<VaccinationPersonListDto>()
            {
                new VaccinationPersonListDto()
                {
                    VaccinationPersonId = Faker.RandomNumber.Next(),
                    EndDate = DateTime.MaxValue,
                    StartDate = DateTime.MinValue,
                }
            };

            _vaccinationPersonServiceMock.Setup(s => s.GetAllPersonVaccinationsAsync(personId)).ReturnsAsync(response);

            // Act
            var actionResult = await target.GetVaccinationForPerson(personId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetVaccinationForPerson_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int personId = Faker.RandomNumber.Next();
            _vaccinationPersonServiceMock.Setup(s => s.GetAllPersonVaccinationsAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetVaccinationForPerson(personId);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task EditVaccinationForPerson_WithValidFamilyDoctorId_ReturnsOkObjectResult()
        {
            // Arrange
            var vaccinationPersonId = Faker.RandomNumber.Next();
            var request = new VaccinationPersonEditDto()
            {
                VaccinationId = Faker.RandomNumber.Next(),
                EndDate = DateTime.MaxValue,
                StartDate = DateTime.MinValue,
            };

            _vaccinationPersonServiceMock.Setup(s => s.EditVaccinationToPersonAsync(vaccinationPersonId, request)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await target.EditVaccinationForPerson(vaccinationPersonId, request);

            // Assert
            var result = actionResult.As<OkObjectResult>();
            result.Should().BeOfType<OkObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(request);
        }

        [Fact]
        public async Task EditVaccinationForPerson_WithInvalidValidFamilyDoctorId_ReturnsNotFoundResult()
        {
            // Arrange
            var vaccinationPersonId = -1;

            _vaccinationPersonServiceMock.Setup(s => s.EditVaccinationToPersonAsync(vaccinationPersonId, null)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.EditVaccinationForPerson(vaccinationPersonId, null);

            // Assert
            var result = actionResult.As<BadRequestObjectResult>();
            actionResult.Should().BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            result.Value.Should().BeOfType<Exception>();
        }
    }
}
