using HealthManagementSystem.Dto;
using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public MedicationService(IMedicationRepository medicationRepository, IIngredientRepository ingredientRepository)
        {
            _medicationRepository = medicationRepository;
            _ingredientRepository = ingredientRepository;
        }
        public async Task AddMedicationAsync(MedicationDto request)
        {
            var ingredientsCollection = new List<Ingredient>();

            foreach (var item in request.Ingredients)
            {
                var foundIngredient = await _ingredientRepository.GetIngredientByNameAsync(item.Name);

                if (foundIngredient != null)
                {
                    ingredientsCollection.Add(foundIngredient);
                }
                else
                {
                    ingredientsCollection.Add(new Ingredient() { Name = item.Name });
                }
            }

            var newMedication = new Medication()
            {
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
                Ingredients = ingredientsCollection
            };


            await _medicationRepository.AddMedicationAsync(newMedication);
        }

        public async Task<ICollection<Medication>> GetAllMedicationsAsync()
        {
            return await _medicationRepository.GetAllMedicationsAsync();
        }

        public async Task<Medication> GetMedicationAsync(int id)
        {
            return await _medicationRepository.GetMedicationAsync(id);
        }

        public async Task EditMedicationAsync(int id, MedicationDto request)
        {
            var ingredientsCollection = new List<Ingredient>();

            foreach (var item in request.Ingredients)
            {
                var foundIngredient = await _ingredientRepository.GetIngredientByNameAsync(item.Name);

                if (foundIngredient != null)
                {
                    ingredientsCollection.Add(foundIngredient);
                }
                else
                {
                    ingredientsCollection.Add(new Ingredient() { Name = item.Name });
                }
            }

            var editMedicine = await _medicationRepository.GetMedicationAsync(id);

            editMedicine.Name = request.Name;
            editMedicine.Description = request.Description;
            editMedicine.Type = request.Type;
            editMedicine.Ingredients = ingredientsCollection;

            await _medicationRepository.EditMedicationAsync(editMedicine);
        }
    }
}
