namespace core.entities {
    public class Flight {
        public int Id { get; set; }
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
    }
}