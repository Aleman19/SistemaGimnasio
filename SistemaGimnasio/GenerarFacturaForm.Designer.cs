namespace SistemaGimnasio
{
    partial class GenerarFacturaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // ComboBox Cliente
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Location = new System.Drawing.Point(12, 12);
            this.cmbCliente.Size = new System.Drawing.Size(260, 23);

            // TextBox Monto
            this.txtMonto.Location = new System.Drawing.Point(12, 41);
            this.txtMonto.Size = new System.Drawing.Size(260, 23);
            this.txtMonto.PlaceholderText = "Monto total";

            // DateTimePicker Fecha
            this.dtpFecha.Location = new System.Drawing.Point(12, 70);
            this.dtpFecha.Size = new System.Drawing.Size(260, 23);

            // Botón Guardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(12, 110);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Botón Cancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(197, 110);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Agregar componentes al formulario
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Factura";
            this.Load += new System.EventHandler(this.GenerarFacturaForm_Load);
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
