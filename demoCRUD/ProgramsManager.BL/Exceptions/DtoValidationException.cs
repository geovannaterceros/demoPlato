using ProgramsManager.BL.Model;
using FluentValidation.Results;

namespace ProgramsManager.BL.Exceptions
{
    public class DtoValidationException : Exception
    {
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public DtoValidationException(IEnumerable<ValidationFailure> validationErrors)
        {
            ValidationErrors = validationErrors.Select(x => new ValidationError
            {
                PropertyName = x.PropertyName,
                ErrorMessage = x.ErrorMessage,
            });
        }
    }
}
