namespace SistemaGimnasio
{
    partial class AgregarEditarInventarioForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // Nombre de la máquina
            this.txtNombre.Location = new System.Drawing.Point(12, 12);
            this.txtNombre.Size = new System.Drawing.Size(260, 23);
            this.txtNombre.PlaceholderText = "Nombre de la máquina";

            // Fecha de compra
            this.dtpFechaCompra.Location = new System.Drawing.Point(12, 41);
            this.dtpFechaCompra.Size = new System.Drawing.Size(260, 23);

            // Estado de la máquina
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] { "Buen Estado", "Revisión Requerida", "Obsoleto" });
            this.cmbEstado.Location = new System.Drawing.Point(12, 70);
            this.cmbEstado.Size = new System.Drawing.Size(260, 23);

            // Botón Guardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(12, 110);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Botón Cancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(197, 110);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Agregar componentes al formulario
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dtpFechaCompra);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar/Editar Inventario";
            this.Load += new System.EventHandler(this.AgregarEditarInventarioForm_Load);
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
