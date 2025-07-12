public class Reservation
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid SpaceId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public ReservationStatus Status { get; private set; }

    public Reservation(Guid userId, Guid spaceId, DateTime startDate, DateTime endDate)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        SpaceId = spaceId;
        StartDate = startDate;
        EndDate = endDate;
        Status = ReservationStatus.Pending;
    }

    public void Cancel()
    {
        if (Status == ReservationStatus.Cancelled)
            throw new InvalidOperationException("Reservation is already cancelled.");

        Status = ReservationStatus.Cancelled;
    }

    public void UpdateStatus(ReservationStatus newStatus)
    {
        if (Status == ReservationStatus.Cancelled)
            throw new InvalidOperationException("Cannot update a cancelled reservation.");

        if (Status != ReservationStatus.Pending)
            throw new InvalidOperationException("Only pending reservations can be updated.");

        if (newStatus == ReservationStatus.Pending || newStatus == Status)
            throw new InvalidOperationException("Invalid status change.");

        Status = newStatus;
    }

    public enum ReservationStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled
    }
}
