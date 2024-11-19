using System.Collections.Generic;

namespace Controller.DataHandler
{
    /// <summary>
    /// Interfaz para manejar datos genéricos.
    /// </summary>
    /// <typeparam name="T">El tipo de datos que se manejará.</typeparam>
    /// <typeparam name="TKey">El tipo del identificador único.</typeparam>
    public interface IDataHandler<T, TKey>
    {
        /// <summary>
        /// Obtiene todos los elementos de un origen de datos.
        /// </summary>
        /// <returns>Lista de elementos del tipo especificado.</returns>
        /// <exception cref="System.IO.FileNotFoundException">Se lanza si el archivo no se encuentra.</exception>
        List<T> GetAll();

        /// <summary>
        /// Guarda todos los elementos en un origen de datos.
        /// </summary>
        /// <param name="data">Lista de elementos a guardar.</param>
        /// <exception cref="System.IO.IOException">Se lanza si ocurre un error al escribir el archivo.</exception>
        void SaveAll(List<T> data);

        /// <summary>
        /// Obtiene un elemento por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del elemento.</param>
        /// <returns>El elemento encontrado, o null si no existe.</returns>
        /// <exception cref="KeyNotFoundException">Se lanza si no se encuentra el elemento con el ID especificado.</exception>
        T GetById(TKey id);

        /// <summary>
        /// Agrega un nuevo elemento al origen de datos.
        /// </summary>
        /// <param name="item">El elemento a agregar.</param>
        void Add(T item);

        /// <summary>
        /// Elimina un elemento del origen de datos por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del elemento a eliminar.</param>
        /// <exception cref="KeyNotFoundException">Se lanza si el elemento con el ID especificado no existe.</exception>
        void Delete(TKey id);
    }
}
