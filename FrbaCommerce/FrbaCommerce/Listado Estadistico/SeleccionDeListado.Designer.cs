namespace FrbaCommerce.Listado_Estadistico
{
    partial class SeleccionDeListado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionDeListado));
            this.elecAnio = new System.Windows.Forms.ComboBox();
            this.elecTrimestre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prodsNoVendidos = new System.Windows.Forms.Button();
            this.masFacturacion = new System.Windows.Forms.Button();
            this.mayorCalif = new System.Windows.Forms.Button();
            this.masSinCalif = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // elecAnio
            // 
            this.elecAnio.FormattingEnabled = true;
            this.elecAnio.Location = new System.Drawing.Point(183, 13);
            this.elecAnio.Name = "elecAnio";
            this.elecAnio.Size = new System.Drawing.Size(121, 21);
            this.elecAnio.TabIndex = 0;
            this.elecAnio.Text = "2013";
            // 
            // elecTrimestre
            // 
            this.elecTrimestre.FormattingEnabled = true;
            this.elecTrimestre.Location = new System.Drawing.Point(183, 40);
            this.elecTrimestre.Name = "elecTrimestre";
            this.elecTrimestre.Size = new System.Drawing.Size(121, 21);
            this.elecTrimestre.TabIndex = 1;
            this.elecTrimestre.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione un año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione un trimestre:";
            // 
            // prodsNoVendidos
            // 
            this.prodsNoVendidos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.prodsNoVendidos.Cursor = System.Windows.Forms.Cursors.Default;
            this.prodsNoVendidos.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodsNoVendidos.Location = new System.Drawing.Point(4, 78);
            this.prodsNoVendidos.Name = "prodsNoVendidos";
            this.prodsNoVendidos.Size = new System.Drawing.Size(300, 76);
            this.prodsNoVendidos.TabIndex = 4;
            this.prodsNoVendidos.Text = "Vendedores con mayor cantidad de productos no vendidos";
            this.prodsNoVendidos.UseVisualStyleBackColor = false;
            this.prodsNoVendidos.Click += new System.EventHandler(this.prodsNoVendidos_Click);
            // 
            // masFacturacion
            // 
            this.masFacturacion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.masFacturacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.masFacturacion.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masFacturacion.Location = new System.Drawing.Point(4, 160);
            this.masFacturacion.Name = "masFacturacion";
            this.masFacturacion.Size = new System.Drawing.Size(300, 76);
            this.masFacturacion.TabIndex = 5;
            this.masFacturacion.Text = "Vendedores con mayor facturación";
            this.masFacturacion.UseVisualStyleBackColor = false;
            this.masFacturacion.Click += new System.EventHandler(this.masFacturacion_Click);
            // 
            // mayorCalif
            // 
            this.mayorCalif.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mayorCalif.Cursor = System.Windows.Forms.Cursors.Default;
            this.mayorCalif.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mayorCalif.Location = new System.Drawing.Point(4, 242);
            this.mayorCalif.Name = "mayorCalif";
            this.mayorCalif.Size = new System.Drawing.Size(300, 76);
            this.mayorCalif.TabIndex = 6;
            this.mayorCalif.Text = "Vendedores con mayores calificaciones";
            this.mayorCalif.UseVisualStyleBackColor = false;
            this.mayorCalif.Click += new System.EventHandler(this.mayorCalif_Click);
            // 
            // masSinCalif
            // 
            this.masSinCalif.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.masSinCalif.Cursor = System.Windows.Forms.Cursors.Default;
            this.masSinCalif.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masSinCalif.Location = new System.Drawing.Point(4, 324);
            this.masSinCalif.Name = "masSinCalif";
            this.masSinCalif.Size = new System.Drawing.Size(300, 76);
            this.masSinCalif.TabIndex = 7;
            this.masSinCalif.Text = "Clientes con mayor cantidad de publicaciones sin calificar";
            this.masSinCalif.UseVisualStyleBackColor = false;
            this.masSinCalif.Click += new System.EventHandler(this.masSinCalif_Click);
            // 
            // SeleccionDeListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 404);
            this.Controls.Add(this.masSinCalif);
            this.Controls.Add(this.mayorCalif);
            this.Controls.Add(this.masFacturacion);
            this.Controls.Add(this.prodsNoVendidos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elecTrimestre);
            this.Controls.Add(this.elecAnio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionDeListado";
            this.Text = "Selección de listado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox elecAnio;
        private System.Windows.Forms.ComboBox elecTrimestre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button prodsNoVendidos;
        private System.Windows.Forms.Button masFacturacion;
        private System.Windows.Forms.Button mayorCalif;
        private System.Windows.Forms.Button masSinCalif;
    }
}