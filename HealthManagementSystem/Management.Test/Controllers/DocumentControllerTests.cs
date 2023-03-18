using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Test.Controllers
{
    public class DocumentControllerTests
    {
        private readonly Mock<IDocumentService> _documentServiceMock;
        private readonly DocumentController target;

        public DocumentControllerTests()
        {
            _documentServiceMock = new Mock<IDocumentService>();
            target = new DocumentController(_documentServiceMock.Object);
        }

        [Fact]
        public async Task EditAllergyForPerson_WithValidAllergyPersonId_ReturnsOkObjectResult()
        {
            // Arrange
            int editDocumentId = Faker.RandomNumber.Next();
            var documentEditDto = new DocumentEditDto()
            {
                Name = Faker.Name.First(),
                Description = Faker.Name.First(),
                FilePath = Faker.Address.City()
            };

            _documentServiceMock.Setup(s => s.EditDocumentAsync(editDocumentId, documentEditDto)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await target.EditDocument(editDocumentId, documentEditDto);

            // Assert
            var okResult = actionResult.As<OkObjectResult>();
            okResult.Should().BeOfType<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(documentEditDto);
        }

        [Fact]
        public async Task EditAllergyForPerson_WithInvalidAllergyPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int editDocumentId = -1;
            var documentEditDto = new DocumentEditDto()
            {
                Name = Faker.Name.First(),
                Description = Faker.Name.First(),
                FilePath = Faker.Address.City()
            };
            _documentServiceMock.Setup(s => s.EditDocumentAsync(editDocumentId, documentEditDto)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.EditDocument(editDocumentId, documentEditDto);

            // Assert
            var result = actionResult.As<ActionResult>();
            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
