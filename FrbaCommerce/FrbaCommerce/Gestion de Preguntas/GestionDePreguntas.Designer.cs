namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class GestionDePreguntas
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
            this.verRespuestas = new System.Windows.Forms.Button();
            this.responderPreguntas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelar.Location = new System.Drawing.Point(94, 160);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(136, 40);
            this.cancelar.TabIndex = 115;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // verRespuestas
            // 
            this.verRespuestas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verRespuestas.Location = new System.Drawing.Point(12, 12);
            this.verRespuestas.Name = "verRespuestas";
            this.verRespuestas.Size = new System.Drawing.Size(218, 40);
            this.verRespuestas.TabIndex = 114;
            this.verRespuestas.Text = "Ver respuestas";
            this.verRespuestas.UseVisualStyleBackColor = true;
            this.verRespuestas.Click += new System.EventHandler(this.verRespuestas_Click);
            // 
            // responderPreguntas
            // 
            this.responderPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.responderPreguntas.Location = new System.Drawing.Point(12, 78);
            this.responderPreguntas.Name = "responderPreguntas";
            this.responderPreguntas.Size = new System.Drawing.Size(218, 40);
            this.responderPreguntas.TabIndex = 116;
            this.responderPreguntas.Text = "Responder preguntas";
            this.responderPreguntas.UseVisualStyleBackColor = true;
            this.responderPreguntas.Click += new System.EventHandler(this.responderPreguntas_Click);
            // 
            // GestionDePreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 212);
            this.Controls.Add(this.responderPreguntas);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.verRespuestas);
            this.Name = "GestionDePreguntas";
            this.Text = "Gestión de preguntas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button verRespuestas;
        private System.Windows.Forms.Button responderPreguntas;
    }
}