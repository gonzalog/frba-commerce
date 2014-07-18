namespace FrbaCommerce.Abm_Empresa
{
    partial class BajaEmpresas
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.elecEMail = new System.Windows.Forms.TextBox();
            this.elecCUIT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buscarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.elecRS = new System.Windows.Forms.TextBox();
            this.grillaEmpresas = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEmpresas)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(583, 398);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(159, 32);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorBox
            // 
            this.errorBox.ForeColor = System.Drawing.Color.Red;
            this.errorBox.Location = new System.Drawing.Point(12, 11);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(745, 39);
            this.errorBox.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.elecEMail);
            this.groupBox1.Controls.Add(this.elecCUIT);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.elecRS);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 95);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // elecEMail
            // 
            this.elecEMail.Location = new System.Drawing.Point(554, 22);
            this.elecEMail.MaxLength = 250;
            this.elecEMail.Name = "elecEMail";
            this.elecEMail.Size = new System.Drawing.Size(176, 20);
            this.elecEMail.TabIndex = 104;
            // 
            // elecCUIT
            // 
            this.elecCUIT.Location = new System.Drawing.Point(322, 22);
            this.elecCUIT.MaxLength = 20;
            this.elecCUIT.Name = "elecCUIT";
            this.elecCUIT.Size = new System.Drawing.Size(180, 20);
            this.elecCUIT.TabIndex = 103;
            this.elecCUIT.TextChanged += new System.EventHandler(this.elecCUIT_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(509, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 100;
            this.label7.Text = "E-Mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "CUIT:";
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(9, 63);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(181, 23);
            this.buscarButton.TabIndex = 0;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(594, 63);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(136, 23);
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
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Razón social";
            // 
            // elecRS
            // 
            this.elecRS.Location = new System.Drawing.Point(80, 22);
            this.elecRS.MaxLength = 250;
            this.elecRS.Name = "elecRS";
            this.elecRS.Size = new System.Drawing.Size(195, 20);
            this.elecRS.TabIndex = 5;
            // 
            // grillaEmpresas
            // 
            this.grillaEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaEmpresas.Location = new System.Drawing.Point(12, 168);
            this.grillaEmpresas.Name = "grillaEmpresas";
            this.grillaEmpresas.RowTemplate.ReadOnly = true;
            this.grillaEmpresas.Size = new System.Drawing.Size(745, 214);
            this.grillaEmpresas.TabIndex = 28;
            this.grillaEmpresas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaEmpresas_CellContentClick);
            // 
            // BajaEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 437);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaEmpresas);
            this.Name = "BajaEmpresas";
            this.Text = "BajaEmpresas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEmpresas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox elecEMail;
        private System.Windows.Forms.TextBox elecCUIT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox elecRS;
        private System.Windows.Forms.DataGridView grillaEmpresas;
    }
}