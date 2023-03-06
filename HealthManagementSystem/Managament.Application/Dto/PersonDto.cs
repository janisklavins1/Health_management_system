namespace HealthManagementSystem.Dto
{
    public class PersonDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Today;
        public string HouseAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostIndex { get; set; } = string.Empty;
        public string PhoneNumberCountryCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
