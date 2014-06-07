namespace FrbaCommerce.Registro_de_Usuario
{
    partial class OpcionTipoRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpcionTipoRegistro));
            this.nuevoCliente = new System.Windows.Forms.Button();
            this.nuevaEmpresa = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nuevoCliente
            // 
            this.nuevoCliente.Location = new System.Drawing.Point(21, 12);
            this.nuevoCliente.Name = "nuevoCliente";
            this.nuevoCliente.Size = new System.Drawing.Size(144, 68);
            this.nuevoCliente.TabIndex = 0;
            this.nuevoCliente.Text = "Registrar nuevo cliente";
            this.nuevoCliente.UseVisualStyleBackColor = true;
            this.nuevoCliente.Click += new System.EventHandler(this.nuevoCliente_Click);
            // 
            // nuevaEmpresa
            // 
            this.nuevaEmpresa.Location = new System.Drawing.Point(240, 12);
            this.nuevaEmpresa.Name = "nuevaEmpresa";
            this.nuevaEmpresa.Size = new System.Drawing.Size(144, 68);
            this.nuevaEmpresa.TabIndex = 1;
            this.nuevaEmpresa.Text = "Registrar nueva empresa";
            this.nuevaEmpresa.UseVisualStyleBackColor = true;
            this.nuevaEmpresa.Click += new System.EventHandler(this.nuevaEmpresa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrbaCommerce.Properties.Resources.commerce2;
            this.pictureBox1.Location = new System.Drawing.Point(171, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(159, 107);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(90, 23);
            this.volver.TabIndex = 3;
            this.volver.Text = "Cancelar";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // OpcionTipoRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(407, 142);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nuevaEmpresa);
            this.Controls.Add(this.nuevoCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpcionTipoRegistro";
            this.Text = "Selección del tipo de usuario";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nuevoCliente;
        private System.Windows.Forms.Button nuevaEmpresa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button volver;
    }
}