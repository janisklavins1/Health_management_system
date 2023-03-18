using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Test.Controllers
{
    public class FamilyDoctorControllerTests
    {
        private readonly Mock<IFamilyDoctorService> familyDoctorServiceMock;
        private readonly FamilyDoctorController target;

        public FamilyDoctorControllerTests()
        {
            familyDoctorServiceMock = new Mock<IFamilyDoctorService>();
            target = new FamilyDoctorController(familyDoctorServiceMock.Object);
        }

        [Fact]
        public async Task GetFamilyDoctorById_WithValidPersonId_ReturnsOkResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            var familyDoctor = new FamilyDoctor()
            {
                PersonId = personId,
                JoiningDate = DateTime.Now,
                PlaceOfEducation = Faker.Company.Name()
            };
            familyDoctorServiceMock.Setup(s => s.GetFamilyDoctorByIdAsync(personId)).ReturnsAsync(familyDoctor);

            // Act
            var actionResult = await target.GetFamilyDoctorById(personId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(familyDoctor);
        }

        [Fact]
        public async Task GetFamilyDoctorById_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int personId = Faker.RandomNumber.Next();
            familyDoctorServiceMock.Setup(s => s.GetFamilyDoctorByIdAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetFamilyDoctorById(personId);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task AddFamilyDoctor_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var request = new FamilyDoctorDto()
            {
                JoiningDate = DateTime.Now,
                MedicalPracticeId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                PlaceOfEducation = Faker.Company.Name(),
                Qualification = Faker.Lorem.Sentence(),
                Status = Faker.Lorem.GetFirstWord()
            };

            // Act
            var actionResult = await target.AddFamilyDoctor(request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddFamilyDoctor_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var request = new FamilyDoctorDto()
            {
                JoiningDate = DateTime.Now,
                MedicalPracticeId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                PlaceOfEducation = Faker.Company.Name(),
                Qualification = Faker.Lorem.Sentence(),
                Status = Faker.Lorem.GetFirstWord()
            };
            familyDoctorServiceMock.Setup(s => s.AddFamilyDoctorAsync(request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddFamilyDoctor(request);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task EditFamilyDoctor_WithValidFamilyDoctorId_ReturnsOkObjectResult()
        {
            // Arrange
            int familyDoctorId = Faker.RandomNumber.Next();
            var request = new FamilyDoctorEditDto()
            {
                MedicalPracticeId = Faker.RandomNumber.Next(),
                Status = Faker.Lorem.GetFirstWord()
            };

            familyDoctorServiceMock.Setup(s => s.EditFamilyDoctorAsync(familyDoctorId, request)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await target.EditFamilyDoctor(familyDoctorId, request);

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
            int familyDoctorId = -1;
            var request = new FamilyDoctorEditDto()
            {
                MedicalPracticeId = Faker.RandomNumber.Next(),
                Status = Faker.Lorem.GetFirstWord()
            };
            familyDoctorServiceMock.Setup(s => s.EditFamilyDoctorAsync(familyDoctorId, request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.EditFamilyDoctor(familyDoctorId, request);

            // Assert
            var result = actionResult.Result.As<BadRequestObjectResult>();
            actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            result.Value.Should().BeOfType<Exception>();
        }
    }
}
