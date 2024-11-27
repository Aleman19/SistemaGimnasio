namespace SistemaGimnasio
{
    partial class MembresiaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMembresiaInfo;
        private System.Windows.Forms.ComboBox cmbTiposMembresias;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;

        /// <summary>
        /// Limpiar recursos utilizados.
        /// </summary>
        /// <param name="disposing">true si se deben liberar los recursos administrados; de lo contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método requerido para el soporte del diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMembresiaInfo = new System.Windows.Forms.Label();
            this.cmbTiposMembresias = new System.Windows.Forms.ComboBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMembresiaInfo
            // 
            this.lblMembresiaInfo.AutoSize = true;
            this.lblMembresiaInfo.Location = new System.Drawing.Point(20, 20);
            this.lblMembresiaInfo.Name = "lblMembresiaInfo";
            this.lblMembresiaInfo.Size = new System.Drawing.Size(200, 60);
            this.lblMembresiaInfo.TabIndex = 0;
            this.lblMembresiaInfo.Text = "Información de la Membresía:";
            // 
            // cmbTiposMembresias
            // 
            this.cmbTiposMembresias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiposMembresias.FormattingEnabled = true;
            this.cmbTiposMembresias.Location = new System.Drawing.Point(20, 100);
            this.cmbTiposMembresias.Name = "cmbTiposMembresias";
            this.cmbTiposMembresias.Size = new System.Drawing.Size(200, 23);
            this.cmbTiposMembresias.TabIndex = 1;
            this.cmbTiposMembresias.SelectedIndexChanged += new System.EventHandler(this.cmbTiposMembresias_SelectedIndexChanged);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(20, 140);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(70, 15);
            this.lblCosto.TabIndex = 2;
            this.lblCosto.Text = "Costo: $0.00";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(20, 180);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(76, 15);
            this.lblFechaInicio.TabIndex = 3;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(20, 220);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(64, 15);
            this.lblFechaFin.TabIndex = 4;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(120, 180);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaInicio.TabIndex = 5;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(120, 220);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaFin.TabIndex = 6;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(20, 260);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 30);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(140, 260);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // MembresiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 320);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.cmbTiposMembresias);
            this.Controls.Add(this.lblMembresiaInfo);
            this.Name = "MembresiaForm";
            this.Text = "Gestión de Membresía";
            this.Load += new System.EventHandler(this.MembresiaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
