using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Test.Controllers
{
    public class LabResultControllerTests
    {
        private readonly Mock<ILabResultService> _labResultServiceMock;
        private readonly LabResultController target;
        public LabResultControllerTests()
        {
            _labResultServiceMock = new Mock<ILabResultService>();
            target = new LabResultController(_labResultServiceMock.Object);
        }

        [Fact]
        public async Task AddNewLabResult_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var request = new LabResultDto()
            {
                Date = DateTime.Now,
                Description = Faker.Lorem.Sentence(),
                PersonId = Faker.RandomNumber.Next()
            };

            // Act
            var actionResult = await target.AddNewLabResult(request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddNewLabResult_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var request = new LabResultDto()
            {
                Date = DateTime.Now,
                Description = Faker.Lorem.Sentence(),
                PersonId = Faker.RandomNumber.Next()
            };
            _labResultServiceMock.Setup(s => s.AddLabResultAsync(request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddNewLabResult(request);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task AddDocumentToLabResult_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var labResultId = Faker.RandomNumber.Next();
            var request = new List<DocumentDto>()
            {
                new DocumentDto()
                {
                    Created = DateTime.Now,
                    Description = Faker.Lorem.Sentence(),
                    FilePath = Faker.Lorem.GetFirstWord(),
                    Name = Faker.Lorem.GetFirstWord()
                }
            };

            // Act
            var actionResult = await target.AddDocumentToLabResult(labResultId, request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddDocumentToLabResult_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var labResultId = -1;
            var request = new List<DocumentDto>()
            {
                new DocumentDto()
                {
                    Created = DateTime.Now,
                    Description = Faker.Lorem.Sentence(),
                    FilePath = Faker.Lorem.GetFirstWord(),
                    Name = Faker.Lorem.GetFirstWord()
                }
            };
            _labResultServiceMock.Setup(s => s.AddDocumentToLabResultAsync(labResultId, request)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddDocumentToLabResult(labResultId, request);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task ChangeLabResultStatus_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var labResultId = Faker.RandomNumber.Next();
            var statusId = Faker.RandomNumber.Next();

            // Act
            var actionResult = await target.ChangeLabResultStatus(labResultId, statusId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(labResultId);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task ChangeLabResultStatus_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var labResultId = -1;
            var statusId = -1;

            _labResultServiceMock.Setup(s => s.ChangeLabResultStatusAsync(labResultId, statusId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.ChangeLabResultStatus(labResultId, statusId);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task GetAllLabResultsForPerson_WithValidPersonId_ReturnsOkResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            var familyDoctor = new List<LabResultListDto>()
            {
                new LabResultListDto()
                {
                    Date = DateTime.Now,
                    LabResultId = Faker.RandomNumber.Next()
                }
            };

            _labResultServiceMock.Setup(s => s.GetLabResultsForPersonAsync(personId)).ReturnsAsync(familyDoctor);

            // Act
            var actionResult = await target.GetAllLabResultsForPerson(personId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(familyDoctor);
        }

        [Fact]
        public async Task GetAllLabResultsForPerson_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int personId = Faker.RandomNumber.Next();
            _labResultServiceMock.Setup(s => s.GetLabResultsForPersonAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetAllLabResultsForPerson(personId);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task DeleteLabResult_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            _labResultServiceMock.Setup(s => s.DeleteLabResultAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.DeleteLabResult(personId);

            // Assert
            var result = actionResult as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            result.Value.Should().Be(personId);
        }
    }
}
