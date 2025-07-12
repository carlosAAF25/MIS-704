namespace Reservas.Application.UseCases.Reservations.CreateReservation
{
    public class CreateReservationCommand
    {
        public Guid UserId { get; set; }
        public Guid SpaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
