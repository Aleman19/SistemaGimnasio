
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace SistemaGimnasio
{
    public partial class LoginForm : Form
    {
        // Rutas de los archivos CSV
        private readonly string clientesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Clientes.csv");
        private readonly string entrenadoresPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Entrenadores.csv");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingresa un usuario y contraseña.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar el login
            var (role, userId) = ValidateLogin(username, password);

            if (role == "Cliente")
            {
                MessageBox.Show($"Bienvenido Cliente ID: {userId}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var clienteForm = new ClienteForm(userId);
                clienteForm.Show();
                this.Hide();
            }
            else if (role == "Entrenador")
            {
                MessageBox.Show($"Bienvenido Entrenador ID: {userId}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var entrenadorForm = new EntrenadorForm(userId);
                entrenadorForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida las credenciales de inicio de sesión revisando los archivos de clientes y entrenadores.
        /// </summary>
        private (string Role, int UserId) ValidateLogin(string username, string password)
        {
            try
            {
                // Validar en Clientes
                if (File.Exists(clientesPath))
                {
                    var clientes = File.ReadAllLines(clientesPath)
                        .Skip(1) // Omitir la cabecera
                        .Select(line => line.Split(','))
                        .Where(data => data.Length >= 5) // Validar que la línea tenga al menos 5 columnas
                        .Select(data => new
                        {
                            Id = int.Parse(data[0]),
                            Username = data[3].Trim().ToLower(),
                            Password = data[4].Trim()
                        });

                    var cliente = clientes.FirstOrDefault(c => c.Username == username.ToLower() && c.Password == password);
                    if (cliente != null)
                    {
                        return ("Cliente", cliente.Id);
                    }
                }

                // Validar en Entrenadores
                if (File.Exists(entrenadoresPath))
                {
                    var entrenadores = File.ReadAllLines(entrenadoresPath)
                        .Skip(1) // Omitir la cabecera
                        .Select(line => line.Split(','))
                        .Where(data => data.Length >= 5) // Validar que la línea tenga al menos 5 columnas
                        .Select(data => new
                        {
                            Id = int.Parse(data[0]),
                            Username = data[3].Trim().ToLower(),
                            Password = data[4].Trim()
                        });

                    var entrenador = entrenadores.FirstOrDefault(e => e.Username == username.ToLower() && e.Password == password);
                    if (entrenador != null)
                    {
                        return ("Entrenador", entrenador.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Si no se encuentra el usuario
            return (null, 0);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Validar existencia de archivos al cargar el formulario
                if (!File.Exists(clientesPath))
                {
                    throw new FileNotFoundException($"El archivo '{clientesPath}' no fue encontrado.");
                }

                if (!File.Exists(entrenadoresPath))
                {
                    throw new FileNotFoundException($"El archivo '{entrenadoresPath}' no fue encontrado.");
                }

                // Validar que los archivos no estén vacíos
                if (File.ReadAllLines(clientesPath).Length <= 1)
                {
                    throw new Exception($"El archivo '{clientesPath}' no contiene registros válidos.");
                }

                if (File.ReadAllLines(entrenadoresPath).Length <= 1)
                {
                    throw new Exception($"El archivo '{entrenadoresPath}' no contiene registros válidos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los archivos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
