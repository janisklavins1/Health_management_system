namespace Management.Application.Dto
{
    public class DocumentDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
