namespace SistemaGimnasio
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnEntrenadores;
        private System.Windows.Forms.Button btnClases;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnSalir;

        private void InitializeComponent()
        {
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnEntrenadores = new System.Windows.Forms.Button();
            this.btnClases = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();

            // Botón Clientes
            this.btnClientes.Text = "Gestión de Clientes";
            this.btnClientes.Location = new System.Drawing.Point(20, 20);
            this.btnClientes.Size = new System.Drawing.Size(200, 40);
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);

            // Botón Entrenadores
            this.btnEntrenadores.Text = "Gestión de Entrenadores";
            this.btnEntrenadores.Location = new System.Drawing.Point(20, 70);
            this.btnEntrenadores.Size = new System.Drawing.Size(200, 40);
            this.btnEntrenadores.Click += new System.EventHandler(this.btnEntrenadores_Click);

            // Botón Clases
            this.btnClases.Text = "Gestión de Clases";
            this.btnClases.Location = new System.Drawing.Point(20, 120);
            this.btnClases.Size = new System.Drawing.Size(200, 40);
            this.btnClases.Click += new System.EventHandler(this.btnClases_Click);

            // Botón Inventario
            this.btnInventario.Text = "Gestión de Inventario";
            this.btnInventario.Location = new System.Drawing.Point(20, 170);
            this.btnInventario.Size = new System.Drawing.Size(200, 40);
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);

            // Botón Facturación
            this.btnFacturacion.Text = "Gestión de Facturación";
            this.btnFacturacion.Location = new System.Drawing.Point(20, 220);
            this.btnFacturacion.Size = new System.Drawing.Size(200, 40);
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);

            // Botón Reportes
            this.btnReportes.Text = "Generación de Reportes";
            this.btnReportes.Location = new System.Drawing.Point(20, 270);
            this.btnReportes.Size = new System.Drawing.Size(200, 40);
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);

            // Botón Salir
            this.btnSalir.Text = "Salir";
            this.btnSalir.Location = new System.Drawing.Point(20, 320);
            this.btnSalir.Size = new System.Drawing.Size(200, 40);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(250, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";

            // Agregar componentes al formulario
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnEntrenadores);
            this.Controls.Add(this.btnClases);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.btnFacturacion);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnSalir);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
