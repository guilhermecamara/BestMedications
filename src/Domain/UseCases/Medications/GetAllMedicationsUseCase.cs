using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;

namespace Domain.UseCases.Medications
{
    public class GetAllMedicationsUseCase : IGetAllMedicationsUseCase
    {
        private readonly IMedicationRepository _medicationRepository;

        public GetAllMedicationsUseCase(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public IEnumerable<Medication> execute()
        {
            return _medicationRepository.GetAll();
        }
    }
}
