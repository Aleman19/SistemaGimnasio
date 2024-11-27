
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class MembresiaForm : Form
    {
        private int idCliente;
        private string membresiasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Membresias.csv");
        private string tiposMembresiasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TiposMembresias.csv");

        public MembresiaForm(int clienteId)
        {
            InitializeComponent();
            idCliente = clienteId;
        }

        private void MembresiaForm_Load(object sender, EventArgs e)
        {
            CargarTiposMembresias();
            CargarDatosMembresia();
        }

        /// <summary>
        /// Carga la información de la membresía desde el archivo CSV.
        /// </summary>
        private void CargarDatosMembresia()
        {
            try
            {
                if (!File.Exists(membresiasPath))
                    throw new FileNotFoundException("El archivo de membresías no fue encontrado.");

                var membresia = File.ReadAllLines(membresiasPath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .Where(data => data.Length >= 6)
                    .Select(data => new
                    {
                        IdMembresia = int.TryParse(data[0], out var idM) ? idM : 0,
                        IdCliente = int.TryParse(data[1], out var idC) ? idC : 0,
                        IdTipoMembresia = int.TryParse(data[2], out var idT) ? idT : 0,
                        FechaInicio = DateTime.TryParse(data[3], out var fi) ? fi : DateTime.MinValue,
                        FechaFin = DateTime.TryParse(data[4], out var ff) ? ff : DateTime.MinValue,
                        Estado = data[5]
                    })
                    .FirstOrDefault(m => m.IdCliente == idCliente);

                if (membresia == null)
                {
                    lblMembresiaInfo.Text = "Sin información de membresía.";
                    return;
                }

                var tiposMembresias = File.ReadAllLines(tiposMembresiasPath)
                    .Skip(1)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => line.Split(','))
                    .Where(data => data.Length >= 4)
                    .Select(data => new
                    {
                        IdTipoMembresia = int.TryParse(data[0], out var idT) ? idT : 0,
                        Nombre = data[1],
                        Costo = decimal.TryParse(data[2], out var costo) ? costo : 0
                    }).ToList();

                var tipoMembresia = tiposMembresias.FirstOrDefault(t => t.IdTipoMembresia == membresia.IdTipoMembresia);

                if (tipoMembresia == null)
                {
                    MessageBox.Show("No se encontró el tipo de membresía asociado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblMembresiaInfo.Text = $"Estado: {membresia.Estado}\n" +
                                        $"Fecha de Inicio: {membresia.FechaInicio:yyyy-MM-dd}\n" +
                                        $"Fecha de Fin: {membresia.FechaFin:yyyy-MM-dd}\n" +
                                        $"Tipo: {tipoMembresia.Nombre}\n" +
                                        $"Costo: {tipoMembresia.Costo:C}";

                cmbTiposMembresias.SelectedValue = membresia.IdTipoMembresia;
                dtpFechaInicio.Value = membresia.FechaInicio;
                dtpFechaFin.Value = membresia.FechaFin;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la información de la membresía: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los tipos de membresías desde el archivo CSV y los muestra en el ComboBox.
        /// </summary>
        private void CargarTiposMembresias()
        {
            try
            {
                if (!File.Exists(tiposMembresiasPath))
                    throw new FileNotFoundException("El archivo de tipos de membresías no fue encontrado.");

                var tiposMembresias = File.ReadAllLines(tiposMembresiasPath)
                    .Skip(1)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => line.Split(','))
                    .Where(data => data.Length >= 4)
                    .Select(data => new
                    {
                        IdTipoMembresia = int.Parse(data[0]),
                        Nombre = data[1],
                        Costo = decimal.Parse(data[2]),
                        DuracionMeses = int.Parse(data[3])
                    })
                    .ToList();

                cmbTiposMembresias.DataSource = tiposMembresias;
                cmbTiposMembresias.DisplayMember = "Nombre";
                cmbTiposMembresias.ValueMember = "IdTipoMembresia";

                if (cmbTiposMembresias.Items.Count > 0)
                    cmbTiposMembresias.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los tipos de membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTiposMembresias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedTipo = (dynamic)cmbTiposMembresias.SelectedItem;
                int duracionMeses = selectedTipo.DuracionMeses;
                decimal costo = selectedTipo.Costo;

                dtpFechaInicio.Value = DateTime.Today;
                dtpFechaFin.Value = DateTime.Today.AddMonths(duracionMeses);

                lblCosto.Text = $"Costo: ${costo:0.00}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la información de la membresía: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTiposMembresias.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un tipo de membresía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lines = File.ReadAllLines(membresiasPath).ToList();
                var header = lines.First();
                var dataLines = lines.Skip(1).Select(line => line.Split(',')).ToList();

                for (int i = 0; i < dataLines.Count; i++)
                {
                    if (int.TryParse(dataLines[i][1], out var id) && id == idCliente)
                    {
                        dataLines[i][2] = cmbTiposMembresias.SelectedValue.ToString();
                        dataLines[i][3] = dtpFechaInicio.Value.ToString("yyyy-MM-dd");
                        dataLines[i][4] = dtpFechaFin.Value.ToString("yyyy-MM-dd");
                        dataLines[i][5] = "Activa";
                        break;
                    }
                }

                File.WriteAllLines(membresiasPath, new[] { header }.Concat(dataLines.Select(d => string.Join(",", d))));
                MessageBox.Show("La membresía se actualizó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosMembresia();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la membresía: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
