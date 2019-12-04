namespace EditordeGrafos
{
    partial class Editor
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
            this.ArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_openGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.m_saveGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_addNode = new System.Windows.Forms.ToolStripMenuItem();
            this.m_moveNode = new System.Windows.Forms.ToolStripMenuItem();
            this.m_deleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.m_addEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.m_directedEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.m_undirectedEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.m_deleteEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.m_moveGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.m_eraseGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.m_deleteGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_nombreAristas = new System.Windows.Forms.ToolStripMenuItem();
            this.m_pesoAristas = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_complement = new System.Windows.Forms.ToolStripMenuItem();
            this.m_euler = new System.Windows.Forms.ToolStripMenuItem();
            this.m_npartite = new System.Windows.Forms.ToolStripMenuItem();
            this.m_kuratowsky = new System.Windows.Forms.ToolStripMenuItem();
            this.m_prim = new System.Windows.Forms.ToolStripMenuItem();
            this.m_coloredEdges = new System.Windows.Forms.ToolStripMenuItem();
            this.m_topological = new System.Windows.Forms.ToolStripMenuItem();
            this.m_hamilton = new System.Windows.Forms.ToolStripMenuItem();
            this.Configuracion = new System.Windows.Forms.ToolStripMenuItem();
            this.m_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.m_exchange = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArista = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Peso = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.MenuArista.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArchivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.verToolStripMenuItem,
            this.algoritmosToolStripMenuItem,
            this.Configuracion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
            // 
            // ArchivoToolStripMenuItem
            // 
            this.ArchivoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.ArchivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_openGraph,
            this.m_saveGraph,
            this.m_Exit});
            this.ArchivoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem";
            this.ArchivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ArchivoToolStripMenuItem.Text = "Archivo";
            // 
            // m_openGraph
            // 
            this.m_openGraph.Name = "m_openGraph";
            this.m_openGraph.ShortcutKeyDisplayString = "    ";
            this.m_openGraph.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.m_openGraph.Size = new System.Drawing.Size(152, 22);
            this.m_openGraph.Text = "Abrir ";
            this.m_openGraph.Click += new System.EventHandler(this.mOpenGraph);
            // 
            // m_saveGraph
            // 
            this.m_saveGraph.Name = "m_saveGraph";
            this.m_saveGraph.ShortcutKeyDisplayString = "   ";
            this.m_saveGraph.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.m_saveGraph.Size = new System.Drawing.Size(152, 22);
            this.m_saveGraph.Text = "Guardar";
            this.m_saveGraph.Click += new System.EventHandler(this.mSaveGraph);
            // 
            // m_Exit
            // 
            this.m_Exit.Name = "m_Exit";
            this.m_Exit.ShortcutKeyDisplayString = "";
            this.m_Exit.Size = new System.Drawing.Size(152, 22);
            this.m_Exit.Text = "Salir";
            this.m_Exit.Click += new System.EventHandler(this.mExit);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_addNode,
            this.m_moveNode,
            this.m_deleteNode,
            this.m_addEdge,
            this.m_deleteEdge,
            this.m_moveGraph,
            this.m_eraseGraph,
            this.m_deleteGraph});
            this.herramientasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.herramientasToolStripMenuItem.Text = "Grafo";
            // 
            // m_addNode
            // 
            this.m_addNode.Name = "m_addNode";
            this.m_addNode.ShortcutKeyDisplayString = " ";
            this.m_addNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.m_addNode.Size = new System.Drawing.Size(158, 22);
            this.m_addNode.Text = "Agrega Nodo ";
            this.m_addNode.Click += new System.EventHandler(this.mAddNode);
            // 
            // m_moveNode
            // 
            this.m_moveNode.Name = "m_moveNode";
            this.m_moveNode.Size = new System.Drawing.Size(158, 22);
            this.m_moveNode.Text = "Mueve Nodo";
            this.m_moveNode.Click += new System.EventHandler(this.mMoveNode);
            // 
            // m_deleteNode
            // 
            this.m_deleteNode.Name = "m_deleteNode";
            this.m_deleteNode.Size = new System.Drawing.Size(158, 22);
            this.m_deleteNode.Text = "Elimina Nodo";
            this.m_deleteNode.Click += new System.EventHandler(this.mDeleteNode);
            // 
            // m_addEdge
            // 
            this.m_addEdge.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_directedEdge,
            this.m_undirectedEdge});
            this.m_addEdge.Name = "m_addEdge";
            this.m_addEdge.Size = new System.Drawing.Size(158, 22);
            this.m_addEdge.Text = "Agrega Arista";
            // 
            // m_directedEdge
            // 
            this.m_directedEdge.Name = "m_directedEdge";
            this.m_directedEdge.Size = new System.Drawing.Size(152, 22);
            this.m_directedEdge.Tag = "d";
            this.m_directedEdge.Text = "Dirigida";
            this.m_directedEdge.Click += new System.EventHandler(this.mDirectedEdge);
            // 
            // m_undirectedEdge
            // 
            this.m_undirectedEdge.Name = "m_undirectedEdge";
            this.m_undirectedEdge.Size = new System.Drawing.Size(152, 22);
            this.m_undirectedEdge.Tag = "nd";
            this.m_undirectedEdge.Text = "No Dirigida";
            this.m_undirectedEdge.Click += new System.EventHandler(this.mUndirectedEdge);
            // 
            // m_deleteEdge
            // 
            this.m_deleteEdge.Name = "m_deleteEdge";
            this.m_deleteEdge.Size = new System.Drawing.Size(158, 22);
            this.m_deleteEdge.Text = "Elimina Arista";
            this.m_deleteEdge.Click += new System.EventHandler(this.mDeleteEdge);
            // 
            // m_moveGraph
            // 
            this.m_moveGraph.Name = "m_moveGraph";
            this.m_moveGraph.Size = new System.Drawing.Size(158, 22);
            this.m_moveGraph.Text = "Mueve Grafo";
            this.m_moveGraph.Click += new System.EventHandler(this.mMoveGraph);
            // 
            // m_eraseGraph
            // 
            this.m_eraseGraph.Name = "m_eraseGraph";
            this.m_eraseGraph.Size = new System.Drawing.Size(158, 22);
            this.m_eraseGraph.Text = "Borra Grafo";
            // 
            // m_deleteGraph
            // 
            this.m_deleteGraph.Name = "m_deleteGraph";
            this.m_deleteGraph.Size = new System.Drawing.Size(158, 22);
            this.m_deleteGraph.Text = "Elimina Grafo";
            this.m_deleteGraph.Click += new System.EventHandler(this.mEraseGraph);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_nombreAristas,
            this.m_pesoAristas});
            this.verToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            this.verToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mView);
            // 
            // m_nombreAristas
            // 
            this.m_nombreAristas.Name = "m_nombreAristas";
            this.m_nombreAristas.Size = new System.Drawing.Size(172, 22);
            this.m_nombreAristas.Text = "Nombre de Aristas";
            // 
            // m_pesoAristas
            // 
            this.m_pesoAristas.Name = "m_pesoAristas";
            this.m_pesoAristas.Size = new System.Drawing.Size(172, 22);
            this.m_pesoAristas.Text = "Peso de aristas";
            // 
            // algoritmosToolStripMenuItem
            // 
            this.algoritmosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_complement,
            this.m_npartite,
            this.m_kuratowsky,
            this.m_prim,
            this.m_coloredEdges,
            this.m_topological,
            this.m_euler,
            this.m_hamilton});
            this.algoritmosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algoritmosToolStripMenuItem.Name = "algoritmosToolStripMenuItem";
            this.algoritmosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.algoritmosToolStripMenuItem.Text = "Algoritmos";
            // 
            // m_complement
            // 
            this.m_complement.Name = "m_complement";
            this.m_complement.Size = new System.Drawing.Size(200, 22);
            this.m_complement.Text = "Complemento";
            this.m_complement.Click += new System.EventHandler(this.mComplement);
            // 
            // m_euler
            // 
            this.m_euler.Name = "m_euler";
            this.m_euler.Size = new System.Drawing.Size(200, 22);
            this.m_euler.Text = "Euler";
            this.m_euler.Click += new System.EventHandler(this.mEuler);
            // 
            // m_npartite
            // 
            this.m_npartite.Name = "m_npartite";
            this.m_npartite.Size = new System.Drawing.Size(200, 22);
            this.m_npartite.Text = "N-Partita";
            this.m_npartite.Click += new System.EventHandler(this.mNPartita);
            // 
            // m_kuratowsky
            // 
            this.m_kuratowsky.Name = "m_kuratowsky";
            this.m_kuratowsky.Size = new System.Drawing.Size(152, 22);
            this.m_kuratowsky.Text = "Isomorfismo";
            this.m_kuratowsky.Click += new System.EventHandler(this.mKuratowsky);
            // 
            // m_prim
            // 
            this.m_prim.Name = "m_prim";
            this.m_prim.Size = new System.Drawing.Size(200, 22);
            this.m_prim.Text = "Prim";
            // 
            // m_coloredEdges
            // 
            this.m_coloredEdges.Name = "m_coloredEdges";
            this.m_coloredEdges.Size = new System.Drawing.Size(152, 22);
            this.m_coloredEdges.Text = "Coloreados";
            this.m_coloredEdges.Click += new System.EventHandler(this.mColoredEdges);
            // 
            // m_topological
            // 
            this.m_topological.Name = "m_topological";
            this.m_topological.Size = new System.Drawing.Size(152, 22);
            this.m_topological.Text = "Clasico";
            this.m_topological.Click += new System.EventHandler(this.mTopological);
            // 
            // m_hamilton
            // 
            this.m_hamilton.Name = "m_hamilton";
            this.m_hamilton.Size = new System.Drawing.Size(200, 22);
            this.m_hamilton.Text = "Hamilton";
            this.m_hamilton.Click += new System.EventHandler(this.mHamilton);
            // 
            // Configuracion
            // 
            this.Configuracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_settings,
            this.m_exchange});
            this.Configuracion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Configuracion.Name = "Configuracion";
            this.Configuracion.Size = new System.Drawing.Size(95, 20);
            this.Configuracion.Text = "Configuración";
            // 
            // m_settings
            // 
            this.m_settings.Name = "m_settings";
            this.m_settings.Size = new System.Drawing.Size(201, 22);
            this.m_settings.Text = "Configurar nodo y arista";
            this.m_settings.Click += new System.EventHandler(this.mConfiguration);
            // 
            // m_exchange
            // 
            this.m_exchange.Name = "m_exchange";
            this.m_exchange.Size = new System.Drawing.Size(201, 22);
            this.m_exchange.Text = "Intercambio";
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
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 493);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Editor";
            this.Text = " Editor de Grafos";
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
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
        private System.Windows.Forms.ToolStripMenuItem ArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_openGraph;
        private System.Windows.Forms.ToolStripMenuItem m_saveGraph;
        private System.Windows.Forms.ToolStripMenuItem m_Exit;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_addNode;
        private System.Windows.Forms.ToolStripMenuItem m_addEdge;
        private System.Windows.Forms.ToolStripMenuItem m_moveNode;
        private System.Windows.Forms.ToolStripMenuItem m_deleteNode;
        private System.Windows.Forms.ToolStripMenuItem m_moveGraph;
        private System.Windows.Forms.ToolStripMenuItem m_directedEdge;
        private System.Windows.Forms.ToolStripMenuItem m_undirectedEdge;
        private System.Windows.Forms.ToolStripMenuItem m_deleteEdge;
        private System.Windows.Forms.ToolStripMenuItem Configuracion;
        private System.Windows.Forms.ContextMenuStrip MenuArista;
        private System.Windows.Forms.ToolStripMenuItem Peso;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_settings;
        private System.Windows.Forms.ToolStripMenuItem m_nombreAristas;
        private System.Windows.Forms.ToolStripMenuItem m_pesoAristas;
        private System.Windows.Forms.ToolStripMenuItem m_exchange;
        private System.Windows.Forms.ToolStripMenuItem m_deleteGraph;
        private System.Windows.Forms.ToolStripMenuItem m_eraseGraph;
        private System.Windows.Forms.ToolStripMenuItem algoritmosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_complement;
        private System.Windows.Forms.ToolStripMenuItem m_euler;
        private System.Windows.Forms.ToolStripMenuItem m_npartite;
        private System.Windows.Forms.ToolStripMenuItem m_kuratowsky;
        private System.Windows.Forms.ToolStripMenuItem m_prim;
        private System.Windows.Forms.ToolStripMenuItem m_coloredEdges;
        private System.Windows.Forms.ToolStripMenuItem m_topological;
        private System.Windows.Forms.ToolStripMenuItem m_hamilton;
    }
}

