namespace FrbaCommerce.Abm_Visibilidad
{
    partial class EditarVisibilidad
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
            this.elecPorcen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.elecPrec = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.elecDescrip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.codNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(136, 330);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(77, 29);
            this.cancelar.TabIndex = 21;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(18, 330);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(77, 29);
            this.aceptar.TabIndex = 20;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // elecPorcen
            // 
            this.elecPorcen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elecPorcen.Location = new System.Drawing.Point(18, 258);
            this.elecPorcen.Name = "elecPorcen";
            this.elecPorcen.Size = new System.Drawing.Size(195, 29);
            this.elecPorcen.TabIndex = 19;
            this.elecPorcen.TextChanged += new System.EventHandler(this.elecPorcen_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "% de la venta";
            // 
            // elecPrec
            // 
            this.elecPrec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elecPrec.Location = new System.Drawing.Point(18, 201);
            this.elecPrec.Name = "elecPrec";
            this.elecPrec.Size = new System.Drawing.Size(195, 29);
            this.elecPrec.TabIndex = 17;
            this.elecPrec.TextChanged += new System.EventHandler(this.elecPrec_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Precio por publicar:";
            // 
            // elecDescrip
            // 
            this.elecDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elecDescrip.Location = new System.Drawing.Point(18, 143);
            this.elecDescrip.Name = "elecDescrip";
            this.elecDescrip.Size = new System.Drawing.Size(195, 29);
            this.elecDescrip.TabIndex = 15;
            this.elecDescrip.TextChanged += new System.EventHandler(this.elecDescrip_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "Editar Visibilidad";
            // 
            // codNum
            // 
            this.codNum.AutoSize = true;
            this.codNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codNum.Location = new System.Drawing.Point(13, 86);
            this.codNum.Name = "codNum";
            this.codNum.Size = new System.Drawing.Size(0, 30);
            this.codNum.TabIndex = 22;
            // 
            // EditarVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 374);
            this.Controls.Add(this.codNum);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.elecPorcen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.elecPrec);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.elecDescrip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditarVisibilidad";
            this.Text = "EditarVisibilidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.TextBox elecPorcen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox elecPrec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox elecDescrip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label codNum;
    }
}