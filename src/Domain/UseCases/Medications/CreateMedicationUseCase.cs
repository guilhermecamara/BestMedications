using Domain.Entities;
using Domain.Repositories;
using Domain.UseCases.Medications.Validators;
using FluentValidation;

namespace Domain.UseCases.Medications
{
    public class CreateMedicationUseCase : ICreateMedicationUseCase
    {
        private readonly ICreateMedicationValidator _createMedicationValidator;
        private readonly IMedicationRepository _medicationRepository;

        public CreateMedicationUseCase(ICreateMedicationValidator createMedicationValidator, IMedicationRepository medicationRepository)
        {
            _createMedicationValidator = createMedicationValidator;
            _medicationRepository = medicationRepository;
        }

        public Medication execute(Medication request)
        {
            var validationResult = _createMedicationValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            return _medicationRepository.Create(request);
        }
    }
}
