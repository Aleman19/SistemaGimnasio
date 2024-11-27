using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    static class Program
    {
        // Rutas ajustadas a la carpeta Assets
        private static readonly string ClientesCsvPath = "Assets/Clientes.csv";
        private static readonly string EntrenadoresCsvPath = "Assets/Entrenadores.csv";
        private static readonly string ClasesCsvPath = "Assets/Clases.csv";
        private static readonly string FacturasCsvPath = "Assets/Facturas.csv";
        private static readonly string InventarioCsvPath = "Assets/Inventario.csv";
        private static readonly string ReportesCsvPath = "Assets/Reportes.csv";
        private static readonly string MembresiasCsvPath = "Assets/Membresias.csv";
        private static readonly string ReservasCsvPath = "Assets/Reservas.csv";

        [STAThread]
        static void Main()
        {
            try
            {
                // Configuraci�n de la cultura predeterminada (en-US)
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

                // Verificar y crear archivos si no existen
                VerificarOCrearArchivos();

                // Configuraci�n de estilos de Windows Forms
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Iniciar el formulario de Login
                var loginForm = new LoginForm();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cr�tico al iniciar la aplicaci�n:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Verifica que los archivos CSV existan en la carpeta Assets.
        /// Si no existen, los crea con datos de ejemplo.
        /// </summary>
        private static void VerificarOCrearArchivos()
        {
            try
            {
                // Crear carpeta Assets si no existe
                string assetsFolder = "Assets";
                if (!Directory.Exists(assetsFolder))
                {
                    Directory.CreateDirectory(assetsFolder);
                }

                // Verificar y crear cada archivo CSV con datos de ejemplo
                CrearArchivoSiNoExiste(ClientesCsvPath, "Id,Nombre,Apellido,Telefono,Username,Password\n" +
                                                       "1,Juan,P�rez,555-1234,juan.perez,1234\n" +
                                                       "2,Mar�a,G�mez,555-5678,maria.gomez,abcd");

                CrearArchivoSiNoExiste(EntrenadoresCsvPath, "Id,Nombre,Apellido,Telefono,Username,Password\n" +
                                                            "1,Ana,L�pez,555-5678,ana.lopez,abcd\n" +
                                                            "2,Carlos,Fern�ndez,555-8765,carlos.fernandez,1234");

                CrearArchivoSiNoExiste(ClasesCsvPath, "IdClase,NombreClase,IdEntrenador,Cupo,HoraInicio,HoraFin,Dias\n" +
                                                      "1,Zumba,1,20,09:00,10:00,Lunes,Mi�rcoles,Viernes\n" +
                                                      "2,CardioDance,2,15,11:00,12:00,Martes,Jueves");

                CrearArchivoSiNoExiste(FacturasCsvPath, "IdFactura,IdCliente,FechaFactura,Monto,Descripcion\n" +
                                                        "1,1,2024-01-01,50.00,Membres�a mensual\n" +
                                                        "2,2,2024-01-01,50.00,Membres�a mensual");

                CrearArchivoSiNoExiste(InventarioCsvPath, "IdEquipo,NombreEquipo,FechaCompra,VidaUtilMeses\n" +
                                                          "1,Cinta de correr,2022-01-01,24\n" +
                                                          "2,Bicicleta est�tica,2021-06-15,36");

                CrearArchivoSiNoExiste(ReportesCsvPath, "IdReporte,Descripcion,FechaCreacion\n");

                CrearArchivoSiNoExiste(MembresiasCsvPath, "IdMembresia,IdCliente,FechaInicio,FechaFin,Estado,Tipo\n" +
                                                          "1,1,2024-01-01,2024-01-31,Activa,Mensual\n" +
                                                          "2,2,2024-01-01,2024-01-31,Activa,Mensual");

                CrearArchivoSiNoExiste(ReservasCsvPath, "IdReserva,IdClase,IdCliente,FechaReserva,Estado\n" +
                                                        "1,1,1,2024-01-10,Confirmada\n" +
                                                        "2,2,2,2024-01-11,Confirmada");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al verificar o crear archivos: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea un archivo si no existe, con el contenido proporcionado.
        /// </summary>
        /// <param name="filePath">Ruta del archivo.</param>
        /// <param name="content">Contenido a escribir en el archivo.</param>
        private static void CrearArchivoSiNoExiste(string filePath, string content)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, content);
                    Console.WriteLine($"Archivo creado: {filePath}");
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Error al crear el archivo {filePath}: {ex.Message}");
            }
        }
    }
}