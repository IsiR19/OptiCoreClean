using Microsoft.AspNetCore.Mvc;

namespace OptiCore.API.Models
{
    public class CustomValidationProblemDetails : ProblemDetails
    {
        private IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}