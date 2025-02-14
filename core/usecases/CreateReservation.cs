using core.interfaces;
using core.entities;

namespace core.usecases {
    public class CreateReservation {
        private readonly IReservationRepository _reservationRepository;
        private readonly IFlightRepository _flightRepository;

        public CreateReservation(IReservationRepository reservationRepository, IFlightRepository flightRepository) {
            _reservationRepository = reservationRepository;
            _flightRepository = flightRepository;
        }

        public void Execute(int flightId, string passengerName, string email, string seatNumber) {
            var flight = _flightRepository.GetFlightById(flightId);
            if (flight == null || flight.AvailableSeats <= 0) {
                throw new Exception("Vuelo no disponible");
            }

            var reservation = new Reservation {
                FlightId = flightId,
                PassengerName = passengerName,
                Email = email,
                SeatNumber = seatNumber
            };

            _reservationRepository.CreateReservation(reservation);
        }
    }
}