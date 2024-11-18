namespace SistemaGimnasio
{
    public partial class FacturacionForm : Form
    {
        public FacturacionForm()
        {
            InitializeComponent();
        }

        private void FacturacionForm_Load(object sender, EventArgs e)
        {
            // Cargar facturas en el DataGridView
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            // Simulación de datos para el DataGridView (reemplazar con datos reales del controlador)
            dgvFacturas.Rows.Clear();
            dgvFacturas.Rows.Add("001", "Juan Pérez", "2024-11-01", "$50.00", "Pagada");
            dgvFacturas.Rows.Add("002", "Ana Gómez", "2024-11-01", "$50.00", "Pendiente");
            dgvFacturas.Rows.Add("003", "Carlos López", "2024-11-01", "$50.00", "Pendiente");
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            // Abrir formulario para generar nueva factura
            var generarFacturaForm = new GenerarFacturaForm();
            generarFacturaForm.ShowDialog();
            // Recargar facturas después de generar una nueva
            CargarFacturas();
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una factura para ver detalles.", "Ver Detalles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos de la factura seleccionada
            var facturaId = dgvFacturas.SelectedRows[0].Cells[0].Value.ToString();

            // Simulación: Mostrar detalles de la factura
            MessageBox.Show($"Detalles de la factura {facturaId}.", "Detalles de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMarcarComoPagada_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una factura para marcar como pagada.", "Marcar como Pagada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación para marcar como pagada
            var facturaId = dgvFacturas.SelectedRows[0].Cells[0].Value.ToString();
            var confirmResult = MessageBox.Show($"¿Está seguro de marcar la factura {facturaId} como pagada?", "Marcar como Pagada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Simulación: Marcar factura como pagada
                MessageBox.Show($"Factura {facturaId} marcada como pagada.", "Factura Pagada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Recargar facturas después de marcar como pagada
                CargarFacturas();
            }
        }
    }
}
