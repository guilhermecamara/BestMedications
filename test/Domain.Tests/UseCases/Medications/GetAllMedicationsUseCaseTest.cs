using Domain.Entities;
using Domain.Repositories;
using Domain.UseCases.Medications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.Tests.UseCases.Medications
{
    public class GetAllMedicationsUseCaseTest
    {
        [Theory, MemberData(nameof(CreateMedicationUseCaseExecuteData))]
        public void GetAllMedicationsUseCaseExecute(Medication[] response, int length)
        {
            // Arrange            
            var mockMedicationRepository = new Mock<IMedicationRepository>();
            mockMedicationRepository.Setup(p => p.GetAll()).Returns(response);

            var useCase = new GetAllMedicationsUseCase(mockMedicationRepository.Object);

            // Act
            var result = useCase.execute();

            // Assert

            Assert.NotNull(result);
            Assert.Equal(result.Count(), length);
        }

        public static IEnumerable<object[]> CreateMedicationUseCaseExecuteData()
        {
            yield return new object[]
            {
                Array.Empty<Medication>(),
                0
            };

            yield return new object[]
            {
                new Medication [] { new Medication(), new Medication() },
                2
            };
        }
    }
}
