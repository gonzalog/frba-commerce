namespace FrbaCommerce.Historial_Cliente
{
    partial class Historial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Historial));
            this.compras = new System.Windows.Forms.Button();
            this.ofertas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compras
            // 
            this.compras.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compras.Location = new System.Drawing.Point(21, 12);
            this.compras.Name = "compras";
            this.compras.Size = new System.Drawing.Size(214, 60);
            this.compras.TabIndex = 0;
            this.compras.Text = "Ver historial de compras";
            this.compras.UseVisualStyleBackColor = true;
            this.compras.Click += new System.EventHandler(this.compras_Click);
            // 
            // ofertas
            // 
            this.ofertas.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ofertas.Location = new System.Drawing.Point(21, 78);
            this.ofertas.Name = "ofertas";
            this.ofertas.Size = new System.Drawing.Size(214, 60);
            this.ofertas.TabIndex = 2;
            this.ofertas.Text = "Ver historial de ofertas";
            this.ofertas.UseVisualStyleBackColor = true;
            this.ofertas.Click += new System.EventHandler(this.ofertas_Click);
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 154);
            this.Controls.Add(this.ofertas);
            this.Controls.Add(this.compras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Historial";
            this.Text = "Historial";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button compras;
        private System.Windows.Forms.Button ofertas;
    }
}