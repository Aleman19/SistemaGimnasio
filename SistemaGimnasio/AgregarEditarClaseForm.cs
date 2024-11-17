using System;
using System.Windows.Forms;

namespace SistemaGimnasio
{
    public partial class AgregarEditarClaseForm : Form
    {
        private string _claseId; // Identificador de la clase para edición

        public AgregarEditarClaseForm(string claseId = null)
        {
            InitializeComponent();
            _claseId = claseId;
        }

        private void AgregarEditarClaseForm_Load(object sender, EventArgs e)
        {
            if (_claseId != null)
            {
                // Cargar datos de la clase para edición
                CargarClase();
            }
        }

        private void CargarClase()
        {
            // Simulación: cargar datos de la clase desde un controlador
            // En un proyecto real, esto debe conectarse al controlador que maneja los datos
            if (_claseId == "101")
            {
                txtNombre.Text = "Zumba";
                cmbEntrenador.SelectedItem = "Juan Pérez";
                numCupos.Value = 20;
                dtpHorario.Value = new DateTime(2024, 11, 20, 18, 0, 0);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbEntrenador.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación: Guardar o actualizar datos de la clase
            if (_claseId == null)
            {
                MessageBox.Show("Clase agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Clase actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
