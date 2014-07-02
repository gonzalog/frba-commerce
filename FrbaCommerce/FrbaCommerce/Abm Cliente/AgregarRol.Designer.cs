namespace FrbaCommerce.Abm_Cliente
{
    partial class AgregarRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarRol));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.ACEPTAR = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(299, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 21);
            this.comboBox1.TabIndex = 123;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(14, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(94, 13);
            this.label.TabIndex = 122;
            this.label.Text = "Asignarle otro rol a";
            // 
            // ACEPTAR
            // 
            this.ACEPTAR.Location = new System.Drawing.Point(396, 53);
            this.ACEPTAR.Name = "ACEPTAR";
            this.ACEPTAR.Size = new System.Drawing.Size(105, 23);
            this.ACEPTAR.TabIndex = 124;
            this.ACEPTAR.Text = "Aceptar";
            this.ACEPTAR.UseVisualStyleBackColor = true;
            this.ACEPTAR.Click += new System.EventHandler(this.ACEPTAR_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(17, 53);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(105, 23);
            this.cancelar.TabIndex = 125;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // AgregarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 84);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.ACEPTAR);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarRol";
            this.Text = "Agregar Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button ACEPTAR;
        private System.Windows.Forms.Button cancelar;
    }
}