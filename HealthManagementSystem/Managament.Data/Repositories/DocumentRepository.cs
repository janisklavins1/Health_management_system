using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly HealthManagementDbContext _context;

        public DocumentRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task DeleteDocumentAsync(int documentId)
        {
            var document = await GetDocumentByIdAsync(documentId);
            _ = _context.Documents.Remove(document) ?? throw new Exception($"Couldn't delete Document with ID {document.DocumentId} .");
            await _context.SaveChangesAsync();
        }

        public async Task EditDocumentAsync(Document document)
        {
            _ = _context.Documents.Attach(document)
                ?? throw new Exception($"Couldn't edit Document with ID {document.DocumentId} .");
            await _context.SaveChangesAsync();
        }

        public async Task<Document> GetDocumentByIdAsync(int documentId)
        {
            var document = await _context.Documents
                .FirstAsync(x => x.DocumentId == documentId);


            return document ?? throw new Exception($"Document with Id {documentId} not found.");
        }
    }
}
