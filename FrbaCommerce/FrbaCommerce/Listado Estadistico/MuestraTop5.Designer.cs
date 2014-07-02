namespace FrbaCommerce.Listado_Estadistico
{
    partial class MuestraTop5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MuestraTop5));
            this.grillaTopFive = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.opcionMes = new System.Windows.Forms.RadioButton();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscarMes = new System.Windows.Forms.ComboBox();
            this.buscarVisi = new System.Windows.Forms.ComboBox();
            this.titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopFive)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaTopFive
            // 
            this.grillaTopFive.AllowUserToAddRows = false;
            this.grillaTopFive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTopFive.Location = new System.Drawing.Point(12, 36);
            this.grillaTopFive.Name = "grillaTopFive";
            this.grillaTopFive.Size = new System.Drawing.Size(255, 176);
            this.grillaTopFive.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opcionMes);
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.buscarMes);
            this.groupBox1.Controls.Add(this.buscarVisi);
            this.groupBox1.Location = new System.Drawing.Point(12, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // opcionMes
            // 
            this.opcionMes.AutoSize = true;
            this.opcionMes.Location = new System.Drawing.Point(151, 33);
            this.opcionMes.Name = "opcionMes";
            this.opcionMes.Size = new System.Drawing.Size(98, 17);
            this.opcionMes.TabIndex = 4;
            this.opcionMes.TabStop = true;
            this.opcionMes.Text = "Buscar por mes";
            this.opcionMes.UseVisualStyleBackColor = true;
            this.opcionMes.CheckedChanged += new System.EventHandler(this.opcionMes_CheckedChanged);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(8, 56);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(111, 31);
            this.limpiar.TabIndex = 3;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // buscarMes
            // 
            this.buscarMes.FormattingEnabled = true;
            this.buscarMes.Location = new System.Drawing.Point(151, 53);
            this.buscarMes.Name = "buscarMes";
            this.buscarMes.Size = new System.Drawing.Size(96, 21);
            this.buscarMes.TabIndex = 2;
            this.buscarMes.Text = "1";
            this.buscarMes.SelectedIndexChanged += new System.EventHandler(this.buscarMes_SelectedIndexChanged);
            // 
            // buscarVisi
            // 
            this.buscarVisi.FormattingEnabled = true;
            this.buscarVisi.Location = new System.Drawing.Point(8, 29);
            this.buscarVisi.Name = "buscarVisi";
            this.buscarVisi.Size = new System.Drawing.Size(119, 21);
            this.buscarVisi.TabIndex = 1;
            this.buscarVisi.SelectedIndexChanged += new System.EventHandler(this.buscarVisi_SelectedIndexChanged);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(8, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(39, 14);
            this.titulo.TabIndex = 2;
            this.titulo.Text = "label1";
            // 
            // MuestraTop5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 222);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaTopFive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MuestraTop5";
            this.Text = "Listado estadístico";
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopFive)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaTopFive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.ComboBox buscarMes;
        private System.Windows.Forms.ComboBox buscarVisi;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.RadioButton opcionMes;
    }
}