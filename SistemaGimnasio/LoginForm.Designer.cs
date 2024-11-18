namespace SistemaGimnasio
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

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
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnLogin = new Button();
            btnSalir = new Button();
            lblUsuario = new Label();
            lblContraseña = new Label();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(140, 58);
            txtUsuario.Margin = new Padding(4, 3, 4, 3);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(233, 23);
            txtUsuario.TabIndex = 0;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(140, 115);
            txtContraseña.Margin = new Padding(4, 3, 4, 3);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(233, 23);
            txtContraseña.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(140, 173);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(88, 27);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(286, 173);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 27);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(58, 61);
            lblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(58, 119);
            lblContraseña.Margin = new Padding(4, 0, 4, 0);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(70, 15);
            lblContraseña.TabIndex = 5;
            lblContraseña.Text = "Contraseña:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 288);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(btnSalir);
            Controls.Add(btnLogin);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginForm";
            Text = "Inicio de Sesión";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
    }
}