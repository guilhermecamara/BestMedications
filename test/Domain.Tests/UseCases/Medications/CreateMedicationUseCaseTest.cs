using Domain.Entities;
using Domain.Repositories;
using Domain.UseCases.Medications;
using Domain.UseCases.Medications.Validators;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests.UseCases.Medications
{
    public class CreateMedicationUseCaseTest
    {
        [Theory, MemberData(nameof(CreateMedicationUseCaseExecuteData))]
        public void CreateMedicationUseCaseExecute(Medication request, Medication response)
        {
            // Arrange
            var createMedicationValidator = new CreateMedicationValidator();

            var mockMedicationRepository = new Mock<IMedicationRepository>();
            mockMedicationRepository.Setup(p => p.Create(request)).Returns(response);

            var useCase = new CreateMedicationUseCase(createMedicationValidator, mockMedicationRepository.Object);

            // Act
            var result = useCase.execute(request);

            // Assert

            Assert.NotNull(result.Id);
            Assert.NotNull(result.CreationDate);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Quantity, response.Quantity);
        }

        public static IEnumerable<object[]> CreateMedicationUseCaseExecuteData()
        {
            yield return new object[]
            {
                new Medication {Name = "Med 1", Quantity = 1},
                new Medication {Id = Guid.NewGuid(), Name = "Med 1", Quantity = 1, CreationDate = DateTime.Now}
            };

            yield return new object[]
            {
                new Medication {Name = "Med 2", Quantity = 30},
                new Medication {Id = Guid.NewGuid(), Name = "Med 2", Quantity = 30, CreationDate = DateTime.Now}
            };
        }

        [Theory, MemberData(nameof(CreateMedicationUseCaseExecuteValidationExceptionData))]
        public void CreateMedicationUseCaseExecuteValidationException(Medication request, string exceptionMessage)
        {
            // Arrange
            var createMedicationValidator = new CreateMedicationValidator();

            var mockMedicationRepository = new Mock<IMedicationRepository>();

            var useCase = new CreateMedicationUseCase(createMedicationValidator, mockMedicationRepository.Object);
            
            // Act
            var caughtException = Assert.Throws<ValidationException>(() => useCase.execute(request));

            // Assert
            Assert.Contains(exceptionMessage, caughtException.Message);
        }

        public static IEnumerable<object[]> CreateMedicationUseCaseExecuteValidationExceptionData()
        {
            yield return new object[]
            {
                new Medication {Name = null, Quantity = 1},
                "Name: 'Name' must not be empty"
            };

            yield return new object[]
            {
                new Medication {Name = "Med 2", Quantity = 0},
                "Quantity: Quantity cannot be 0"
            };

            yield return new object[]
            {
                new Medication {Name = "", Quantity = 30},
                "Name: 'Name' must not be empty"
            };

            yield return new object[]
            {
                new Medication {Name = new string('s', 151), Quantity = 50},
                "Name: Name max length is 150"
            };
        }
    }
}
