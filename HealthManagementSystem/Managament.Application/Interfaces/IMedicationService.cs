using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IMedicationService
    {
        Task<Medication> GetMedication(int id);
        Task<ICollection<Medication>> GetAllMedicationsAsync();
        void AddMedication(Medication medication);

        Task EditMedicationAsync(Medication medication);
    }
}
