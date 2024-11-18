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
    public partial class ClientesForm : Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            // Aquí se cargarán los datos desde el controlador
            CargarClientes();
        }

        private void CargarClientes()
        {
            // Simulación de datos para el DataGridView (reemplazar con datos reales del controlador)
            dgvClientes.Rows.Clear();
            dgvClientes.Rows.Add("1", "Juan Pérez", "Activo", "Mensual");
            dgvClientes.Rows.Add("2", "Ana Gómez", "Activo", "Anual");
            dgvClientes.Rows.Add("3", "Carlos López", "Vencido", "Mensual");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Abrir formulario para agregar cliente
            var agregarClienteForm = new AgregarEditarClienteForm();
            agregarClienteForm.ShowDialog();
            // Recargar datos después de agregar
            CargarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos del cliente seleccionado
            var clienteId = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();

            // Abrir formulario para editar cliente
            var editarClienteForm = new AgregarEditarClienteForm(clienteId);
            editarClienteForm.ShowDialog();
            // Recargar datos después de editar
            CargarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación para eliminar
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Simulación de eliminación
                var clienteId = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show($"Cliente con ID {clienteId} eliminado.", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Recargar datos después de eliminar
                CargarClientes();
            }
        }
    }
}
