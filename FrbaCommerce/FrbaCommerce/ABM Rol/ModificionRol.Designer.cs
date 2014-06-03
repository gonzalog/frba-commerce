namespace FrbaCommerce.ABM_Rol
{
    partial class ModificionRol
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
            this.buscarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.grillaRoles = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(256, 371);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 25);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // errorBox
            // 
            this.errorBox.ForeColor = System.Drawing.Color.Red;
            this.errorBox.Location = new System.Drawing.Point(12, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(450, 39);
            this.errorBox.TabIndex = 18;
            this.errorBox.TextChanged += new System.EventHandler(this.errorBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nombreBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(9, 71);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(181, 23);
            this.buscarButton.TabIndex = 0;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click_1);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(244, 71);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(200, 23);
            this.limpiarButton.TabIndex = 1;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre Rol:";
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(78, 29);
            this.nombreBox.MaxLength = 255;
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(100, 20);
            this.nombreBox.TabIndex = 5;
            // 
            // grillaRoles
            // 
            this.grillaRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaRoles.Location = new System.Drawing.Point(12, 190);
            this.grillaRoles.Name = "grillaRoles";
            this.grillaRoles.RowTemplate.ReadOnly = true;
            this.grillaRoles.Size = new System.Drawing.Size(451, 168);
            this.grillaRoles.TabIndex = 16;
            this.grillaRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaRoles_CellContentClick);
            // 
            // ModificionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 408);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaRoles);
            this.Name = "ModificionRol";
            this.Text = "ListaRoles";
            this.Load += new System.EventHandler(this.ModificionRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.DataGridView grillaRoles;

    }
}