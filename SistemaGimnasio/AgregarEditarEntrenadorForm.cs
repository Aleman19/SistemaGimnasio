using System;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class AgregarEditarEntrenadorForm : Form
    {
        private string _entrenadorId; // Identificador del entrenador para edición

        public AgregarEditarEntrenadorForm(string entrenadorId = null)
        {
            InitializeComponent();
            _entrenadorId = entrenadorId;
        }

        private void AgregarEditarEntrenadorForm_Load(object sender, EventArgs e)
        {
            if (_entrenadorId != null)
            {
                // Cargar datos del entrenador para edición
                CargarEntrenador();
            }
        }

        private void CargarEntrenador()
        {
            // Simulación: cargar datos del entrenador desde el controlador
            if (_entrenadorId == "001")
            {
                txtNombre.Text = "Juan Pérez";
                txtEspecialidades.Text = "Zumba, CardioDance";
                txtHorario.Text = "Lunes a Viernes";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEspecialidades.Text) || string.IsNullOrWhiteSpace(txtHorario.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación: Guardar o actualizar entrenador
            if (_entrenadorId == null)
            {
                MessageBox.Show("Entrenador agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Entrenador actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
