using core.interfaces;
using core.entities;

namespace core.usecases {
    public class SearchFlights {
        private readonly IFlightRepository _flightRepository;

        public SearchFlights(IFlightRepository flightRepository) {
            _flightRepository = flightRepository;
        }

        public List<Flight> Execute(string origin, string destination, DateTime date) {
            if (string.IsNullOrEmpty(origin) && string.IsNullOrEmpty(destination))
            {
                return _flightRepository.GetAllFlights();
            }
            return _flightRepository.SearchFlights(origin, destination, date);
        }
    }
}