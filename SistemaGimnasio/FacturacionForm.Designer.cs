namespace SistemaGimnasio
{
    partial class FacturacionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Button btnMarcarComoPagada;

        private void InitializeComponent()
        {
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.btnMarcarComoPagada = new System.Windows.Forms.Button();

            // Configuración del DataGridView
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", Width = 50 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Cliente", HeaderText = "Cliente", Width = 150 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", Width = 100 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Monto", HeaderText = "Monto", Width = 100 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 100 }
            });
            this.dgvFacturas.Location = new System.Drawing.Point(12, 12);
            this.dgvFacturas.Size = new System.Drawing.Size(600, 250);

            // Botón Generar Factura
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.Location = new System.Drawing.Point(12, 270);
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);

            // Botón Ver Detalles
            this.btnVerDetalles.Text = "Ver Detalles";
            this.btnVerDetalles.Location = new System.Drawing.Point(150, 270);
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);

            // Botón Marcar como Pagada
            this.btnMarcarComoPagada.Text = "Marcar como Pagada";
            this.btnMarcarComoPagada.Location = new System.Drawing.Point(290, 270);
            this.btnMarcarComoPagada.Click += new System.EventHandler(this.btnMarcarComoPagada_Click);

            // Agregar componentes al formulario
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.btnVerDetalles);
            this.Controls.Add(this.btnMarcarComoPagada);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(634, 311);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Facturación";
            this.Load += new System.EventHandler(this.FacturacionForm_Load);
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

