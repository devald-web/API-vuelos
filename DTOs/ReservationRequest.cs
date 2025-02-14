namespace vuelos.DTOs
{
    public record ReservationRequest(int FlightId, string PassengerName, string Email, string SeatNumber);
}