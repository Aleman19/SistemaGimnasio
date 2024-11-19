using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Controller.DataHandler
{
    /// <summary>
    /// Implementación de <see cref="IDataHandler{T}"/> usando archivos JSON.
    /// </summary>
    /// <typeparam name="T">El tipo de datos que se manejará.</typeparam>
    public class JsonDataHandler<T> : IDataHandler<T> where T : class
    {
        private readonly string _filePath;
        private static readonly object FileLock = new object();

        /// <summary>
        /// Constructor que inicializa la ruta del archivo JSON.
        /// </summary>
        /// <param name="filePath">La ruta del archivo JSON.</param>
        public JsonDataHandler(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            EnsureFileExists();
        }

        /// <summary>
        /// Verifica si el archivo existe, y lo crea si no está presente.
        /// </summary>
        private void EnsureFileExists()
        {
            lock (FileLock)
            {
                if (!File.Exists(_filePath))
                {
                    File.WriteAllText(_filePath, "[]"); // Crea un archivo JSON vacío
                }
            }
        }

        /// <summary>
        /// Obtiene todos los elementos del archivo JSON.
        /// </summary>
        /// <returns>Lista de elementos del tipo especificado.</returns>
        public List<T> GetAll()
        {
            lock (FileLock)
            {
                try
                {
                    var jsonData = File.ReadAllText(_filePath);
                    return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
                }
                catch (JsonSerializationException ex)
                {
                    throw new InvalidOperationException($"Error al deserializar los datos del archivo {_filePath}: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new IOException($"Error al leer el archivo {_filePath}: {ex.Message}", ex);
                }
            }
        }

        /// <summary>
        /// Guarda todos los elementos en el archivo JSON.
        /// </summary>
        /// <param name="data">Lista de elementos a guardar.</param>
        public void SaveAll(List<T> data)
        {
            lock (FileLock)
            {
                try
                {
                    var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                    File.WriteAllText(_filePath, jsonData);
                }
                catch (Exception ex)
                {
                    throw new IOException($"Error al escribir en el archivo {_filePath}: {ex.Message}", ex);
                }
            }
        }

        /// <summary>
        /// Obtiene un elemento por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del elemento.</param>
        /// <returns>El elemento encontrado, o null si no existe.</returns>
        public T GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("El ID no puede ser nulo o vacío.", nameof(id));
            }

            try
            {
                var allData = GetAll();

                // Validar que la entidad tiene una propiedad "Id"
                var propertyInfo = typeof(T).GetProperty("Id");
                if (propertyInfo == null)
                {
                    throw new InvalidOperationException($"El tipo {typeof(T).Name} no tiene una propiedad 'Id'.");
                }

                return allData.FirstOrDefault(item =>
                    propertyInfo.GetValue(item)?.ToString() == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el elemento con ID {id}: {ex.Message}", ex);
            }
        }
    }

    public interface IDataHandler<T> where T : class
    {
    }
}
