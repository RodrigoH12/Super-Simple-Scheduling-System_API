using Newtonsoft.Json;
using SuperSimpleSchedulingSystem.Data.Exceptions;
using SuperSimpleSchedulingSystem.Logic.Exceptions;
using System.Net;

namespace SuperSimpleSchedulingSystem.Presentation.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private const string _jsonContentType = "application/json";
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var ErrorResponse = new MiddlewareResponse<string>(null);
            if (ex is UnauthorizedAccessException || ex is ArgumentNullException)
            {
                ErrorResponse.Status = (int)HttpStatusCode.Unauthorized;
                ErrorResponse.error.Message = "Unauthorized";
            }
            else if (ex is LogicException)
            {
                ErrorResponse.Status = (int)HttpStatusCode.OK;
                ErrorResponse.error.Message = $"Logic Exception {Environment.NewLine} Message: {ex.Message + Environment.NewLine}";
            }
            else if (ex is DatabaseException)
            {
                ErrorResponse.Status = (int)HttpStatusCode.OK;
                ErrorResponse.error.Message = $"Data Error {Environment.NewLine} Message: {ex.Message}{Environment.NewLine}";
            }
            else if (ex is BadRequestException)
            {
                ErrorResponse.Status = (int)HttpStatusCode.BadRequest;
                ErrorResponse.error.Message = $"Data Error {Environment.NewLine} Message: {ex.Message}{Environment.NewLine}";
                if (((BadRequestException)ex).Details != null)
                {
                    ErrorResponse.error.Details = ((BadRequestException)ex).Details;
                }
            }
            else if (ex is NotFoundException)
            {
                ErrorResponse.Status = (int)HttpStatusCode.NotFound;
                ErrorResponse.error.Message = $"Data Error {Environment.NewLine} Message: {ex.Message}{Environment.NewLine}";
            }
            else if (ex is AlreadyExistException)
            {
                ErrorResponse.Status = (int)HttpStatusCode.BadRequest;
                ErrorResponse.error.Message = $"Data Error {Environment.NewLine} Message: {ex.Message}{Environment.NewLine}";
            }
            else
            {
                ErrorResponse.Status = (int)HttpStatusCode.InternalServerError;
                ErrorResponse.error.Message = $"Internal Server Error: {ex.Message}";
            }
            context.Response.ContentType = _jsonContentType;
            context.Response.StatusCode = ErrorResponse.Status;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(ErrorResponse));
        }
    }
}
