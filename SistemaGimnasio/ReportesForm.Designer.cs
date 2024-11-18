namespace SistemaGimnasio
{
    partial class ReportesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvReportes;

        private void InitializeComponent()
        {
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvReportes = new System.Windows.Forms.DataGridView();

            // Configuración del ComboBox
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.Location = new System.Drawing.Point(12, 12);
            this.cmbTipoReporte.Size = new System.Drawing.Size(260, 23);
            this.cmbTipoReporte.PlaceholderText = "Seleccione el tipo de reporte";

            // Fecha de inicio
            this.dtpFechaInicio.Location = new System.Drawing.Point(12, 41);
            this.dtpFechaInicio.Size = new System.Drawing.Size(260, 23);

            // Fecha de fin
            this.dtpFechaFin.Location = new System.Drawing.Point(12, 70);
            this.dtpFechaFin.Size = new System.Drawing.Size(260, 23);

            // Botón Generar
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.Location = new System.Drawing.Point(12, 99);
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // Configuración del DataGridView
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(12, 140);
            this.dgvReportes.Size = new System.Drawing.Size(600, 250);

            // Agregar componentes al formulario
            this.Controls.Add(this.cmbTipoReporte);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgvReportes);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación de Reportes";
            this.Load += new System.EventHandler(this.ReportesForm_Load);
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