using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data;


namespace SistemaGimnasio
{
    public partial class ReservaForm : Form
    {
        private string clasesFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Clases.csv");
        private string reservasFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Reservas.csv");
        private int clienteId;

        public ReservaForm(int idCliente)
        {
            InitializeComponent();
            clienteId = idCliente;
        }

        private void ReservaForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el archivo de clases existe
                if (!File.Exists(clasesFilePath))
                {
                    throw new FileNotFoundException($"El archivo de clases no fue encontrado en la ruta: {clasesFilePath}");
                }

                // Cargar datos de las clases
                var lineas = File.ReadAllLines(clasesFilePath);

                if (lineas.Length <= 1) // Verificar si el archivo tiene datos
                {
                    MessageBox.Show("El archivo de clases está vacío.", "Archivo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvClases.DataSource = null;
                    return;
                }

                var clases = lineas
                    .Skip(1) // Omitir cabecera
                    .Select(line => line.Split(','))
                    .Select(data => new
                    {
                        IdClase = int.Parse(data[0]),
                        NombreClase = data[1],
                        Cupo = int.Parse(data[3]),
                        Horario = $"{data[4]} - {data[5]}",
                        Dias = data[6]
                    }).ToList();

                dgvClases.DataSource = clases;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las clases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClases.SelectedRows.Count == 0) // Validar que se haya seleccionado una clase
                {
                    MessageBox.Show("Por favor, selecciona una clase para reservar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los datos de la clase seleccionada
                var selectedRow = dgvClases.SelectedRows[0];
                int idClase = int.Parse(selectedRow.Cells["IdClase"].Value.ToString());
                string nombreClase = selectedRow.Cells["NombreClase"].Value.ToString();

                // Crear el archivo de reservas si no existe
                if (!File.Exists(reservasFilePath))
                {
                    File.WriteAllText(reservasFilePath, "IdReserva,IdClase,IdCliente,FechaReserva,Estado\n");
                }

                // Generar un nuevo ID de reserva
                var lineas = File.ReadAllLines(reservasFilePath);
                int newIdReserva = lineas.Length > 1 ? lineas.Skip(1).Count() + 1 : 1;

                // Agregar la nueva reserva
                string nuevaReserva = $"{newIdReserva},{idClase},{clienteId},{DateTime.Now:yyyy-MM-dd},Confirmada";
                File.AppendAllText(reservasFilePath, nuevaReserva + Environment.NewLine);

                MessageBox.Show($"Reserva exitosa para la clase: {nombreClase}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: Cerrar el formulario después de la reserva
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario
        }
    }
}
