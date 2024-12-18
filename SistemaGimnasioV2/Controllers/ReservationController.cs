using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly GymDbContext _dbContext;

    public ReservationController(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/Reservation/Client/5
    [HttpGet("Client/{clientId}")]
    public IActionResult GetReservationsByClient(int clientId)
    {
        var reservations = _dbContext.Reservations.Where(r => r.UserId == clientId).ToList();
        if (!reservations.Any())
            return NotFound("No se encontraron reservas para este cliente.");

        return Ok(reservations);
    }

    // POST: api/Reservation/Add
    [HttpPost("Add")]
    public IActionResult AddReservation([FromBody] Reservation newReservation)
    {
        if (newReservation == null)
            return BadRequest("Datos de la reserva no válidos.");

        _dbContext.Reservations.Add(newReservation);
        _dbContext.SaveChanges();

        return Ok(newReservation);
    }

    // DELETE: api/Reservation/Delete/5
    [HttpDelete("Delete/{reservationId}")]
    public IActionResult DeleteReservation(int reservationId)
    {
        var reservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == reservationId);
        if (reservation == null)
            return NotFound("Reserva no encontrada.");

        _dbContext.Reservations.Remove(reservation);
        _dbContext.SaveChanges();

        return Ok($"Reserva con ID {reservationId} eliminada.");
    }
}
