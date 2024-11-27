namespace SistemaGimnasio

{
    partial class EntrenadorForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.DataGridView dgvClases;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.ComboBox cmbAniosReporte;
        private System.Windows.Forms.ComboBox cmbReportes;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblClasesAsignadas;
        private System.Windows.Forms.Label lblReservasConfirmadas;
        private System.Windows.Forms.Label lblInventario;

        /// <summary>
        /// Limpiar recursos
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Inicialización del formulario
        /// </summary>
        private void InitializeComponent()
        {
            lblBienvenida = new Label();
            dgvClases = new DataGridView();
            dgvReservas = new DataGridView();
            dgvInventario = new DataGridView();
            cmbAniosReporte = new ComboBox();
            cmbReportes = new ComboBox();
            btnGenerarReporte = new Button();
            btnCerrarSesion = new Button();
            lblClasesAsignadas = new Label();
            lblReservasConfirmadas = new Label();
            lblInventario = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBienvenida.Location = new Point(20, 20);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(303, 21);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido al área Entrenador (ID: {0})";
            // 
            // dgvClases
            // 
            dgvClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClases.Location = new Point(20, 80);
            dgvClases.Name = "dgvClases";
            dgvClases.Size = new Size(500, 150);
            dgvClases.TabIndex = 1;
            dgvClases.CellContentClick += dgvClases_CellContentClick;
            dgvClases.SelectionChanged += dgvClases_SelectionChanged;
            // 
            // dgvReservas
            // 
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(550, 80);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.Size = new Size(400, 150);
            dgvReservas.TabIndex = 2;
            dgvReservas.CellContentClick += dgvReservas_CellContentClick;
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(20, 260);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.Size = new Size(500, 150);
            dgvInventario.TabIndex = 3;
            dgvInventario.CellContentClick += dgvInventario_CellContentClick;
            // 
            // cmbAniosReporte
            // 
            cmbAniosReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAniosReporte.FormattingEnabled = true;
            cmbAniosReporte.Location = new Point(550, 260);
            cmbAniosReporte.Name = "cmbAniosReporte";
            cmbAniosReporte.Size = new Size(120, 23);
            cmbAniosReporte.TabIndex = 4;
            // 
            // cmbReportes
            // 
            cmbReportes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportes.FormattingEnabled = true;
            cmbReportes.Items.AddRange(new object[] { "Reporte Contable", "Reporte de Matrícula de Clientes", "Reporte de Clases Más Demandadas" });
            cmbReportes.Location = new Point(550, 300);
            cmbReportes.Name = "cmbReportes";
            cmbReportes.Size = new Size(200, 23);
            cmbReportes.TabIndex = 5;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.Location = new Point(770, 260);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(120, 30);
            btnGenerarReporte.TabIndex = 6;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(770, 320);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(120, 30);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblClasesAsignadas
            // 
            lblClasesAsignadas.AutoSize = true;
            lblClasesAsignadas.Location = new Point(20, 60);
            lblClasesAsignadas.Name = "lblClasesAsignadas";
            lblClasesAsignadas.Size = new Size(100, 15);
            lblClasesAsignadas.TabIndex = 8;
            lblClasesAsignadas.Text = "Clases Asignadas:";
            // 
            // lblReservasConfirmadas
            // 
            lblReservasConfirmadas.AutoSize = true;
            lblReservasConfirmadas.Location = new Point(550, 60);
            lblReservasConfirmadas.Name = "lblReservasConfirmadas";
            lblReservasConfirmadas.Size = new Size(126, 15);
            lblReservasConfirmadas.TabIndex = 9;
            lblReservasConfirmadas.Text = "Reservas Confirmadas:";
            // 
            // lblInventario
            // 
            lblInventario.AutoSize = true;
            lblInventario.Location = new Point(20, 240);
            lblInventario.Name = "lblInventario";
            lblInventario.Size = new Size(63, 15);
            lblInventario.TabIndex = 10;
            lblInventario.Text = "Inventario:";
            // 
            // EntrenadorForm
            // 
            ClientSize = new Size(980, 450);
            Controls.Add(lblInventario);
            Controls.Add(lblReservasConfirmadas);
            Controls.Add(lblClasesAsignadas);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnGenerarReporte);
            Controls.Add(cmbReportes);
            Controls.Add(cmbAniosReporte);
            Controls.Add(dgvInventario);
            Controls.Add(dgvReservas);
            Controls.Add(dgvClases);
            Controls.Add(lblBienvenida);
            Name = "EntrenadorForm";
            Text = "Área Entrenador";
            Load += EntrenadorForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClases).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
