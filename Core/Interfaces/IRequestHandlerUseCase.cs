using Core.Dto.Contents;

namespace Core.Interfaces;

public interface IRequestHandlerUseCase<in TRequestUseCase, out TResponseUseCase>
    where TRequestUseCase : IRequestUseCase<ResponseContentResult>
    where TResponseUseCase : ResponseContentResult
{
    Task<bool> Handle(TRequestUseCase request, IResponseUseCase<TResponseUseCase> response);
}