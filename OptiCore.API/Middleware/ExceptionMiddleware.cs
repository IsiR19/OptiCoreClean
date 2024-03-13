using OptiCore.API.Models;
using OptiCore.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace OptiCore.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string problemType = nameof(Exception);
            object problem;

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problemType = nameof(BadRequestException);
                    problem = new CustomValidationProblemDetails
                    {
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message,
                        Type = problemType
                    };
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    problemType = nameof(NotFoundException);
                    problem = new CustomValidationProblemDetails
                    {
                        Title = notFoundException.Message,
                        Status = (int)statusCode,
                        Detail = notFoundException.InnerException?.Message,
                        Type = problemType
                    };
                    break;
                default:
                    problem = new CustomValidationProblemDetails
                    {
                        Title = "An unexpected error occurred.",
                        Status = (int)statusCode,
                        Detail = ex.Message,
                        Type = problemType
                    };
                    break;
            }

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = (int)statusCode;
            string response = JsonSerializer.Serialize(problem);
            await httpContext.Response.WriteAsync(response);
        }
    }
}
