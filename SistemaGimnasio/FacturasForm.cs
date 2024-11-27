
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class FacturasForm : Form
    {
        private string facturasFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Facturas.csv");
        private int clienteId;

        public FacturasForm(int idCliente)
        {
            InitializeComponent();
            clienteId = idCliente;
        }

        private void FacturasForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(facturasFilePath))
                {
                    MessageBox.Show($"El archivo de facturas no fue encontrado en la ruta: {facturasFilePath}",
                        "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                var lineas = File.ReadAllLines(facturasFilePath);

                if (lineas.Length <= 1)
                {
                    MessageBox.Show("El archivo de facturas está vacío o no contiene datos.",
                        "Archivo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvFacturas.DataSource = null;
                    return;
                }

                var facturas = lineas
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .Where(data => int.Parse(data[1]) == clienteId)
                    .Select(data => new
                    {
                        IdFactura = int.Parse(data[0]),
                        FechaFactura = DateTime.Parse(data[2]).ToString("yyyy-MM-dd"),
                        Monto = decimal.Parse(data[3]),
                        Descripcion = data[4]
                    }).ToList();

                if (facturas.Count == 0)
                {
                    MessageBox.Show("No se encontraron facturas asociadas al cliente.",
                        "Sin facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvFacturas.DataSource = null;
                }
                else
                {
                    dgvFacturas.DataSource = facturas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var facturas = File.ReadAllLines(facturasFilePath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                    .Where(data => int.Parse(data[1]) == clienteId &&
                                   DateTime.Parse(data[2]).Date >= fechaInicio &&
                                   DateTime.Parse(data[2]).Date <= fechaFin)
                    .Select(data => new
                    {
                        IdFactura = int.Parse(data[0]),
                        FechaFactura = DateTime.Parse(data[2]).ToString("yyyy-MM-dd"),
                        Monto = decimal.Parse(data[3]),
                        Descripcion = data[4]
                    }).ToList();

                dgvFacturas.DataSource = facturas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
