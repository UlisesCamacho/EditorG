namespace EditordeGrafos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.Abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BorraGrafo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregaNodo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AgregaRelacion = new System.Windows.Forms.ToolStripMenuItem();
            this.AristaDirigida = new System.Windows.Forms.ToolStripMenuItem();
            this.AristaNoDirigida = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MueveNodo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.EliminaNod = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MueveGraf = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.EliminaAris = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.propiedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreDeAristasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesoDeAristasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArista = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Peso = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.especialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.MenuArista.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.propiedadesToolStripMenuItem,
            this.verToolStripMenuItem,
            this.especialesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
        //    this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nuevo,
            this.Abrir,
            this.toolStripSeparator1,
            this.Guardar,
            this.toolStripSeparator2,
            this.BorraGrafo,
            this.toolStripSeparator10,
            this.Salir});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.nuevoToolStripMenuItem.Text = "Archivo";
            this.nuevoToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.nuevoToolStripMenuItem_DropDownItemClicked);
            // 
            // Nuevo
            // 
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.ShortcutKeyDisplayString = "  ";
            this.Nuevo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.Nuevo.Size = new System.Drawing.Size(134, 22);
            this.Nuevo.Text = "Nuevo";
            // 
            // Abrir
            // 
            this.Abrir.Name = "Abrir";
            this.Abrir.ShortcutKeyDisplayString = "";
            this.Abrir.Size = new System.Drawing.Size(134, 22);
            this.Abrir.Text = "Abrir ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // Guardar
            // 
            this.Guardar.Name = "Guardar";
            this.Guardar.ShortcutKeyDisplayString = "";
            this.Guardar.Size = new System.Drawing.Size(134, 22);
            this.Guardar.Text = "Guardar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
            // 
            // BorraGrafo
            // 
            this.BorraGrafo.Name = "BorraGrafo";
            this.BorraGrafo.Size = new System.Drawing.Size(134, 22);
            this.BorraGrafo.Text = "Borra Grafo";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(131, 6);
            // 
            // Salir
            // 
            this.Salir.Name = "Salir";
            this.Salir.ShortcutKeyDisplayString = "";
            this.Salir.Size = new System.Drawing.Size(134, 22);
            this.Salir.Text = "Salir";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregaNodo,
            this.toolStripSeparator4,
            this.AgregaRelacion,
            this.toolStripSeparator5,
            this.MueveNodo,
            this.toolStripSeparator7,
            this.EliminaNod,
            this.toolStripSeparator6,
            this.MueveGraf,
            this.toolStripSeparator8,
            this.EliminaAris,
            this.toolStripSeparator9});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            this.herramientasToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // AgregaNodo
            // 
            this.AgregaNodo.Name = "AgregaNodo";
            this.AgregaNodo.ShortcutKeyDisplayString = "";
            this.AgregaNodo.Size = new System.Drawing.Size(157, 22);
            this.AgregaNodo.Text = "Agrega Nodo ";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(154, 6);
            // 
            // AgregaRelacion
            // 
            this.AgregaRelacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AristaDirigida,
            this.AristaNoDirigida});
            this.AgregaRelacion.Name = "AgregaRelacion";
            this.AgregaRelacion.Size = new System.Drawing.Size(157, 22);
            this.AgregaRelacion.Text = "Agrega relacion";
            this.AgregaRelacion.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.RelacionClicked);
            // 
            // AristaDirigida
            // 
            this.AristaDirigida.Name = "AristaDirigida";
            this.AristaDirigida.Size = new System.Drawing.Size(135, 22);
            this.AristaDirigida.Text = "Dirigida";
            // 
            // AristaNoDirigida
            // 
            this.AristaNoDirigida.Name = "AristaNoDirigida";
            this.AristaNoDirigida.Size = new System.Drawing.Size(135, 22);
            this.AristaNoDirigida.Text = "No Dirigida";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(154, 6);
            // 
            // MueveNodo
            // 
            this.MueveNodo.Name = "MueveNodo";
            this.MueveNodo.Size = new System.Drawing.Size(157, 22);
            this.MueveNodo.Text = "Mueve Nodo";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(154, 6);
            // 
            // EliminaNod
            // 
            this.EliminaNod.Name = "EliminaNod";
            this.EliminaNod.Size = new System.Drawing.Size(157, 22);
            this.EliminaNod.Text = "Elimina Nodo";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(154, 6);
            // 
            // MueveGraf
            // 
            this.MueveGraf.Name = "MueveGraf";
            this.MueveGraf.Size = new System.Drawing.Size(157, 22);
            this.MueveGraf.Text = "Mueve Grafo";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(154, 6);
            // 
            // EliminaAris
            // 
            this.EliminaAris.Name = "EliminaAris";
            this.EliminaAris.Size = new System.Drawing.Size(157, 22);
            this.EliminaAris.Text = "Elimina Arista";
            this.EliminaAris.Click += new System.EventHandler(this.EliminaAris_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(154, 6);
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
            this.pesoDeAristasToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // nombreDeAristasToolStripMenuItem
            // 
            this.nombreDeAristasToolStripMenuItem.Name = "nombreDeAristasToolStripMenuItem";
            this.nombreDeAristasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.nombreDeAristasToolStripMenuItem.Text = "Nombre de Aristas";
            this.nombreDeAristasToolStripMenuItem.Click += new System.EventHandler(this.nombreDeAristasToolStripMenuItem_Click);
            // 
            // pesoDeAristasToolStripMenuItem
            // 
            this.pesoDeAristasToolStripMenuItem.Name = "pesoDeAristasToolStripMenuItem";
            this.pesoDeAristasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pesoDeAristasToolStripMenuItem.Text = "Peso de Aristas";
            this.pesoDeAristasToolStripMenuItem.Click += new System.EventHandler(this.pesoDeAristasToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // MenuArista
            // 
            this.MenuArista.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Peso});
            this.MenuArista.Name = "MenuArista";
            this.MenuArista.Size = new System.Drawing.Size(133, 26);
            this.MenuArista.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.MenuArista_Closing);
            // 
            // Peso
            // 
            this.Peso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.Peso.Name = "Peso";
            this.Peso.Size = new System.Drawing.Size(132, 22);
            this.Peso.Text = "Peso Arista";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // especialesToolStripMenuItem
            // 
            this.especialesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.completoToolStripMenuItem});
            this.especialesToolStripMenuItem.Name = "especialesToolStripMenuItem";
            this.especialesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.especialesToolStripMenuItem.Text = "Especiales";
            // 
            // completoToolStripMenuItem
            // 
            this.completoToolStripMenuItem.Name = "completoToolStripMenuItem";
            this.completoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.completoToolStripMenuItem.Text = "Completo";
            this.completoToolStripMenuItem.Click += new System.EventHandler(this.completoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 676);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " Editor de Grafos";
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Resize_form);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MenuArista.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Abrir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Guardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Salir;
        private System.Windows.Forms.ToolStripMenuItem Nuevo;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AgregaNodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem AgregaRelacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MueveNodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem EliminaNod;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem MueveGraf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem AristaDirigida;
        private System.Windows.Forms.ToolStripMenuItem AristaNoDirigida;
        private System.Windows.Forms.ToolStripMenuItem EliminaAris;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem BorraGrafo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ContextMenuStrip MenuArista;
        private System.Windows.Forms.ToolStripMenuItem Peso;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem propiedadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreDeAristasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesoDeAristasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completoToolStripMenuItem;
    }
}

