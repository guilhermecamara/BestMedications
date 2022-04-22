using Domain.Entities;
using Domain.Repositories;
using Domain.UseCases.Medications.Validators;
using FluentValidation;

namespace Domain.UseCases.Medications
{
    public class UpdateMedicationUseCase : IUpdateMedicationUseCase
    {
        private readonly IUpdateMedicationValidator _updatemedicationValidator;
        private readonly IMedicationRepository _medicationRepository;

        public UpdateMedicationUseCase(IUpdateMedicationValidator updatemedicationValidator, IMedicationRepository medicationRepository)
        {
            _updatemedicationValidator = updatemedicationValidator;
            _medicationRepository = medicationRepository;
        }

        public Medication execute(Medication request)
        {
            var validationResult = _updatemedicationValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            return _medicationRepository.Update(request);
        }
    }
}
