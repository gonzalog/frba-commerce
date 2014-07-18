namespace FrbaCommerce.ABM_Rol
{
    partial class CambiarFunciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarFunciones));
            this.Aceptar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.funcionesDelRol = new System.Windows.Forms.ListBox();
            this.boxParaQuitar = new System.Windows.Forms.ComboBox();
            this.boxParaAgregar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(12, 300);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 1;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(129, 300);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 2;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // funcionesDelRol
            // 
            this.funcionesDelRol.FormattingEnabled = true;
            this.funcionesDelRol.Location = new System.Drawing.Point(12, 86);
            this.funcionesDelRol.Name = "funcionesDelRol";
            this.funcionesDelRol.Size = new System.Drawing.Size(192, 95);
            this.funcionesDelRol.TabIndex = 3;
            // 
            // boxParaQuitar
            // 
            this.boxParaQuitar.FormattingEnabled = true;
            this.boxParaQuitar.Location = new System.Drawing.Point(12, 207);
            this.boxParaQuitar.Name = "boxParaQuitar";
            this.boxParaQuitar.Size = new System.Drawing.Size(192, 21);
            this.boxParaQuitar.TabIndex = 4;
            this.boxParaQuitar.SelectedIndexChanged += new System.EventHandler(this.boxParaQuitar_SelectedIndexChanged);
            // 
            // boxParaAgregar
            // 
            this.boxParaAgregar.FormattingEnabled = true;
            this.boxParaAgregar.Location = new System.Drawing.Point(12, 256);
            this.boxParaAgregar.Name = "boxParaAgregar";
            this.boxParaAgregar.Size = new System.Drawing.Size(192, 21);
            this.boxParaAgregar.TabIndex = 5;
            this.boxParaAgregar.SelectedIndexChanged += new System.EventHandler(this.boxParaAgregar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Funciones del rol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quitar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Agregar";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(12, 342);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(187, 38);
            this.errorBox.TabIndex = 43;
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(12, 31);
            this.nombre.MaxLength = 250;
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(192, 20);
            this.nombre.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Nombre:";
            // 
            // CambiarFunciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 392);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxParaAgregar);
            this.Controls.Add(this.boxParaQuitar);
            this.Controls.Add(this.funcionesDelRol);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CambiarFunciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CambiarFunciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.ListBox funcionesDelRol;
        private System.Windows.Forms.ComboBox boxParaQuitar;
        private System.Windows.Forms.ComboBox boxParaAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label4;
    }
}