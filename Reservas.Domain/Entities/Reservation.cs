public class Reservation
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid SpaceId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public ReservationStatus Status { get; private set; } // Estado de la reserva

    // Constructor
    public Reservation(Guid userId, Guid spaceId, DateTime startDate, DateTime endDate)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        SpaceId = spaceId;
        StartDate = startDate;
        EndDate = endDate;
        Status = ReservationStatus.Pending; // Estado inicial por defecto
    }

    // Método para cancelar
    public void Cancel()
    {
        if (Status == ReservationStatus.Cancelled)
            throw new InvalidOperationException("Reservation is already cancelled.");

        Status = ReservationStatus.Cancelled;
    }

    public enum ReservationStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled
    }
}
