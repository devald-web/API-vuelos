using core.entities;

namespace core.interfaces {
    public interface IFlightRepository {
        List<Flight> GetAllFlights();
        Flight? GetFlightById(int id);
        List<Flight> SearchFlights(string origin, string destination, DateTime date);
        int GetAvailableSeats(int flightId);
    }
}