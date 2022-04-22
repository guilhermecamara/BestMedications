using Domain.Entities;
using FluentValidation;

namespace Domain.UseCases.Medications.Validators
{
    public interface ICreateMedicationValidator : IValidator<Medication>
    {
    }
}
