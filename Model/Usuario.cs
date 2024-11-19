using System;

namespace Model
{
    /// <summary>
    /// Clase que representa un usuario del sistema.
    /// </summary>
    public class Usuario
    {
        // Enumerador para representar los roles de usuario
        public enum Roles
        {
            Cliente,
            Entrenador,
            Administrador // Posibilidad de agregar nuevos roles en el futuro
        }

        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombre de usuario para iniciar sesión.
        /// </summary>
        private string _nombreUsuario;

        public string NombreUsuario
        {
            get => _nombreUsuario;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de usuario no puede estar vacío.");
                _nombreUsuario = value;
            }
        }

        /// <summary>
        /// Contraseña del usuario (encriptada o en texto plano en esta versión inicial).
        /// </summary>
        private string _contraseña;

        public string Contraseña
        {
            get => _contraseña;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                    throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
                _contraseña = value;
            }
        }

        /// <summary>
        /// Rol del usuario.
        /// </summary>
        public Roles Rol { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Usuario()
        {
            // Inicializa propiedades con valores predeterminados
            Id = Guid.NewGuid().ToString(); // Genera un ID único
            Rol = Roles.Cliente; // Rol por defecto
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <param name="contraseña">Contraseña.</param>
        /// <param name="rol">Rol del usuario.</param>
        public Usuario(string nombreUsuario, string contraseña, Roles rol)
        {
            Id = Guid.NewGuid().ToString(); // Genera un ID único automáticamente
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Rol = rol;
        }

        /// <summary>
        /// Valida las credenciales del usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <param name="contraseña">Contraseña.</param>
        /// <returns>True si las credenciales coinciden, de lo contrario false.</returns>
        public bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            return NombreUsuario == nombreUsuario && Contraseña == contraseña;
        }

        /// <summary>
        /// Devuelve una representación de cadena del usuario.
        /// </summary>
        /// <returns>Información básica del usuario.</returns>
        public override string ToString()
        {
            return $"Usuario: {NombreUsuario}, Rol: {Rol}";
        }
    }
}
