namespace EditorDeGrafos
{
    partial class GrafoSecundario
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
            this.Aceptar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.saveFileGrafo = new System.Windows.Forms.SaveFileDialog();
            this.openFileGrafo = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarRelacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dirigidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noDirigidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mueveNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mueveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Aceptar
            // 
            this.Aceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Aceptar.Location = new System.Drawing.Point(666, 365);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 1;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(12, 365);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 2;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // openFileGrafo
            // 
            this.openFileGrafo.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.borrarGrafoToolStripMenuItem,
            this.salirToolStripMenuItem,
            this.nuevoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.abrirToolStripMenuItem.Text = "Nuevo";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.guardarToolStripMenuItem.Text = "Abrir";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // borrarGrafoToolStripMenuItem
            // 
            this.borrarGrafoToolStripMenuItem.Name = "borrarGrafoToolStripMenuItem";
            this.borrarGrafoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.borrarGrafoToolStripMenuItem.Text = "Guardar";
            this.borrarGrafoToolStripMenuItem.Click += new System.EventHandler(this.borrarGrafoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.salirToolStripMenuItem.Text = "Borrar Grafo";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.nuevoToolStripMenuItem.Text = "Salir";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarNodoToolStripMenuItem,
            this.agregarRelacionToolStripMenuItem,
            this.mueveNodoToolStripMenuItem,
            this.eliminaNodoToolStripMenuItem,
            this.mueveToolStripMenuItem,
            this.eliminaAristaToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // agregarNodoToolStripMenuItem
            // 
            this.agregarNodoToolStripMenuItem.Name = "agregarNodoToolStripMenuItem";
            this.agregarNodoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.agregarNodoToolStripMenuItem.Text = "Agregar Nodo";
            this.agregarNodoToolStripMenuItem.Click += new System.EventHandler(this.agregarNodoToolStripMenuItem_Click);
            // 
            // agregarRelacionToolStripMenuItem
            // 
            this.agregarRelacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dirigidaToolStripMenuItem,
            this.noDirigidaToolStripMenuItem});
            this.agregarRelacionToolStripMenuItem.Name = "agregarRelacionToolStripMenuItem";
            this.agregarRelacionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.agregarRelacionToolStripMenuItem.Text = "Agregar Relacion";
            // 
            // dirigidaToolStripMenuItem
            // 
            this.dirigidaToolStripMenuItem.Name = "dirigidaToolStripMenuItem";
            this.dirigidaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.dirigidaToolStripMenuItem.Text = "Dirigida";
            this.dirigidaToolStripMenuItem.Click += new System.EventHandler(this.dirigidaToolStripMenuItem_Click);
            // 
            // noDirigidaToolStripMenuItem
            // 
            this.noDirigidaToolStripMenuItem.Name = "noDirigidaToolStripMenuItem";
            this.noDirigidaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.noDirigidaToolStripMenuItem.Text = "No Dirigida";
            this.noDirigidaToolStripMenuItem.Click += new System.EventHandler(this.noDirigidaToolStripMenuItem_Click);
            // 
            // mueveNodoToolStripMenuItem
            // 
            this.mueveNodoToolStripMenuItem.Name = "mueveNodoToolStripMenuItem";
            this.mueveNodoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.mueveNodoToolStripMenuItem.Text = "Mueve Nodo";
            this.mueveNodoToolStripMenuItem.Click += new System.EventHandler(this.mueveNodoToolStripMenuItem_Click);
            // 
            // eliminaNodoToolStripMenuItem
            // 
            this.eliminaNodoToolStripMenuItem.Name = "eliminaNodoToolStripMenuItem";
            this.eliminaNodoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.eliminaNodoToolStripMenuItem.Text = "Elimina Nodo";
            this.eliminaNodoToolStripMenuItem.Click += new System.EventHandler(this.eliminaNodoToolStripMenuItem_Click);
            // 
            // mueveToolStripMenuItem
            // 
            this.mueveToolStripMenuItem.Name = "mueveToolStripMenuItem";
            this.mueveToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.mueveToolStripMenuItem.Text = "Mueve Grafo";
            this.mueveToolStripMenuItem.Click += new System.EventHandler(this.mueveToolStripMenuItem_Click);
            // 
            // eliminaAristaToolStripMenuItem
            // 
            this.eliminaAristaToolStripMenuItem.Name = "eliminaAristaToolStripMenuItem";
            this.eliminaAristaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.eliminaAristaToolStripMenuItem.Text = "Elimina Arista";
            this.eliminaAristaToolStripMenuItem.Click += new System.EventHandler(this.eliminaAristaToolStripMenuItem_Click);
            // 
            // GrafoSecundario
            // 
            this.AcceptButton = this.Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(753, 400);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GrafoSecundario";
            this.Text = "GrafoSeccundario";
            this.Load += new System.EventHandler(this.GrafoSecundario_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GrafoSecundario_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GrafoSecundario_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GrafoSecundario_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GrafoSecundario_MouseUp);
            this.Resize += new System.EventHandler(this.GrafoSecundario_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.SaveFileDialog saveFileGrafo;
        private System.Windows.Forms.OpenFileDialog openFileGrafo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarRelacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dirigidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noDirigidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mueveNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mueveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaAristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
    }
}