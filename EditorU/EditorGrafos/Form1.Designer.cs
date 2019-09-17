namespace EditorGrafos
{
    partial class EditorGrafo
    {
        /// <summary>
        /// Editor realizado por los alumnos de la ACM
        /// Arturo Garía Pérez
        /// Braulio Alejandro García Rivera
        /// Aldo Daniel Ponce Hernandez
        /// Andrey Hernandez Alonso
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarRelacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dirigidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noDirigidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mueveNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mueveGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propiedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreDeAristasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biPartitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciclicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giratorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isoformismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.propiedadesToolStripMenuItem,
            this.verToolStripMenuItem,
            this.especialesToolStripMenuItem,
            this.isoformismoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.borrarGrafoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Archivo_Click);
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.AccessibleName = "Save";
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveToolStripMenuItem.Text = "Nuevo";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.AccessibleName = "Abrir";
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.openToolStripMenuItem.Text = "Abrir";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.AccessibleName = "Guardar";
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // borrarGrafoToolStripMenuItem
            // 
            this.borrarGrafoToolStripMenuItem.Name = "borrarGrafoToolStripMenuItem";
            this.borrarGrafoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.borrarGrafoToolStripMenuItem.Text = "Borrar Grafo";
            this.borrarGrafoToolStripMenuItem.Click += new System.EventHandler(this.borrarGrafoToolStripMenuItem_Click_1);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarNodoToolStripMenuItem,
            this.agregarRelacionToolStripMenuItem,
            this.mueveNodoToolStripMenuItem,
            this.eliminaNodoToolStripMenuItem,
            this.mueveGrafoToolStripMenuItem,
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
            // mueveGrafoToolStripMenuItem
            // 
            this.mueveGrafoToolStripMenuItem.Name = "mueveGrafoToolStripMenuItem";
            this.mueveGrafoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.mueveGrafoToolStripMenuItem.Text = "Mueve Grafo";
            this.mueveGrafoToolStripMenuItem.Click += new System.EventHandler(this.mueveGrafoToolStripMenuItem_Click);
            // 
            // eliminaAristaToolStripMenuItem
            // 
            this.eliminaAristaToolStripMenuItem.Name = "eliminaAristaToolStripMenuItem";
            this.eliminaAristaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.eliminaAristaToolStripMenuItem.Text = "Elimina Arista";
            this.eliminaAristaToolStripMenuItem.Click += new System.EventHandler(this.eliminaAristaToolStripMenuItem_Click);
            // 
            // propiedadesToolStripMenuItem
            // 
            this.propiedadesToolStripMenuItem.Name = "propiedadesToolStripMenuItem";
            this.propiedadesToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.propiedadesToolStripMenuItem.Text = "Propiedades";
            this.propiedadesToolStripMenuItem.Click += new System.EventHandler(this.propiedadesToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nombreDeAristasToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // nombreDeAristasToolStripMenuItem
            // 
            this.nombreDeAristasToolStripMenuItem.Name = "nombreDeAristasToolStripMenuItem";
            this.nombreDeAristasToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.nombreDeAristasToolStripMenuItem.Text = "Peso de Aristas";
            this.nombreDeAristasToolStripMenuItem.Click += new System.EventHandler(this.nombreDeAristasToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // especialesToolStripMenuItem
            // 
            this.especialesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.completoToolStripMenuItem,
            this.biPartitaToolStripMenuItem,
            this.ciclicoToolStripMenuItem,
            this.giratorioToolStripMenuItem});
            this.especialesToolStripMenuItem.Name = "especialesToolStripMenuItem";
            this.especialesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.especialesToolStripMenuItem.Text = "Especiales";
            // 
            // completoToolStripMenuItem
            // 
            this.completoToolStripMenuItem.Name = "completoToolStripMenuItem";
            this.completoToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.completoToolStripMenuItem.Text = "Completo";
            this.completoToolStripMenuItem.Click += new System.EventHandler(this.completoToolStripMenuItem_Click);
            // 
            // biPartitaToolStripMenuItem
            // 
            this.biPartitaToolStripMenuItem.Name = "biPartitaToolStripMenuItem";
            this.biPartitaToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.biPartitaToolStripMenuItem.Text = "Bi-Partita";
            // 
            // ciclicoToolStripMenuItem
            // 
            this.ciclicoToolStripMenuItem.Name = "ciclicoToolStripMenuItem";
            this.ciclicoToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ciclicoToolStripMenuItem.Text = "Ciclico";
            // 
            // giratorioToolStripMenuItem
            // 
            this.giratorioToolStripMenuItem.Name = "giratorioToolStripMenuItem";
            this.giratorioToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.giratorioToolStripMenuItem.Text = "Giratorio";
            // 
            // isoformismoToolStripMenuItem
            // 
            this.isoformismoToolStripMenuItem.Name = "isoformismoToolStripMenuItem";
            this.isoformismoToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.isoformismoToolStripMenuItem.Text = "Isomorfismo";
            this.isoformismoToolStripMenuItem.Click += new System.EventHandler(this.isoformismoToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // EditorGrafo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorGrafo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Grafos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditorGrafo_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarRelacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dirigidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noDirigidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mueveNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mueveGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaAristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propiedadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreDeAristasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialesToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem completoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biPartitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciclicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giratorioToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem isoformismoToolStripMenuItem;
    }
}

