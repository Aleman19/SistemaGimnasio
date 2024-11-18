using System.Collections.Generic;
using Controller.DataHandler;
using Model;
using System;
using System.Linq;

namespace Controller
{
    public class UsuarioController
    {
        private readonly JsonDataHandler<Usuario> _dataHandler;

        public UsuarioController()
        {
            _dataHandler = new JsonDataHandler<Usuario>("Assets/Usuarios.json");
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public List<Usuario> GetUsuarios()
        {
            return _dataHandler.GetAll();
        }

        /// <summary>
        /// Guarda la lista de usuarios en el archivo JSON.
        /// </summary>
        /// <param name="usuarios">Lista de usuarios.</param>
        public void SaveUsuarios(List<Usuario> usuarios)
        {
            _dataHandler.SaveAll(usuarios);
        }

        /// <summary>
        /// Agrega un nuevo usuario al sistema.
        /// </summary>
        /// <param name="usuario">El usuario a agregar.</param>
        public void AddUsuario(Usuario usuario)
        {
            var usuarios = GetUsuarios();
            usuario.Id = Guid.NewGuid().ToString(); // Genera un ID único para el usuario.
            usuarios.Add(usuario);
            SaveUsuarios(usuarios);
        }

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario a eliminar.</param>
        public void RemoveUsuario(string usuarioId)
        {
            var usuarios = GetUsuarios();
            usuarios.RemoveAll(u => u.Id == usuarioId);
            SaveUsuarios(usuarios);
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>El usuario encontrado o null si no existe.</returns>
        public Usuario GetUsuarioById(string usuarioId)
        {
            return _dataHandler.GetById(usuarioId);
        }

        /// <summary>
        /// Valida las credenciales de inicio de sesión.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario.</param>
        /// <param name="contraseña">La contraseña.</param>
        /// <returns>El usuario si las credenciales son válidas, de lo contrario null.</returns>
        public Usuario Login(string nombreUsuario, string contraseña)
        {
            var usuarios = GetUsuarios();
            return usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);
        }
    }
}
