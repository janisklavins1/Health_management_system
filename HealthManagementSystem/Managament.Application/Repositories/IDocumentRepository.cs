using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IDocumentRepository
    {
        Task<Document> GetDocumentByIdAsync(int documentId);
        Task EditDocumentAsync(Document document);
        Task DeleteDocument(int documentId);
    }
}
