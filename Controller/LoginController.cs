using Models;

namespace Controllers
{
    public class LoginController
    {
        private string clientesPath;
        private string entrenadoresPath;

        public LoginController(string clientesPath, string entrenadoresPath)
        {
            this.clientesPath = clientesPath;
            this.entrenadoresPath = entrenadoresPath;

            // Verificar existencia de archivos
            if (!File.Exists(clientesPath))
                throw new FileNotFoundException($"El archivo de clientes no fue encontrado: {clientesPath}");

            if (!File.Exists(entrenadoresPath))
                throw new FileNotFoundException($"El archivo de entrenadores no fue encontrado: {entrenadoresPath}");
        }

        /// <summary>
        /// Valida las credenciales de inicio de sesión revisando en los archivos de clientes y entrenadores.
        /// </summary>
        public (string Role, int UserId) ValidateLogin(string username, string password)
        {
            try
            {
                // Validar Clientes
                var clientes = LoadClientes();
                var cliente = clientes.FirstOrDefault(c => c.Username == username && c.Password == password);
                if (cliente != null)
                    return ("Cliente", cliente.IdCliente);

                // Validar Entrenadores
                var entrenadores = LoadEntrenadores();
                var entrenador = entrenadores.FirstOrDefault(e => e.Username == username && e.Password == password);
                if (entrenador != null)
                    return ("Entrenador", entrenador.IdEntrenador);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ValidateLogin: {ex.Message}");
                throw;
            }

            // No se encontró un usuario, devolver valores predeterminados
            return ("N/A", 0);
        }

        /// <summary>
        /// Carga los clientes desde el archivo CSV.
        /// </summary>
        private List<Cliente> LoadClientes()
        {
            try
            {
                return File.ReadAllLines(clientesPath)
                    .Skip(1) // Omitir la cabecera
                    .Select(line => line.Split(','))
                    .Select(data => new Cliente
                    {
                        IdCliente = int.Parse(data[0]),
                        Nombre = data[1],
                        Apellido = data[2],
                        Username = data[3],
                        Password = data[4],
                        Email = data[5],
                        Telefono = data[6],
                        FechaRegistro = DateTime.Parse(data[7]),
                        EstadoMembresia = data[8],
                        FechaFinMembresia = DateTime.Parse(data[9])
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando clientes desde el archivo: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Carga los entrenadores desde el archivo CSV.
        /// </summary>
        private List<Entrenador> LoadEntrenadores()
        {
            try
            {
                return File.ReadAllLines(entrenadoresPath)
                    .Skip(1) // Omitir la cabecera
                    .Select(line => line.Split(','))
                    .Select(data => new Entrenador
                    {
                        IdEntrenador = int.Parse(data[0]),
                        Nombre = data[1],
                        Apellido = data[2],
                        Username = data[3],
                        Password = data[4],
                        Email = data[5],
                        Telefono = data[6],
                        FechaInicio = DateTime.Parse(data[7]),
                        Especialidad = data[8]
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando entrenadores desde el archivo: {ex.Message}");
                throw;
            }
        }
    }
}