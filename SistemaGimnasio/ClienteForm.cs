using SistemaGimnasio;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace SistemaGimnasio
{
    public partial class ClienteForm : Form
    {
        private int idCliente;
        private readonly string membresiasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Membresias.csv");
        private readonly string tiposMembresiasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TiposMembresias.csv");

        public ClienteForm(int clienteId)
        {
            InitializeComponent();
            idCliente = clienteId;
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"Bienvenido, {ObtenerNombreCliente()}!";
            SincronizarEstadosMembresias(); // Sincronizar estados de membresías
            CargarMembresia(); // Cargar información de la membresía
        }

        /// <summary>
        /// Obtiene el nombre del cliente desde el archivo de clientes.
        /// </summary>
        /// <returns>Nombre completo del cliente</returns>
        private string ObtenerNombreCliente()
        {
            string clientesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Clientes.csv");

            try
            {
                if (!File.Exists(clientesPath))
                    throw new FileNotFoundException($"El archivo de clientes '{clientesPath}' no existe.");

                var cliente = File.ReadAllLines(clientesPath)
                    .Skip(1) // Omitir cabecera
                    .Select(line => line.Split(','))
                    .Where(data => data.Length >= 7) // Validar columnas
                    .FirstOrDefault(data => int.Parse(data[0]) == idCliente);

                if (cliente == null)
                    return "Cliente no encontrado";

                return $"{cliente[1].Trim()} {cliente[2].Trim()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el nombre del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error al cargar cliente";
            }
        }

        /// <summary>
        /// Carga los datos de la membresía del cliente actual.
        /// </summary>
        private void CargarMembresia()
        {
            try
            {
                if (!File.Exists(membresiasPath))
                    throw new FileNotFoundException($"El archivo de membresías '{membresiasPath}' no existe.");

                var membresia = File.ReadAllLines(membresiasPath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .FirstOrDefault(data => int.Parse(data[1]) == idCliente);

                if (membresia == null)
                {
                    lblMembresia.Text = "Sin información de membresía.";
                    btnGestionarMembresia.Enabled = true;
                    return;
                }

                var tipoMembresia = CargarTipoMembresia(membresia[2]);

                lblMembresia.Text = $"Tipo de Membresía: {tipoMembresia?[1] ?? "Desconocido"}\n" +
                                    $"Costo: {tipoMembresia?[2] ?? "Desconocido"}\n" +
                                    $"Estado: {membresia[5]}\n" +
                                    $"Fecha Inicio: {DateTime.Parse(membresia[3]):yyyy-MM-dd}\n" +
                                    $"Fecha Fin: {DateTime.Parse(membresia[4]):yyyy-MM-dd}";

                btnGestionarMembresia.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la membresía: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblMembresia.Text = "Error al cargar información de la membresía.";
                btnGestionarMembresia.Enabled = true;
            }
        }

        /// <summary>
        /// Carga el tipo de membresía según el ID proporcionado.
        /// </summary>
        /// <param name="idTipo">ID del tipo de membresía</param>
        /// <returns>Arreglo con los datos del tipo de membresía</returns>
        private string[] CargarTipoMembresia(string idTipo)
        {
            try
            {
                if (!File.Exists(tiposMembresiasPath))
                    throw new FileNotFoundException($"El archivo de tipos de membresías '{tiposMembresiasPath}' no existe.");

                return File.ReadAllLines(tiposMembresiasPath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .FirstOrDefault(data => data[0] == idTipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el tipo de membresía: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Sincroniza los estados de las membresías basados en las fechas de vigencia.
        /// </summary>
        private void SincronizarEstadosMembresias()
        {
            try
            {
                if (!File.Exists(membresiasPath))
                    throw new FileNotFoundException($"El archivo de membresías '{membresiasPath}' no existe.");

                var lines = File.ReadAllLines(membresiasPath).ToList();

                if (lines.Count <= 1) // Si solo contiene la cabecera
                    throw new InvalidOperationException("El archivo de membresías no contiene datos.");

                var header = lines.First();
                var dataLines = lines.Skip(1).ToList();

                var actualizaciones = dataLines
                    .Select(line =>
                    {
                        var data = line.Split(',');
                        if (data.Length < 6)
                        {
                            MessageBox.Show($"Línea mal formateada: {line}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }

                        DateTime.TryParse(data[3], out var fechaInicio);
                        DateTime.TryParse(data[4], out var fechaFin);

                        data[5] = (DateTime.Now >= fechaInicio && DateTime.Now <= fechaFin) ? "Activa" : "Vencida";
                        return string.Join(",", data);
                    })
                    .Where(line => line != null)
                    .ToList();

                File.WriteAllLines(membresiasPath, new[] { header }.Concat(actualizaciones));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al sincronizar estados de membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionarMembresia_Click(object sender, EventArgs e)
        {
            var membresiaForm = new MembresiaForm(idCliente);
            if (membresiaForm.ShowDialog() == DialogResult.OK)
            {
                SincronizarEstadosMembresias();
                CargarMembresia();
            }
        }

        private void btnReservarClase_Click(object sender, EventArgs e)
        {
            var reservarClaseForm = new ReservaForm(idCliente);
            reservarClaseForm.ShowDialog();
        }

        private void btnConsultarFacturas_Click(object sender, EventArgs e)
        {
            var facturasForm = new FacturasForm(idCliente);
            facturasForm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            var loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
