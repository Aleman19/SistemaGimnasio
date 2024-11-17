using System;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class ClaseForm : Form
    {
        public ClaseForm()
        {
            InitializeComponent();
        }

        private void ClaseForm_Load(object sender, EventArgs e)
        {
            // Cargar clases en el DataGridView
            CargarClases();
        }

        private void CargarClases()
        {
            // Simulación de datos para el DataGridView (reemplazar con datos reales del controlador)
            dgvClases.Rows.Clear();
            dgvClases.Rows.Add("101", "Zumba", "Juan Pérez", "20", "2024-11-20 18:00");
            dgvClases.Rows.Add("102", "Yoga", "Ana Gómez", "15", "2024-11-21 08:00");
            dgvClases.Rows.Add("103", "CardioDance", "Carlos López", "25", "2024-11-22 19:00");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Abrir formulario para agregar una clase
            var agregarClaseForm = new AgregarEditarClaseForm();
            agregarClaseForm.ShowDialog();
            // Recargar clases después de agregar
            CargarClases();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvClases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una clase para editar.", "Editar Clase", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos de la clase seleccionada
            var claseId = dgvClases.SelectedRows[0].Cells[0].Value.ToString();

            // Abrir formulario para editar la clase
            var editarClaseForm = new AgregarEditarClaseForm(claseId);
            editarClaseForm.ShowDialog();
            // Recargar clases después de editar
            CargarClases();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvClases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una clase para eliminar.", "Eliminar Clase", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación para eliminar
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar esta clase?", "Eliminar Clase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Simulación de eliminación
                var claseId = dgvClases.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show($"Clase con ID {claseId} eliminada.", "Clase Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Recargar clases después de eliminar
                CargarClases();
            }
        }
    }
}
