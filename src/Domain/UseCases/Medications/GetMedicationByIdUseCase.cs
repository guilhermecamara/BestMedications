using Domain.Entities;
using Domain.Repositories;
using System;

namespace Domain.UseCases.Medications
{
    public class GetMedicationByIdUseCase : IGetMedicationByIdUseCase
    {
        private readonly IMedicationRepository _medicationRepository;

        public GetMedicationByIdUseCase(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public Medication execute(Guid request)
        {
            return _medicationRepository.Get(request);
        }
    }
}
