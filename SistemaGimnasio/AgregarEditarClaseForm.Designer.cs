namespace SistemaGimnasio
{
    partial class AgregarEditarClaseForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbEntrenador;
        private System.Windows.Forms.NumericUpDown numCupos;
        private System.Windows.Forms.DateTimePicker dtpHorario;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbEntrenador = new System.Windows.Forms.ComboBox();
            this.numCupos = new System.Windows.Forms.NumericUpDown();
            this.dtpHorario = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // Nombre de la clase
            this.txtNombre.Location = new System.Drawing.Point(12, 12);
            this.txtNombre.Size = new System.Drawing.Size(260, 23);
            this.txtNombre.PlaceholderText = "Nombre de la clase";

            // Entrenador
            this.cmbEntrenador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntrenador.Items.AddRange(new object[] { "Juan Pérez", "Ana Gómez", "Carlos López" }); // Simulación
            this.cmbEntrenador.Location = new System.Drawing.Point(12, 41);
            this.cmbEntrenador.Size = new System.Drawing.Size(260, 23);

            // Cupos
            this.numCupos.Location = new System.Drawing.Point(12, 70);
            this.numCupos.Size = new System.Drawing.Size(260, 23);
            this.numCupos.Minimum = 1;
            this.numCupos.Maximum = 100;
            this.numCupos.Value = 20;

            // Horario
            this.dtpHorario.Location = new System.Drawing.Point(12, 99);
            this.dtpHorario.Size = new System.Drawing.Size(260, 23);

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
            this.Controls.Add(this.cmbEntrenador);
            this.Controls.Add(this.numCupos);
            this.Controls.Add(this.dtpHorario);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar/Editar Clase";
            this.Load += new System.EventHandler(this.AgregarEditarClaseForm_Load);
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
