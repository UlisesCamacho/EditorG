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
            this.Cerrar = new System.Windows.Forms.Button();
            this.listBoxNodos = new System.Windows.Forms.ListBox();
            this.listBoxOrdenados = new System.Windows.Forms.ListBox();
            this.Ordenar = new System.Windows.Forms.Button();
            this.listBoxlistas = new System.Windows.Forms.ListBox();
            this.listasDos = new System.Windows.Forms.ListBox();
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
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(95, 173);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 3;
            this.Cerrar.Text = "cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click_1);
            // 
            // listBoxNodos
            // 
            this.listBoxNodos.FormattingEnabled = true;
            this.listBoxNodos.Location = new System.Drawing.Point(319, 3);
            this.listBoxNodos.Name = "listBoxNodos";
            this.listBoxNodos.Size = new System.Drawing.Size(66, 147);
            this.listBoxNodos.TabIndex = 5;
            // 
            // listBoxOrdenados
            // 
            this.listBoxOrdenados.FormattingEnabled = true;
            this.listBoxOrdenados.Location = new System.Drawing.Point(442, 3);
            this.listBoxOrdenados.Name = "listBoxOrdenados";
            this.listBoxOrdenados.Size = new System.Drawing.Size(64, 147);
            this.listBoxOrdenados.TabIndex = 6;
            this.listBoxOrdenados.SelectedIndexChanged += new System.EventHandler(this.listBoxOrdenados_SelectedIndexChanged);
            // 
            // Ordenar
            // 
            this.Ordenar.Location = new System.Drawing.Point(367, 190);
            this.Ordenar.Name = "Ordenar";
            this.Ordenar.Size = new System.Drawing.Size(75, 23);
            this.Ordenar.TabIndex = 7;
            this.Ordenar.Text = "Ordenar";
            this.Ordenar.UseVisualStyleBackColor = true;
            this.Ordenar.Click += new System.EventHandler(this.Ordenar_Click);
            // 
            // listBoxlistas
            // 
            this.listBoxlistas.FormattingEnabled = true;
            this.listBoxlistas.Location = new System.Drawing.Point(536, 3);
            this.listBoxlistas.Name = "listBoxlistas";
            this.listBoxlistas.Size = new System.Drawing.Size(66, 186);
            this.listBoxlistas.TabIndex = 8;
            // 
            // listasDos
            // 
            this.listasDos.FormattingEnabled = true;
            this.listasDos.Location = new System.Drawing.Point(622, 3);
            this.listasDos.Name = "listasDos";
            this.listasDos.Size = new System.Drawing.Size(71, 186);
            this.listasDos.TabIndex = 9;
            // 
            // Caminos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 261);
            this.Controls.Add(this.listasDos);
            this.Controls.Add(this.listBoxlistas);
            this.Controls.Add(this.Ordenar);
            this.Controls.Add(this.listBoxOrdenados);
            this.Controls.Add(this.listBoxNodos);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.richTextBoxCamino);
            this.Name = "Caminos";
            this.Text = "Caminos";
            this.Load += new System.EventHandler(this.Caminos_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCamino;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.ListBox listBoxNodos;
        private System.Windows.Forms.ListBox listBoxOrdenados;
        private System.Windows.Forms.Button Ordenar;
        private System.Windows.Forms.ListBox listBoxlistas;
        private System.Windows.Forms.ListBox listasDos;
    }
}