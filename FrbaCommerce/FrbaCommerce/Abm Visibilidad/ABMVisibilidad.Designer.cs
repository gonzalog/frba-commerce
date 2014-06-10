namespace FrbaCommerce.Abm_Visibilidad
{
    partial class ABMVisibilidad
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.Modificar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrbaCommerce.Properties.Resources.commerce2;
            this.pictureBox1.Location = new System.Drawing.Point(216, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 142);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(269, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "Bajas";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(22, 225);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(269, 23);
            this.cancelButton.TabIndex = 26;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Modificar
            // 
            this.Modificar.Location = new System.Drawing.Point(22, 113);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(269, 23);
            this.Modificar.TabIndex = 25;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = true;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Dar de alta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "ABM de Visibilidad";
            // 
            // ABMVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 262);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "ABMVisibilidad";
            this.Text = "ABM Visibilidad";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}