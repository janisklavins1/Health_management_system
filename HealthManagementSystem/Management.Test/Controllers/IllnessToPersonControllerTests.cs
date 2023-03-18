using Management.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Test.Controllers
{
    public class IllnessToPersonControllerTests
    {
        private readonly Mock<IIllnessPersonService> illnessPersonServiceMock;
        private readonly IllnessToPersonController target;

        public IllnessToPersonControllerTests()
        {
            illnessPersonServiceMock = new Mock<IIllnessPersonService>();
            target = new IllnessToPersonController(illnessPersonServiceMock.Object);
        }

        [Fact]
        public async Task AddIllnessToPerson_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var request = new IllnessPersonDto()
            {
                DateDiscovered = DateTime.Now,
                IllnessId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                Prohibitions = Faker.Lorem.Sentence(),
                Status = Faker.Lorem.GetFirstWord()
            };

            // Act
            var actionResult = await target.AddIllnessToPerson(request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddIllnessToPerson_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var request = new IllnessPersonDto()
            {
                DateDiscovered = DateTime.Now,
                IllnessId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                Prohibitions = Faker.Lorem.Sentence(),
                Status = Faker.Lorem.GetFirstWord()
            };
            illnessPersonServiceMock.Setup(s => s.AddIllnessToPersonAsync(request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddIllnessToPerson(request);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task GetIllnessForPerson_WithValidPersonId_ReturnsOkResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            var request = new List<IllnessPersonListDto>()
            {
                new IllnessPersonListDto()
                {
                    DateDiscovered = DateTime.Now,
                    Prohibitions = Faker.Lorem.Sentence(),
                    Status = Faker.Lorem.GetFirstWord(),
                    Illness = new Illness()
                    {
                        Description = Faker.Lorem.Sentence(),
                        IllnessId = Faker.RandomNumber.Next(),
                        Name = Faker.Lorem.GetFirstWord()
                    },
                    IllnessPersonId = Faker.RandomNumber.Next()
                }
            };
            illnessPersonServiceMock.Setup(s => s.GetAllPersonIllnessesAsync(personId)).ReturnsAsync(request);

            // Act
            var actionResult = await target.GetIllnessForPerson(personId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(request);
        }

        [Fact]
        public async Task GetIllnessForPerson_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int personId = Faker.RandomNumber.Next();
            illnessPersonServiceMock.Setup(s => s.GetAllPersonIllnessesAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetIllnessForPerson(personId);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task EditAllergyForPerson_WithValidIllnessPersonId_ReturnsOkObjectResult()
        {
            // Arrange
            int illnessPersonId = Faker.RandomNumber.Next();
            var request = new IllnessPersonEditDto()
            {
                DateDiscovered = DateTime.Now,
                IllnessId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                Prohibitions = Faker.Lorem.Sentence(),
                Status = Faker.Lorem.GetFirstWord()
            };

            illnessPersonServiceMock.Setup(s => s.EditIllnessToPersonAsync(illnessPersonId, request)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await target.EditAllergyForPerson(illnessPersonId, request);

            // Assert
            var result = actionResult.As<OkObjectResult>();
            result.Should().BeOfType<OkObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(request);
        }

        [Fact]
        public async Task EditAllergyForPerson_WithInvalidValidIllnessPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int illnessPersonId = -1;
            var request = new IllnessPersonEditDto()
            {
                DateDiscovered = DateTime.Now,
                IllnessId = Faker.RandomNumber.Next(),
                PersonId = Faker.RandomNumber.Next(),
                Prohibitions = Faker.Lorem.Sentence(),
                Status = Faker.Lorem.GetFirstWord()
            };
            illnessPersonServiceMock.Setup(s => s.EditIllnessToPersonAsync(illnessPersonId, request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.EditAllergyForPerson(illnessPersonId, request);

            // Assert
            var result = actionResult.As<BadRequestObjectResult>();
            actionResult.Should().BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            result.Value.Should().BeOfType<Exception>();
        }
    }
}
