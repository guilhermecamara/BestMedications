using System;

namespace Domain.UseCases.Interfaces
{
    public interface IGetEntityUseCase<Response> : IUseCase<Guid, Response>
    {
    }
}
