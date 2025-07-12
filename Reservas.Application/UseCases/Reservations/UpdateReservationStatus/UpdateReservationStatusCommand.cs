using static Reservation;

public class UpdateReservationStatusCommand
{
    public Guid ReservationId { get; set; }
    public ReservationStatus NewStatus { get; set; }
}
