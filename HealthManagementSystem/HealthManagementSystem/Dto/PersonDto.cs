namespace HealthManagementSystem.Dto
{
    public class PersonDto
    {
        public string Name { get; set; } = "Name";
        public string Surname { get; set; } = "Surname";
        public string Gender { get; set; } = "Gender";
        public DateTime BirthDate { get; set; } = DateTime.Today;
    }
}
