using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EditordeGrafos
{
    public partial class Form1 : Form
    {
        Grafo grafo,g2,gis;
        Point p;
        int ckwn;
        int Dijks;
        int flo;
        Point pm;
        Arista a;
        Graphics g;
        Bitmap bmp1; 
        char nombre;
        private int accion;
        NodoP nu;
        Pen fl;
        int tipoarista;
        bool gactivo;
        bool mov;
        bool band;
        BinaryFormatter file;
        int camin;
        NodoP orig, destin;
        Timer time;
        Arista arista;
        List<NodoP> CCE;
        List<string[]> camino;
        bool tck;
        bool bandcam;
        int icam;
        int numero;
        bool coloreando;
        Color resp;
        /// <summary>
        /// From principal 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
            bandcam = false;
            camin = 1;
       //     toolStripButton5.Visible = false;
        //    toolStrip4.Visible = false;
            //ItemMetodos.Visible = false;
            icam = 0;
            ckwn = 0;
            numero = 0;
            tck = false;
            CCE = new List<NodoP>();
            Dijks= 0;
            flo = 1;
            coloreando = false;
            resp = Color.White;
            g2 = new Grafo();
            a = new Arista();
        //    trackBar1.Visible = false;
            fl = new Pen(Brushes.Green);
            bmp1 = new Bitmap(800,600);
            g = CreateGraphics();
            file = new BinaryFormatter();
            grafo = new Grafo();
        /*    AgregaNodo.Enabled= Agrega.Enabled = true; 
            MueveNodo.Enabled=Mueve.Enabled = false;
            AgregaRelacion.Enabled=Dirigida.Enabled=NoDirigida.Enabled = false;
            EliminaNod.Enabled=EliminaNodo.Enabled = false;
            MueveGraf.Enabled = MueveGrafo.Enabled = false;
            EliminaAris.Enabled=EliminaArista.Enabled = false;
            caminoEulerInicio.Visible = false;
            cierraEuler.Visible = false;
            PropiedadesGrafo.Enabled = false;*/
           // Colorear.Enabled = true;
         //   toolStrip2.Visible = false;
            
           // ColoreaTool.Enabled = Colorear.Enabled = true;
           // EulerTool.Enabled = EulerMenu.Enabled = true;
          //  DijkstraCam.Enabled = DijkstraTool.Enabled = true;
          //  FloydTool.Enabled = CaminoFloyd.Enabled = true;
            band = false;
           // intercambioTool.Enabled = true;
            accion = 0;
            gactivo = false;
            pm = new Point();
            nombre = 'A';
            mov = false;
            time = new Timer();
       //     Kruskal.Enabled=KruskalMenu.Enabled = true;
       //     intercambioTool.Enabled = false;
            time.Tick += time_Tick;
        }         
        public Form1()
        { 
               
            InitializeComponent();
        }

        #region mouse
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Grafo g2;
            pm = e.Location;
            p = pm;
            switch (e.Button.ToString())
            {
                case "Left":
                    if (accion != 0 && accion !=1)
                    { 
                        band = true;
                        Form1_Paint(this, null);
                        band = false;          
                    }
                break;   
                case "Right":   
                        int total = grafo.Aristas.Count;
                            for (int i = 0; i < total; i++)
                            {
                                arista = grafo.Aristas[i];
                                if (arista.toca(pm))
                                {
                                    MenuArista.Enabled = true;
                                    MenuArista.ClientSize = new Size(50, 50);
                                    MenuArista.Visible = true;
                                    MenuArista.Show(Cursor.Position);
                                   break;
                                }

                            }
                break;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                        pm = e.Location;
                        band = false;
                        Form1_Paint(this, null);
            }
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            NodoP des;
            Graphics au;
            au = Graphics.FromImage(bmp1);
            au.Clear(BackColor);
            switch (accion)
            {
                case 1:
                     p = pm;
                     pm = e.Location;
                     band = true;
                     Form1_Paint(this, null);
                     band = false;    
                break;
                case 2:
                nu = null; 
                break;
                case 3:
                    des = (NodoP)grafo.Find(delegate(NodoP a) { if (e.Location.X > a.POS.X-15 && e.Location.X < a.POS.X + 30 && e.Location.Y > a.POS.Y-15 && e.Location.Y < a.POS.Y + 30)return true; else return false; });
                    if (des != null && nu != null)
                    {
                       // toolStrip4.Visible = true;
                        //ItemMetodos.Visible = true;
                        if (nu.insertaRelacion(des,grafo.Aristas.Count))
                        {
                            a = new Arista(tipoarista, nu, des, "e" + grafo.Aristas.Count.ToString());
                            grafo.AgregaArista(a);
                            nu.GRADO++;
                            des.GRADO++;
                            nu.GradoExterno++;
                            des.GradoInterno++;
                        }
                        if (tipoarista == 2 && a.Destino.NOMBRE!=a.Origen.NOMBRE)
                        {
                            des.insertaRelacion(nu, grafo.Aristas.Count-1);
                            des.GradoExterno++;
                            nu.GradoInterno++; 
                        }
                        if (coloreando == true)
                        {
                            grafo.colorear();

                        }
                        grafo.pinta(au);
                        band = false;
                        nu = null;

                        
                    }
                    else
                    {
                        grafo.pinta(au);
                    }
                    g.DrawImage(bmp1, 0, 0);
                break;
                case 4:
                    nu = (NodoP)grafo.Find(delegate(NodoP a) { if (e.Location.X > a.POS.X - 15 && e.Location.X < a.POS.X + 30 && e.Location.Y > a.POS.Y - 15 && e.Location.Y < a.POS.Y + 30)return true; else return false; });
                    if (nu != null)
                    {
                        grafo.RemueveNodo(nu);
                        band = true;
                        if (grafo.Count == 0)
                        {
                            nombre = 'A';
                            gactivo = false;
                        }
                        Form1_Paint(this, null);
                        band = false;
                    }
                break;
                case 7:
                case 9:
                case 8:
                    SeleccionaNodos();
                break;
            }
        }    
