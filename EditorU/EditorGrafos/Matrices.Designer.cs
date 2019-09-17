namespace EditorGrafos
{
    partial class Matrices
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gradosGrafo = new System.Windows.Forms.RadioButton();
            this.matrizp = new System.Windows.Forms.RadioButton();
            this.MatrizAyasencia = new System.Windows.Forms.RadioButton();
            this.LimpiarData = new System.Windows.Forms.RadioButton();
            this.gradoGrafo = new System.Windows.Forms.Label();
            this.grado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(340, 187);
            this.dataGridView1.TabIndex = 0;
            // 
            // gradosGrafo
            // 
            this.gradosGrafo.AutoSize = true;
            this.gradosGrafo.Location = new System.Drawing.Point(390, 183);
            this.gradosGrafo.Name = "gradosGrafo";
            this.gradosGrafo.Size = new System.Drawing.Size(83, 17);
            this.gradosGrafo.TabIndex = 1;
            this.gradosGrafo.TabStop = true;
            this.gradosGrafo.Text = "Grado Grafo";
            this.gradosGrafo.UseVisualStyleBackColor = true;
            this.gradosGrafo.CheckedChanged += new System.EventHandler(this.gradosGrafo_CheckedChanged);
            // 
            // matrizp
            // 
            this.matrizp.AutoSize = true;
            this.matrizp.Location = new System.Drawing.Point(388, 83);
            this.matrizp.Name = "matrizp";
            this.matrizp.Size = new System.Drawing.Size(85, 17);
            this.matrizp.TabIndex = 1;
            this.matrizp.TabStop = true;
            this.matrizp.Text = "Matriz Pesos";
            this.matrizp.UseVisualStyleBackColor = true;
            this.matrizp.CheckedChanged += new System.EventHandler(this.matrizp_CheckedChanged);
            // 
            // MatrizAyasencia
            // 
            this.MatrizAyasencia.AutoSize = true;
            this.MatrizAyasencia.Location = new System.Drawing.Point(388, 134);
            this.MatrizAyasencia.Name = "MatrizAyasencia";
            this.MatrizAyasencia.Size = new System.Drawing.Size(111, 17);
            this.MatrizAyasencia.TabIndex = 2;
            this.MatrizAyasencia.TabStop = true;
            this.MatrizAyasencia.Text = "Matriz Adyasencia";
            this.MatrizAyasencia.UseVisualStyleBackColor = true;
            this.MatrizAyasencia.CheckedChanged += new System.EventHandler(this.MatrizAyasencia_CheckedChanged_1);
            // 
            // LimpiarData
            // 
            this.LimpiarData.AutoSize = true;
            this.LimpiarData.Location = new System.Drawing.Point(52, 289);
            this.LimpiarData.Name = "LimpiarData";
            this.LimpiarData.Size = new System.Drawing.Size(81, 17);
            this.LimpiarData.TabIndex = 3;
            this.LimpiarData.TabStop = true;
            this.LimpiarData.Text = "LimpiarData";
            this.LimpiarData.UseVisualStyleBackColor = true;
            this.LimpiarData.CheckedChanged += new System.EventHandler(this.LimpiarData_CheckedChanged);
            // 
            // gradoGrafo
            // 
            this.gradoGrafo.AutoSize = true;
            this.gradoGrafo.Location = new System.Drawing.Point(488, 185);
            this.gradoGrafo.Name = "gradoGrafo";
            this.gradoGrafo.Size = new System.Drawing.Size(84, 13);
            this.gradoGrafo.TabIndex = 4;
            this.gradoGrafo.Text = "Grado Del Grafo";
            // 
            // grado
            // 
            this.grado.AutoSize = true;
            this.grado.Location = new System.Drawing.Point(602, 187);
            this.grado.Name = "grado";
            this.grado.Size = new System.Drawing.Size(35, 13);
            this.grado.TabIndex = 5;
            this.grado.Text = "label1";
            // 
            // MatrizPesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grado);
            this.Controls.Add(this.gradoGrafo);
            this.Controls.Add(this.LimpiarData);
            this.Controls.Add(this.MatrizAyasencia);
            this.Controls.Add(this.matrizp);
            this.Controls.Add(this.gradosGrafo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MatrizPesos";
            this.Text = "MatrizPesos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton gradosGrafo;
        private System.Windows.Forms.RadioButton matrizp;
        private System.Windows.Forms.RadioButton MatrizAyasencia;
        private System.Windows.Forms.RadioButton LimpiarData;
        private System.Windows.Forms.Label gradoGrafo;
        private System.Windows.Forms.Label grado;
    }
}