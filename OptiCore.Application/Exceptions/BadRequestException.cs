using FluentValidation.Results;

namespace OptiCore.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public List<string> Errors { get; set; }

        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            Errors = new();
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}