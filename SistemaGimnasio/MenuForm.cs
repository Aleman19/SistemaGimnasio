
namespace SistemaGimnasio
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            var clientesForm = new ClientesForm();
            clientesForm.ShowDialog();
        }

        private void btnEntrenadores_Click(object sender, EventArgs e)
        {
            var entrenadoresForm = new EntrenadoresForm();
            entrenadoresForm.ShowDialog();
        }

        private void btnClases_Click(object sender, EventArgs e)
        {
            var clasesForm = new ClaseForm();
            clasesForm.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            var inventarioForm = new InventarioForm();
            inventarioForm.ShowDialog();
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            var facturacionForm = new FacturacionForm();
            facturacionForm.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            var reportesForm = new ReportesForm();
            reportesForm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
