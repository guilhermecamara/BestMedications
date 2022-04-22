using Domain.Entities;
using Domain.UseCases.Interfaces;

namespace Domain.UseCases.Medications
{
    public interface IGetAllMedicationsUseCase : IGetAllEntitiesUseCase<Medication>
    {
    }
}
