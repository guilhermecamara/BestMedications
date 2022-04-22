using System.Collections.Generic;

namespace Domain.UseCases.Interfaces
{
    public interface IGetAllEntitiesUseCase<Response>
    {
        IEnumerable<Response> execute();
    }
}
