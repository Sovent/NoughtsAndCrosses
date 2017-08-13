using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NoughtsAndCrosses.Filters
{
  public class GameExceptionFilter : ExceptionFilterAttribute
  {
    public override void OnException(ExceptionContext context)
    {
      switch (context.Exception)
      {
        case InvalidOperationException exception:
          context.Result = ConvertException(HttpStatusCode.BadRequest, exception);
          break;
        case ArgumentOutOfRangeException exception:
          context.Result = ConvertException(HttpStatusCode.BadRequest, exception);
          break;
        case Exception exception:
          context.Result = ConvertException(HttpStatusCode.InternalServerError, exception);
          break;
      }
    }

    private IActionResult ConvertException(HttpStatusCode statusCode, Exception exception)
    {
      return new ContentResult
      {
        Content = exception.Message,
        StatusCode = (int)statusCode
      };
    }
  }
}