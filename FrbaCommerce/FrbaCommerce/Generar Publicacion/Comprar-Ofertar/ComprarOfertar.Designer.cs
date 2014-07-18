namespace FrbaCommerce.Comprar_Ofertar
{
    partial class ComprarOfertar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprarOfertar));
            this.VolverButton = new System.Windows.Forms.Button();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rubroSearcher = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buscarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buscador = new System.Windows.Forms.TextBox();
            this.anterior = new System.Windows.Forms.Button();
            this.irAFinal = new System.Windows.Forms.Button();
            this.posterior = new System.Windows.Forms.Button();
            this.irAInicio = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.precio5 = new System.Windows.Forms.Label();
            this.precio4 = new System.Windows.Forms.Label();
            this.precio3 = new System.Windows.Forms.Label();
            this.precio2 = new System.Windows.Forms.Label();
            this.precio1 = new System.Windows.Forms.Label();
            this.boton1 = new System.Windows.Forms.Button();
            this.boton2 = new System.Windows.Forms.Button();
            this.boton3 = new System.Windows.Forms.Button();
            this.boton4 = new System.Windows.Forms.Button();
            this.boton5 = new System.Windows.Forms.Button();
            this.Descripcion1 = new System.Windows.Forms.Label();
            this.Descripcion4 = new System.Windows.Forms.Label();
            this.Descripcion2 = new System.Windows.Forms.Label();
            this.Descripcion3 = new System.Windows.Forms.Label();
            this.Descripcion5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numPag = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VolverButton
            // 
            this.VolverButton.Location = new System.Drawing.Point(620, 537);
            this.VolverButton.Name = "VolverButton";
            this.VolverButton.Size = new System.Drawing.Size(136, 32);
            this.VolverButton.TabIndex = 31;
            this.VolverButton.Text = "Volver";
            this.VolverButton.UseVisualStyleBackColor = true;
            this.VolverButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorBox
            // 
            this.errorBox.ForeColor = System.Drawing.Color.Red;
            this.errorBox.Location = new System.Drawing.Point(12, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(761, 39);
            this.errorBox.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rubroSearcher);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buscador);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 81);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // rubroSearcher
            // 
            this.rubroSearcher.FormattingEnabled = true;
            this.rubroSearcher.Location = new System.Drawing.Point(436, 22);
            this.rubroSearcher.Name = "rubroSearcher";
            this.rubroSearcher.Size = new System.Drawing.Size(308, 21);
            this.rubroSearcher.TabIndex = 7;
            this.rubroSearcher.SelectedIndexChanged += new System.EventHandler(this.rubroSearcher_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rubro:";
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(9, 48);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(181, 23);
            this.buscarButton.TabIndex = 0;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(566, 48);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(178, 23);
            this.limpiarButton.TabIndex = 1;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción:";
            // 
            // buscador
            // 
            this.buscador.Location = new System.Drawing.Point(78, 22);
            this.buscador.MaxLength = 250;
            this.buscador.Name = "buscador";
            this.buscador.Size = new System.Drawing.Size(279, 20);
            this.buscador.TabIndex = 5;
            // 
            // anterior
            // 
            this.anterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.anterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anterior.Location = new System.Drawing.Point(326, 488);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(55, 39);
            this.anterior.TabIndex = 33;
            this.anterior.Text = "<";
            this.anterior.UseVisualStyleBackColor = true;
            this.anterior.Click += new System.EventHandler(this.anterior_Click);
            // 
            // irAFinal
            // 
            this.irAFinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.irAFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.irAFinal.Location = new System.Drawing.Point(448, 488);
            this.irAFinal.Name = "irAFinal";
            this.irAFinal.Size = new System.Drawing.Size(55, 39);
            this.irAFinal.TabIndex = 34;
            this.irAFinal.Text = ">>";
            this.irAFinal.UseVisualStyleBackColor = true;
            this.irAFinal.Click += new System.EventHandler(this.irAFinal_Click);
            // 
            // posterior
            // 
            this.posterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.posterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posterior.Location = new System.Drawing.Point(387, 488);
            this.posterior.Name = "posterior";
            this.posterior.Size = new System.Drawing.Size(55, 39);
            this.posterior.TabIndex = 35;
            this.posterior.Text = ">";
            this.posterior.UseVisualStyleBackColor = true;
            this.posterior.Click += new System.EventHandler(this.posterior_Click);
            // 
            // irAInicio
            // 
            this.irAInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.irAInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.irAInicio.Location = new System.Drawing.Point(265, 488);
            this.irAInicio.Name = "irAInicio";
            this.irAInicio.Size = new System.Drawing.Size(55, 39);
            this.irAInicio.TabIndex = 36;
            this.irAInicio.Text = "<<";
            this.irAInicio.UseVisualStyleBackColor = true;
            this.irAInicio.Click += new System.EventHandler(this.irAInicio_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.54271F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.71748F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.60841F));
            this.tableLayoutPanel1.Controls.Add(this.precio5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.precio4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.precio3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.precio2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.precio1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.boton1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.boton2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.boton3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.boton4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.boton5, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Descripcion1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Descripcion4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Descripcion2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Descripcion3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Descripcion5, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 181);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 281);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // precio5
            // 
            this.precio5.AutoSize = true;
            this.precio5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio5.Location = new System.Drawing.Point(517, 224);
            this.precio5.Name = "precio5";
            this.precio5.Size = new System.Drawing.Size(0, 18);
            this.precio5.TabIndex = 23;
            // 
            // precio4
            // 
            this.precio4.AutoSize = true;
            this.precio4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio4.Location = new System.Drawing.Point(517, 168);
            this.precio4.Name = "precio4";
            this.precio4.Size = new System.Drawing.Size(0, 18);
            this.precio4.TabIndex = 22;
            // 
            // precio3
            // 
            this.precio3.AutoSize = true;
            this.precio3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio3.Location = new System.Drawing.Point(517, 112);
            this.precio3.Name = "precio3";
            this.precio3.Size = new System.Drawing.Size(0, 18);
            this.precio3.TabIndex = 21;
            // 
            // precio2
            // 
            this.precio2.AutoSize = true;
            this.precio2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio2.Location = new System.Drawing.Point(517, 56);
            this.precio2.Name = "precio2";
            this.precio2.Size = new System.Drawing.Size(0, 18);
            this.precio2.TabIndex = 20;
            // 
            // precio1
            // 
            this.precio1.AutoSize = true;
            this.precio1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio1.Location = new System.Drawing.Point(517, 0);
            this.precio1.Name = "precio1";
            this.precio1.Size = new System.Drawing.Size(0, 18);
            this.precio1.TabIndex = 19;
            // 
            // boton1
            // 
            this.boton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton1.Location = new System.Drawing.Point(629, 3);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(129, 50);
            this.boton1.TabIndex = 9;
            this.boton1.Text = "Me interesa";
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // boton2
            // 
            this.boton2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boton2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton2.Location = new System.Drawing.Point(629, 59);
            this.boton2.Name = "boton2";
            this.boton2.Size = new System.Drawing.Size(129, 50);
            this.boton2.TabIndex = 12;
            this.boton2.Text = "Me interesa";
            this.boton2.UseVisualStyleBackColor = false;
            this.boton2.Click += new System.EventHandler(this.boton2_Click);
            // 
            // boton3
            // 
            this.boton3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boton3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton3.Location = new System.Drawing.Point(629, 115);
            this.boton3.Name = "boton3";
            this.boton3.Size = new System.Drawing.Size(129, 50);
            this.boton3.TabIndex = 10;
            this.boton3.Text = "Me interesa";
            this.boton3.UseVisualStyleBackColor = false;
            this.boton3.Click += new System.EventHandler(this.boton3_Click);
            // 
            // boton4
            // 
            this.boton4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boton4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton4.Location = new System.Drawing.Point(629, 171);
            this.boton4.Name = "boton4";
            this.boton4.Size = new System.Drawing.Size(129, 50);
            this.boton4.TabIndex = 11;
            this.boton4.Text = "Me interesa";
            this.boton4.UseVisualStyleBackColor = false;
            this.boton4.Click += new System.EventHandler(this.boton4_Click);
            // 
            // boton5
            // 
            this.boton5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.boton5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton5.Location = new System.Drawing.Point(629, 227);
            this.boton5.Name = "boton5";
            this.boton5.Size = new System.Drawing.Size(129, 50);
            this.boton5.TabIndex = 13;
            this.boton5.Text = "Me interesa";
            this.boton5.UseVisualStyleBackColor = false;
            this.boton5.Click += new System.EventHandler(this.boton5_Click);
            // 
            // Descripcion1
            // 
            this.Descripcion1.AutoSize = true;
            this.Descripcion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion1.Location = new System.Drawing.Point(3, 0);
            this.Descripcion1.Name = "Descripcion1";
            this.Descripcion1.Size = new System.Drawing.Size(0, 18);
            this.Descripcion1.TabIndex = 14;
            // 
            // Descripcion4
            // 
            this.Descripcion4.AutoSize = true;
            this.Descripcion4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion4.Location = new System.Drawing.Point(3, 168);
            this.Descripcion4.Name = "Descripcion4";
            this.Descripcion4.Size = new System.Drawing.Size(0, 18);
            this.Descripcion4.TabIndex = 17;
            // 
            // Descripcion2
            // 
            this.Descripcion2.AutoSize = true;
            this.Descripcion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion2.Location = new System.Drawing.Point(3, 56);
            this.Descripcion2.Name = "Descripcion2";
            this.Descripcion2.Size = new System.Drawing.Size(0, 18);
            this.Descripcion2.TabIndex = 15;
            // 
            // Descripcion3
            // 
            this.Descripcion3.AutoSize = true;
            this.Descripcion3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion3.Location = new System.Drawing.Point(3, 112);
            this.Descripcion3.Name = "Descripcion3";
            this.Descripcion3.Size = new System.Drawing.Size(0, 18);
            this.Descripcion3.TabIndex = 16;
            // 
            // Descripcion5
            // 
            this.Descripcion5.AutoSize = true;
            this.Descripcion5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion5.Location = new System.Drawing.Point(3, 224);
            this.Descripcion5.Name = "Descripcion5";
            this.Descripcion5.Size = new System.Drawing.Size(0, 18);
            this.Descripcion5.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(528, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 39;
            this.label4.Text = "Precio";
            // 
            // numPag
            // 
            this.numPag.AutoSize = true;
            this.numPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPag.Location = new System.Drawing.Point(364, 543);
            this.numPag.Name = "numPag";
            this.numPag.Size = new System.Drawing.Size(48, 18);
            this.numPag.TabIndex = 40;
            this.numPag.Text = "0 de 0";
            // 
            // ComprarOfertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 577);
            this.Controls.Add(this.numPag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.irAInicio);
            this.Controls.Add(this.posterior);
            this.Controls.Add(this.irAFinal);
            this.Controls.Add(this.anterior);
            this.Controls.Add(this.VolverButton);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComprarOfertar";
            this.Text = "Comprar-Ofertar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VolverButton;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox buscador;
        private System.Windows.Forms.ComboBox rubroSearcher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button anterior;
        private System.Windows.Forms.Button irAFinal;
        private System.Windows.Forms.Button posterior;
        private System.Windows.Forms.Button irAInicio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button boton1;
        private System.Windows.Forms.Button boton2;
        private System.Windows.Forms.Button boton3;
        private System.Windows.Forms.Button boton4;
        private System.Windows.Forms.Button boton5;
        private System.Windows.Forms.Label precio5;
        private System.Windows.Forms.Label precio4;
        private System.Windows.Forms.Label precio3;
        private System.Windows.Forms.Label precio2;
        private System.Windows.Forms.Label precio1;
        private System.Windows.Forms.Label Descripcion1;
        private System.Windows.Forms.Label Descripcion4;
        private System.Windows.Forms.Label Descripcion2;
        private System.Windows.Forms.Label Descripcion3;
        private System.Windows.Forms.Label Descripcion5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label numPag;
    }
}