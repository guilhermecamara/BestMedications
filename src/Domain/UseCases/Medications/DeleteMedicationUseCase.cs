using Domain.Repositories;
using System;

namespace Domain.UseCases.Medications
{
    public class DeleteMedicationUseCase : IDeleteMedicationUseCase
    {
        private readonly IMedicationRepository _medicationRepository;

        public DeleteMedicationUseCase(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public void execute(Guid id)
        {
            _medicationRepository.Delete(id);
        }
    }
}
