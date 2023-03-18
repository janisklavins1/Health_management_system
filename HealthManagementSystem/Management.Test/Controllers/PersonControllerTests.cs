using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Test.Controllers
{
    public class PersonControllerTests
    {
        private readonly Mock<IPersonService> _personServiceMock;
        private readonly PersonController target;

        public PersonControllerTests()
        {
            _personServiceMock = new Mock<IPersonService>();
            target = new PersonController(_personServiceMock.Object);
        }

        [Fact]
        public async Task GetAllPersons_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var response = new List<Person>()
            {
                new Person()
                {
                    Name = Faker.Name.First(),
                    Surname = Faker.Name.Last(),
                    Address = new Address()
                    {
                        CityId = Faker.RandomNumber.Next(),
                        CountryId = Faker.RandomNumber.Next(),
                        PostIndex = Faker.Address.UkPostCode(),
                        HouseAddress = Faker.Address.StreetAddress()
                    },
                    BirthDate = DateTime.Now,
                    Gender = Faker.Lorem.GetFirstWord(),
                    PhoneNumber = new PhoneNumber()
                    {
                        Number = Faker.Phone.Number(),
                        PhoneNumberCountryCode = new PhoneNumberCountryCode()
                        {
                            Code = Faker.RandomNumber.Next(999).ToString(),
                        }
                    }
                }
            };

            _personServiceMock.Setup(s => s.GetAllPersonsAsync()).ReturnsAsync(response);

            // Act
            var actionResult = await target.GetAllPersons();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetAllPersons_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            _personServiceMock.Setup(s => s.GetAllPersonsAsync()).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetAllPersons();

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task GetPersonById_WithValidPersonId_ReturnsOkResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            var response = new Person()
            {
                Name = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                Address = new Address()
                {
                    CityId = Faker.RandomNumber.Next(),
                    CountryId = Faker.RandomNumber.Next(),
                    PostIndex = Faker.Address.UkPostCode(),
                    HouseAddress = Faker.Address.StreetAddress()
                },
                BirthDate = DateTime.Now,
                Gender = Faker.Lorem.GetFirstWord(),
                PhoneNumber = new PhoneNumber()
                {
                    Number = Faker.Phone.Number(),
                    PhoneNumberCountryCode = new PhoneNumberCountryCode()
                    {
                        Code = Faker.RandomNumber.Next(999).ToString(),
                    }
                }
            };

            _personServiceMock.Setup(s => s.GetPersonByIdAsync(personId)).ReturnsAsync(response);

            // Act
            var actionResult = await target.GetPersonById(personId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result.As<OkObjectResult>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetPersonById_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            int personId = -1;
            _personServiceMock.Setup(s => s.GetPersonByIdAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.GetPersonById(personId);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task AddPerson_RequestIsValid_ReturnOkResponse()
        {
            // Arrange
            var request = new PersonDto()
            {
                Name = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                HouseAddress = Faker.Address.StreetAddress(),
                PhoneNumber = Faker.Phone.Number(),
                City = Faker.Address.City(),
                Country = Faker.Address.Country(),
                BirthDate = DateTime.Now,
                Gender = Faker.Lorem.GetFirstWord(),
                PhoneNumberCountryCode = Faker.RandomNumber.Next(999).ToString(),
                PostIndex = Faker.Address.UkPostCode()
            };

            // Act
            var actionResult = await target.AddPerson(request);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().Be(request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task AddPerson_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            _personServiceMock.Setup(s => s.AddPersonAsync(null)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.AddPerson(null);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task EditPerson_WithValidPersonId_ReturnsOkObjectResult()
        {
            // Arrange
            var personId = Faker.RandomNumber.Next();
            var request = new PersonEditDto()
            {
                Name = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                HouseAddress = Faker.Address.StreetAddress(),
                PhoneNumber = Faker.Phone.Number(),
                City = Faker.Address.City(),
                Country = Faker.Address.Country(),
                PhoneNumberCountryCode = Faker.RandomNumber.Next(999).ToString(),
                PostIndex = Faker.Address.UkPostCode()
            };

            _personServiceMock.Setup(s => s.EditPersonAsync(personId, request)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await target.EditPerson(personId, request);

            // Assert
            var result = actionResult.Result.As<OkObjectResult>();
            result.Should().BeOfType<OkObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(request);
        }

        [Fact]
        public async Task EditPerson_WithInvalidValidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            var familyDoctorId = -1;

            _personServiceMock.Setup(s => s.EditPersonAsync(familyDoctorId, null)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.EditPerson(familyDoctorId, null);

            // Assert
            var result = actionResult.Result.As<BadRequestObjectResult>();
            actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            result.Value.Should().BeOfType<Exception>();
        }

        [Fact]
        public async Task DeletePerson_WithInvalidPersonId_ReturnsNotFoundResult()
        {
            // Arrange
            var personId = -1;
            _personServiceMock.Setup(s => s.DeletePersonAsync(personId)).ThrowsAsync(new Exception());

            // Act
            var actionResult = await target.DeletePerson(personId);

            // Assert
            var result = actionResult as BadRequestObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }
    }
}
