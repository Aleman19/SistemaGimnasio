namespace SistemaGimnasio
{
    partial class AgregarEditarClienteForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.ComboBox cmbMembresia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cmbMembresia = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // Nombre del cliente
            this.txtNombre.Location = new System.Drawing.Point(12, 12);
            this.txtNombre.Size = new System.Drawing.Size(260, 23);
            this.txtNombre.PlaceholderText = "Nombre del cliente";

            // Email del cliente
            this.txtEmail.Location = new System.Drawing.Point(12, 41);
            this.txtEmail.Size = new System.Drawing.Size(260, 23);
            this.txtEmail.PlaceholderText = "Correo electrónico";

            // Fecha de inicio de la membresía
            this.dtpFechaInicio.Location = new System.Drawing.Point(12, 70);
            this.dtpFechaInicio.Size = new System.Drawing.Size(260, 23);

            // Tipo de membresía
            this.cmbMembresia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMembresia.Items.AddRange(new object[] { "Mensual", "Anual", "Semestral" });
            this.cmbMembresia.Location = new System.Drawing.Point(12, 99);
            this.cmbMembresia.Size = new System.Drawing.Size(260, 23);

            // Botón Guardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(12, 140);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Botón Cancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(197, 140);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Agregar componentes al formulario
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.cmbMembresia);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar/Editar Cliente";
            this.Load += new System.EventHandler(this.AgregarEditarClienteForm_Load);
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
