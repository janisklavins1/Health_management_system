using Management.Application.Dto;

namespace Management.Application.Interfaces
{
    public interface IDocumentService
    {
        Task EditDocumentAsync(int documentId, DocumentEditDto request);
        Task DeleteDocumentAsync(int documentId);
    }
}
