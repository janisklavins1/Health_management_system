using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Application.Repositories;

namespace Management.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task DeleteDocumentAsync(int documentId)
        {
           await _documentRepository.DeleteDocumentAsync(documentId);
        }

        public async Task EditDocumentAsync(int documentId, DocumentEditDto request)
        {
            var documentEdit = await _documentRepository.GetDocumentByIdAsync(documentId);
            documentEdit.FilePath = request.FilePath;
            documentEdit.Name = request.Name;
            documentEdit.Description = request.Description;
            await _documentRepository.EditDocumentAsync(documentEdit);
        }
    }
}
