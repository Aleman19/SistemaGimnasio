using System;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class InventarioForm : Form
    {
        public InventarioForm()
        {
            InitializeComponent();
        }

        private void InventarioForm_Load(object sender, EventArgs e)
        {
            // Cargar elementos del inventario en el DataGridView
            CargarInventario();
        }

        private void CargarInventario()
        {
            // Simulación de datos para el DataGridView (reemplazar con datos reales del controlador)
            dgvInventario.Rows.Clear();
            dgvInventario.Rows.Add("001", "Bicicleta Estática", "2020-10-15", "Buen Estado");
            dgvInventario.Rows.Add("002", "Caminadora", "2019-08-10", "Revisión Requerida");
            dgvInventario.Rows.Add("003", "Máquina de Pesas", "2021-01-20", "Buen Estado");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Abrir formulario para agregar máquina
            var agregarInventarioForm = new AgregarEditarInventarioForm();
            agregarInventarioForm.ShowDialog();
            // Recargar inventario después de agregar
            CargarInventario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un elemento del inventario para editar.", "Editar Máquina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos de la máquina seleccionada
            var inventarioId = dgvInventario.SelectedRows[0].Cells[0].Value.ToString();

            // Abrir formulario para editar máquina
            var editarInventarioForm = new AgregarEditarInventarioForm(inventarioId);
            editarInventarioForm.ShowDialog();
            // Recargar inventario después de editar
            CargarInventario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un elemento del inventario para eliminar.", "Eliminar Máquina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación para eliminar
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este elemento del inventario?", "Eliminar Máquina", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Simulación de eliminación
                var inventarioId = dgvInventario.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show($"Máquina con ID {inventarioId} eliminada.", "Elemento Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Recargar inventario después de eliminar
                CargarInventario();
            }
        }
    }
}
