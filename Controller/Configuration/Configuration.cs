using System;
using System.IO;

namespace Controller.Configuration
{
    /// <summary>
    /// Clase para manejar configuraciones globales del sistema.
    /// </summary>
    public static class Configuration
    {
        // Ruta base de los archivos JSON
        public static readonly string AssetsPath = Path.Combine(Directory.GetCurrentDirectory(), "Asset");

        // Archivos JSON utilizados en el sistema
        public static readonly string UsersFile = Path.Combine(AssetsPath, "Usuarios.json");
        public static readonly string ClassesFile = Path.Combine(AssetsPath, "Clases.json");
        public static readonly string InventoryFile = Path.Combine(AssetsPath, "Inventario.json");
        public static readonly string MembershipsFile = Path.Combine(AssetsPath, "Membresias.json");
        public static readonly string ReservationsFile = Path.Combine(AssetsPath, "Reservas.json");
        public static readonly string InvoicesFile = Path.Combine(AssetsPath, "Facturas.json");

        /// <summary>
        /// Asegura que el directorio de recursos exista.
        /// </summary>
        public static void EnsureAssetsFolderExists()
        {
            if (!Directory.Exists(AssetsPath))
            {
                Directory.CreateDirectory(AssetsPath);
            }
        }

        /// <summary>
        /// Asegura que los archivos JSON utilizados por el sistema existan. Si no, los crea vacíos.
        /// </summary>
        public static void EnsureJsonFilesExist()
        {
            string[] files = { UsersFile, ClassesFile, InventoryFile, MembershipsFile, ReservationsFile, InvoicesFile };
            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllText(file, "[]"); // Inicializa un archivo JSON vacío con un array.
                }
            }
        }
    }
}
