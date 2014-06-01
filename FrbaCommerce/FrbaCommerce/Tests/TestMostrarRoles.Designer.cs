namespace FrbaCommerce.Tests
{
    partial class TestMostrarRoles
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.rol = new System.Windows.Forms.ColumnHeader();
            this.habilitado = new System.Windows.Forms.ColumnHeader();
            this.vistaDeRoles = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vistaDeRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rol,
            this.habilitado});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(284, 262);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // rol
            // 
            this.rol.Text = "rolNombre";
            // 
            // habilitado
            // 
            this.habilitado.Text = "habilitado";
            // 
            // vistaDeRoles
            // 
            this.vistaDeRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vistaDeRoles.Location = new System.Drawing.Point(22, 24);
            this.vistaDeRoles.Name = "vistaDeRoles";
            this.vistaDeRoles.Size = new System.Drawing.Size(240, 150);
            this.vistaDeRoles.TabIndex = 1;
            //this.vistaDeRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vistaDeRoles_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestMostrarRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vistaDeRoles);
            this.Controls.Add(this.listView1);
            this.Name = "TestMostrarRoles";
            this.Text = "TestMostrarRoles";
            ((System.ComponentModel.ISupportInitialize)(this.vistaDeRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader rol;
        private System.Windows.Forms.ColumnHeader habilitado;
        private System.Windows.Forms.DataGridView vistaDeRoles;
        private System.Windows.Forms.Button button1;

    }
}