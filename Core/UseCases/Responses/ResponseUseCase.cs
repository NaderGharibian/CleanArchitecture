using Core.Dto;
using Core.Dto.Contents;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.UseCases.Responses
{
    public abstract class ResponseUseCase<T> :  IResponseUseCase<T> where T : ResponseContentResult
    {
        public ContentResult ContentResult { get; }
        protected ResponseUseCase()
        {
            ContentResult = new ContentResult();
        }
        public virtual void Handle(T response)
        {
            ContentResult.ContentType = "application/json";
            ContentResult.Content = JsonConvert.SerializeObject(response);
        }
    }
}
