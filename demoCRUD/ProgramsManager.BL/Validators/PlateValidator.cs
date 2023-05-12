using FluentValidation;
using ProgramsManager.Models.Models;


namespace ProgramsManager.BL.Validators
{
    public class PlateValidator : AbstractValidator<PlateDto>
    {
        public PlateValidator()
        {
            this.RuleFor((x) => x.Name)
                .Must((x) => IsValidateName(x))
                .WithMessage("Name is not validate");

        }

        private bool IsValidateName(string name) 
        {
            string[] words = name.Split(name);
            return words.Length == 2;
        }
    }
}
