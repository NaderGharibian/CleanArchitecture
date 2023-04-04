using Core.Dto.Contents;

namespace Core.Interfaces;

public interface IRequestUseCase<out TResponseUseCase> where TResponseUseCase : ResponseContentResult
{

}