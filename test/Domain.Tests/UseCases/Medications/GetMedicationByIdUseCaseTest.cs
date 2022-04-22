using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Domain.UseCases.Medications;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests.UseCases.Medications
{
    public class GetMedicationByIdUseCaseTest
    {
        [Theory, MemberData(nameof(GedMedicationByIdUseCaseExecuteData))]
        public void GetMedicationByIdUseCaseExecute(Guid request, Medication response)
        {
            // Arrange            
            var mockMedicationRepository = new Mock<IMedicationRepository>();
            mockMedicationRepository.Setup(p => p.Get(request)).Returns(response);

            var useCase = new GetMedicationByIdUseCase(mockMedicationRepository.Object);

            // Act
            var result = useCase.execute(request);

            // Assert
            Assert.NotNull(result.Id);
            Assert.NotNull(result.CreationDate);
            Assert.Equal(result.Id, request);
            Assert.Equal(result.Name, response.Name);
            Assert.Equal(result.Quantity, response.Quantity);
        }

        public static IEnumerable<object[]> GedMedicationByIdUseCaseExecuteData()
        {
            var id1 = Guid.NewGuid();
            yield return new object[]
            {
                id1,
                new Medication {Id = id1, Name = "Med 1", Quantity = 1, CreationDate = DateTime.Now}
            };

            var id2 = Guid.NewGuid();
            yield return new object[]
            {
                id2,
                new Medication {Id = id2, Name = "Med 2", Quantity = 20, CreationDate = DateTime.Now}
            };
        }

        [Theory, MemberData(nameof(GetMedicationByIdUseCaseNotFoundExceptionData))]
        public void GetMedicationByIdUseCaseNotFoundException(Guid request)
        {
            // Arrange            
            var mockMedicationRepository = new Mock<IMedicationRepository>();
            mockMedicationRepository.Setup(p => p.Get(request)).Throws(() => new EntityNotFoundException(nameof(Medication), request));

            var useCase = new GetMedicationByIdUseCase(mockMedicationRepository.Object);

            // Act
            var caughtException = Assert.Throws<EntityNotFoundException>(() => useCase.execute(request));

            // Assert
            Assert.Contains($"Entity \"Medication\" ({request}) was not found", caughtException.Message);
        }

        public static IEnumerable<object[]> GetMedicationByIdUseCaseNotFoundExceptionData()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new object[]
                {
                    Guid.NewGuid()
                };
            }
        }
    }
}
