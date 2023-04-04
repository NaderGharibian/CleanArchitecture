using Core.Dto.Contents;

namespace Core.Interfaces;

public interface IResponseUseCase<in TResponseUseCase> where TResponseUseCase : ResponseContentResult
{
    void Handle(TResponseUseCase response);
}