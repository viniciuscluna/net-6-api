using FluentValidation;
using microservice.Dto;

namespace microservice.Validation
{
    public class CarValidator : AbstractValidator<CarDto>
    {
        public CarValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
