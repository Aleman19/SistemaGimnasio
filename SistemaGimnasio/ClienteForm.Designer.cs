namespace SistemaGimnasio

{
    partial class ClienteForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblMembresia;
        private System.Windows.Forms.Button btnGestionarMembresia;
        private System.Windows.Forms.Button btnReservarClase;
        private System.Windows.Forms.Button btnConsultarFacturas;
        private System.Windows.Forms.Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblMembresia = new System.Windows.Forms.Label();
            this.btnGestionarMembresia = new System.Windows.Forms.Button();
            this.btnReservarClase = new System.Windows.Forms.Button();
            this.btnConsultarFacturas = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.Location = new System.Drawing.Point(20, 20);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(176, 21);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido, [Usuario]";
            // 
            // lblMembresia
            // 
            this.lblMembresia.AutoSize = true;
            this.lblMembresia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMembresia.Location = new System.Drawing.Point(20, 60);
            this.lblMembresia.Name = "lblMembresia";
            this.lblMembresia.Size = new System.Drawing.Size(167, 38);
            this.lblMembresia.TabIndex = 1;
            this.lblMembresia.Text = "Tipo de Membresía: [Tipo]\nEstado: [Estado]";
            // 
            // btnGestionarMembresia
            // 
            this.btnGestionarMembresia.Location = new System.Drawing.Point(24, 175);
            this.btnGestionarMembresia.Name = "btnGestionarMembresia";
            this.btnGestionarMembresia.Size = new System.Drawing.Size(200, 30);
            this.btnGestionarMembresia.TabIndex = 2;
            this.btnGestionarMembresia.Text = "Gestionar Membresía";
            this.btnGestionarMembresia.UseVisualStyleBackColor = true;
            this.btnGestionarMembresia.Click += new System.EventHandler(this.btnGestionarMembresia_Click);
            // 
            // btnReservarClase
            // 
            this.btnReservarClase.Location = new System.Drawing.Point(24, 225);
            this.btnReservarClase.Name = "btnReservarClase";
            this.btnReservarClase.Size = new System.Drawing.Size(200, 30);
            this.btnReservarClase.TabIndex = 3;
            this.btnReservarClase.Text = "Reservar Clase";
            this.btnReservarClase.UseVisualStyleBackColor = true;
            this.btnReservarClase.Click += new System.EventHandler(this.btnReservarClase_Click);
            // 
            // btnConsultarFacturas
            // 
            this.btnConsultarFacturas.Location = new System.Drawing.Point(20, 277);
            this.btnConsultarFacturas.Name = "btnConsultarFacturas";
            this.btnConsultarFacturas.Size = new System.Drawing.Size(200, 30);
            this.btnConsultarFacturas.TabIndex = 4;
            this.btnConsultarFacturas.Text = "Consultar Facturas";
            this.btnConsultarFacturas.UseVisualStyleBackColor = true;
            this.btnConsultarFacturas.Click += new System.EventHandler(this.btnConsultarFacturas_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(24, 332);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(200, 30);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // ClienteForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 384);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.lblMembresia);
            this.Controls.Add(this.btnGestionarMembresia);
            this.Controls.Add(this.btnReservarClase);
            this.Controls.Add(this.btnConsultarFacturas);
            this.Controls.Add(this.btnCerrarSesion);
            this.Name = "ClienteForm";
            this.Text = "Área Cliente";
            this.Load += new System.EventHandler(this.ClienteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}