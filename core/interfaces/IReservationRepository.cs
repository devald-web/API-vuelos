using core.entities;

namespace core.interfaces {
    public interface IReservationRepository {
        void CreateReservation(Reservation reservation);
        List<Reservation> GetReservationsByFlight(int flightId);
        List<Reservation> GetReservationsByEmail(string email);
        Reservation? GetReservationById(int id);
        void CancelReservation(int reservationId);
        void UpdateReservation(int reservationId, string? newSeatNumber = null, string? newPassengerName = null, string? newEmail = null);
        void CheckInReservation(int reservationId);
        bool IsSeatTaken(int flightId, string seatNumber);
    }
}