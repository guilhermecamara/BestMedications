using Domain.Entities;
using Domain.Errors;
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
    public class UpdateMedicationUseCaseTest
    {
        [Theory, MemberData(nameof(UpdateMedicationUseCaseExecuteData))]
        public void UpdateMedicationUseCaseExecute(Medication request, Medication response)
        {
            // Arrange
            var updateMedicationValidator = new UpdateMedicationValidator();

            var mockMedicationRepository = new Mock<IMedicationRepository>();
            mockMedicationRepository.Setup(p => p.Update(request)).Returns(response);

            var useCase = new UpdateMedicationUseCase(updateMedicationValidator, mockMedicationRepository.Object);

            // Act
            var result = useCase.execute(request);

            // Assert            
            Assert.NotNull(result.Id);
            Assert.NotNull(result.CreationDate);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Quantity, response.Quantity);
        }

        public static IEnumerable<object[]> UpdateMedicationUseCaseExecuteData()
        {
            var id1 = Guid.NewGuid();
            yield return new object[]
            {
                new Medication {Id = id1, Name = "Med 1", Quantity = 2},
                new Medication {Id = id1, Name = "Med 1", Quantity = 2, CreationDate = DateTime.Now}
            };

            var id2 = Guid.NewGuid();
            yield return new object[]
            {
                new Medication {Id = id2, Name = "Med 2", Quantity = 1},
                new Medication {Id = id2, Name = "Med 2", Quantity = 1, CreationDate = DateTime.Now}
            };
        }

        [Theory, MemberData(nameof(UpdateMedicationUseCaseExecuteValidationExceptionData))]
        public void UpdateMedicationUseCaseExecuteValidationException(Medication request, string exceptionMessage)
        {
            // Arrange
            var updateMedicationValidator = new UpdateMedicationValidator();

            var mockMedicationRepository = new Mock<IMedicationRepository>();

            var useCase = new UpdateMedicationUseCase(updateMedicationValidator, mockMedicationRepository.Object);

            // Act
            var caughtException = Assert.Throws<ValidationException>(() => useCase.execute(request));

            // Assert
            Assert.Contains(exceptionMessage, caughtException.Message);
        }

        public static IEnumerable<object[]> UpdateMedicationUseCaseExecuteValidationExceptionData()
        {
            yield return new object[]
            {
                new Medication {Id = Guid.NewGuid(), Name = null, Quantity = 1},
                "Name: 'Name' must not be empty"
            };

            yield return new object[]
            {
                new Medication {Id = Guid.NewGuid(), Name = "Med 2", Quantity = 0},
                "Quantity: Quantity cannot be 0"
            };

            yield return new object[]
            {
                new Medication {Id = Guid.NewGuid(), Name = new string('s', 151), Quantity = 1},
                "Name: Name max length is 150"
            };

            yield return new object[]
            {
                new Medication {Id = Guid.NewGuid(), Name = "", Quantity = 2},
                "Name: 'Name' must not be empty"
            };

            yield return new object[]
            {
                new Medication {Id = null, Name = "Med 5", Quantity = 3},
                "Id: Id cannot be null"
            };
        }

        [Theory, MemberData(nameof(UpdateMedicationByIdUseCaseNotFoundExceptionData))]
        public void UpdateMedicationByIdUseCaseNotFoundException(Medication request)
        {
            // Arrange
            var updateMedicationValidator = new UpdateMedicationValidator();

            var mockMedicationRepository = new Mock<IMedicationRepository>();
            mockMedicationRepository.Setup(p => p.Update(request)).Throws(() => new EntityNotFoundException(nameof(Medication), request.Id));

            var useCase = new UpdateMedicationUseCase(updateMedicationValidator, mockMedicationRepository.Object);

            // Act
            var caughtException = Assert.Throws<EntityNotFoundException>(() => useCase.execute(request));

            // Assert
            Assert.Contains($"Entity \"Medication\" ({request.Id}) was not found", caughtException.Message);
        }

        public static IEnumerable<object[]> UpdateMedicationByIdUseCaseNotFoundExceptionData()
        {
            var id1 = Guid.NewGuid();
            yield return new object[]
            {
                new Medication {Id = id1, Name = "Med 1", Quantity = 2}
            };

            var id2 = Guid.NewGuid();
            yield return new object[]
            {
                new Medication {Id = id2, Name = "Med 2", Quantity = 3}
            };
        }
    }
}
