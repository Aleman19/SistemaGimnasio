using System;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class GenerarFacturaForm : Form
    {
        public GenerarFacturaForm()
        {
            InitializeComponent();
        }

        private void GenerarFacturaForm_Load(object sender, EventArgs e)
        {
            // Cargar lista de clientes en el ComboBox
            CargarClientes();
        }

        private void CargarClientes()
        {
            // Simulación de datos de clientes (reemplazar con datos reales del controlador)
            cmbCliente.Items.Clear();
            cmbCliente.Items.Add("Juan Pérez");
            cmbCliente.Items.Add("Ana Gómez");
            cmbCliente.Items.Add("Carlos López");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (cmbCliente.SelectedItem == null || string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar formato numérico para el monto
            if (!decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("El monto debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación: Guardar factura
            MessageBox.Show("Factura generada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cerrar formulario
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
