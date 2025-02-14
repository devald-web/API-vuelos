using core.interfaces;
using core.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace infrastructure.data
{
    public class FlightRepository : IFlightRepository
    {
        private readonly List<Flight> _flights;

        public FlightRepository()
        {
            _flights = new List<Flight> {
        // Vuelos Europa
        new Flight {
            Id = 1,
            Origin = "Madrid",
            Destination = "Paris",
            DepartureTime = DateTime.UtcNow.AddDays(1),
            ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(2),
            Price = 2200.00M,
            AvailableSeats = 150
        },
        new Flight {
            Id = 2,
            Origin = "London",
            Destination = "New York",
            DepartureTime = DateTime.UtcNow.AddDays(2),
            ArrivalTime = DateTime.UtcNow.AddDays(2).AddHours(8),
            Price = 850.00M,
            AvailableSeats = 280
        },
        new Flight {
            Id = 3,
            Origin = "Tokyo",
            Destination = "Seoul",
            DepartureTime = DateTime.UtcNow.AddDays(1).AddHours(4),
            ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(6),
            Price = 3200.00M,
            AvailableSeats = 190
        },
        new Flight {
            Id = 4,
            Origin = "Dubai",
            Destination = "Singapore",
            DepartureTime = DateTime.UtcNow.AddDays(1).AddHours(8),
            ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(15),
            Price = 5800.00M,
            AvailableSeats = 300
        },
        new Flight {
            Id = 5,
            Origin = "Sydney",
            Destination = "Los Angeles",
            DepartureTime = DateTime.UtcNow.AddDays(3),
            ArrivalTime = DateTime.UtcNow.AddDays(3).AddHours(14),
            Price = 1200.00M,
            AvailableSeats = 250
        },
        new Flight {
            Id = 6,
            Origin = "Paris",
            Destination = "Istanbul",
            DepartureTime = DateTime.UtcNow.AddDays(2).AddHours(6),
            ArrivalTime = DateTime.UtcNow.AddDays(2).AddHours(9),
            Price = 3100.00M,
            AvailableSeats = 170
        },
        new Flight {
            Id = 7,
            Origin = "Mexico City",
            Destination = "São Paulo",
            DepartureTime = DateTime.UtcNow.AddDays(2).AddHours(3),
            ArrivalTime = DateTime.UtcNow.AddDays(2).AddHours(11),
            Price = 740.00M,
            AvailableSeats = 195
        },
        new Flight {
            Id = 8,
            Origin = "Mumbai",
            Destination = "Dubai",
            DepartureTime = DateTime.UtcNow.AddDays(4),
            ArrivalTime = DateTime.UtcNow.AddDays(4).AddHours(4),
            Price = 445.00M,
            AvailableSeats = 220
        },
        new Flight {
            Id = 9,
            Origin = "Frankfurt",
            Destination = "Singapore",
            DepartureTime = DateTime.UtcNow.AddDays(5),
            ArrivalTime = DateTime.UtcNow.AddDays(5).AddHours(12),
            Price = 875.00M,
            AvailableSeats = 288
        },
        new Flight {
            Id = 10,
            Origin = "Amsterdam",
            Destination = "Bangkok",
            DepartureTime = DateTime.UtcNow.AddDays(3).AddHours(5),
            ArrivalTime = DateTime.UtcNow.AddDays(3).AddHours(17),
            Price = 785.00M,
            AvailableSeats = 265
        },
        new Flight {
            Id = 11,
            Origin = "Hong Kong",
            Destination = "Sydney",
            DepartureTime = DateTime.UtcNow.AddDays(4).AddHours(2),
            ArrivalTime = DateTime.UtcNow.AddDays(4).AddHours(11),
            Price = 890.00M,
            AvailableSeats = 278
        },
        new Flight {
            Id = 12,
            Origin = "Toronto",
            Destination = "London",
            DepartureTime = DateTime.UtcNow.AddDays(6),
            ArrivalTime = DateTime.UtcNow.AddDays(6).AddHours(7),
            Price = 720.00M,
            AvailableSeats = 245
        },
        new Flight {
            Id = 13,
            Origin = "San Francisco",
            Destination = "Tokyo",
            DepartureTime = DateTime.UtcNow.AddDays(5).AddHours(8),
            ArrivalTime = DateTime.UtcNow.AddDays(6),
            Price = 980.00M,
            AvailableSeats = 290
        },
        new Flight {
            Id = 14,
            Origin = "Beijing",
            Destination = "Moscow",
            DepartureTime = DateTime.UtcNow.AddDays(7),
            ArrivalTime = DateTime.UtcNow.AddDays(7).AddHours(8),
            Price = 650.00M,
            AvailableSeats = 235
        },
        new Flight {
            Id = 15,
            Origin = "Cairo",
            Destination = "Rome",
            DepartureTime = DateTime.UtcNow.AddDays(4).AddHours(12),
            ArrivalTime = DateTime.UtcNow.AddDays(4).AddHours(15),
            Price = 420.00M,
            AvailableSeats = 185
        },
        new Flight {
            Id = 16,
            Origin = "Lima",
            Destination = "Miami",
            DepartureTime = DateTime.UtcNow.AddDays(3).AddHours(14),
            ArrivalTime = DateTime.UtcNow.AddDays(3).AddHours(20),
            Price = 580.00M,
            AvailableSeats = 210
        },
        new Flight {
            Id = 17,
            Origin = "Vancouver",
            Destination = "Seoul",
            DepartureTime = DateTime.UtcNow.AddDays(8),
            ArrivalTime = DateTime.UtcNow.AddDays(8).AddHours(11),
            Price = 920.00M,
            AvailableSeats = 255
        },
        new Flight {
            Id = 18,
            Origin = "Brussels",
            Destination = "Cape Town",
            DepartureTime = DateTime.UtcNow.AddDays(6).AddHours(6),
            ArrivalTime = DateTime.UtcNow.AddDays(6).AddHours(16),
            Price = 840.00M,
            AvailableSeats = 225
        },
        new Flight {
            Id = 19,
            Origin = "Singapore",
            Destination = "Melbourne",
            DepartureTime = DateTime.UtcNow.AddDays(5).AddHours(22),
            ArrivalTime = DateTime.UtcNow.AddDays(6).AddHours(5),
            Price = 670.00M,
            AvailableSeats = 240
        },
        new Flight {
            Id = 20,
            Origin = "New York",
            Destination = "Paris",
            DepartureTime = DateTime.UtcNow.AddDays(9),
            ArrivalTime = DateTime.UtcNow.AddDays(9).AddHours(7),
            Price = 820.00M,
            AvailableSeats = 295
        }
    };
        }

        public List<Flight> GetAllFlights()
        {
            return _flights;
        }

        public Flight? GetFlightById(int id)
        {
            return _flights.FirstOrDefault(f => f.Id == id);
        }

        public List<Flight> SearchFlights(string origin, string destination, DateTime date)
        {
            return _flights.Where(f =>
                f.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase) &&
                f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase) &&
                f.DepartureTime.Date == date.Date
            ).ToList();
        }

        public int GetAvailableSeats(int flightId)
        {
            var flight = _flights.FirstOrDefault(f => f.Id == flightId);
            return flight?.AvailableSeats ?? 0;
        }
    }
}