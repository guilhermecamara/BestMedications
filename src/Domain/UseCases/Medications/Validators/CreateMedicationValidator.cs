using Domain.Entities;
using FluentValidation;

namespace Domain.UseCases.Medications.Validators
{
    public class CreateMedicationValidator : AbstractValidator<Medication>, ICreateMedicationValidator
    {
        public CreateMedicationValidator()
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .Length(1, 150)
            .WithMessage("Name max length is 150");

            RuleFor(a => a.Quantity)            
            .GreaterThan(0u)
            .WithMessage("Quantity cannot be 0");
        }
    }
}
