using System;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        private void ReportesForm_Load(object sender, EventArgs e)
        {
            // Cargar opciones de tipo de reporte en el ComboBox
            CargarTiposDeReporte();
        }

        private void CargarTiposDeReporte()
        {
            // Agregar opciones al ComboBox
            cmbTipoReporte.Items.Add("Reporte de Usuarios");
            cmbTipoReporte.Items.Add("Reporte de Clases");
            cmbTipoReporte.Items.Add("Reporte Financiero");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // Validar selección de tipo de reporte
            if (cmbTipoReporte.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generar reporte según la opción seleccionada
            var tipoReporte = cmbTipoReporte.SelectedItem.ToString();
            var fechaInicio = dtpFechaInicio.Value;
            var fechaFin = dtpFechaFin.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación: Mostrar datos en el DataGridView
            dgvReportes.Rows.Clear();

            switch (tipoReporte)
            {
                case "Reporte de Usuarios":
                    dgvReportes.Rows.Add("1", "Juan Pérez", "Activo", "Mensual");
                    dgvReportes.Rows.Add("2", "Ana Gómez", "Activo", "Anual");
                    break;

                case "Reporte de Clases":
                    dgvReportes.Rows.Add("101", "Zumba", "Juan Pérez", "2024-11-20", "20/20");
                    dgvReportes.Rows.Add("102", "Yoga", "Ana Gómez", "2024-11-21", "15/15");
                    break;

                case "Reporte Financiero":
                    dgvReportes.Rows.Add("2024-11", "$500.00", "$200.00", "$300.00");
                    dgvReportes.Rows.Add("2024-10", "$450.00", "$250.00", "$200.00");
                    break;

                default:
                    MessageBox.Show("Tipo de reporte no soportado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
