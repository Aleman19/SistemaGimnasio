using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SistemaGimnasio
{
    public partial class AgregarEditarClienteForm : Form
    {
        private string _clienteId; // Para identificar si se edita un cliente existente
        public AgregarEditarClienteForm(string clienteId = null)
        {
            InitializeComponent();
            _clienteId = clienteId;
        }

        private void AgregarEditarClienteForm_Load(object sender, EventArgs e)
        {
            if (_clienteId != null)
            {
                // Cargar datos del cliente para edición
                CargarCliente();
            }
        }

        private void CargarCliente()
        {
            // Simulación: cargar datos del cliente desde un controlador
            // En un proyecto real, esto se conecta al controlador que maneja los datos
            if (_clienteId == "1")
            {
                txtNombre.Text = "Juan Pérez";
                txtEmail.Text = "juan@gmail.com";
                dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
                cmbMembresia.SelectedItem = "Mensual";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación: Guardar o actualizar datos del cliente
            if (_clienteId == null)
            {
                MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

