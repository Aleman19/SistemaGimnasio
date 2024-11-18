﻿namespace SistemaGimnasio
{
    partial class AgregarEditarEntrenadorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEspecialidades;
        private System.Windows.Forms.TextBox txtHorario;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEspecialidades = new System.Windows.Forms.TextBox();
            this.txtHorario = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // Nombre del entrenador
            this.txtNombre.Location = new System.Drawing.Point(12, 12);
            this.txtNombre.Size = new System.Drawing.Size(260, 23);
            this.txtNombre.PlaceholderText = "Nombre del entrenador";

            // Especialidades del entrenador
            this.txtEspecialidades.Location = new System.Drawing.Point(12, 41);
            this.txtEspecialidades.Size = new System.Drawing.Size(260, 23);
            this.txtEspecialidades.PlaceholderText = "Especialidades (separadas por coma)";

            // Horario del entrenador
            this.txtHorario.Location = new System.Drawing.Point(12, 70);
            this.txtHorario.Size = new System.Drawing.Size(260, 23);
            this.txtHorario.PlaceholderText = "Horario";

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
            this.Controls.Add(this.txtEspecialidades);
            this.Controls.Add(this.txtHorario);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar/Editar Entrenador";
            this.Load += new System.EventHandler(this.AgregarEditarEntrenadorForm_Load);
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