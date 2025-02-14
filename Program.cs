using core.interfaces;
using core.usecases;
using infrastructure.data;
using Microsoft.Extensions.DependencyInjection;
using vuelos.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<SearchFlights>();
builder.Services.AddScoped<CreateReservation>();
builder.Services.AddScoped<CancelReservation>();
builder.Services.AddScoped<ModifyReservation>();
builder.Services.AddScoped<CheckInReservation>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints existentes
app.MapGet("/flights", (SearchFlights searchFlights) =>
{
    var flights = searchFlights.Execute("", "", DateTime.Now);
    return Results.Ok(flights);
})
.WithName("GetAllFlights");

app.MapGet("/flights/search", (string origin, string destination, DateTime date, SearchFlights searchFlights) =>
{
    var flights = searchFlights.Execute(origin, destination, date);
    return Results.Ok(flights);
})
.WithName("SearchFlights");

app.MapPost("/reservations", (ReservationRequest request, CreateReservation createReservation) =>
{
    try
    {
        createReservation.Execute(
            request.FlightId,
            request.PassengerName,
            request.Email,
            request.SeatNumber
        );
        return Results.Ok("Reserva creada exitosamente");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.WithName("CreateReservation");

// Nuevos endpoints
app.MapGet("/flights/{id}", (int id, IFlightRepository flightRepository) =>
{
    var flight = flightRepository.GetFlightById(id);
    if (flight == null)
        return Results.NotFound($"No se encontró el vuelo con ID {id}");
    return Results.Ok(flight);
})
.WithName("GetFlightById");

app.MapGet("/flights/{id}/reservations", (int id, IReservationRepository reservationRepository) =>
{
    var reservations = reservationRepository.GetReservationsByFlight(id);
    return Results.Ok(reservations);
})
.WithName("GetFlightReservations");

app.MapGet("/reservations/email/{email}", (string email, IReservationRepository reservationRepository) =>
{
    var reservations = reservationRepository.GetReservationsByEmail(email);
    return Results.Ok(reservations);
})
.WithName("GetReservationsByEmail");

app.MapGet("/flights/{id}/seats", (int id, IFlightRepository flightRepository) =>
{
    var flight = flightRepository.GetFlightById(id);
    if (flight == null)
        return Results.NotFound($"No se encontró el vuelo con ID {id}");
        
    var availableSeats = flightRepository.GetAvailableSeats(id);
    return Results.Ok(new { flightId = id, availableSeats = availableSeats });
})
.WithName("GetAvailableSeats");

app.MapPost("/reservations/{id}/cancel", (int id, CancelReservation cancelReservation) =>
{
    try
    {
        cancelReservation.Execute(id);
        return Results.Ok("Reserva cancelada exitosamente");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.WithName("CancelReservation");

app.MapPut("/reservations/{id}", (int id, ReservationUpdateRequest request, ModifyReservation modifyReservation) =>
{
    try
    {
        modifyReservation.Execute(
            id,
            request.NewSeatNumber,
            request.NewPassengerName,
            request.NewEmail
        );
        return Results.Ok("Reserva modificada exitosamente");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.WithName("ModifyReservation");

app.MapPost("/reservations/{id}/checkin", (int id, CheckInReservation checkInReservation) =>
{
    try
    {
        checkInReservation.Execute(id);
        return Results.Ok("Check-in realizado exitosamente");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.WithName("CheckInReservation");

app.Run();

public record ReservationUpdateRequest(string? NewSeatNumber, string? NewPassengerName, string? NewEmail);