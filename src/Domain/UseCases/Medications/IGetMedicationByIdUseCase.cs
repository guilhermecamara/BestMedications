using Domain.Entities;
using Domain.UseCases.Interfaces;

namespace Domain.UseCases.Medications
{
    public interface IGetMedicationByIdUseCase : IGetEntityUseCase<Medication>
    {
    }
}
