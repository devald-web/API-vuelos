using core.interfaces;
using core.entities;

namespace infrastructure.data {
    public class ReservationRepository : IReservationRepository {
        private readonly List<Reservation> _reservations;

        public ReservationRepository() {
            _reservations = new List<Reservation>();
        }

        public void CreateReservation(Reservation reservation) {
            reservation.Id = _reservations.Count + 1;
            reservation.ReservationDate = DateTime.Now;
            reservation.Status = ReservationStatus.Active;
            _reservations.Add(reservation);
        }

        public List<Reservation> GetReservationsByFlight(int flightId) {
            return _reservations.Where(r => r.FlightId == flightId).ToList();
        }

        public List<Reservation> GetReservationsByEmail(string email) {
            return _reservations.Where(r => r.Email.ToLower() == email.ToLower()).ToList();
        }

        public Reservation? GetReservationById(int id) {
            return _reservations.FirstOrDefault(r => r.Id == id);
        }

        public void CancelReservation(int reservationId) {
            var reservation = GetReservationById(reservationId)
                ?? throw new Exception("Reserva no encontrada");

            if (reservation.Status != ReservationStatus.Active)
                throw new Exception("La reserva ya no está activa");

            reservation.Status = ReservationStatus.Cancelled;
            reservation.CancellationDate = DateTime.Now;
        }

        public void UpdateReservation(int reservationId, string? newSeatNumber = null, string? newPassengerName = null, string? newEmail = null) {
            var reservation = GetReservationById(reservationId)
                ?? throw new Exception("Reserva no encontrada");

            if (newSeatNumber != null)
                reservation.SeatNumber = newSeatNumber;
            if (newPassengerName != null)
                reservation.PassengerName = newPassengerName;
            if (newEmail != null)
                reservation.Email = newEmail;
        }

        public void CheckInReservation(int reservationId) {
            var reservation = GetReservationById(reservationId)
                ?? throw new Exception("Reserva no encontrada");

            if (reservation.Status != ReservationStatus.Active)
                throw new Exception("No se puede hacer check-in en esta reserva");

            reservation.Status = ReservationStatus.CheckedIn;
            reservation.CheckInDate = DateTime.Now;
        }

        public bool IsSeatTaken(int flightId, string seatNumber) {
            return _reservations.Any(r => 
                r.FlightId == flightId && 
                r.SeatNumber == seatNumber && 
                r.Status != ReservationStatus.Cancelled);
        }
    }
}