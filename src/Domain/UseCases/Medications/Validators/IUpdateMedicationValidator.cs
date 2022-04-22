using Domain.Entities;
using FluentValidation;

namespace Domain.UseCases.Medications.Validators
{
    public interface IUpdateMedicationValidator : IValidator<Medication>
    {
    }
}
