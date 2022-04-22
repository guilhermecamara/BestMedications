using System;

namespace Domain.UseCases.Interfaces
{
    public interface IDeleteEntityUseCase
    {
        void execute(Guid id);
    }
}
