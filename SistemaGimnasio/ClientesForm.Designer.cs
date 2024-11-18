namespace SistemaGimnasio
{
    partial class ClientesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;

        private void InitializeComponent()
        {
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            // Configuración del DataGridView
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", Width = 50 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", Width = 150 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 100 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Membresía", HeaderText = "Membresía", Width = 100 }
            });
            this.dgvClientes.Location = new System.Drawing.Point(12, 12);
            this.dgvClientes.Size = new System.Drawing.Size(500, 250);

            // Botón Agregar
            this.btnAgregar.Text = "Agregar Cliente";
            this.btnAgregar.Location = new System.Drawing.Point(12, 270);
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // Botón Editar
            this.btnEditar.Text = "Editar Cliente";
            this.btnEditar.Location = new System.Drawing.Point(130, 270);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // Botón Eliminar
            this.btnEliminar.Text = "Eliminar Cliente";
            this.btnEliminar.Location = new System.Drawing.Point(250, 270);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // Agregar componentes al formulario
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Clientes";
            this.Load += new System.EventHandler(this.ClientesForm_Load);
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