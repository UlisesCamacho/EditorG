namespace EditorDeGrafos
{
    partial class Euler
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
            this.richTextBoxCamino = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BarVelocidad = new System.Windows.Forms.TrackBar();
            this.Play = new System.Windows.Forms.Button();
            this.pausa = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxCamino
            // 
            this.richTextBoxCamino.Location = new System.Drawing.Point(32, 58);
            this.richTextBoxCamino.Name = "richTextBoxCamino";
            this.richTextBoxCamino.Size = new System.Drawing.Size(238, 165);
            this.richTextBoxCamino.TabIndex = 0;
            this.richTextBoxCamino.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recorrido";
            // 
            // BarVelocidad
            // 
            this.BarVelocidad.Location = new System.Drawing.Point(287, 58);
            this.BarVelocidad.Name = "BarVelocidad";
            this.BarVelocidad.Size = new System.Drawing.Size(200, 45);
            this.BarVelocidad.TabIndex = 2;
            this.BarVelocidad.Scroll += new System.EventHandler(this.BarVelocidad_Scroll);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(287, 124);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 3;
            this.Play.Text = "play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // pausa
            // 
            this.pausa.Location = new System.Drawing.Point(393, 124);
            this.pausa.Name = "pausa";
            this.pausa.Size = new System.Drawing.Size(75, 23);
            this.pausa.TabIndex = 4;
            this.pausa.Text = "pausa";
            this.pausa.UseVisualStyleBackColor = true;
            this.pausa.Click += new System.EventHandler(this.pausa_Click);
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(362, 200);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 5;
            this.Cerrar.Text = "cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.button3_Click);
            // 
            // Euler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 261);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.pausa);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.BarVelocidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxCamino);
            this.Name = "Euler";
            this.Text = "Euler";
            this.Load += new System.EventHandler(this.Euler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCamino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar BarVelocidad;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button pausa;
        private System.Windows.Forms.Button Cerrar;
    }
}