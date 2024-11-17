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

        /// <summary>
        /// Constructor que inicializa la ruta del archivo JSON.
        /// </summary>
        /// <param name="filePath">La ruta del archivo JSON.</param>
        public JsonDataHandler(string filePath)
        {
            _filePath = filePath;
            EnsureFileExists();
        }

        /// <summary>
        /// Verifica si el archivo existe, y lo crea si no está presente.
        /// </summary>
        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]"); // Crea un archivo JSON vacío
            }
        }

        /// <summary>
        /// Obtiene todos los elementos del archivo JSON.
        /// </summary>
        /// <returns>Lista de elementos del tipo especificado.</returns>
        public List<T> GetAll()
        {
            try
            {
                var jsonData = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al leer los datos del archivo {_filePath}: {ex.Message}");
            }
        }

        /// <summary>
        /// Guarda todos los elementos en el archivo JSON.
        /// </summary>
        /// <param name="data">Lista de elementos a guardar.</param>
        public void SaveAll(List<T> data)
        {
            try
            {
                // Especificar explicitamente Newtonsoft.Json.Formatting
                var jsonData = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al escribir los datos en el archivo {_filePath}: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene un elemento por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del elemento.</param>
        /// <returns>El elemento encontrado, o null si no existe.</returns>
        public T GetById(string id)
        {
            try
            {
                var allData = GetAll();
                return allData.FirstOrDefault(item =>
                    (item.GetType().GetProperty("Id")?.GetValue(item, null)?.ToString() ?? string.Empty) == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el elemento por ID: {ex.Message}");
            }
        }
    }
}
