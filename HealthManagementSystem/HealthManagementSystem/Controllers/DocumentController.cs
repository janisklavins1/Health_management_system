using Management.Application.Dto;
using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPut("{documentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditDocument(int documentId, DocumentEditDto request)
        {
            try
            {
                await _documentService.EditDocumentAsync(documentId, request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{documentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDocument(int documentId)
        {
            try
            {
                await _documentService.DeleteDocumentAsync(documentId);
                return Ok(documentId);
            }
            catch (Exception)
            {
                return BadRequest(documentId);
            }
        }
    }
}
