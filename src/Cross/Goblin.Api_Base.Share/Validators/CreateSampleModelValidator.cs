using FluentValidation;
using Goblin.Api_Base.Share.Models;

namespace Goblin.Api_Base.Share.Validators
{
    public class CreateSampleModelValidator : AbstractValidator<GoblinApi_BaseCreateSampleModel>
    {
        public CreateSampleModelValidator()
        {
            RuleFor(x => x.SampleData)
                .NotEmpty()
                .WithMessage("Please Input Sample Data");
        }
    }
}