namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class responderPregunta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(responderPregunta));
            this.cancelar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.titulo = new System.Windows.Forms.Label();
            this.respuesta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelar.Location = new System.Drawing.Point(360, 208);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(82, 31);
            this.cancelar.TabIndex = 116;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptar.Location = new System.Drawing.Point(12, 208);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(82, 31);
            this.aceptar.TabIndex = 117;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(12, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(55, 13);
            this.titulo.TabIndex = 118;
            this.titulo.Text = "Pregunta";
            // 
            // respuesta
            // 
            this.respuesta.Location = new System.Drawing.Point(12, 37);
            this.respuesta.Multiline = true;
            this.respuesta.Name = "respuesta";
            this.respuesta.Size = new System.Drawing.Size(430, 155);
            this.respuesta.TabIndex = 119;
            // 
            // responderPregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 250);
            this.Controls.Add(this.respuesta);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "responderPregunta";
            this.Text = "Responder pregunta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.TextBox respuesta;
    }
}