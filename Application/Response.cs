#nullable enable

using System.Collections.Generic;

namespace Application
{
    public class Response<TDto>
    {
        public Response(TDto data, string? message = null)
        {
            Result = new Result(true, message);
            Data = data!;
        }

        public Response(string message)
        {
            Result = new Result(false, message);
        }

        public void AddErrors(string error)
        {
            Errors ??= new List<string>();
            Errors.Add(error);
        }

        public Result Result { get; init; }
        public List<string>? Errors { get; private set; }
        public TDto? Data { get; init; }
    }
}