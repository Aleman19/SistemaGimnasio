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
            btnClientes = new Button();
            btnEntrenadores = new Button();
            btnClases = new Button();
            btnInventario = new Button();
            btnFacturacion = new Button();
            btnReportes = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(20, 20);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(200, 40);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Gestión de Clientes";
            btnClientes.Click += btnClientes_Click;
            // 
            // btnEntrenadores
            // 
            btnEntrenadores.Location = new Point(20, 70);
            btnEntrenadores.Name = "btnEntrenadores";
            btnEntrenadores.Size = new Size(200, 40);
            btnEntrenadores.TabIndex = 1;
            btnEntrenadores.Text = "Gestión de Entrenadores";
            btnEntrenadores.Click += btnEntrenadores_Click;
            // 
            // btnClases
            // 
            btnClases.Location = new Point(20, 120);
            btnClases.Name = "btnClases";
            btnClases.Size = new Size(200, 40);
            btnClases.TabIndex = 2;
            btnClases.Text = "Gestión de Clases";
            btnClases.Click += btnClases_Click;
            // 
            // btnInventario
            // 
            btnInventario.Location = new Point(20, 170);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(200, 40);
            btnInventario.TabIndex = 3;
            btnInventario.Text = "Gestión de Inventario";
            btnInventario.Click += btnInventario_Click;
            // 
            // btnFacturacion
            // 
            btnFacturacion.Location = new Point(20, 220);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Size = new Size(200, 40);
            btnFacturacion.TabIndex = 4;
            btnFacturacion.Text = "Gestión de Facturación";
            btnFacturacion.Click += btnFacturacion_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(20, 270);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(200, 40);
            btnReportes.TabIndex = 5;
            btnReportes.Text = "Generación de Reportes";
            btnReportes.Click += btnReportes_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(20, 320);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(200, 40);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // MenuForm
            // 
            ClientSize = new Size(250, 400);
            Controls.Add(btnClientes);
            Controls.Add(btnEntrenadores);
            Controls.Add(btnClases);
            Controls.Add(btnInventario);
            Controls.Add(btnFacturacion);
            Controls.Add(btnReportes);
            Controls.Add(btnSalir);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            Load += MenuForm_Load;
            ResumeLayout(false);
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
