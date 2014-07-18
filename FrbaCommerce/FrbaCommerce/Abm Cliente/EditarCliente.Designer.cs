namespace FrbaCommerce.Abm_Cliente
{
    partial class EditarCliente
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
            this.cancelar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.elecFechaNac = new System.Windows.Forms.DateTimePicker();
            this.elecTelefono = new System.Windows.Forms.TextBox();
            this.elecEMail = new System.Windows.Forms.TextBox();
            this.elecNroDoc = new System.Windows.Forms.TextBox();
            this.elecTipoDoc = new System.Windows.Forms.DomainUpDown();
            this.elecApe = new System.Windows.Forms.TextBox();
            this.elecNombre = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.elecPiso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.elecLocalidad = new System.Windows.Forms.TextBox();
            this.elecDepartamento = new System.Windows.Forms.TextBox();
            this.elecCP = new System.Windows.Forms.TextBox();
            this.elecNumero = new System.Windows.Forms.TextBox();
            this.elecCalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tipoDoc = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.Label();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.nuevoRol = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(209, 435);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(136, 40);
            this.cancelar.TabIndex = 119;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(6, 435);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(121, 40);
            this.aceptar.TabIndex = 118;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // elecFechaNac
            // 
            this.elecFechaNac.Location = new System.Drawing.Point(137, 207);
            this.elecFechaNac.Name = "elecFechaNac";
            this.elecFechaNac.Size = new System.Drawing.Size(214, 20);
            this.elecFechaNac.TabIndex = 117;
            this.elecFechaNac.ValueChanged += new System.EventHandler(this.elecFechaNac_ValueChanged);
            // 
            // elecTelefono
            // 
            this.elecTelefono.Location = new System.Drawing.Point(137, 181);
            this.elecTelefono.MaxLength = 15;
            this.elecTelefono.Name = "elecTelefono";
            this.elecTelefono.Size = new System.Drawing.Size(214, 20);
            this.elecTelefono.TabIndex = 116;
            this.elecTelefono.TextChanged += new System.EventHandler(this.elecTelefono_TextChanged);
            // 
            // elecEMail
            // 
            this.elecEMail.Location = new System.Drawing.Point(137, 155);
            this.elecEMail.MaxLength = 250;
            this.elecEMail.Name = "elecEMail";
            this.elecEMail.Size = new System.Drawing.Size(214, 20);
            this.elecEMail.TabIndex = 115;
            this.elecEMail.TextChanged += new System.EventHandler(this.elecEMail_TextChanged);
            // 
            // elecNroDoc
            // 
            this.elecNroDoc.Location = new System.Drawing.Point(137, 130);
            this.elecNroDoc.MaxLength = 20;
            this.elecNroDoc.Name = "elecNroDoc";
            this.elecNroDoc.Size = new System.Drawing.Size(214, 20);
            this.elecNroDoc.TabIndex = 114;
            this.elecNroDoc.TextChanged += new System.EventHandler(this.elecNroDoc_TextChanged);
            // 
            // elecTipoDoc
            // 
            this.elecTipoDoc.Location = new System.Drawing.Point(137, 106);
            this.elecTipoDoc.Name = "elecTipoDoc";
            this.elecTipoDoc.Size = new System.Drawing.Size(214, 20);
            this.elecTipoDoc.TabIndex = 113;
            this.elecTipoDoc.Text = "Seleccione un tipo de documento";
            this.elecTipoDoc.SelectedItemChanged += new System.EventHandler(this.elecTipoDoc_SelectedItemChanged);
            // 
            // elecApe
            // 
            this.elecApe.Location = new System.Drawing.Point(137, 82);
            this.elecApe.MaxLength = 250;
            this.elecApe.Name = "elecApe";
            this.elecApe.Size = new System.Drawing.Size(214, 20);
            this.elecApe.TabIndex = 112;
            this.elecApe.TextChanged += new System.EventHandler(this.elecApe_TextChanged);
            // 
            // elecNombre
            // 
            this.elecNombre.Location = new System.Drawing.Point(137, 56);
            this.elecNombre.MaxLength = 250;
            this.elecNombre.Name = "elecNombre";
            this.elecNombre.Size = new System.Drawing.Size(214, 20);
            this.elecNombre.TabIndex = 111;
            this.elecNombre.TextChanged += new System.EventHandler(this.elecNombre_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 110;
            this.label12.Text = "Fecha de nacimiento:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.elecPiso);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.elecLocalidad);
            this.groupBox1.Controls.Add(this.elecDepartamento);
            this.groupBox1.Controls.Add(this.elecCP);
            this.groupBox1.Controls.Add(this.elecNumero);
            this.groupBox1.Controls.Add(this.elecCalle);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 188);
            this.groupBox1.TabIndex = 109;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dirección";
            // 
            // elecPiso
            // 
            this.elecPiso.Location = new System.Drawing.Point(125, 75);
            this.elecPiso.MaxLength = 2;
            this.elecPiso.Name = "elecPiso";
            this.elecPiso.Size = new System.Drawing.Size(208, 20);
            this.elecPiso.TabIndex = 73;
            this.elecPiso.TextChanged += new System.EventHandler(this.elecPiso_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "Piso:";
            // 
            // elecLocalidad
            // 
            this.elecLocalidad.Location = new System.Drawing.Point(125, 131);
            this.elecLocalidad.MaxLength = 250;
            this.elecLocalidad.Name = "elecLocalidad";
            this.elecLocalidad.Size = new System.Drawing.Size(208, 20);
            this.elecLocalidad.TabIndex = 71;
            this.elecLocalidad.TextChanged += new System.EventHandler(this.elecLocalidad_TextChanged);
            // 
            // elecDepartamento
            // 
            this.elecDepartamento.Location = new System.Drawing.Point(125, 103);
            this.elecDepartamento.MaxLength = 1;
            this.elecDepartamento.Name = "elecDepartamento";
            this.elecDepartamento.Size = new System.Drawing.Size(208, 20);
            this.elecDepartamento.TabIndex = 70;
            this.elecDepartamento.TextChanged += new System.EventHandler(this.elecDepartamento_TextChanged);
            // 
            // elecCP
            // 
            this.elecCP.Location = new System.Drawing.Point(125, 157);
            this.elecCP.MaxLength = 6;
            this.elecCP.Name = "elecCP";
            this.elecCP.Size = new System.Drawing.Size(208, 20);
            this.elecCP.TabIndex = 77;
            this.elecCP.TextChanged += new System.EventHandler(this.elecCP_TextChanged);
            // 
            // elecNumero
            // 
            this.elecNumero.Location = new System.Drawing.Point(125, 49);
            this.elecNumero.MaxLength = 5;
            this.elecNumero.Name = "elecNumero";
            this.elecNumero.Size = new System.Drawing.Size(208, 20);
            this.elecNumero.TabIndex = 69;
            this.elecNumero.TextChanged += new System.EventHandler(this.elecNumero_TextChanged);
            // 
            // elecCalle
            // 
            this.elecCalle.Location = new System.Drawing.Point(125, 23);
            this.elecCalle.MaxLength = 250;
            this.elecCalle.Name = "elecCalle";
            this.elecCalle.Size = new System.Drawing.Size(208, 20);
            this.elecCalle.TabIndex = 68;
            this.elecCalle.TextChanged += new System.EventHandler(this.elecCalle_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "Calle:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Localidad:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "Número:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Departamento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "Código postal:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "Telefono:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 107;
            this.label7.Text = "E-Mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "Numero de documento:";
            // 
            // tipoDoc
            // 
            this.tipoDoc.AutoSize = true;
            this.tipoDoc.Location = new System.Drawing.Point(9, 108);
            this.tipoDoc.Name = "tipoDoc";
            this.tipoDoc.Size = new System.Drawing.Size(102, 13);
            this.tipoDoc.TabIndex = 105;
            this.tipoDoc.Text = "Tipo de documento:";
            // 
            // apellido
            // 
            this.apellido.AutoSize = true;
            this.apellido.Location = new System.Drawing.Point(9, 85);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(47, 13);
            this.apellido.TabIndex = 104;
            this.apellido.Text = "Apellido:";
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Location = new System.Drawing.Point(9, 60);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(47, 13);
            this.nombre.TabIndex = 103;
            this.nombre.Text = "Nombre:";
            // 
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.errorBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.errorBox.Location = new System.Drawing.Point(12, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(269, 38);
            this.errorBox.TabIndex = 101;
            // 
            // nuevoRol
            // 
            this.nuevoRol.Location = new System.Drawing.Point(6, 494);
            this.nuevoRol.Name = "nuevoRol";
            this.nuevoRol.Size = new System.Drawing.Size(339, 27);
            this.nuevoRol.TabIndex = 120;
            this.nuevoRol.Text = "Asignarle un nuevo rol a ";
            this.nuevoRol.UseVisualStyleBackColor = true;
            this.nuevoRol.Click += new System.EventHandler(this.nuevoRol_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrbaCommerce.Properties.Resources.commerce2;
            this.pictureBox1.Location = new System.Drawing.Point(302, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // EditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 537);
            this.Controls.Add(this.nuevoRol);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.elecFechaNac);
            this.Controls.Add(this.elecTelefono);
            this.Controls.Add(this.elecEMail);
            this.Controls.Add(this.elecNroDoc);
            this.Controls.Add(this.elecTipoDoc);
            this.Controls.Add(this.elecApe);
            this.Controls.Add(this.elecNombre);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tipoDoc);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.errorBox);
            this.Name = "EditarCliente";
            this.Text = "EditarCliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.DateTimePicker elecFechaNac;
        private System.Windows.Forms.TextBox elecTelefono;
        private System.Windows.Forms.TextBox elecEMail;
        private System.Windows.Forms.TextBox elecNroDoc;
        private System.Windows.Forms.DomainUpDown elecTipoDoc;
        private System.Windows.Forms.TextBox elecApe;
        private System.Windows.Forms.TextBox elecNombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox elecPiso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox elecLocalidad;
        private System.Windows.Forms.TextBox elecDepartamento;
        private System.Windows.Forms.TextBox elecCP;
        private System.Windows.Forms.TextBox elecNumero;
        private System.Windows.Forms.TextBox elecCalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tipoDoc;
        private System.Windows.Forms.Label apellido;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Button nuevoRol;
    }
}