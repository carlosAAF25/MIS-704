using FluentValidation;

namespace Reservas.Application.UseCases.Reservations.CreateReservation
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.SpaceId).NotEmpty();
            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage("Start date must be before end date.");
            RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Start date must be in the future.");
        }
    }
}