#endregion
        #region menus
        private void nuevoToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            nuevoToolStripMenuItem.HideDropDown();
            switch (e.ClickedItem.Name)
            {
                case "Nuevo":
                    band = false;
                  //  intercambioTool.Enabled = false;
                    mov = false;
                    BackColor = Color.White;
                    g.Clear(BackColor);
                //    Agrega.Enabled = true;
                 //   Kruskal.Visible=KruskalMenu.Visible = false;
                  //  ItemMetodos.Visible = false;
               //     caminoEulerInicio.Visible = false;
                 //   MueveNodo.Enabled=Mueve.Enabled = false;
                //    AgregaRelacion.Enabled=Dirigida.Enabled=NoDirigida.Enabled = false;
               //     EliminaNod.Enabled=EliminaNodo.Enabled = false;
               //     MueveGraf.Enabled = MueveGrafo.Enabled = false;
                    AristaNoDirigida.Enabled = true;
               //     toolStripButton5.Visible = false;
                    AristaDirigida.Enabled= true;
             //       EliminaAris.Enabled = EliminaArista.Enabled = false;
                    g2 = new Grafo();
                 //   ColoreaTool.Enabled = Colorear.Enabled = true;
                  //  EulerTool.Enabled = EulerMenu.Enabled = true;
                   // DijkstraCam.Enabled = DijkstraTool.Enabled = true;
                   // FloydTool.Enabled = CaminoFloyd.Enabled =true;
                   // toolStrip4.Visible = false;
            //        PropiedadesGrafo.Enabled=false;
                 //   toolStrip2.Visible = false;
                   // Colorear.Enabled = true;
                    grafo = new Grafo();
                    nombre = 'A';
                    gactivo = false;
                break;
                case "Abrir":
                       
                    OpenFileDialog filed = new OpenFileDialog();
                    filed.InitialDirectory = Application.StartupPath+"\\Ejemplos";
                    filed.DefaultExt = ".grafo";                    
                    string namefile;
                    filed.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
                    if (filed.ShowDialog() == DialogResult.OK)
                      {
                        namefile = filed.FileName;
                        
                        try
                        {
                            using (Stream stream = File.Open(namefile, FileMode.Open))
                            {
                               BinaryFormatter bin = new BinaryFormatter();
                               grafo = (Grafo)bin.Deserialize(stream);
                               grafo.pinta(g);
                            }
                        }
                        catch (IOException exe)
                        {
                            MessageBox.Show(exe.ToString());
                        }
                        g2 = new Grafo();
                  /*      AgregaRelacion.Enabled = Dirigida.Enabled=NoDirigida.Enabled = true;
                        Agrega.Enabled = true;
                        intercambioTool.Enabled = true;*/
                     //   toolStrip4.Visible = true;
                    //    ItemMetodos.Visible = true;
                        if (grafo.Aristas[0].Tipo == 1)
                        {
                        //    ColoreaTool.Enabled = Colorear.Enabled = true;
                          //  Kruskal.Visible=KruskalMenu.Visible = false;
                          //  DijkstraCam.Visible = DijkstraTool.Visible = true;
                         //   FloydTool.Visible = CaminoFloyd.Visible = true;
                     //       AristaDirigida.Enabled= Dirigida.Enabled = true;
                      //      AristaNoDirigida.Enabled = NoDirigida.Enabled = false;
                     //       EulerTool.Visible = false;
                     //       toolStripButton5.Visible = true;

                        }
                        else
                        {
                     //       toolStripButton5.Visible = false;
                          //  Kruskal.Visible=KruskalMenu.Visible = true;
                   /*         AristaNoDirigida.Enabled = NoDirigida.Enabled = true;
                            AristaDirigida.Enabled = Dirigida.Enabled = false; */
                           // ColoreaTool.Visible = Colorear.Visible = true;
                           // DijkstraCam.Visible = DijkstraTool.Visible = true;
                         //   FloydTool.Visible = CaminoFloyd.Visible = false;
                          //  EulerTool.Visible = EulerMenu.Visible = true;
                        }
         //               MueveGraf.Enabled = MueveGrafo.Enabled = true;
          //              MueveNodo.Enabled = Mueve.Enabled = true;
           //             EliminaNod.Enabled = EliminaNodo.Enabled = true;
            //            EliminaAris.Enabled = EliminaArista.Enabled = true;
                        
                        accion = 1;
               //         Agrega.Checked = AgregaNodo.Checked = true;
                //        Mueve.Checked = MueveNodo.Checked = false;
                //        MueveGraf.Checked = MueveGrafo.Checked = false;
                //        EliminaNod.Checked = EliminaNodo.Checked = false;
                //        EliminaAris.Checked = EliminaArista.Checked = false;
                 //       PropiedadesGrafo.Enabled = true;
               //         Colorear.Enabled = true;
                //        toolStrip2.Visible = false;
                        grafo.desseleccionar();
                        nombre = 'A';
                        for (int nn = 0; nn < grafo.Count; nn++)
                        {
                            nombre++;
                        }
                        
                    }
                break;
                case "Guardar":
                    SaveFileDialog sav = new SaveFileDialog();
                    sav.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
                    sav.InitialDirectory = Application.StartupPath + "\\ProyectosGrafo";
                    String nombr;
                    if (sav.ShowDialog() == DialogResult.OK)
                    {
                        nombr=sav.FileName;
                        try
                        {
                            using (Stream stream = File.Open(nombr, FileMode.Create))
                            {
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream,grafo);
                            }
                        }
                        catch (IOException exe)
                        {
                            MessageBox.Show(exe.ToString());
                        }
                    }
                break;
                case "BorraGrafo":
                    grafo = new Grafo();
                    g.Clear(BackColor);
                    g2 = new Grafo();
                    nombre = 'A';
                break;

                case "Salir":
                    System.Windows.Forms.Application.Exit();
                break;
            }
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
               
                case "Agrega":
                case "AgregaNodo":
                    pm = new Point();
                    
                    accion = 1;
          /*          Agrega.Checked=AgregaNodo.Checked = true;
                    Mueve.Checked = MueveNodo.Checked = false;
                    MueveGraf.Checked = MueveGrafo.Checked = false;
                    EliminaNod.Checked = EliminaNodo.Checked = false;
                    EliminaAris.Checked=EliminaArista.Checked = false;*/
                    
                    grafo.desseleccionar();
                break;
                case "Mueve":
                case "MueveNodo":
                    band = true;
                    accion = 2;
       /*             Mueve.Checked = MueveNodo.Checked = true;
                    Agrega.Checked=AgregaNodo.Checked = false;
                    EliminaNod.Checked = EliminaNodo.Checked = false;
                    MueveGraf.Checked = MueveGrafo.Checked = false;
                    EliminaAris.Checked=EliminaArista.Checked = false; */
             //       toolStrip2.Visible = false;
                    grafo.desseleccionar();
                break;
                case "EliminaNodo":
                case "EliminaNod":
                    accion = 4;
         /*           EliminaNod.Checked = EliminaNodo.Checked = true;
                    Mueve.Checked = MueveNodo.Checked = false;
                    Agrega.Checked=AgregaNodo.Checked = false;       
                    MueveGraf.Checked = MueveGrafo.Checked = false;
                    EliminaAris.Checked = EliminaArista.Checked = false; */
                //    toolStrip2.Visible = false;
                    grafo.desseleccionar();
                break;
                case "MueveGrafo":
                case "MueveGraf":
            //        MueveGraf.Checked = MueveGrafo.Checked = true;
             //       EliminaNod.Checked = EliminaNodo.Checked = false;
             //       Mueve.Checked = MueveNodo.Checked = false;
             //       Agrega.Checked=AgregaNodo.Checked = false;
              //      EliminaAris.Checked = EliminaArista.Checked = false;
                    accion = 5;
                //    toolStrip2.Visible = false;
                    grafo.desseleccionar();
                break;
                case "EliminaArista":
                    accion = 6;
           /*         EliminaAris.Checked = EliminaArista.Checked = true;
                    MueveGraf.Checked = MueveGrafo.Checked = false;
                    EliminaNod.Checked = EliminaNodo.Checked = false;
                    Mueve.Checked = MueveNodo.Checked = false;
                    Agrega.Checked=AgregaNodo.Checked = false;*/
                //    toolStrip2.Visible = false;
                    grafo.desseleccionar();
                break;
                case "PropiedadesGrafo":
                     Form f;
                     if(AristaDirigida.Enabled==false)
                        f = new Form3(grafo,2);
                     else
                        f = new Form3(grafo,1);
                     f.Activate();
                     f.Show();
                  //   toolStrip2.Visible = false;
                     grafo.desseleccionar();
                break;
                case "caminoEulerInicio":
                if (destin != null && orig != null)
                {
                    List<NodoP> x = new List<NodoP>();
                    g2 = new Grafo(grafo);
                    if (Dijks != 1 && flo != 1)
                    {
                        List<NodoP> caminito = new List<NodoP>();
                        grafo.Circuito(orig, destin, grafo.Aristas.Count, caminito);
                        caminito.Add(orig);
                        if (caminito.Count == 0)
                            MessageBox.Show("No Hay camino euleriano entre esos vertices");
                        else
                        {

                            time.Interval = 300;
                            time.Enabled = true;


                            for (int ci = 0; ci < 15; ci++)
                            {
                                Arista ari = new Arista(); ;
                                Grafo g3 = new Grafo(g2);
                                g3.Aristas.Clear();
                                foreach (NodoP rel in g3)
                                {
                                    rel.relaciones.Clear();
                                }
                                for (int i = caminito.Count - 1; i >= 0; i--)
                                {
                                    if (i > 0)
                                    {
                                        g3.Find(delegate(NodoP d) { if (d.NOMBRE == caminito[i].NOMBRE)return true; else return false; }).insertaRelacion(g3.Find(delegate(NodoP o) { if (o.NOMBRE == caminito[i - 1].NOMBRE)return true; else return false; }), g3.Aristas.Count);
                                        ari = new Arista(1, g3.Find(delegate(NodoP d) { if (d.NOMBRE == caminito[i].NOMBRE)return true; else return false; }), g3.Find(delegate(NodoP o) { if (o.NOMBRE == caminito[i - 1].NOMBRE)return true; else return false; }), "e" + (caminito.Count - i).ToString());
                                        g3.AgregaArista(ari);
                                    }
                                    g.Clear(BackColor);
                                    g3.pinta(g);
                                    for (int c = 0; c < 10000000; c++)
                                    {
                                    }
                                }

                            }

                            grafo.pinta(g);
                        }


                    }
                    else
                    {
                        if (Dijks == 1)
                        {
                            int[] c = new int[grafo.Count];
                            string caminitos = "";
                            if(orig==null || destin==null)
                            {
                                MessageBox.Show("No se ha seleccionado un nodo destino o un nodo origen");
                                break;
                            }
                            c = grafo.Dijkstra(orig,ref camino);
                            foreach (int camii in c)
                            {
                                if (camii != 10000000)
                                    caminitos += " " + camii.ToString();
                                else
                                {
                                    caminitos += " " + "∞";
                                }
                            }
                            caminitos += Environment.NewLine;
                            foreach(string[] camii in camino)
                            {
                                caminitos += " "+camii[0]+":" + camii[1]; 
                            }
                            MessageBox.Show(caminitos);
                            g2 = new Grafo(grafo);
                            grafo.dejaCaminoDijkstra(camino,c,orig,destin);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor selecciona el nodo para sacar sus caminos");
                }
                break;
                case "intercambio":
                case "intercambioTool":
                    int cont=0;
                    char name='A';
                    bool num;
                    int aux;
                    if((int.TryParse(grafo[0].NOMBRE.ToString(),out aux))==true)
                        num=true;
                    else
                        num=false;
                    if (num == true)
                    {
                        foreach (NodoP cambio in grafo)
                        {
                            cambio.NOMBRE = name.ToString();
                            name++;
                        }
                        nombre = 'A';
                        for (int i = 0; i < grafo.Count; i++)
                            nombre++;
                    }
                    else
                    {
                        numero = grafo.Count;
                        foreach (NodoP cambio in grafo)
                        {
                            cambio.NOMBRE = cont.ToString();
                            cont++;
                        }
                    }
                break;
                case "cierraEuler":
                    time.Stop();
                    coloreando = false;
                    grafo.desColorea(resp);
                  //  trackBar1.Visible = false;
                    if (g2.Count > 1)
                    {
                        grafo = new Grafo(g2);
                        g2 = new Grafo();
                    }
                    if (gis!=null)
                        gis = null;
                    grafo.bosque = false;
                    foreach(Arista qt in grafo.Aristas)
                    {
                        qt.bosqueT = 0;
                    }
                    band = false;
                    grafo.pinta(g);
              /*      caminoEulerInicio.Visible = false;
                    toolStrip2.Hide();
                    cierraEuler.Visible = false;
                    AgregaRelacion.Enabled = true;
                    Agrega.Enabled = true;
                    MueveGraf.Enabled = MueveGrafo.Enabled = true;
                    MueveNodo.Enabled = Mueve.Enabled =true;
                    EliminaNod.Enabled = EliminaNodo.Enabled = true;
                    EliminaAris.Enabled = EliminaArista.Enabled = true;
                    PropiedadesGrafo.Enabled = true;*/
                    orig = null;
                    destin = null;
            //        if (tipoarista == 1)
               //         Dirigida.Enabled = true;
              //      else
                //        NoDirigida.Enabled = true;
                    pm = new Point();
                    accion = 0;
                break;
                case "Dirigida":
                    accion = 3;
             //       toolStripButton5.Visible = true;
                    band = true;
             //       Mueve.Checked = MueveNodo.Checked = false;
             //       intercambioTool.Enabled = true;
             //       Agrega.Checked = AgregaNodo.Checked = false;
             //       EliminaNod.Checked = EliminaNodo.Checked = false;
             //       MueveGraf.Checked = MueveGrafo.Checked = false;
             //       EliminaAris.Checked = EliminaArista.Checked = false;
                    AgregaRelacion.Checked = true;
             //       toolStrip2.Visible = false;
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    fl.StartCap = LineCap.RoundAnchor;
                    fl.Width = 4;
                    tipoarista = 1;
             //       AristaNoDirigida.Enabled=NoDirigida.Enabled = false;
              //      Dirigida.Checked=AristaDirigida.Checked = true;
                   // DijkstraCam.Visible = true;
                   // CaminoFloyd.Visible = true;
                    grafo.desseleccionar();
                  //  ColoreaTool.Visible = Colorear.Visible = true;
                  //  DijkstraCam.Visible = DijkstraTool.Visible = true;
                //    FloydTool.Visible = CaminoFloyd.Visible = true;
                  //  EulerMenu.Visible = EulerTool.Visible = false;
                   // Kruskal.Visible=KruskalMenu.Visible = false;
                   
                break;
                case "NoDirigida":
                    accion = 3;
                    band = true;
           /*         Mueve.Checked = MueveNodo.Checked = false;
                    intercambioTool.Enabled = true;
                    Agrega.Checked = AgregaNodo.Checked = false;
                    EliminaNod.Checked = EliminaNodo.Checked = false;
                    MueveGraf.Checked = MueveGrafo.Checked = false;
                    EliminaAris.Checked = EliminaArista.Checked = false;*/
                    AgregaRelacion.Checked = true;
            //        toolStrip2.Visible = false;
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                    fl.StartCap = LineCap.NoAnchor;
                    fl.Width = 4;
                    tipoarista = 2;
                    grafo.desseleccionar();
                 //   AristaDirigida.Enabled=Dirigida.Enabled = false;
                  //  NoDirigida.Checked = AristaNoDirigida.Checked = false;
                                  

                  //  ColoreaTool.Visible = Colorear.Visible = true;
                  //  EulerTool.Visible = EulerMenu.Visible = true;
                  //  DijkstraCam.Visible = DijkstraTool.Visible = true;
                  //  FloydTool.Visible = CaminoFloyd.Visible = false;
                 /*   DijkstraCam.Visible = false;
                    CaminoFloyd.Visible = false;
                    Kruskal.Visible=KruskalMenu.Visible = true;*/
                    break;

            }
        }

        private void RelacionClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            accion = 3;
            band = true;
   /*         Mueve.Checked = MueveNodo.Checked = false;
            intercambioTool.Enabled = true;
            Agrega.Checked = AgregaNodo.Checked = false;
            EliminaNod.Checked = EliminaNodo.Checked = false;
            MueveGraf.Checked = MueveGrafo.Checked = false;
            EliminaAris.Checked = EliminaArista.Checked = false;*/
            AgregaRelacion.Checked = true;
        //    toolStrip2.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "Dirigida":
                case "AristaDirigida":
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    fl.StartCap = LineCap.RoundAnchor;
                    fl.Width = 4;
                    tipoarista = 1;
             //       AristaNoDirigida.Enabled=NoDirigida.Enabled = false;
              //      Dirigida.Checked=AristaDirigida.Checked = true;
                  //  DijkstraCam.Visible = true;
                  //  CaminoFloyd.Visible = true;
                    grafo.desseleccionar();
             /*       ColoreaTool.Visible = Colorear.Visible = true;
                    DijkstraCam.Visible = DijkstraTool.Visible = true;
                    FloydTool.Visible = CaminoFloyd.Visible = true;
                    EulerMenu.Visible = EulerTool.Visible = false;
                    Kruskal.Visible=KruskalMenu.Visible = false;*/
                    break;
                case "NoDirigida":
                case "AristaNoDirigida":
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                    fl.StartCap = LineCap.NoAnchor;
                    fl.Width = 4;
                    tipoarista = 2;
                    grafo.desseleccionar();
               //     AristaDirigida.Enabled=Dirigida.Enabled = false;
               //     NoDirigida.Checked = AristaNoDirigida.Checked = false;
                    
              /*      ColoreaTool.Visible = Colorear.Visible = true;
                    EulerTool.Visible = EulerMenu.Visible = true;
                    DijkstraCam.Visible = DijkstraTool.Visible = true;
                    FloydTool.Visible = CaminoFloyd.Visible = false;
                    DijkstraCam.Visible = false;
                    CaminoFloyd.Visible = false;
                    Kruskal.Visible=KruskalMenu.Visible = true;*/
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (gactivo == true)
                if (MessageBox.Show("Deseas Guardar Antes de Salir?", "Editor de Grafos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFileDialog sav = new SaveFileDialog();
                    sav.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
                    String nombr;
                    if (sav.ShowDialog() == DialogResult.OK)
                    {
                        nombr = sav.FileName;
                        try
                        {
                            using (Stream stream = File.Open(nombr, FileMode.Create))
                            {
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream, grafo);
                            }
                        }
                        catch (IOException exe)
                        {
                            MessageBox.Show(exe.ToString());
                        }
                    }
                    else
                        e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
        }

        private void AyudaItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           // ayudaToolStripMenuItem.HideDropDown();
            switch (e.ClickedItem.Name)
            {
                case "Acercade":
                    MessageBox.Show(" ");
                break;
            }

        }

        private void ColorItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Configuracion.HideDropDown();
            ColorDialog a = new ColorDialog();
            switch (e.ClickedItem.Name)
            {
                case "ColArista":
                    if (a.ShowDialog() == DialogResult.OK)
                    {
                        if (fl.EndCap == System.Drawing.Drawing2D.LineCap.ArrowAnchor)
                            grafo.ColorAristaDi = a.Color;
                        else
                            grafo.ColorAristaNoDi = a.Color;
                    }
                    break;
                case "ColNodo":
                    if (a.ShowDialog() == DialogResult.OK)
                    {
                        foreach (NodoP ccol in grafo)
                        {
                            ccol.COLOR = a.Color;
                        }
                    }
                    break;
            }
            Form1_Paint(this, null);
        }

        private void Metodos_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           // ItemMetodos.HideDropDown();
            
           
                switch (e.ClickedItem.Name)
                {

                    case "Kruskal":
                    case "KruskalMenu":
                        grafo.desColorea(resp);
                        coloreando = false;
                        if (grafo.Componentes() == 1)
                        {
                            if (grafo.Aristas.FindAll(delegate(Arista cer) { if (cer.PESO == 0)return true; else return false; }).Count != grafo.Aristas.Count)
                            {
                                if (g2.Count < 1)
                                    g2 = new Grafo(grafo);
                                else
                                {
                                    grafo = new Grafo(g2);
                                    orig = null;
                                    destin = null;
                                    g2 = new Grafo(grafo);
                                }
                  //              cierraEuler.Visible = true;
                                g.Clear(BackColor);
                                grafo = grafo.Kruskal();
                                grafo.pinta(g);
                            }
                            else
                                MessageBox.Show("Las aristas no tienen peso");
                        }
                        else
                        {
                            MessageBox.Show("Grafo no conectado");
                        }

                    break;
                    case "Colorear":
                    case "ColoreaTool":
                    if (grafo.Componentes() == 1)
                    {
                        coloreando = true;
                        resp = grafo[0].COLOR;
                        grafo.Sort(delegate(NodoP ord, NodoP ordb) { return (ordb.GRADO.CompareTo(ord.GRADO)); });
                        grafo.colorear();
                        grafo.pinta(g);
                        Coloreado formilla = new Coloreado(grafo.colorear());

                        formilla.Show();
            //            cierraEuler.Visible = true;
                    }
                    else
                        MessageBox.Show("Grafo no conectado");
                    break;
                    case "DijkstraCam":
                    case "DijkstraTool":
                        coloreando = false;
                        grafo.desColorea(resp);
                    if (grafo.Aristas.FindAll(delegate(Arista cer) { if (cer.PESO == 0)return true; else return false; }).Count != grafo.Aristas.Count)
                    {
                        if (g2.Count < 1)
                            g2 = new Grafo(grafo);
                        else
                        {
                            grafo = new Grafo(g2);
                            orig = null;
                            destin = null;
                            g2 = new Grafo(grafo);
                        }
                        MessageBox.Show("Clickea el nodo para sacar sus caminos mas cortos \nDespués presiona iniciar en la barra de herramientas(Botón verde)");
                        accion = 9;
                        Dijks = 1;
               //         caminoEulerInicio.Visible = true;
               //         cierraEuler.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("Las aristas no tienen peso");   
                    }
   
                    break;
                    case "CaminoFloyd":
                    case "FloydTool":
                        coloreando = false;
                        grafo.desColorea(resp);
                        if (grafo.Aristas.FindAll(delegate(Arista cer) { if (cer.PESO == 0)return true; else return false; }).Count != grafo.Aristas.Count)
                        {
                            Form4 fo4 = new Form4(grafo);
                            fo4.Show();
                        }
                        else
                            MessageBox.Show("Las aristas no tiene peso");

                        break;
                    case "CentroGrafo":
                    case "CentroGrafoTool":
                        coloreando = false;
                        grafo.desColorea(resp);
                        if (grafo.Aristas.FindAll(delegate(Arista cer) { if (cer.PESO == 0)return true; else return false; }).Count != grafo.Aristas.Count)
                        {
                            if (g2.Count < 1)
                                g2 = new Grafo(grafo);
                            else
                            {
                                grafo = new Grafo(g2);
                                orig = null;
                                destin = null;
                                g2 = new Grafo(grafo);
                            }
                            MessageBox.Show("el centro del grafo es " + grafo.centroGrafo().NOMBRE.ToString());
                        }
                        else
                            MessageBox.Show("Las aristas no tiene peso");
                    break;
                    case "ClasificacionTopo":
                    case "ClasificacionTopoTool":
                        //if (componentes() == 1)
                        coloreando = false;
                        grafo.desColorea(resp);
                        {
                            g.Clear(BackColor);
                            NodoP nodoRef = new NodoP();
                            NodoP nodoRef2 = new NodoP();
                            if (g2.Count < 1)
                                g2 = new Grafo(grafo);
                            else
                            {
                                grafo = new Grafo(g2);
                                orig = null;
                                destin = null;
                                g2 = new Grafo(grafo);
                            }
                            string a = "";
                            string b = "";
                            foreach (NodoP ct in grafo)
                            {
                                if (ct.VISITADO != true)
                                    a += grafo.clasifiacionTopologica(ct);

                            }
                            foreach (NodoP dv in grafo)
                            {
                                dv.VISITADO = false;
                            }
                            for (int cou = a.Length - 1; cou >= 0; cou--)
                            {
                                b += a[cou];
                            }
                            grafo.Aristas.Clear();
                            for (int cCl = 0; cCl < b.Length; cCl++)
                            {
                                if (cCl < b.Length - 1)
                                {
                                    nodoRef = grafo.Find(delegate(NodoP c) { if (c.NOMBRE == b[cCl].ToString())return true; else return false; });
                                    nodoRef2 = grafo.Find(delegate(NodoP c) { if (c.NOMBRE == b[cCl + 1].ToString())return true; else return false; });
                                    Arista nueva = new Arista(1, nodoRef, nodoRef2, "e ");
                                    nodoRef.POS = new Point((90 * cCl) + 90, 200);
                                    nodoRef2.POS = new Point(nodoRef.POS.X + 90, 200);
                                    grafo.Aristas.Add(nueva);
                                }
                            }
                            grafo.Find(delegate(NodoP nr) { if (nr.NOMBRE == b[0].ToString())return true; else return false; });
                            grafo.pinta(g);
                        }
                       // else
                         //   MessageBox.Show("Grafo no conectado");
                    break;
                    case "grafoPlano":
                        {
                            if (g2.Count < 1)
                                g2 = new Grafo(grafo);
                            else
                            {
                                grafo = new Grafo(g2);
                                orig = null;
                                destin = null;
                                g2 = new Grafo(grafo);
                            }
                            if (grafo.Aristas.Count >= ((3 * grafo.Count) - 6))
                            {
                                MessageBox.Show("No plano por corolario 1: E<=3V-6= " + ((3 * grafo.Count) - 6).ToString());
                                // g.DrawString("No plano por corolario 1: E<=3V-6= " + ((3 * grafo.Count) - 6).ToString(),new Font("Arial",10),Brushes.Black,ClientRectangle.Width-600,ClientRectangle.Height-70);

                                if (grafo.Aristas.Count >= ((2 * grafo.Count) - 4))
                                {
                                    MessageBox.Show("No plano por corolario 1: E<=2V-4= " + ((2 * grafo.Count) - 4).ToString());
                                    // g.DrawString("No plano por corolario 1: E<=2V-4= " + ((2 * grafo.Count) -4).ToString(), new Font("Arial", 10), Brushes.Black, ClientRectangle.Width - 600, ClientRectangle.Height - 20);
                                }
                            }
                        }
                        break;
                    case "VerticesCut":
                    case "Cut":
                           coloreando = false;
                    grafo.desColorea(resp);
                        if (componentes() == 1)
                        {
                            if (g2.Count < 1)
                                g2 = new Grafo(grafo);
                            else
                            {
                                grafo = new Grafo(g2);
                                orig = null;
                                destin = null;
                                g2 = new Grafo(grafo);
                            }
                            List<NodoP> cuts = new List<NodoP>();
                            String cus = "";
                            cuts = grafo.verticesCut();
                            foreach (NodoP cu in cuts)
                            {
                                cus += cu.NOMBRE.ToString() + " ";
                                cu.SELECCIONADO = true;
                            }
                            grafo.pinta(g);
                            if (cuts.Count > 0)
                                MessageBox.Show("Los Vertices " + cus + "Son Cut");
                            else
                                MessageBox.Show("El grafo no tiene vertices cut");
                            grafo.desseleccionar();
                            g2 = new Grafo();
                            grafo.pinta(g);
                        }
                        else
                            MessageBox.Show("Grafo no conectado");
                    break;
                    case "EulerTool":
                    case "EulerMenu":
                     if (componentes() == 1)
                     {
                         if (g2.Count < 1)
                             g2 = new Grafo(grafo);
                         else
                         {
                             grafo = new Grafo(g2);
                             orig = null;
                             destin = null;
                         }
                         CCE = new List<NodoP>();
              /*           trackBar1.Location = new Point(ClientRectangle.Width - 150, 65);
                         trackBar1.Size = new Size(150, 40);
                         trackBar1.BackColor = Color.Blue;
                         trackBar1.Cursor = Cursors.Default;
                         trackBar1.TickStyle = TickStyle.BottomRight;
                         trackBar1.Value = 0;
                         trackBar1.Maximum = 250;
                         trackBar1.Visible = true;*/
                         //ItemMetodos.HideDropDown();
                         flo = 0;
                         Dijks = 0;
                         List<NodoP> caminito = new List<NodoP>(), dob = new List<NodoP>();
                                 dob = grafo.FindAll(delegate(NodoP no) { if (no.GRADO % 2 == 0)return false; else return true; });
                                 // g2 = new Grafo(grafo);
                                 if (dob.Count > 2)
                                 {
                                     MessageBox.Show("El grafo no tiene camino ni circuito Euleriano");
                                     //trackBar1.Hide();
                                     grafo = new Grafo(g2);
                                     g2 = new Grafo();
                                 }
                                 else
                                 {
                               /*      AgregaRelacion.Enabled = Dirigida.Enabled = NoDirigida.Enabled = false;
                                     Agrega.Enabled = false;
                                     MueveGraf.Enabled = MueveGrafo.Enabled = false;
                                     MueveNodo.Enabled = Mueve.Enabled = false;
                                     EliminaNod.Enabled = EliminaNodo.Enabled = false;
                                     EliminaAris.Enabled = EliminaArista.Enabled = false;

                                     PropiedadesGrafo.Enabled = false;
                                     cierraEuler.Visible = true;*/
                                     grafo.Sort(delegate(NodoP orden, NodoP orden2) { return ((orden2.GRADO.CompareTo(orden.GRADO))); });
                                     if (dob.Count > 0)
                                     {
                                         MessageBox.Show("El grafo tiene solamente camino Euleriano \nda click en Aceptar para comenzar simulación");
                                         orig = dob[0];
                                         destin = dob[1];
                                         orig.SELECCIONADO = true;
                                         destin.SELECCIONADO = true;
                                     }
                                     else
                                     {
                                         MessageBox.Show("El grafo tiene Circuito \nda click en Aceptar para comenzar simulación"); 
                                         orig = grafo[grafo.Count - 1];
                                         //orig = grafo[0];
                                         orig.SELECCIONADO = true;
                                         destin = orig;
                                     }
                                     accion = 8;

                                     grafo.Circuito(orig, destin, grafo.Aristas.Count, caminito);
                                     caminito.Add(orig);
                                     CCE = caminito;
                                     if (caminito.Count == 0)
                                     {
                                         MessageBox.Show("No Hay camino euleriano entre esos vertices");
                                   //      trackBar1.Hide();
                                         grafo = new Grafo(g2);
                                         g2 = new Grafo();
                                     }
                                     else
                                     {
                                         grafo.Aristas.Clear();
                                         accion = 14;
                                         band = true;
                                         bandcam = true;
                                         icam = CCE.Count;
                                         this.Form1_Paint(this, null);
                                         time.Enabled = true;
                                         time.Interval = 300;
                                         time.Start();

                                     }

                                 }
                             
                         foreach (NodoP d in g2)
                         {
                             foreach (NodoRel rel in d.relaciones)
                             {
                                 rel.VISITADA = false;
                             }
                         }
                     }
                     else
                         MessageBox.Show("Grafo no conectado");
                     break;
                }
            
        }

        private void MatrizInf_itemCicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (componentes() == 1)
            {
           //     toolStrip2.Visible = true;
                accion = 7;
                nu = null;
                orig = null;
                destin = null;
                switch (e.ClickedItem.Name)
                {
                    case "CaminosRecursivo":
                        camin = 1;
                        break;
                    case "CaminosMultiplicacion":
                        camin = 2;
                        break;
                }
     //           cierraEuler.Visible = true;

            }
            else
                MessageBox.Show("Grafo no conectado");
        }

        private void IniciaCamino_Click(object sender, EventArgs e)
        {
            int[] c = new int[grafo.Count];
            coloreando = false;
            grafo.desColorea(resp);
            if (orig != null && destin != null)
                switch (camin)
                {

                    case 1:
                        try
                        {
                   //         MessageBox.Show("hay " + (grafo.CaminosRecursivo(orig, destin, int.Parse(nCaminos.Text))).ToString() + " Caminos");
                        }
                        catch (Exception w)
                        {
                            MessageBox.Show("Debe introducir un número entero");
                        }
                        break;
                    case 2:
                //        MessageBox.Show("hay " + (grafo.MatrizInfinita(orig, destin, int.Parse(nCaminos.Text), ProgresoMatriz)).ToString() + " Caminos");
                   //     ProgresoMatriz.Value = 0;
                        break;
                    case 3:

                        break;
                }
            else
                MessageBox.Show("Por favor seleccione los vertices destino y origen");
        }

        private void Euler_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
           
        }

        private void Ver_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "NombreAristas":
                    if (grafo.NombreAristasVisible)
                    {
                        grafo.NombreAristasVisible = false;
                    }
                    else
                    {
                        grafo.NombreAristasVisible = true;
                    }
                    grafo.pinta(g);
                    break;
                case "PesoAristas":
                    if (grafo.PesoAristasVisible)
                    {
                        grafo.PesoAristasVisible = false;
                    }
                    else
                    {
                        grafo.PesoAristasVisible = true;
                    }
                    grafo.pinta(g);
                    break;

            }

        }

        private void editar_Click(object sender, EventArgs e)
        {
            Form2 ed = new Form2(grafo);
            ed.Activate();
            ed.Show();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void Especiales_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) //especiales
        {
           
            switch (e.ClickedItem.Name)
            {
                case "kn":
                    int nVer;
                    char no = 'A';
                    Form5 f5 = new Form5(3);
                    if (f5.ShowDialog() != DialogResult.None)
                    {
                        g.Clear(BackColor);
                        grafo = new Grafo();
                        g2 = new Grafo();
                /*        AgregaNodo.Enabled = Agrega.Enabled = true;
                        Mueve.Enabled = MueveNodo.Enabled = true;
                        intercambioTool.Enabled = true;
                        MueveGraf.Enabled = MueveGrafo.Enabled = true;
                        EliminaAris.Enabled = EliminaArista.Enabled = true;
                        EliminaNod.Enabled = EliminaNodo.Enabled = true;
                        Dirigida.Enabled = AristaDirigida.Enabled = false;
                        NoDirigida.Enabled = AristaNoDirigida.Enabled = true; */
                    //    EulerTool.Visible = EulerMenu.Visible = true;
                     //   Colorear.Visible = ColoreaTool.Visible = true;
                     //   Kruskal.Visible = KruskalMenu.Visible = true;
              //          Dirigida.Enabled=NoDirigida.Enabled = AgregaRelacion.Enabled = true;
               //         Dirigida.Enabled=AristaDirigida.Enabled=false;
                      //  DijkstraCam.Visible = DijkstraTool.Visible = true;
                      //  FloydTool.Visible = CaminoFloyd.Visible = false;
                      //  DijkstraCam.Visible = true;
                      //  CaminoFloyd.Visible = false;
                  //      PropiedadesGrafo.Enabled = true;
                        tipoarista = 2;
                  //      toolStrip4.Visible = true;
                     //   ItemMetodos.Visible = true;
                        nVer = f5.N;
                        if (nVer > 1)
                        {
                            double ang = 0;
                            double inc = (360 / nVer) * Math.PI / 180;
                            List<char> listAux = new List<char>();

                            grafo = new Grafo();
                            for (int i = 0; i < nVer; i++)
                            {
                                float x = this.Size.Width / 2 + (float)((Math.Cos(ang)) * (150));
                                float y = this.Size.Height / 2 + (float)((Math.Sin(ang)) * (150));

                                listAux.Add(no);
                                grafo.Add(new NodoP(new Point((int)x, (int)y), no));

                                ang += inc;
                                no++;
                            }
                            listAux.RemoveAt(0);
                            foreach (NodoP v in grafo)
                            {
                                foreach (char c in listAux)
                                {
                                    NodoP verAux = grafo.Find(delegate(NodoP nodi) { if (nodi.NOMBRE == c.ToString())return true; else return false; }); ;
                                    if (v.insertaRelacion(verAux, grafo.Aristas.Count))
                                    {
                                        a = new Arista(tipoarista, v, verAux, "e" + grafo.Aristas.Count.ToString());
                                        grafo.AgregaArista(a);
                                        v.GRADO++;
                                        verAux.GRADO++;
                                        v.GradoExterno++;
                                        verAux.GradoInterno++;
                                    }

                                    verAux.insertaRelacion(v, grafo.Aristas.Count - 1);
                                    verAux.GradoExterno++;
                                    v.GradoInterno++;
                                }
                                if (listAux.Count != 0)
                                    listAux.RemoveAt(0);
                            }
                            grafo.pinta(g);
                            nombre = 'A';
                            for (int nn = 0; nn < grafo.Count; nn++)
                            {
                                nombre++;
                            }
                        }
                    }
                    break;
                case "cn":
                    f5 = new Form5(3);
                    NodoP v1 = null, v2 = null;
                    int nV;

                    if (f5.ShowDialog() != DialogResult.None)
                    {
                        g.Clear(BackColor);
                        grafo = new Grafo();
                        g2 = new Grafo();
                 /*       AgregaNodo.Enabled = Agrega.Enabled = true;
                        Mueve.Enabled = MueveNodo.Enabled = true;
                        intercambioTool.Enabled = true;
                        MueveGraf.Enabled = MueveGrafo.Enabled = true;
                        EliminaAris.Enabled = EliminaArista.Enabled = true;
                        EliminaNod.Enabled = EliminaNodo.Enabled = true;
                        Dirigida.Enabled = AristaDirigida.Enabled = false;
                        NoDirigida.Enabled = AristaNoDirigida.Enabled = true; */
                       // EulerTool.Visible = EulerMenu.Visible = true;
                   //     Colorear.Visible = ColoreaTool.Visible = true;
                  //      Kruskal.Visible = KruskalMenu.Visible = true;
               //         Dirigida.Enabled=NoDirigida.Enabled = AgregaRelacion.Enabled = true;
                //        Dirigida.Enabled = AristaDirigida.Enabled = false;
                  //      DijkstraCam.Visible = DijkstraTool.Visible = true;
                   //     FloydTool.Visible = CaminoFloyd.Visible = false;
                   /*     DijkstraCam.Visible = true;
                        CaminoFloyd.Visible = false;*/
                        
                 //       PropiedadesGrafo.Enabled = true;
                        tipoarista = 2;
                 //       toolStrip4.Visible = true;
                        //ItemMetodos.Visible = true;
                        nV = f5.N;
                        no = 'A';
                        double teta = 0;

                        if (nV > 1)
                        {
                            double inc = (360 / nV) * Math.PI / 180;


                            for (int i = 0; i < nV; i++)
                            {
                                float x = this.Size.Width / 2 + (float)((Math.Cos(teta)) * (150));
                                float y = this.Size.Height / 2 + (float)((Math.Sin(teta)) * (150));


                                v1 = new NodoP(new Point((int)x, (int)y), no);

                                if (v2 != null)
                                {
                                    if (v1.insertaRelacion(v2, grafo.Aristas.Count))
                                    {
                                        a = new Arista(tipoarista, v1, v2, "e" + grafo.Aristas.Count.ToString());
                                        grafo.AgregaArista(a);
                                        v1.GRADO++;
                                        v2.GRADO++;
                                        v1.GradoExterno++;
                                        v2.GradoInterno++;
                                    }

                                    v2.insertaRelacion(v1, grafo.Aristas.Count - 1);
                                    v2.GradoExterno++;
                                    v1.GradoInterno++;
                                }

                                grafo.AgregaNodo(v1);
                                v2 = v1;
                                teta += inc;
                                no++;
                            }
                            a = new Arista(2, v1, grafo[0], "e");
                            v1.insertaRelacion(grafo[0], grafo.Count);
                            grafo[0].insertaRelacion(v1, grafo.Count);
                            v1.GRADO++;
                            v1.GradoExterno++;
                            v1.GradoInterno++;
                            grafo[0].GRADO++;
                            grafo[0].GradoExterno++;
                            grafo[0].GradoInterno++;
                            grafo.AgregaArista(a);
                        }
                        grafo.pinta(g);
                        nombre = 'A';
                        for (int nn = 0; nn < grafo.Count; nn++)
                        {
                            nombre++;
                        }
                    }

                    break;
                case "wn":

                     f5 = new Form5(3);
                    v1 =  v2 = null;
                    

                    if (f5.ShowDialog() != DialogResult.None)
                    {
                        g.Clear(BackColor);
                        grafo = new Grafo();
                        g2 = new Grafo();
            /*            AgregaNodo.Enabled = Agrega.Enabled = true;
                        Mueve.Enabled = MueveNodo.Enabled = true;
                        intercambioTool.Enabled = true;
                        MueveGraf.Enabled = MueveGrafo.Enabled = true;
                        EliminaAris.Enabled = EliminaArista.Enabled = true;
                        EliminaNod.Enabled = EliminaNodo.Enabled = true;
                        Dirigida.Enabled = AristaDirigida.Enabled = false;
                        NoDirigida.Enabled = AristaNoDirigida.Enabled = true; */
                       // EulerTool.Visible = EulerMenu.Visible = true;
                       // Colorear.Visible = ColoreaTool.Visible = true;
                       // Kruskal.Visible = KruskalMenu.Visible = true;
                //        Dirigida.Enabled=NoDirigida.Enabled = AgregaRelacion.Enabled = true;
                 //       Dirigida.Enabled = AristaDirigida.Enabled = false;
                   /*     DijkstraCam.Visible = DijkstraTool.Visible = true;
                        FloydTool.Visible = CaminoFloyd.Visible = false;
                        DijkstraCam.Visible = true;
                        CaminoFloyd.Visible = false;*/
                  //      PropiedadesGrafo.Enabled = true;
                        tipoarista = 2;
                //        toolStrip4.Visible = true;
                     //   ItemMetodos.Visible = true; 
                        nV = f5.N;
                        no = 'A';
                        double teta = 0;

                        if (nV > 1)
                        {
                            double inc = (360 / nV) * Math.PI / 180;


                            for (int i = 0; i < nV; i++)
                            {
                                float x = this.Size.Width / 2 + (float)((Math.Cos(teta)) * (150));
                                float y = this.Size.Height / 2 + (float)((Math.Sin(teta)) * (150));


                                v1 = new NodoP(new Point((int)x, (int)y), no);

                                if (v2 != null)
                                {
                                    if (v1.insertaRelacion(v2, grafo.Aristas.Count))
                                    {
                                        a = new Arista(tipoarista, v1, v2, "e" + grafo.Aristas.Count.ToString());
                                        grafo.AgregaArista(a);
                                        v1.GRADO++;
                                        v2.GRADO++;
                                        v1.GradoExterno++;
                                        v2.GradoInterno++;
                                    }

                                    v2.insertaRelacion(v1, grafo.Aristas.Count - 1);
                                    v2.GradoExterno++;
                                    v1.GradoInterno++;
                                }

                                grafo.AgregaNodo(v1);
                                v2 = v1;
                                teta += inc;
                                no++;
                            }
                            a = new Arista(2, v1, grafo[0], "e");
                            v1.insertaRelacion(grafo[0], grafo.Count);
                            grafo[0].insertaRelacion(v1, grafo.Count);
                            v1.GRADO++;
                            v1.GradoExterno++;
                            v1.GradoInterno++;
                            grafo[0].GRADO++;
                            grafo[0].GradoExterno++;
                            grafo[0].GradoInterno++;
                            grafo.AgregaArista(a);
                        }
                       
                        nombre = 'A';
                        for (int nn = 0; nn < grafo.Count; nn++)
                        {
                            nombre++;
                        }
                        v1 = new NodoP(new Point(this.Size.Width / 2, this.Size.Height / 2), nombre);
                       
                        foreach (NodoP pwn in grafo)
                        {
                            a = new Arista(2, v1, pwn, "e");
                            v1.insertaRelacion(pwn, grafo.Count);
                            pwn.insertaRelacion(v1, grafo.Count);
                            v1.GRADO++;
                            v1.GradoExterno++;
                            v1.GradoInterno++;
                            pwn.GRADO++;
                           pwn.GradoExterno++;
                            pwn.GradoInterno++;
                            grafo.AgregaArista(a);
                        }
                        grafo.AgregaNodo(v1);
                        grafo.pinta(g);
                    }


                    break;
                case "Petersen":
                        try
                        {
                            using (Stream stream = File.Open(Application.StartupPath + "\\Ejemplos" + "\\Petersen.grafo", FileMode.Open))
                            {
                               BinaryFormatter bin = new BinaryFormatter();
                               grafo = (Grafo)bin.Deserialize(stream);
                               grafo.pinta(g);
                            }
                        }
                        catch (IOException exe)
                        {
                            MessageBox.Show(exe.ToString());
                        }
                        g2 = new Grafo();
             /*           AgregaRelacion.Enabled = Dirigida.Enabled=NoDirigida.Enabled = true;
                        Agrega.Enabled = true;
                        intercambioTool.Enabled = true;*/
                //        toolStrip4.Visible = true;
                   //     ItemMetodos.Visible = true;
                        {
                      //      Kruskal.Visible=KruskalMenu.Visible = true;
                     //       AristaNoDirigida.Enabled = NoDirigida.Enabled = true;
                      //      AristaDirigida.Enabled = Dirigida.Visible = false;
                        /*    ColoreaTool.Visible = Colorear.Visible = true;
                            DijkstraCam.Visible = DijkstraTool.Visible = true;
                            FloydTool.Visible = CaminoFloyd.Visible = false;
                            EulerTool.Visible = EulerMenu.Visible = true;*/
                        }
            /*            MueveGraf.Enabled = MueveGrafo.Enabled = true;
                        MueveNodo.Enabled = Mueve.Enabled = true;
                        EliminaNod.Enabled = EliminaNodo.Enabled = true;
                        EliminaAris.Enabled = EliminaArista.Enabled = true;*/
                       
                        accion = 1;
            /*            Agrega.Checked = AgregaNodo.Checked = true;
                        Mueve.Checked = MueveNodo.Checked = false;
                        MueveGraf.Checked = MueveGrafo.Checked = false;
                        EliminaNod.Checked = EliminaNodo.Checked = false;
                        EliminaAris.Checked = EliminaArista.Checked = false;
                        PropiedadesGrafo.Enabled = true;*/
                     //   Colorear.Enabled = true;
                 //       toolStrip2.Visible = false;
                        grafo.desseleccionar();
                        nombre = 'A';
                        for (int nn = 0; nn < grafo.Count; nn++)
                        {
                            nombre++;
                        }
                break;
                case "Dodecaedro":
                     try
                        {
                            using (Stream stream = File.Open(Application.StartupPath + "\\Ejemplos" + "\\dodecaedro.grafo", FileMode.Open))
                            {
                               BinaryFormatter bin = new BinaryFormatter();
                               grafo = (Grafo)bin.Deserialize(stream);
                               grafo.pinta(g);
                            }
                        }
                        catch (IOException exe)
                        {
                            MessageBox.Show(exe.ToString());
                        }
                        g2 = new Grafo();
              //          AgregaRelacion.Enabled = Dirigida.Enabled=NoDirigida.Enabled = true;
               //         Agrega.Enabled = true;
                //        intercambioTool.Enabled = true;
                 //       toolStrip4.Visible = true;
                 //       ItemMetodos.Visible = true;
                        {
                  //          Kruskal.Visible=KruskalMenu.Visible = true;
                 //           AristaNoDirigida.Enabled = NoDirigida.Enabled = true;
                  //          AristaDirigida.Enabled = Dirigida.Visible = false;
                    //        ColoreaTool.Visible = Colorear.Visible = true;
                     //       DijkstraCam.Visible = DijkstraTool.Visible = true;
                      //      FloydTool.Visible = CaminoFloyd.Visible = false;
                      //      EulerTool.Visible = EulerMenu.Visible = true;
                        }
              /*          MueveGraf.Enabled = MueveGrafo.Enabled = true;
                        MueveNodo.Enabled = Mueve.Enabled = true;
                        EliminaNod.Enabled = EliminaNodo.Enabled = true;
                        EliminaAris.Enabled = EliminaArista.Enabled = true;*/
                        
                        accion = 1;
             /*           Agrega.Checked = AgregaNodo.Checked = true;
                        Mueve.Checked = MueveNodo.Checked = false;
                        MueveGraf.Checked = MueveGrafo.Checked = false;
                        EliminaNod.Checked = EliminaNodo.Checked = false;
                        EliminaAris.Checked = EliminaArista.Checked = false;
                        PropiedadesGrafo.Enabled = true; */
                    //    Colorear.Enabled = true;
                    //    toolStrip2.Visible = false;
                        grafo.desseleccionar();
                        nombre = 'A';
                        for (int nn = 0; nn < grafo.Count; nn++)
                        {
                            nombre++;
                        }
                   break;
                case "Cimitarra":
                   try
                   {
                       using (Stream stream = File.Open(Application.StartupPath + "\\Ejemplos" + "\\Cimitarra.grafo", FileMode.Open))
                       {
                           BinaryFormatter bin = new BinaryFormatter();
                           grafo = (Grafo)bin.Deserialize(stream);
                           grafo.pinta(g);
                       }
                   }
                   catch (IOException exe)
                   {
                       MessageBox.Show(exe.ToString());
                   }
                   g2 = new Grafo();
           //        AgregaRelacion.Enabled = Dirigida.Enabled=NoDirigida.Enabled = true;
            //       Agrega.Enabled = true;
             //      intercambioTool.Enabled = true;
            //       toolStrip4.Visible = true;
                 //  ItemMetodos.Visible = true;
                   {
                    //   Kruskal.Visible =KruskalMenu.Visible= true;
               //        AristaNoDirigida.Enabled = NoDirigida.Enabled = true;
                //       AristaDirigida.Enabled = Dirigida.Visible = false;
                  /*     ColoreaTool.Visible = Colorear.Visible = true;
                       DijkstraCam.Visible = DijkstraTool.Visible = true;
                       FloydTool.Visible = CaminoFloyd.Visible = false;
                       EulerTool.Visible = EulerMenu.Visible = true;*/
                   }
      /*             MueveGraf.Enabled = MueveGrafo.Enabled = true;
                   MueveNodo.Enabled = Mueve.Enabled = true;
                   EliminaNod.Enabled = EliminaNodo.Enabled = true;
                   EliminaAris.Enabled = EliminaArista.Enabled = true;*/
                  
                   accion = 1;
             /*      Agrega.Checked = AgregaNodo.Checked = true;
                   Mueve.Checked = MueveNodo.Checked = false;
                   MueveGraf.Checked = MueveGrafo.Checked = false;
                   EliminaNod.Checked = EliminaNodo.Checked = false;
                   EliminaAris.Checked = EliminaArista.Checked = false;
                   PropiedadesGrafo.Enabled = true; */
                   //Colorear.Enabled = true;
               //    toolStrip2.Visible = false;
                   grafo.desseleccionar();
                   nombre = 'A';
                   for (int nn = 0; nn < grafo.Count; nn++)
                   {
                       nombre++;
                   }
                   break;
            }
        }


        private void MenuArista_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (toolStripTextBox1.Text.Length > 0)
            {
                arista.PESO = int.Parse(toolStripTextBox1.Text);
                arista = null;
                toolStripTextBox1.Text = "";
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
       //     time.Interval = 600 - (2 * trackBar1.Value);
        }


        #endregion 
        #region paint
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics au;
            au = Graphics.FromImage(bmp1);
            au.Clear(BackColor);
            if (band)
            {
                //au.Clear(BackColor);
                switch (accion)
                {                   
                    case 1:
                        bool num;
                        int iaux;
                        if (grafo.Count > 0)
                        {
                            if ((int.TryParse(grafo[0].NOMBRE.ToString(), out iaux)) == true)
                                num = true;
                            else
                                num = false;
                        }
                        else
                            num = false;
                        if (num == false)
                        {
                            nu = new NodoP(pm, nombre);
                            nombre++;
                        }
                        else 
                        {
                            nu = new NodoP(pm,nombre );
                            nu.NOMBRE = numero.ToString();
                            numero++;
                        }
                        if (grafo.Count == 0)
                        {
                 //           Dirigida.Enabled = NoDirigida.Enabled = true;
                        }
                        if (grafo.Count > 1)
                            nu.COLOR = grafo[0].COLOR;
                        grafo.AgregaNodo(nu);
                //        intercambioTool.Enabled = true;
                 //       PropiedadesGrafo.Enabled = true;
                        AgregaRelacion.Enabled= true;
                       
              /*          MueveGraf.Enabled = MueveGrafo.Enabled = true;
                        MueveNodo.Enabled=Mueve.Enabled = true;
                        EliminaNod.Enabled=EliminaNodo.Enabled = true;
                        EliminaAris.Enabled = EliminaArista.Enabled = true; */
                       // Colorear.Enabled = true;
                  //      toolStrip2.Visible = false;
                        gactivo = true;
                        nu = null;          
                    break;
                    case 2:
                        nu = (NodoP)grafo.Find(delegate(NodoP a) { if (pm.X > a.POS.X - 15 && pm.X < a.POS.X + 30 && pm.Y > a.POS.Y - 15 && pm.Y < a.POS.Y + 30)return true; else return false; });
                    break;
                    case 3:
                        nu = (NodoP)grafo.Find(delegate(NodoP a) { if (pm.X > a.POS.X - 15 && pm.X < a.POS.X + 30 && pm.Y > a.POS.Y - 15 && pm.Y < a.POS.Y + 30)return true; else return false; });
                        p = pm;
                        
                    break;
                    case 5:
                        Grafo aux=new Grafo();
                        aux = grafo;
                         aux.Sort(delegate(NodoP a, NodoP b) { return a.POS.X.CompareTo(b.POS.X); });
                         if (pm.X > aux.ToArray()[0].POS.X && pm.X < aux.ToArray()[aux.Count - 1].POS.X)
                         {
                             aux.Sort(delegate(NodoP a, NodoP b) { return a.POS.Y.CompareTo(b.POS.Y); });
                             if (pm.Y > aux.ToArray()[0].POS.Y && pm.Y < aux.ToArray()[aux.Count - 1].POS.Y)
                             {
                                 mov = true;             
                             }
                             else
                                 mov = false;
                         }
                         else
                         mov = false;
                    break;
                    case 6:
                            int total = grafo.Aristas.Count;
                            Arista arista;
                            for (int i = 0; i < total; i++)
                            {
                                arista = grafo.Aristas[i];
                                if (arista.toca(pm))
                                {
                                    grafo.RemueveArista(arista);
                                    if(coloreando==true)
                                    grafo.colorear();
                                   break;
                                }
                            }
                    break;
                    case 14:  
                                Arista ari;
                                NodoP o, d;
                                o=d=null;
                                if (bandcam == true)
                                {
                                    ari = new Arista(); ;
                                    grafo = new Grafo(g2);
                                    grafo.Aristas.Clear();
                                    foreach (NodoP rel in grafo)
                                    {
                                        rel.relaciones.Clear();
                                    }
                                    bandcam = false;
                                    au.Clear(BackColor);
                                }

                                    if (tck == true)
                                    {
                                        accion = 0;
                                        tck = false;
                                        if (icam > 0)
                                        {
                                            grafo.Find(delegate(NodoP dx) { if (dx.NOMBRE == CCE[icam].NOMBRE)return true; else return false; }).insertaRelacion(grafo.Find(delegate(NodoP ox) { if (ox.NOMBRE == CCE[icam - 1].NOMBRE)return true; else return false; }), grafo.Aristas.Count);
                                            d=grafo.Find(delegate(NodoP dx) { if (dx.NOMBRE == CCE[icam].NOMBRE)return true; else return false; });
                                            o=grafo.Find(delegate(NodoP ox) { if (ox.NOMBRE == CCE[icam - 1].NOMBRE)return true; else return false; });
                                            d.COLOR = Color.Blue;
                                            o.COLOR = Color.Blue;
                                            Pen penn = new Pen(Brushes.Red);
                                            penn.Width = 4;
                                            g.DrawEllipse(penn,new Rectangle(d.POS.X - 16, d.POS.Y - 16,30, 30));

                                            ari = new Arista(1, d, o, "e" + (CCE.Count - icam).ToString());
                                            
                                            grafo.AgregaArista(ari);
      
                                        }
                                        grafo.pinta(g);
                                        
                                  
                                    }
                    break;
                    
                }
                if(gis!=null)
                {
                    gis.pinta(au);
                    g.DrawImage(bmp1, 0, 0);
                }
                grafo.pinta(au);
                g.DrawImage(bmp1, 0, 0);
            }
            else
            {
                switch (accion)
                {
                    case 1:
                    break;
                    case 2:
                        if (nu != null)
                        {
                            nu.POS = pm;
                            au.Clear(BackColor);
                          
                        }
                    break;
                    case 3:
                        au.Clear(BackColor);
                        if(nu!=null)
                            au.DrawLine(fl, p,pm);
                        
                    break;
                    case 5:
                    if (mov)
                    {
                        Point po = new Point(pm.X - p.X, pm.Y - p.Y);
                        foreach(NodoP n in grafo)
                        {
                            Point nue = new Point(n.POS.X + po.X, n.POS.Y + po.Y);
                            n.POS = nue;
                        }
                        
                        p = pm;
                        au.Clear(BackColor);
                    }

                    break;
                    
                }
                if(gis!=null)
                {
                    gis.pinta(au);
                    g.DrawImage(bmp1, 0, 0);
                }
                grafo.pinta(au);
                g.DrawImage(bmp1, 0, 0);
            }
        }   
        #endregion
        #region otrosEventos
        private void Resize_form(object sender, EventArgs e)
        {
            if (ClientSize.Width != 0 && ClientSize.Height != 0)
            {
                bmp1 = new Bitmap(ClientSize.Width, ClientSize.Height);
                g = CreateGraphics();
                g.DrawImage(bmp1, 0, 0);
     //           trackBar1.Location = new Point(ClientRectangle.Width - 100, 65);
            }
        }


        public void SeleccionaNodos()
        {
            if (orig == null || destin == null)
            {
                if (orig == null)
                {
                    orig = (NodoP)grafo.Find(delegate(NodoP a) { if (pm.X > a.POS.X - 15 && pm.X < a.POS.X + 30 && pm.Y > a.POS.Y - 15 && pm.Y < a.POS.Y + 30)return true; else return false; });
                    if (orig != null)
                        orig.SELECCIONADO = true;
                }
                else
                    if (destin == null)
                    {
                        destin = (NodoP)grafo.Find(delegate(NodoP a) { if (pm.X > a.POS.X - 15 && pm.X < a.POS.X + 30 && pm.Y > a.POS.Y - 15 && pm.Y < a.POS.Y + 30)return true; else return false; });
                        if (destin != null)
                            destin.SELECCIONADO = true;
                    }
            }
            else
            {
                nu = (NodoP)grafo.Find(delegate(NodoP a) { if (pm.X > a.POS.X - 15 && pm.X < a.POS.X + 30 && pm.Y > a.POS.Y - 15 && pm.Y < a.POS.Y + 30)return true; else return false; });
                if (nu != null)
                {
                    nu.SELECCIONADO = false;
                    if (nu == orig)
                        orig = null;
                    if (nu == destin)
                        destin = null;
                    nu = null;
                }
            }
            grafo.pinta(g);
        }

        void time_Tick(object sender, EventArgs e)
        {

            tck = true;
            accion = 14;
            if (icam < 0)
            {
                icam = CCE.Count - 1;
                bandcam = true;
            }
            else
                icam--;

            this.Form1_Paint(this, null);

        }

        public int componentes()
        {
            List<List<NodoP>> componentes = new List<List<NodoP>>();
            List<NodoP> nue = new List<NodoP>();
            Grafo aux = new Grafo(grafo);
            bool enco = false;

            foreach (NodoP nod in grafo)
            {
                foreach (List<NodoP> n in componentes)
                {
                    if (enco == false)
                        if (n.Find(delegate(NodoP f) { if (f.NOMBRE == nod.NOMBRE)return true; else return false; }) != null)
                            enco = true;
                }
                if (enco == false)
                {
                    nue = new List<NodoP>();
                    grafo.Componentes2(nod, nue);
                    componentes.Add(nue);

                }
                enco = false;

            }
            foreach (NodoP re in grafo)
            {
                foreach (NodoRel rela in re.relaciones)
                {
                    rela.VISITADA = false;
                }
            }
            return componentes.Count;
        }

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(grafo.amplitud(grafo[0]));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!grafo.aciclico())
                MessageBox.Show("El grafo no es aciclico");
            else
                MessageBox.Show("El grafo es aciclico");
        }

        private void Dirigida_Click(object sender, EventArgs e)
        {

        }

        private void EliminaNodo_Click(object sender, EventArgs e)
        {

        }

        private void MueveGrafo_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void propiedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f;
            if (AristaDirigida.Enabled == false)
                f = new Form3(grafo, 2);
            else
                f = new Form3(grafo, 1);
            f.Activate();
            f.Show();
       //     toolStrip2.Visible = false;
            grafo.desseleccionar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(grafo.corolarios())
            {
                MessageBox.Show("El grafo es plano por corolarios");
            }
            else
            {
                MessageBox.Show("El grafo no es plano por corolarios");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abre el archivo del otro grafo para verificar si son isomorfos");
            OpenFileDialog filed = new OpenFileDialog();
            filed.InitialDirectory = Application.StartupPath+"\\Ejemplos";
            filed.DefaultExt = ".grafo";           
            Grafo isom=null;
            string namefile;
            filed.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
            if (filed.ShowDialog() == DialogResult.OK)
            {
                namefile = filed.FileName;

                try
                {
                    using (Stream stream = File.Open(namefile, FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        gis = (Grafo)bin.Deserialize(stream);
                        //isom.pinta(g);
             //           cierraEuler.Visible = true;
                    }
                }
                catch (IOException exe)
                {
                    MessageBox.Show(exe.ToString());
                }
                if (grafo.isomorfo(gis))
                    MessageBox.Show("El grafo es isomorfo");
                else
                    MessageBox.Show("El grafo No es isomorfo");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            grafo.abarcador(grafo[0],"");
     //       cierraEuler.Visible = true;
            foreach(NodoP des in grafo)
            {
                des.VISITADO = false;
            }
        }





    }
}
