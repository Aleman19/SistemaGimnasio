using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;

namespace SistemaGimnasioV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly GymDbContext _dbContext;

        public HomeController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            string message;

            try
            {
                // Intentar contar los usuarios en la base de datos
                var usersCount = _dbContext.Users.Count();
                message = $"Conexión exitosa. Usuarios en la base de datos: {usersCount}";
            }
            catch (Exception ex)
            {
                // Capturar cualquier error de conexión
                message = $"Error al conectar con la base de datos: {ex.Message}";
            }

            // Pasar el mensaje a la vista
            ViewData["DbConnectionMessage"] = message;
            return View();
        }
    }
}
