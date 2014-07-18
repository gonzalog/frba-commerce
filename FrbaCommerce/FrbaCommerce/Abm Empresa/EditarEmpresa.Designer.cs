namespace FrbaCommerce.Abm_Empresa
{
    partial class EditarEmpresa
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
            this.errorBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.elecFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.elecNombreContacto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.elecCiudad = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.elecTelefono = new System.Windows.Forms.TextBox();
            this.elecEMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nuevoRol = new System.Windows.Forms.Button();
            this.elecCUIT3 = new System.Windows.Forms.TextBox();
            this.elecCUIT2 = new System.Windows.Forms.TextBox();
            this.elecCUIT1 = new System.Windows.Forms.TextBox();
            this.elecRazonSocial = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(215, 461);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(136, 40);
            this.cancelar.TabIndex = 138;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(12, 461);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(121, 40);
            this.aceptar.TabIndex = 137;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 188);
            this.groupBox1.TabIndex = 128;
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
            this.elecCP.MaxLength = 10;
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
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.errorBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.errorBox.Location = new System.Drawing.Point(12, 12);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(269, 38);
            this.errorBox.TabIndex = 120;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrbaCommerce.Properties.Resources.commerce2;
            this.pictureBox1.Location = new System.Drawing.Point(302, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 121;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // elecFechaCreacion
            // 
            this.elecFechaCreacion.Location = new System.Drawing.Point(137, 229);
            this.elecFechaCreacion.Name = "elecFechaCreacion";
            this.elecFechaCreacion.Size = new System.Drawing.Size(214, 20);
            this.elecFechaCreacion.TabIndex = 152;
            this.elecFechaCreacion.ValueChanged += new System.EventHandler(this.elecFechaCreacion_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 229);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 13);
            this.label15.TabIndex = 151;
            this.label15.Text = "Fecha de creación:";
            // 
            // elecNombreContacto
            // 
            this.elecNombreContacto.Location = new System.Drawing.Point(137, 199);
            this.elecNombreContacto.MaxLength = 250;
            this.elecNombreContacto.Name = "elecNombreContacto";
            this.elecNombreContacto.Size = new System.Drawing.Size(214, 20);
            this.elecNombreContacto.TabIndex = 150;
            this.elecNombreContacto.TextChanged += new System.EventHandler(this.elecNombreContacto_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 13);
            this.label14.TabIndex = 149;
            this.label14.Text = "Nombre de contacto:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 147;
            this.label13.Text = "CUIT:";
            // 
            // elecCiudad
            // 
            this.elecCiudad.Location = new System.Drawing.Point(137, 146);
            this.elecCiudad.MaxLength = 250;
            this.elecCiudad.Name = "elecCiudad";
            this.elecCiudad.Size = new System.Drawing.Size(214, 20);
            this.elecCiudad.TabIndex = 146;
            this.elecCiudad.TextChanged += new System.EventHandler(this.elecCiudad_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 145;
            this.label12.Text = "Ciudad:";
            // 
            // elecTelefono
            // 
            this.elecTelefono.Location = new System.Drawing.Point(137, 119);
            this.elecTelefono.MaxLength = 15;
            this.elecTelefono.Name = "elecTelefono";
            this.elecTelefono.Size = new System.Drawing.Size(214, 20);
            this.elecTelefono.TabIndex = 144;
            this.elecTelefono.TextChanged += new System.EventHandler(this.elecTelefono_TextChanged);
            // 
            // elecEMail
            // 
            this.elecEMail.Location = new System.Drawing.Point(137, 93);
            this.elecEMail.MaxLength = 250;
            this.elecEMail.Name = "elecEMail";
            this.elecEMail.Size = new System.Drawing.Size(214, 20);
            this.elecEMail.TabIndex = 143;
            this.elecEMail.TextChanged += new System.EventHandler(this.elecEMail_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 142;
            this.label8.Text = "Telefono:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 141;
            this.label7.Text = "E-Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Razón social:";
            // 
            // nuevoRol
            // 
            this.nuevoRol.Location = new System.Drawing.Point(12, 526);
            this.nuevoRol.Name = "nuevoRol";
            this.nuevoRol.Size = new System.Drawing.Size(339, 27);
            this.nuevoRol.TabIndex = 153;
            this.nuevoRol.Text = "Asignarle un nuevo rol a ";
            this.nuevoRol.UseVisualStyleBackColor = true;
            this.nuevoRol.Click += new System.EventHandler(this.nuevoRol_Click);
            // 
            // elecCUIT3
            // 
            this.elecCUIT3.Location = new System.Drawing.Point(317, 172);
            this.elecCUIT3.MaxLength = 2;
            this.elecCUIT3.Name = "elecCUIT3";
            this.elecCUIT3.Size = new System.Drawing.Size(35, 20);
            this.elecCUIT3.TabIndex = 156;
            this.elecCUIT3.TextChanged += new System.EventHandler(this.elecCUIT3_TextChanged);
            // 
            // elecCUIT2
            // 
            this.elecCUIT2.Location = new System.Drawing.Point(178, 172);
            this.elecCUIT2.MaxLength = 8;
            this.elecCUIT2.Name = "elecCUIT2";
            this.elecCUIT2.Size = new System.Drawing.Size(133, 20);
            this.elecCUIT2.TabIndex = 155;
            this.elecCUIT2.TextChanged += new System.EventHandler(this.elecCUIT2_TextChanged);
            // 
            // elecCUIT1
            // 
            this.elecCUIT1.Location = new System.Drawing.Point(138, 172);
            this.elecCUIT1.MaxLength = 2;
            this.elecCUIT1.Name = "elecCUIT1";
            this.elecCUIT1.Size = new System.Drawing.Size(34, 20);
            this.elecCUIT1.TabIndex = 154;
            this.elecCUIT1.TextChanged += new System.EventHandler(this.elecCUIT1_TextChanged);
            // 
            // elecRazonSocial
            // 
            this.elecRazonSocial.AutoSize = true;
            this.elecRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elecRazonSocial.Location = new System.Drawing.Point(134, 70);
            this.elecRazonSocial.Name = "elecRazonSocial";
            this.elecRazonSocial.Size = new System.Drawing.Size(51, 16);
            this.elecRazonSocial.TabIndex = 157;
            this.elecRazonSocial.Text = "label3";
            // 
            // EditarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 560);
            this.Controls.Add(this.elecRazonSocial);
            this.Controls.Add(this.elecCUIT3);
            this.Controls.Add(this.elecCUIT2);
            this.Controls.Add(this.elecCUIT1);
            this.Controls.Add(this.nuevoRol);
            this.Controls.Add(this.elecFechaCreacion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.elecNombreContacto);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.elecCiudad);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.elecTelefono);
            this.Controls.Add(this.elecEMail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.errorBox);
            this.Name = "EditarEmpresa";
            this.Text = "EditarEmpresa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.DateTimePicker elecFechaCreacion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox elecNombreContacto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox elecCiudad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox elecTelefono;
        private System.Windows.Forms.TextBox elecEMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button nuevoRol;
        private System.Windows.Forms.TextBox elecCUIT3;
        private System.Windows.Forms.TextBox elecCUIT2;
        private System.Windows.Forms.TextBox elecCUIT1;
        private System.Windows.Forms.Label elecRazonSocial;
    }
}