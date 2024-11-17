using System;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class AgregarEditarInventarioForm : Form
    {
        private string _inventarioId; // Identificador de la máquina para edición

        public AgregarEditarInventarioForm(string inventarioId = null)
        {
            InitializeComponent();
            _inventarioId = inventarioId;
        }

        private void AgregarEditarInventarioForm_Load(object sender, EventArgs e)
        {
            if (_inventarioId != null)
            {
                // Cargar datos de la máquina para edición
                CargarInventario();
            }
        }

        private void CargarInventario()
        {
            // Simulación: cargar datos del inventario desde un controlador
            // En un proyecto real, esto debe conectarse al controlador
            if (_inventarioId == "001")
            {
                txtNombre.Text = "Bicicleta Estática";
                dtpFechaCompra.Value = new DateTime(2020, 10, 15);
                cmbEstado.SelectedItem = "Buen Estado";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación: Guardar o actualizar datos del inventario
            if (_inventarioId == null)
            {
                MessageBox.Show("Elemento del inventario agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Elemento del inventario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Cerrar formulario después de guardar
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
