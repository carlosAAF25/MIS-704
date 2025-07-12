namespace Reservas.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public Guid SpaceId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public ReservationStatus Status { get; private set; } = ReservationStatus.Pending;

        public Reservation(Guid userId, Guid spaceId, DateTime startDate, DateTime endDate)
        {
            UserId = userId;
            SpaceId = spaceId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Approve()
        {
            Status = ReservationStatus.Approved;
        }

        public void Reject()
        {
            Status = ReservationStatus.Rejected;
        }
    }

    public enum ReservationStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled
    }
}
