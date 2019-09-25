namespace EditorDeGrafos
{
    partial class Caminos
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
            this.play = new System.Windows.Forms.Button();
            this.pausa = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.BarVelocidad = new System.Windows.Forms.TrackBar();
            this.listBoxNodos = new System.Windows.Forms.ListBox();
            this.listBoxOrdenados = new System.Windows.Forms.ListBox();
            this.Ordenar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxCamino
            // 
            this.richTextBoxCamino.Location = new System.Drawing.Point(43, 37);
            this.richTextBoxCamino.Name = "richTextBoxCamino";
            this.richTextBoxCamino.Size = new System.Drawing.Size(230, 96);
            this.richTextBoxCamino.TabIndex = 0;
            this.richTextBoxCamino.Text = "";
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(300, 97);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(75, 23);
            this.play.TabIndex = 1;
            this.play.Text = "play";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click_1);
            // 
            // pausa
            // 
            this.pausa.Location = new System.Drawing.Point(409, 97);
            this.pausa.Name = "pausa";
            this.pausa.Size = new System.Drawing.Size(75, 23);
            this.pausa.TabIndex = 2;
            this.pausa.Text = "pause";
            this.pausa.UseVisualStyleBackColor = true;
            this.pausa.Click += new System.EventHandler(this.pausa_Click_1);
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(299, 175);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 3;
            this.Cerrar.Text = "cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click_1);
            // 
            // BarVelocidad
            // 
            this.BarVelocidad.Location = new System.Drawing.Point(299, 37);
            this.BarVelocidad.Name = "BarVelocidad";
            this.BarVelocidad.Size = new System.Drawing.Size(195, 45);
            this.BarVelocidad.TabIndex = 4;
            // 
            // listBoxNodos
            // 
            this.listBoxNodos.FormattingEnabled = true;
            this.listBoxNodos.Location = new System.Drawing.Point(513, 37);
            this.listBoxNodos.Name = "listBoxNodos";
            this.listBoxNodos.Size = new System.Drawing.Size(66, 147);
            this.listBoxNodos.TabIndex = 5;
            // 
            // listBoxOrdenados
            // 
            this.listBoxOrdenados.FormattingEnabled = true;
            this.listBoxOrdenados.Location = new System.Drawing.Point(604, 37);
            this.listBoxOrdenados.Name = "listBoxOrdenados";
            this.listBoxOrdenados.Size = new System.Drawing.Size(64, 147);
            this.listBoxOrdenados.TabIndex = 6;
            this.listBoxOrdenados.SelectedIndexChanged += new System.EventHandler(this.listBoxOrdenados_SelectedIndexChanged);
            // 
            // Ordenar
            // 
            this.Ordenar.Location = new System.Drawing.Point(543, 203);
            this.Ordenar.Name = "Ordenar";
            this.Ordenar.Size = new System.Drawing.Size(75, 23);
            this.Ordenar.TabIndex = 7;
            this.Ordenar.Text = "Ordenar";
            this.Ordenar.UseVisualStyleBackColor = true;
            this.Ordenar.Click += new System.EventHandler(this.Ordenar_Click);
            // 
            // Caminos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 261);
            this.Controls.Add(this.Ordenar);
            this.Controls.Add(this.listBoxOrdenados);
            this.Controls.Add(this.listBoxNodos);
            this.Controls.Add(this.BarVelocidad);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.pausa);
            this.Controls.Add(this.play);
            this.Controls.Add(this.richTextBoxCamino);
            this.Name = "Caminos";
            this.Text = "Caminos";
            this.Load += new System.EventHandler(this.Caminos_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCamino;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button pausa;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.TrackBar BarVelocidad;
        private System.Windows.Forms.ListBox listBoxNodos;
        private System.Windows.Forms.ListBox listBoxOrdenados;
        private System.Windows.Forms.Button Ordenar;
    }
}