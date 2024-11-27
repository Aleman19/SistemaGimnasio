using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class EntrenadorForm : Form
    {
        private int idEntrenador;
        private readonly string clasesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Clases.csv");
        private readonly string reservasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Reservas.csv");
        private readonly string inventarioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Inventario.csv");
        private readonly string facturasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Facturas.csv");
        private readonly string clientesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Clientes.csv");

        public EntrenadorForm(int entrenadorId)
        {
            InitializeComponent();
            idEntrenador = entrenadorId;
        }

        private void EntrenadorForm_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"Bienvenido al área Entrenador (ID: {idEntrenador})";
            CargarClases();
            CargarInventario();
            CargarFiltrosReporteContable(); // Inicializar filtros
        }

        private void CargarClases()
        {
            try
            {
                // Verificar si el archivo existe
                if (!File.Exists(clasesPath))
                    throw new FileNotFoundException($"El archivo de clases no fue encontrado: {clasesPath}");

                // Leer y procesar las clases asignadas al entrenador
                var clases = File.ReadAllLines(clasesPath)
                    .Skip(1) // Saltar encabezados
                    .Select(line => line.Split(',')) // Dividir por comas
                    .Where(data => int.Parse(data[2]) == idEntrenador) // Filtrar por entrenador
                    .Select(data => new
                    {
                        IdClase = int.Parse(data[0]),
                        NombreClase = data[1],
                        Cupo = int.Parse(data[3]),
                        Horario = $"{data[4]} - {data[5]}",
                        Dias = data[6]
                    })
                    .ToList();

                // Asignar las clases al DataGridView
                dgvClases.DataSource = clases;

                // Seleccionar la primera fila automáticamente (si hay datos)
                if (clases.Count > 0)
                {
                    dgvClases.Rows[0].Selected = true;
                    MostrarReservas(); // Mostrar reservas para la clase seleccionada
                }
                else
                {
                    MessageBox.Show("No se encontraron clases asignadas para este entrenador.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReservas.DataSource = null; // Limpiar el DataGridView de reservas
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarReservas()
        {
            try
            {
                // Verificar si hay una fila seleccionada en el DataGridView de clases
                if (dgvClases.SelectedRows.Count == 0)
                {
                    dgvReservas.DataSource = null;
                    return;
                }

                var selectedRow = dgvClases.SelectedRows[0];
                var cellValue = selectedRow.Cells["IdClase"].Value;

                // Validar que el valor de la celda no sea nulo
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show("La clase seleccionada no tiene un ID válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvReservas.DataSource = null;
                    return;
                }

                // Convertir el ID de la clase
                if (!int.TryParse(cellValue.ToString(), out int idClase))
                {
                    MessageBox.Show("El ID de la clase seleccionada no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar si el archivo de reservas existe
                if (!File.Exists(reservasPath))
                    throw new FileNotFoundException($"El archivo de reservas '{reservasPath}' no fue encontrado.");

                // Leer y procesar las reservas para la clase seleccionada
                var reservas = File.ReadAllLines(reservasPath)
                    .Skip(1) // Saltar encabezados
                    .Select(line => line.Split(',')) // Dividir por comas
                    .Where(data => data.Length >= 5 &&
                                   int.TryParse(data[1], out int id) && id == idClase && // Filtrar por IdClase
                                   data[4] == "Confirmada") // Estado confirmado
                    .Select(data => new
                    {
                        IdReserva = int.Parse(data[0]),
                        IdCliente = int.Parse(data[2]),
                        FechaReserva = DateTime.TryParse(data[3], out DateTime fecha) ? fecha.ToString("yyyy-MM-dd") : "Fecha Inválida"
                    })
                    .ToList();

                // Verificar si hay reservas
                if (reservas.Count == 0)
                {
                    MessageBox.Show("No hay reservas confirmadas para la clase seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReservas.DataSource = null;
                    return;
                }

                // Mostrar las reservas en el DataGridView
                dgvReservas.DataSource = reservas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void CargarInventario()
        {
            try
            {
                if (!File.Exists(inventarioPath))
                    throw new FileNotFoundException($"El archivo de inventario no fue encontrado: {inventarioPath}");

                var inventario = File.ReadAllLines(inventarioPath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .Select(data => new
                    {
                        IdEquipo = int.Parse(data[0]),
                        NombreEquipo = data[1],
                        FechaCompra = DateTime.Parse(data[2]),
                        VidaUtilMeses = int.Parse(data[3]),
                        MesesRestantes = int.Parse(data[3]) - (int)((DateTime.Now - DateTime.Parse(data[2])).TotalDays / 30)
                    })
                    .ToList();

                dgvInventario.DataSource = inventario;

                var equiposDanados = inventario.Where(e => e.MesesRestantes <= 0).ToList();
                var equiposPorReemplazar = inventario.Where(e => e.MesesRestantes > 0 && e.MesesRestantes <= 3).ToList();

                if (equiposDanados.Any())
                {
                    string mensaje = "Equipos fuera de uso:\n" + string.Join("\n", equiposDanados.Select(e => $"- {e.NombreEquipo} (ID: {e.IdEquipo})"));
                    MessageBox.Show(mensaje, "Equipos Fuera de Uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (equiposPorReemplazar.Any())
                {
                    string mensaje = "Equipos cercanos al fin de su vida útil:\n" + string.Join("\n", equiposPorReemplazar.Select(e => $"- {e.NombreEquipo} (ID: {e.IdEquipo}, Meses Restantes: {e.MesesRestantes})"));
                    MessageBox.Show(mensaje, "Equipos por Reemplazar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFiltrosReporteContable()
        {
            try
            {
                var facturas = File.ReadAllLines(facturasPath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .Select(data => DateTime.Parse(data[2]).Year)
                    .Distinct()
                    .OrderByDescending(year => year)
                    .ToList();

                cmbAniosReporte.Items.Clear();
                cmbAniosReporte.Items.AddRange(facturas.Cast<object>().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar filtros del reporte contable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selección del ComboBox de reportes
                if (cmbReportes.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un tipo de reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string seleccion = cmbReportes.SelectedItem?.ToString() ?? string.Empty; // Garantiza que no sea nulo

                // Definir nombres de reportes como constantes
                const string REPORTE_CONTABLE = "Reporte Contable";
                const string REPORTE_CLASES = "Reporte de Clases Más Demandadas";
                const string REPORTE_CLIENTES = "Reporte de Matrícula de Clientes";

                switch (seleccion)
                {
                    case REPORTE_CONTABLE:
                        // Validar que se haya seleccionado un año
                        if (cmbAniosReporte.SelectedItem == null)
                        {
                            MessageBox.Show("Seleccione un año para el reporte contable.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validar que el año seleccionado sea un número entero válido
                        if (int.TryParse(cmbAniosReporte.SelectedItem?.ToString(), out int anio))
                        {
                            GenerarReporteContable(anio);
                        }
                        else
                        {
                            MessageBox.Show("El año seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case REPORTE_CLASES:
                        GenerarReporteClases();
                        break;

                    case REPORTE_CLIENTES:
                        GenerarReporteMatricula();
                        break;

                    default:
                        MessageBox.Show("Seleccione un reporte válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void GenerarReporteContable(int anio)
        {
            try
            {
                if (!File.Exists(facturasPath))
                    throw new FileNotFoundException($"El archivo de facturas no fue encontrado: {facturasPath}");

                var ingresos = File.ReadAllLines(facturasPath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .Where(data => DateTime.Parse(data[2]).Year == anio)
                    .GroupBy(f => DateTime.Parse(f[2]).ToString("yyyy-MM"))
                    .Select(g => new { Mes = g.Key, Total = g.Sum(f => decimal.Parse(f[3])) })
                    .ToList();

                string reporte = $"Reporte Contable del Año {anio}:\n\n";
                foreach (var item in ingresos)
                    reporte += $"Mes: {item.Mes}, Ingresos Totales: {item.Total:C}\n";

                MessageBox.Show(reporte, "Reporte Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte contable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReporteMatricula()
        {
            try
            {
                if (!File.Exists(clientesPath))
                    throw new FileNotFoundException($"El archivo de clientes no fue encontrado: {clientesPath}");

                var clientes = File.ReadAllLines(clientesPath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .GroupBy(c => DateTime.Parse(c[7]).ToString("yyyy-MM"))
                    .Select(g => new { Mes = g.Key, TotalClientes = g.Count() })
                    .ToList();

                string reporte = "Reporte de Matrícula:\n\n";
                foreach (var item in clientes)
                    reporte += $"Mes: {item.Mes}, Total Clientes: {item.TotalClientes}\n";

                MessageBox.Show(reporte, "Reporte de Matrícula de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte de matrícula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReporteClases()
        {
            try
            {
                // Validar existencia de los archivos necesarios
                if (!File.Exists(reservasPath))
                    throw new FileNotFoundException($"El archivo de reservas '{reservasPath}' no fue encontrado.");
                if (!File.Exists(clasesPath))
                    throw new FileNotFoundException($"El archivo de clases '{clasesPath}' no fue encontrado.");

                // Leer y procesar las reservas
                var reservas = File.ReadAllLines(reservasPath)
                    .Skip(1) // Saltar encabezados
                    .Select(line => line.Split(',')) // Dividir por columnas
                    .Where(data => data.Length >= 5 && data[4] == "Confirmada") // Validar longitud y estado
                    .GroupBy(data =>
                    {
                        if (int.TryParse(data[1], out int idClase))
                            return idClase;
                        return -1; // Clase inválida
                    })
                    .Where(group => group.Key != -1) // Filtrar datos inválidos
                    .Select(group => new
                    {
                        IdClase = group.Key,
                        TotalReservas = group.Count()
                    })
                    .OrderByDescending(r => r.TotalReservas)
                    .Take(5) // Tomar las 5 clases más demandadas
                    .ToList();

                // Validar si hay reservas confirmadas
                if (reservas.Count == 0)
                {
                    MessageBox.Show("No se encontraron reservas confirmadas en los datos.", "Reporte de Clases", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Leer y procesar las clases
                var clases = File.ReadAllLines(clasesPath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .Where(data => data.Length >= 7) // Validar longitud
                    .ToDictionary(
                        data =>
                        {
                            if (int.TryParse(data[0], out int idClase))
                                return idClase;
                            return -1; // Id inválido
                        },
                        data => data.Length > 1 ? data[1] : string.Empty // NombreClase como valor o vacío si no hay datos
                    );

                // Construir el reporte
                string reporte = "Reporte de Clases Más Demandadas (Top 5):\n\n";
                foreach (var reserva in reservas)
                {
                    if (clases.TryGetValue(reserva.IdClase, out string? nombreClase) && !string.IsNullOrEmpty(nombreClase))
                    {
                        reporte += $"Clase: {nombreClase}, Total Reservas: {reserva.TotalReservas}\n";
                    }
                    else
                    {
                        reporte += $"Clase con ID {reserva.IdClase} no encontrada en el archivo de clases.\n";
                    }
                }

                // Mostrar el reporte
                MessageBox.Show(reporte, "Reporte de Clases Más Demandadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Archivo faltante: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error de formato en los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvClases_SelectionChanged(object sender, EventArgs e)
        {
            MostrarReservas();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            var loginForm = new LoginForm();
            loginForm.Show();
        }

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}