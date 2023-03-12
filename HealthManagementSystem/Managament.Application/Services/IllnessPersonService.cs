using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class IllnessPersonService : IIllnessPersonService
    {
        private readonly IIllnessPersonRepository _illnessPersonRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IIllnessRepository _illnessRepository;

        public IllnessPersonService(IIllnessPersonRepository illnessPersonRepository, IPersonRepository personRepository, IIllnessRepository illnessRepository)
        {
            _illnessPersonRepository = illnessPersonRepository;
            _personRepository = personRepository;
            _illnessRepository = illnessRepository;
        }

        public async Task AddIllnessToPersonAsync(IllnessPersonDto request)
        {
            var person = await _personRepository.GetPersonByIdAsync(request.PersonId);
            var illness = await _illnessRepository.GetIllnessByIdAsync(request.IllnessId);

            var illnessPerson = new IllnessPerson()
            {
                Illness = illness,
                Person = person,
                DateDiscovered = request.DateDiscovered,
                Status = request.Status,
                Prohibitions = request.Prohibitions
            };

            await _illnessPersonRepository.AddIllnessToPersonAsync(illnessPerson);
        }

        public async Task EditIllnessToPersonAsync(int illnessPersonId, IllnessPersonEditDto request)
        {
            var illness = await _illnessRepository.GetIllnessByIdAsync(request.IllnessId);
            var illnessPerson = await _illnessPersonRepository.GetIllnessesPersonByIdAsync(illnessPersonId);
            illnessPerson.Illness = illness;
            illnessPerson.DateDiscovered = request.DateDiscovered;
            illnessPerson.Status = request.Status;
            illnessPerson.Prohibitions = request.Prohibitions;

            await _illnessPersonRepository.EditIllnessToPersonAsync(illnessPerson);
        }

        public async Task<List<IllnessPersonListDto>> GetAllPersonIllnessesAsync(int personId)
        {
            return await _illnessPersonRepository.GetAllPersonIllnessesAsync(personId);
        }
    }
}
