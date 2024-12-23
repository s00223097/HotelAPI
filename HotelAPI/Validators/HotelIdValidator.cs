using FluentValidation;

namespace HotelAPI.Validators
{
    public class HotelIdValidator : AbstractValidator<int> // base class from fluentval
    {
        public HotelIdValidator()
        {
            // Extremely basic validation - A ID must be a positive number
            RuleFor(id => id).GreaterThan(0).WithMessage("Hotel ID must be a positive number");
            // Other validations? Maybe that they have to follow a certain pattern
            
        }
    }
}
