using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Test.Controllers
{
    public class MedicationToPersonControllerTests
    {
        private readonly Mock<IMedicationPersonService> _medicationPersonServiceMock;
        private readonly MedicationToPersonController target;

        public MedicationToPersonControllerTests()
        {
            _medicationPersonServiceMock = new Mock<IMedicationPersonService>();
            target = new MedicationToPersonController(_medicationPersonServiceMock.Object);
        }

        [Fact]
        public async Task AddMedicationToPerson_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var request = new MedicationPersonDto()
            {
                EndingDate = DateTime.MaxValue,
                IsActive = Faker.Boolean.Random(),
                MedicationId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                StartingDate = DateTime.MinValue
            };

            // Act
            var actionResult = await target.AddMedicationToPerson(request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddMedicationToPerson_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var request = new MedicationPersonDto()
            {
                EndingDate = DateTime.MaxValue,
                IsActive = Faker.Boolean.Random(),
                MedicationId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                StartingDate = DateTime.MinValue
            };

            _medicationPersonServiceMock.Setup(s => s.AddMedicationToPersonAsync(request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddMedicationToPerson(request);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task GetMedicationForPerson_WithValidPersonId_ReturnsOkResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            var familyDoctor = new List<MedicationPersonListDto>()
            { 
                new MedicationPersonListDto()
                {
                    EndingDate = DateTime.MaxValue,
                    IsActive = Faker.Boolean.Random(),
                    StartingDate = DateTime.MinValue,
                    MedicationPersonId = Faker.RandomNumber.Next()
                }
            };

            _medicationPersonServiceMock.Setup(s => s.GetAllPersonMedicationsAsync(personId)).ReturnsAsync(familyDoctor);

            // Act
            var actionResult = await target.GetMedicationForPerson(personId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(familyDoctor);
        }

        [Fact]
        public async Task GetMedicationForPerson_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int personId = Faker.RandomNumber.Next();
            _medicationPersonServiceMock.Setup(s => s.GetAllPersonMedicationsAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetMedicationForPerson(personId);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task EditMedicationForPerson_WithValidFamilyDoctorId_ReturnsOkObjectResult()
        {
            // Arrange
            int medicationPersonId = Faker.RandomNumber.Next();
            var request = new MedicationPersonEditDto()
            {
                EndingDate = DateTime.MaxValue,
                IsActive = Faker.Boolean.Random(),
                MedicationId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                StartingDate = DateTime.MinValue
            };

            _medicationPersonServiceMock.Setup(s => s.EditMedicationToPersonAsync(medicationPersonId, request)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await target.EditMedicationForPerson(medicationPersonId, request);

            // Assert
            var result = actionResult.As<OkObjectResult>();
            result.Should().BeOfType<OkObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(request);
        }

        [Fact]
        public async Task EditMedicationForPerson_WithInvalidValidFamilyDoctorId_ReturnsNotFoundResult()
        {
            // Arrange
            int medicationPersonId = -1;
            var request = new MedicationPersonEditDto()
            {
                EndingDate = DateTime.MaxValue,
                IsActive = Faker.Boolean.Random(),
                MedicationId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                StartingDate = DateTime.MinValue
            };

            _medicationPersonServiceMock.Setup(s => s.EditMedicationToPersonAsync(medicationPersonId, request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.EditMedicationForPerson(medicationPersonId, request);

            // Assert
            var result = actionResult.As<BadRequestObjectResult>();
            actionResult.Should().BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            result.Value.Should().BeOfType<Exception>();
        }
    }
}
