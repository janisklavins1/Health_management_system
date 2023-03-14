using Management.Application.Dto;
using Management.Application.Enums;
using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class LabResultService : ILabResultService
    {
        private readonly ILabResultRepository _labResultRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ILabResultStatusRepository _labResultStatusRepository;
        private readonly ILabResultStatusLabResultsRepository _labResultStatusLabResultsRepository;
        private readonly IDocumentRepository _documentRepository;

        public LabResultService(
            ILabResultRepository labResultRepository,
            IPersonRepository personRepository,
            ILabResultStatusRepository labResultStatusRepository,
            ILabResultStatusLabResultsRepository labResultStatusLabResultsRepository,
            IDocumentRepository documentRepository)
        {
            _labResultRepository = labResultRepository;
            _personRepository = personRepository;
            _labResultStatusRepository = labResultStatusRepository;
            _labResultStatusLabResultsRepository = labResultStatusLabResultsRepository;
            _documentRepository = documentRepository;
        }

        public async Task AddDocumentToLabResultAsync(int labResultId, List<DocumentDto> request)
        {
            var labResult = await _labResultRepository.GetLabResultAsync(labResultId);
            foreach (var document in request)
            {
                var newDocument = new Document()
                {
                    FilePath = document.FilePath,
                    DateCreated = document.Created,
                    Name = document.Name,
                    Description = document.Description
                };
                labResult.Documents.Add(newDocument);
            }

            await _labResultRepository.AddDocumentToLabResultAsync(labResult);
        }

        public async Task AddLabResultAsync(LabResultDto request)
        {
            var person = await _personRepository.GetPersonByIdAsync(request.PersonId);

            var documentList = new List<Document>();
            foreach (var item in request.Document)
            {
                documentList.Add(new Document()
                {
                    FilePath = item.FilePath,
                    DateCreated = item.Created,
                    Name = item.Name,
                    Description = item.Description
                });
            }

            var labResult = new LabResult()
            {
                Description = request.Description,
                Documents = documentList,
                Date = request.Date,
                Person = person
            };

            // Saves in DB LabResult
            await _labResultRepository.AddLabResultAsync(labResult);

            // Creates LabResultStatusesLabResult entry
            await CreateNewLabResultStatusEntry(labResult, LabResultStatusEnum.Processing);
        }

        public async Task ChangeLabResultStatusAsync(int labResultId, int statusId)
        {
            var labResult = await _labResultRepository.GetLabResultAsync(labResultId);
            await CreateNewLabResultStatusEntry(labResult, (LabResultStatusEnum)statusId);
        }

        public async Task DeleteLabResultAsync(int labResultId)
        {
            await _labResultRepository.DeleteLabResultAsync(labResultId);
        }

        public async Task<List<LabResultListDto>> GetLabResultsForPersonAsync(int personId)
        {
            var labResults = await _labResultRepository.GetLabResultsForPersonAsync(personId);

            foreach (var item in labResults)
            {
                item.LabResultStatuses = await _labResultStatusLabResultsRepository.GetLabResultStatusesAsync(item.LabResultId);
            }

            return labResults;
        }

        private async Task CreateNewLabResultStatusEntry(LabResult labResult, LabResultStatusEnum status)
        {
            var labResultStatus = await _labResultStatusRepository.GetLabResultStatusByIdAsync((int)status);
            var labResultsStatusToLabResult = new LabResultStatusLabResult()
            {
                LabResult = labResult,
                LabResultStatus = labResultStatus,
                Date = DateTime.Now

            };

            await _labResultStatusLabResultsRepository.AddLabResultsStatusToLabResultAsync(labResultsStatusToLabResult);
        }
    }
}
