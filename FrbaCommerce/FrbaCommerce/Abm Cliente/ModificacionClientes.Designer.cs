namespace FrbaCommerce.Abm_Cliente
{
    partial class ModificacionClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificacionClientes));
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxTipoDoc = new System.Windows.Forms.ComboBox();
            this.elecEMail = new System.Windows.Forms.TextBox();
            this.elecNroDoc = new System.Windows.Forms.TextBox();
            this.elecApe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tipoDoc = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.Label();
            this.buscarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.grillaClientes = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(828, 483);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(159, 32);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorBox
            // 
            this.errorBox.ForeColor = System.Drawing.Color.Red;
            this.errorBox.Location = new System.Drawing.Point(17, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(970, 39);
            this.errorBox.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxTipoDoc);
            this.groupBox1.Controls.Add(this.elecEMail);
            this.groupBox1.Controls.Add(this.elecNroDoc);
            this.groupBox1.Controls.Add(this.elecApe);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tipoDoc);
            this.groupBox1.Controls.Add(this.apellido);
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nombreBox);
            this.groupBox1.Location = new System.Drawing.Point(17, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(970, 155);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // boxTipoDoc
            // 
            this.boxTipoDoc.FormattingEnabled = true;
            this.boxTipoDoc.Location = new System.Drawing.Point(434, 22);
            this.boxTipoDoc.Name = "boxTipoDoc";
            this.boxTipoDoc.Size = new System.Drawing.Size(180, 21);
            this.boxTipoDoc.TabIndex = 105;
            // 
            // elecEMail
            // 
            this.elecEMail.Location = new System.Drawing.Point(693, 23);
            this.elecEMail.Name = "elecEMail";
            this.elecEMail.Size = new System.Drawing.Size(259, 20);
            this.elecEMail.TabIndex = 104;
            // 
            // elecNroDoc
            // 
            this.elecNroDoc.Location = new System.Drawing.Point(434, 48);
            this.elecNroDoc.Name = "elecNroDoc";
            this.elecNroDoc.Size = new System.Drawing.Size(180, 20);
            this.elecNroDoc.TabIndex = 103;
            this.elecNroDoc.TextChanged += new System.EventHandler(this.elecNroDoc_TextChanged);
            // 
            // elecApe
            // 
            this.elecApe.Location = new System.Drawing.Point(59, 48);
            this.elecApe.Name = "elecApe";
            this.elecApe.Size = new System.Drawing.Size(224, 20);
            this.elecApe.TabIndex = 101;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 100;
            this.label7.Text = "E-Mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Numero de documento:";
            // 
            // tipoDoc
            // 
            this.tipoDoc.AutoSize = true;
            this.tipoDoc.Location = new System.Drawing.Point(306, 25);
            this.tipoDoc.Name = "tipoDoc";
            this.tipoDoc.Size = new System.Drawing.Size(102, 13);
            this.tipoDoc.TabIndex = 98;
            this.tipoDoc.Text = "Tipo de documento:";
            // 
            // apellido
            // 
            this.apellido.AutoSize = true;
            this.apellido.Location = new System.Drawing.Point(5, 51);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(47, 13);
            this.apellido.TabIndex = 97;
            this.apellido.Text = "Apellido:";
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(9, 115);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(181, 23);
            this.buscarButton.TabIndex = 0;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(816, 115);
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
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre:";
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(59, 22);
            this.nombreBox.MaxLength = 255;
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(224, 20);
            this.nombreBox.TabIndex = 5;
            // 
            // grillaClientes
            // 
            this.grillaClientes.AllowUserToAddRows = false;
            this.grillaClientes.AllowUserToDeleteRows = false;
            this.grillaClientes.AllowUserToResizeRows = false;
            this.grillaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaClientes.Location = new System.Drawing.Point(17, 235);
            this.grillaClientes.Name = "grillaClientes";
            this.grillaClientes.RowTemplate.ReadOnly = true;
            this.grillaClientes.Size = new System.Drawing.Size(970, 214);
            this.grillaClientes.TabIndex = 20;
            this.grillaClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaClientes_CellContentClick);
            // 
            // ModificacionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 527);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificacionClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificacion Clientes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaClientes)).EndInit();
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
        private System.Windows.Forms.DataGridView grillaClientes;
        private System.Windows.Forms.TextBox elecEMail;
        private System.Windows.Forms.TextBox elecNroDoc;
        private System.Windows.Forms.TextBox elecApe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tipoDoc;
        private System.Windows.Forms.Label apellido;
        private System.Windows.Forms.ComboBox boxTipoDoc;
    }
}