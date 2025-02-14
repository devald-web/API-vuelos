namespace core.entities {
    public enum ReservationStatus {
        Active,
        Cancelled,
        CheckedIn
    }

    public class Reservation {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public required string PassengerName { get; set; }
        public required string Email { get; set; }
        public required string SeatNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Active;
        public DateTime? CheckInDate { get; set; }
        public DateTime? CancellationDate { get; set; }
    }
}