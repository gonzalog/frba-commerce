namespace FrbaCommerce.Comprar_Ofertar
{
    partial class InteresadoVentaDirecta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InteresadoVentaDirecta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cantidadCompra = new System.Windows.Forms.NumericUpDown();
            this.vencimiento = new System.Windows.Forms.Label();
            this.publicDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BotonComprar = new System.Windows.Forms.Button();
            this.boxConsulta = new System.Windows.Forms.GroupBox();
            this.BotonConsultar = new System.Windows.Forms.Button();
            this.consultaText = new System.Windows.Forms.TextBox();
            this.precio = new System.Windows.Forms.Label();
            this.stock = new System.Windows.Forms.Label();
            this.descrip = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BotonCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadCompra)).BeginInit();
            this.boxConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cantidadCompra);
            this.groupBox1.Controls.Add(this.vencimiento);
            this.groupBox1.Controls.Add(this.publicDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BotonComprar);
            this.groupBox1.Controls.Add(this.boxConsulta);
            this.groupBox1.Controls.Add(this.precio);
            this.groupBox1.Controls.Add(this.stock);
            this.groupBox1.Controls.Add(this.descrip);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 195);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Publicación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(180, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cantidad:";
            // 
            // cantidadCompra
            // 
            this.cantidadCompra.Location = new System.Drawing.Point(183, 154);
            this.cantidadCompra.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantidadCompra.Name = "cantidadCompra";
            this.cantidadCompra.Size = new System.Drawing.Size(47, 20);
            this.cantidadCompra.TabIndex = 17;
            this.cantidadCompra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // vencimiento
            // 
            this.vencimiento.AutoSize = true;
            this.vencimiento.ForeColor = System.Drawing.SystemColors.MenuText;
            this.vencimiento.Location = new System.Drawing.Point(124, 115);
            this.vencimiento.Name = "vencimiento";
            this.vencimiento.Size = new System.Drawing.Size(41, 13);
            this.vencimiento.TabIndex = 16;
            this.vencimiento.Text = "label12";
            // 
            // publicDate
            // 
            this.publicDate.AutoSize = true;
            this.publicDate.ForeColor = System.Drawing.SystemColors.MenuText;
            this.publicDate.Location = new System.Drawing.Point(124, 93);
            this.publicDate.Name = "publicDate";
            this.publicDate.Size = new System.Drawing.Size(41, 13);
            this.publicDate.TabIndex = 15;
            this.publicDate.Text = "label11";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Vence:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Publicado:";
            // 
            // BotonComprar
            // 
            this.BotonComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonComprar.Location = new System.Drawing.Point(9, 139);
            this.BotonComprar.Name = "BotonComprar";
            this.BotonComprar.Size = new System.Drawing.Size(165, 35);
            this.BotonComprar.TabIndex = 4;
            this.BotonComprar.Text = "Comprar";
            this.BotonComprar.UseVisualStyleBackColor = true;
            this.BotonComprar.Click += new System.EventHandler(this.BotonComprar_Click);
            // 
            // boxConsulta
            // 
            this.boxConsulta.Controls.Add(this.BotonConsultar);
            this.boxConsulta.Controls.Add(this.consultaText);
            this.boxConsulta.Location = new System.Drawing.Point(275, 49);
            this.boxConsulta.Name = "boxConsulta";
            this.boxConsulta.Size = new System.Drawing.Size(224, 125);
            this.boxConsulta.TabIndex = 2;
            this.boxConsulta.TabStop = false;
            this.boxConsulta.Text = "Consultar";
            // 
            // BotonConsultar
            // 
            this.BotonConsultar.Location = new System.Drawing.Point(126, 98);
            this.BotonConsultar.Name = "BotonConsultar";
            this.BotonConsultar.Size = new System.Drawing.Size(88, 23);
            this.BotonConsultar.TabIndex = 1;
            this.BotonConsultar.Text = "Enviar consulta";
            this.BotonConsultar.UseVisualStyleBackColor = true;
            this.BotonConsultar.Click += new System.EventHandler(this.BotonConsultar_Click);
            // 
            // consultaText
            // 
            this.consultaText.Location = new System.Drawing.Point(9, 19);
            this.consultaText.MaxLength = 255;
            this.consultaText.Multiline = true;
            this.consultaText.Name = "consultaText";
            this.consultaText.Size = new System.Drawing.Size(205, 75);
            this.consultaText.TabIndex = 0;
            // 
            // precio
            // 
            this.precio.AutoSize = true;
            this.precio.ForeColor = System.Drawing.SystemColors.MenuText;
            this.precio.Location = new System.Drawing.Point(124, 71);
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(41, 13);
            this.precio.TabIndex = 12;
            this.precio.Text = "label12";
            // 
            // stock
            // 
            this.stock.AutoSize = true;
            this.stock.ForeColor = System.Drawing.SystemColors.MenuText;
            this.stock.Location = new System.Drawing.Point(124, 49);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(41, 13);
            this.stock.TabIndex = 11;
            this.stock.Text = "label11";
            // 
            // descrip
            // 
            this.descrip.AutoSize = true;
            this.descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descrip.ForeColor = System.Drawing.SystemColors.MenuText;
            this.descrip.Location = new System.Drawing.Point(124, 27);
            this.descrip.Name = "descrip";
            this.descrip.Size = new System.Drawing.Size(41, 13);
            this.descrip.TabIndex = 8;
            this.descrip.Text = "label8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(6, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stock:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción:";
            // 
            // BotonCancelar
            // 
            this.BotonCancelar.Location = new System.Drawing.Point(389, 223);
            this.BotonCancelar.Name = "BotonCancelar";
            this.BotonCancelar.Size = new System.Drawing.Size(128, 27);
            this.BotonCancelar.TabIndex = 3;
            this.BotonCancelar.Text = "Cancelar";
            this.BotonCancelar.UseVisualStyleBackColor = true;
            this.BotonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
            // 
            // InteresadoVentaDirecta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 262);
            this.Controls.Add(this.BotonCancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InteresadoVentaDirecta";
            this.Text = "InteresadoVentaDirecta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadCompra)).EndInit();
            this.boxConsulta.ResumeLayout(false);
            this.boxConsulta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label precio;
        private System.Windows.Forms.Label stock;
        private System.Windows.Forms.Label descrip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox boxConsulta;
        private System.Windows.Forms.TextBox consultaText;
        private System.Windows.Forms.Button BotonConsultar;
        private System.Windows.Forms.Button BotonCancelar;
        private System.Windows.Forms.Button BotonComprar;
        private System.Windows.Forms.Label vencimiento;
        private System.Windows.Forms.Label publicDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown cantidadCompra;
        private System.Windows.Forms.Label label1;
    }
}