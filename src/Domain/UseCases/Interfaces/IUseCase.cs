namespace Domain.UseCases.Interfaces
{
    public interface IUseCase<Request, Response>
    {
        Response execute(Request request);
    }
}
