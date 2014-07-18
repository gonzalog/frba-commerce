namespace FrbaCommerce.Abm_Empresa
{
    partial class AltaEmpresa
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.cancelar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.elecFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.elecNombreContacto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.elecCUIT1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.elecCiudad = new System.Windows.Forms.TextBox();
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
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.elecTelefono = new System.Windows.Forms.TextBox();
            this.elecEMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.elecRazonSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.elecCUIT2 = new System.Windows.Forms.TextBox();
            this.elecCUIT3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrbaCommerce.Properties.Resources.commerce2;
            this.pictureBox1.Location = new System.Drawing.Point(302, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            this.errorBox.TabIndex = 84;
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(212, 461);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(136, 40);
            this.cancelar.TabIndex = 123;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(9, 461);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(121, 40);
            this.aceptar.TabIndex = 122;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // elecFechaCreacion
            // 
            this.elecFechaCreacion.Location = new System.Drawing.Point(137, 226);
            this.elecFechaCreacion.Name = "elecFechaCreacion";
            this.elecFechaCreacion.Size = new System.Drawing.Size(214, 20);
            this.elecFechaCreacion.TabIndex = 121;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 226);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 13);
            this.label15.TabIndex = 120;
            this.label15.Text = "Fecha de creación:";
            // 
            // elecNombreContacto
            // 
            this.elecNombreContacto.Location = new System.Drawing.Point(137, 196);
            this.elecNombreContacto.MaxLength = 255;
            this.elecNombreContacto.Name = "elecNombreContacto";
            this.elecNombreContacto.Size = new System.Drawing.Size(214, 20);
            this.elecNombreContacto.TabIndex = 119;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 13);
            this.label14.TabIndex = 118;
            this.label14.Text = "Nombre de contacto:";
            // 
            // elecCUIT1
            // 
            this.elecCUIT1.Location = new System.Drawing.Point(137, 169);
            this.elecCUIT1.MaxLength = 2;
            this.elecCUIT1.Name = "elecCUIT1";
            this.elecCUIT1.Size = new System.Drawing.Size(34, 20);
            this.elecCUIT1.TabIndex = 117;
            this.elecCUIT1.TextChanged += new System.EventHandler(this.elecCUIT_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 116;
            this.label13.Text = "CUIT:";
            // 
            // elecCiudad
            // 
            this.elecCiudad.Location = new System.Drawing.Point(137, 143);
            this.elecCiudad.MaxLength = 255;
            this.elecCiudad.Name = "elecCiudad";
            this.elecCiudad.Size = new System.Drawing.Size(214, 20);
            this.elecCiudad.TabIndex = 115;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 114;
            this.label12.Text = "Ciudad:";
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
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 188);
            this.groupBox1.TabIndex = 113;
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
            this.elecLocalidad.MaxLength = 255;
            this.elecLocalidad.Name = "elecLocalidad";
            this.elecLocalidad.Size = new System.Drawing.Size(208, 20);
            this.elecLocalidad.TabIndex = 71;
            // 
            // elecDepartamento
            // 
            this.elecDepartamento.Location = new System.Drawing.Point(125, 103);
            this.elecDepartamento.MaxLength = 1;
            this.elecDepartamento.Name = "elecDepartamento";
            this.elecDepartamento.Size = new System.Drawing.Size(208, 20);
            this.elecDepartamento.TabIndex = 70;
            // 
            // elecCP
            // 
            this.elecCP.Location = new System.Drawing.Point(125, 157);
            this.elecCP.MaxLength = 10;
            this.elecCP.Name = "elecCP";
            this.elecCP.Size = new System.Drawing.Size(208, 20);
            this.elecCP.TabIndex = 77;
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
            this.elecCalle.MaxLength = 255;
            this.elecCalle.Name = "elecCalle";
            this.elecCalle.Size = new System.Drawing.Size(208, 20);
            this.elecCalle.TabIndex = 68;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Localidad:";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Código postal:";
            // 
            // elecTelefono
            // 
            this.elecTelefono.Location = new System.Drawing.Point(137, 116);
            this.elecTelefono.MaxLength = 15;
            this.elecTelefono.Name = "elecTelefono";
            this.elecTelefono.Size = new System.Drawing.Size(214, 20);
            this.elecTelefono.TabIndex = 112;
            this.elecTelefono.TextChanged += new System.EventHandler(this.elecTelefono_TextChanged);
            // 
            // elecEMail
            // 
            this.elecEMail.Location = new System.Drawing.Point(137, 90);
            this.elecEMail.MaxLength = 255;
            this.elecEMail.Name = "elecEMail";
            this.elecEMail.Size = new System.Drawing.Size(214, 20);
            this.elecEMail.TabIndex = 111;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 110;
            this.label8.Text = "Telefono:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 109;
            this.label7.Text = "E-Mail:";
            // 
            // elecRazonSocial
            // 
            this.elecRazonSocial.Location = new System.Drawing.Point(137, 64);
            this.elecRazonSocial.MaxLength = 255;
            this.elecRazonSocial.Name = "elecRazonSocial";
            this.elecRazonSocial.Size = new System.Drawing.Size(214, 20);
            this.elecRazonSocial.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Razón social:";
            // 
            // elecCUIT2
            // 
            this.elecCUIT2.Location = new System.Drawing.Point(177, 169);
            this.elecCUIT2.MaxLength = 8;
            this.elecCUIT2.Name = "elecCUIT2";
            this.elecCUIT2.Size = new System.Drawing.Size(135, 20);
            this.elecCUIT2.TabIndex = 124;
            this.elecCUIT2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // elecCUIT3
            // 
            this.elecCUIT3.Location = new System.Drawing.Point(318, 169);
            this.elecCUIT3.MaxLength = 2;
            this.elecCUIT3.Name = "elecCUIT3";
            this.elecCUIT3.Size = new System.Drawing.Size(33, 20);
            this.elecCUIT3.TabIndex = 125;
            this.elecCUIT3.TextChanged += new System.EventHandler(this.elecCUIT3_TextChanged);
            // 
            // AltaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 513);
            this.Controls.Add(this.elecCUIT3);
            this.Controls.Add(this.elecCUIT2);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.elecFechaCreacion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.elecNombreContacto);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.elecCUIT1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.elecCiudad);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.elecTelefono);
            this.Controls.Add(this.elecEMail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.elecRazonSocial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.errorBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaEmpresa";
            this.Text = "AltaEmpresa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.DateTimePicker elecFechaCreacion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox elecNombreContacto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox elecCUIT1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox elecCiudad;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox elecTelefono;
        private System.Windows.Forms.TextBox elecEMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox elecRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox elecCUIT2;
        private System.Windows.Forms.TextBox elecCUIT3;
    }
}