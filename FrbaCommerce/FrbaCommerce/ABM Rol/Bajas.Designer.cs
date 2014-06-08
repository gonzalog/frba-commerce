namespace FrbaCommerce.ABM_Rol
{
    partial class Bajas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bajas));
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.Efectivizar = new System.Windows.Forms.Button();
            this.boxDeRoles = new System.Windows.Forms.CheckedListBox();
            this.Recordatorio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(154, 403);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 25);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorBox
            // 
            this.errorBox.ForeColor = System.Drawing.Color.Red;
            this.errorBox.Location = new System.Drawing.Point(24, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(218, 121);
            this.errorBox.TabIndex = 22;
            // 
            // Efectivizar
            // 
            this.Efectivizar.Location = new System.Drawing.Point(24, 405);
            this.Efectivizar.Name = "Efectivizar";
            this.Efectivizar.Size = new System.Drawing.Size(75, 23);
            this.Efectivizar.TabIndex = 24;
            this.Efectivizar.Text = "Efectivizar";
            this.Efectivizar.UseVisualStyleBackColor = true;
            this.Efectivizar.Click += new System.EventHandler(this.Efectivizar_Click);
            // 
            // boxDeRoles
            // 
            this.boxDeRoles.FormattingEnabled = true;
            this.boxDeRoles.Location = new System.Drawing.Point(24, 168);
            this.boxDeRoles.Name = "boxDeRoles";
            this.boxDeRoles.Size = new System.Drawing.Size(218, 214);
            this.boxDeRoles.TabIndex = 25;
            this.boxDeRoles.SelectedIndexChanged += new System.EventHandler(this.boxDeRoles_SelectedIndexChanged);
            // 
            // Recordatorio
            // 
            this.Recordatorio.Location = new System.Drawing.Point(95, 139);
            this.Recordatorio.Name = "Recordatorio";
            this.Recordatorio.Size = new System.Drawing.Size(147, 23);
            this.Recordatorio.TabIndex = 26;
            this.Recordatorio.Text = "Recordar el estado inicial";
            this.Recordatorio.UseVisualStyleBackColor = true;
            this.Recordatorio.Click += new System.EventHandler(this.Recordatorio_Click);
            // 
            // Bajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 442);
            this.Controls.Add(this.Recordatorio);
            this.Controls.Add(this.boxDeRoles);
            this.Controls.Add(this.Efectivizar);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.errorBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bajas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Button Efectivizar;
        private System.Windows.Forms.CheckedListBox boxDeRoles;
        private System.Windows.Forms.Button Recordatorio;
    }
}