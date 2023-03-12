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

        public LabResultService(ILabResultRepository labResultRepository, IPersonRepository personRepository, ILabResultStatusRepository labResultStatusRepository)
        {
            _labResultRepository = labResultRepository;
            _personRepository = personRepository;
            _labResultStatusRepository = labResultStatusRepository;
        }

        public async Task AddLabResultAsync(LabResultDto request)
        {
            var person = await _personRepository.GetPersonByIdAsync(request.PersonId);
            var labResultStatus = await _labResultStatusRepository.GetLabResultStatusByIdAsync((int)LabResultStatusEnum.Processing);

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

            var labResultStatusesList = new List<LabResultStatus>() 
            {
                labResultStatus
            };

            var labResult = new LabResult()
            {
                Description = request.Description,
                Documents = documentList,
                Date = request.Date,
                Person = person,
                LabResultStatuses = labResultStatusesList
            };

            // LabResultStatusesLabResult nomainas status uz InProgress...

            await _labResultRepository.AddLabResultAsync(labResult);
        }
    }
}
