using core.interfaces;
using core.entities;

namespace core.usecases {
    public class CancelReservation {
        private readonly IReservationRepository _reservationRepository;

        public CancelReservation(IReservationRepository reservationRepository) {
            _reservationRepository = reservationRepository;
        }

        public void Execute(int reservationId) {
            _reservationRepository.CancelReservation(reservationId);
        }
    }

    public class ModifyReservation {
        private readonly IReservationRepository _reservationRepository;
        private readonly IFlightRepository _flightRepository;

        public ModifyReservation(IReservationRepository reservationRepository, IFlightRepository flightRepository) {
            _reservationRepository = reservationRepository;
            _flightRepository = flightRepository;
        }

        public void Execute(int reservationId, string? newSeatNumber = null, string? newPassengerName = null, string? newEmail = null) {
            var reservation = _reservationRepository.GetReservationById(reservationId)
                ?? throw new Exception("Reserva no encontrada");

            if (reservation.Status != ReservationStatus.Active)
                throw new Exception("Solo se pueden modificar reservas activas");

            if (newSeatNumber != null) {
                var flight = _flightRepository.GetFlightById(reservation.FlightId)
                    ?? throw new Exception("Vuelo no encontrado");
                
                if (_reservationRepository.IsSeatTaken(reservation.FlightId, newSeatNumber))
                    throw new Exception("El asiento seleccionado no está disponible");
            }

            _reservationRepository.UpdateReservation(reservationId, newSeatNumber, newPassengerName, newEmail);
        }
    }

    public class CheckInReservation {
        private readonly IReservationRepository _reservationRepository;

        public CheckInReservation(IReservationRepository reservationRepository) {
            _reservationRepository = reservationRepository;
        }

        public void Execute(int reservationId) {
            var reservation = _reservationRepository.GetReservationById(reservationId)
                ?? throw new Exception("Reserva no encontrada");

            if (reservation.Status != ReservationStatus.Active)
                throw new Exception("No se puede hacer check-in en esta reserva");

            _reservationRepository.CheckInReservation(reservationId);
        }
    }
}