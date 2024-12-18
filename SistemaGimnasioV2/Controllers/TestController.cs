using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;

namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly GymDbContext _dbContext;

        public TestController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Prueba la conexión a la base de datos.
        /// </summary>
        /// <returns>Mensaje indicando el estado de la conexión.</returns>
        [HttpGet("TestConnection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                // Verifica si la base de datos está disponible
                var canConnect = await _dbContext.Database.CanConnectAsync();

                if (canConnect)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Conexión a la base de datos exitosa."
                    });
                }
                else
                {
                    return StatusCode(500, new
                    {
                        Success = false,
                        Message = "No se pudo conectar a la base de datos."
                    });
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores y devolución de un mensaje detallado
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Error al conectar con la base de datos.",
                    Details = ex.Message
                });
            }
        }
    }
}
