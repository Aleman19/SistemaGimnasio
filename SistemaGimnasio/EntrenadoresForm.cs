using System;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class EntrenadoresForm : Form
    {
        public EntrenadoresForm()
        {
            InitializeComponent();
        }

        private void EntrenadoresForm_Load(object sender, EventArgs e)
        {
            // Cargar entrenadores en el DataGridView
            CargarEntrenadores();
        }

        private void CargarEntrenadores()
        {
            // Simulación de datos para el DataGridView (reemplazar con datos reales del controlador)
            dgvEntrenadores.Rows.Clear();
            dgvEntrenadores.Rows.Add("001", "Juan Pérez", "Zumba, CardioDance", "Lunes a Viernes");
            dgvEntrenadores.Rows.Add("002", "Ana Gómez", "Yoga, Funcional", "Martes y Jueves");
            dgvEntrenadores.Rows.Add("003", "Carlos López", "Pesas, Crossfit", "Lunes, Miércoles y Viernes");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Abrir formulario para agregar entrenador
            var agregarEntrenadorForm = new AgregarEditarEntrenadorForm();
            agregarEntrenadorForm.ShowDialog();
            // Recargar entrenadores después de agregar
            CargarEntrenadores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvEntrenadores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un entrenador para editar.", "Editar Entrenador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos del entrenador seleccionado
            var entrenadorId = dgvEntrenadores.SelectedRows[0].Cells[0].Value.ToString();

            // Abrir formulario para editar entrenador
            var editarEntrenadorForm = new AgregarEditarEntrenadorForm(entrenadorId);
            editarEntrenadorForm.ShowDialog();
            // Recargar entrenadores después de editar
            CargarEntrenadores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvEntrenadores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un entrenador para eliminar.", "Eliminar Entrenador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación para eliminar
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este entrenador?", "Eliminar Entrenador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Simulación de eliminación
                var entrenadorId = dgvEntrenadores.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show($"Entrenador con ID {entrenadorId} eliminado.", "Entrenador Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Recargar entrenadores después de eliminar
                CargarEntrenadores();
            }
        }
    }
