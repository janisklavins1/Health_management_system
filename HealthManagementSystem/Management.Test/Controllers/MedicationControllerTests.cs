using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Test.Controllers
{
    public class MedicationControllerTests
    {
        private readonly Mock<IMedicationService> _medicationServiceMock;
        private readonly MedicationController target;

        public MedicationControllerTests()
        {
            _medicationServiceMock = new Mock<IMedicationService>();
            target = new MedicationController(_medicationServiceMock.Object);
        }

        [Fact]
        public async Task GetAllMedicationsAsync_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var medicationList = new List<Medication>()
            {
                new Medication()
                {
                    Description = Faker.Lorem.Sentence(),
                    MedicationId = Faker.RandomNumber.Next(),
                    Name = Faker.Lorem.GetFirstWord()
                }
            };
            _medicationServiceMock.Setup(s => s.GetAllMedicationsAsync()).ReturnsAsync(medicationList);

            // Act
            var actionResult = await target.GetAllMedicationsAsync();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(medicationList);
        }

        [Fact]
        public async Task GetAllMedicationsAsync_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            _medicationServiceMock.Setup(s => s.GetAllMedicationsAsync()).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetAllMedicationsAsync();

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task AddMedication_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var request = new MedicationDto()
            {
                Name = Faker.Lorem.GetFirstWord(),
                Description = Faker.Lorem.Sentence()
            };

            // Act
            var actionResult = await target.AddMedication(request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddMedication_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var request = new MedicationDto()
            {
                Name = Faker.Lorem.GetFirstWord(),
                Description = Faker.Lorem.Sentence()
            };

            _medicationServiceMock.Setup(s => s.AddMedicationAsync(request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddMedication(request);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task EditFamilyDoctor_WithValidFamilyDoctorId_ReturnsOkObjectResult()
        {
            // Arrange
            var medicationId = Faker.RandomNumber.Next();
            var request = new MedicationDto()
            {
                Description = Faker.Lorem.Sentence(),
                Name = Faker.Lorem.GetFirstWord()
            };

            _medicationServiceMock.Setup(s => s.EditMedicationAsync(medicationId, request)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await target.EditMedication(medicationId, request);

            // Assert
            var result = actionResult.Result.As<OkObjectResult>();
            result.Should().BeOfType<OkObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(request);
        }

        [Fact]
        public async Task EditFamilyDoctor_WithInvalidValidFamilyDoctorId_ReturnsNotFoundResult()
        {
            // Arrange
            var medicationId = Faker.RandomNumber.Next();
            var request = new MedicationDto()
            {
                Description = Faker.Lorem.Sentence(),
                Name = Faker.Lorem.GetFirstWord()
            };

            _medicationServiceMock.Setup(s => s.EditMedicationAsync(medicationId, request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.EditMedication(medicationId, request);

            // Assert
            var result = actionResult.Result.As<BadRequestObjectResult>();
            actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            result.Value.Should().BeOfType<Exception>();
        }
    }
}
