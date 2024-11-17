using System.Collections.Generic;

namespace Controller.DataHandler
{
    /// <summary>
    /// Interfaz para manejar datos genéricos.
    /// </summary>
    /// <typeparam name="T">El tipo de datos que se manejará.</typeparam>
    public interface IDataHandler<T>
    {
        /// <summary>
        /// Obtiene todos los elementos de un archivo JSON.
        /// </summary>
        /// <returns>Lista de elementos del tipo especificado.</returns>
        List<T> GetAll();

        /// <summary>
        /// Guarda todos los elementos en un archivo JSON.
        /// </summary>
        /// <param name="data">Lista de elementos a guardar.</param>
        void SaveAll(List<T> data);

        /// <summary>
        /// Obtiene un elemento por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del elemento.</param>
        /// <returns>El elemento encontrado, o null si no existe.</returns>
        T GetById(string id);
    }
}

