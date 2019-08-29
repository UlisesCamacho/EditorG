namespace EditordeGrafos
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboNodos = new System.Windows.Forms.ComboBox();
            this.comboAristas = new System.Windows.Forms.ComboBox();
            this.textBoxNodos = new System.Windows.Forms.TextBox();
            this.textBoxAristas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nodos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Aristas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Peso";
            // 
            // comboNodos
            // 
            this.comboNodos.FormattingEnabled = true;
            this.comboNodos.Location = new System.Drawing.Point(15, 61);
            this.comboNodos.Name = "comboNodos";
            this.comboNodos.Size = new System.Drawing.Size(121, 21);
            this.comboNodos.TabIndex = 1;
            this.comboNodos.TextChanged += new System.EventHandler(this.comboNodos_TextChanged);
            // 
            // comboAristas
            // 
            this.comboAristas.FormattingEnabled = true;
            this.comboAristas.Location = new System.Drawing.Point(12, 125);
            this.comboAristas.Name = "comboAristas";
            this.comboAristas.Size = new System.Drawing.Size(121, 21);
            this.comboAristas.TabIndex = 1;
            this.comboAristas.TextChanged += new System.EventHandler(this.comboAristas_TextChanged);
            // 
            // textBoxNodos
            // 
            this.textBoxNodos.Location = new System.Drawing.Point(225, 61);
            this.textBoxNodos.Name = "textBoxNodos";
            this.textBoxNodos.Size = new System.Drawing.Size(100, 20);
            this.textBoxNodos.TabIndex = 2;
            this.textBoxNodos.TextChanged += new System.EventHandler(this.textBoxNodos_TextChanged);
            // 
            // textBoxAristas
            // 
            this.textBoxAristas.Location = new System.Drawing.Point(225, 126);
            this.textBoxAristas.Name = "textBoxAristas";
            this.textBoxAristas.Size = new System.Drawing.Size(100, 20);
            this.textBoxAristas.TabIndex = 2;
            this.textBoxAristas.TextChanged += new System.EventHandler(this.textBoxAristas_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 386);
            this.Controls.Add(this.textBoxAristas);
            this.Controls.Add(this.textBoxNodos);
            this.Controls.Add(this.comboAristas);
            this.Controls.Add(this.comboNodos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Editar";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboNodos;
        private System.Windows.Forms.ComboBox comboAristas;
        private System.Windows.Forms.TextBox textBoxNodos;
        private System.Windows.Forms.TextBox textBoxAristas;
    }
}