using Domain.Repositories;
using Domain.UseCases.Medications;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests.UseCases.Medications
{
    public class DeleteMedicationUseCaseTest
    {
        [Theory, MemberData(nameof(DeleteMedicationUseCaseExecuteData))]
        public void DeleteMedicationUseCaseExecute(Guid id)
        {
            // Arrange            
            var mockMedicationRepository = new Mock<IMedicationRepository>();

            var useCase = new DeleteMedicationUseCase(mockMedicationRepository.Object);

            // Act
            useCase.execute(id);

            // Assert
            Assert.True(true);
        }

        public static IEnumerable<object[]> DeleteMedicationUseCaseExecuteData()
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
