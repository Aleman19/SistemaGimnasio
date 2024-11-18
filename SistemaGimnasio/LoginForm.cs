
namespace SistemaGimnasio
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Crear una instancia del controlador de usuarios
            var usuarioController = new UsuarioController();

            // Validar las credenciales ingresadas por el usuario
            var usuario = usuarioController.Login(txtUsuario.Text, txtContraseña.Text);

            if (usuario != null)
            {
                // Mostrar mensaje de bienvenida
                MessageBox.Show($"Bienvenido {usuario.NombreUsuario}. Rol: {usuario.Rol}", "Inicio de Sesión");

                // Redirigir al formulario correspondiente según el rol del usuario
                if (usuario.Rol == "Admin")
                {
                    var menuForm = new MenuForm(); // Formulario principal para administradores
                    menuForm.Show();
                }
                else if (usuario.Rol == "Entrenador")
                {
                    var entrenadorForm = new EntrenadoresForm();
                    entrenadorForm.Show();
                }
                else if (usuario.Rol == "Cliente")
                {
                    var clienteForm = new ClientesForm();
                    clienteForm.Show();
                }

                // Ocultar el formulario de login
                this.Hide();
            }
            else
            {
                // Mostrar mensaje de error si las credenciales son incorrectas
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
