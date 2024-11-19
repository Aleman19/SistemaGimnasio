namespace SistemaGimnasio
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inicializa la configuraci�n de la aplicaci�n (como DPI, fuentes predeterminadas, etc.).
            ApplicationConfiguration.Initialize();

            // Mostrar el formulario de Login al iniciar.
            using (var loginForm = new LoginForm())
            {
                // Si el login es exitoso, se muestra el men� principal.
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MenuForm());
                }
            }
        }
    }
}
