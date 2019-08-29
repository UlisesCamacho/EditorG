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
       // int ckwn;
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
            icam = 0;
        //    ckwn = 0;
            numero = 0;
            tck = false;
            CCE = new List<NodoP>();
            Dijks= 0;
            flo = 1;
            coloreando = false;
            resp = Color.White;
            g2 = new Grafo();
            a = new Arista();
            fl = new Pen(Brushes.Green);
            bmp1 = new Bitmap(800,600);
            g = CreateGraphics();
            file = new BinaryFormatter();
            grafo = new Grafo();
            band = false;
           
            accion = 0;
            gactivo = false;
            pm = new Point();
            nombre = 'A';
            mov = false;
            time = new Timer();
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
                    mov = false;
                    BackColor = Color.White;
                    g.Clear(BackColor);
                    AristaNoDirigida.Enabled = true;
                    AristaDirigida.Enabled= true;
                    g2 = new Grafo();
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
                        if (grafo.Aristas[0].Tipo == 1)
                        {
                      

                        }
                        else
                        {
                    
                        }
         
                        accion = 1;
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
                    grafo.desseleccionar();
                break;
                case "Mueve":
                case "MueveNodo":
                    band = true;
                    accion = 2;
                    grafo.desseleccionar();
                break;
                case "EliminaNodo":
                case "EliminaNod":
                    accion = 4;
                    grafo.desseleccionar();
                break;
                case "MueveGrafo":
                case "MueveGraf":
                    accion = 5;
                    grafo.desseleccionar();
                break;
                case "EliminaArista":
              //      accion = 6;
               //     grafo.desseleccionar();

                break;
                case "PropiedadesGrafo":
                     Form f;
                     if(AristaDirigida.Enabled==false)
                        f = new Form3(grafo,2);
                     else
                        f = new Form3(grafo,1);
                     f.Activate();
                     f.Show();
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
              
                    orig = null;
                    destin = null;
           
                    pm = new Point();
                    accion = 0;
                break;
                case "Dirigida":
                    accion = 3;
          
                    band = true;
            
                    AgregaRelacion.Checked = true;
            
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    fl.StartCap = LineCap.RoundAnchor;
                    fl.Width = 4;
                    tipoarista = 1;
                    grafo.desseleccionar();
                 
                   
                break;
                case "NoDirigida":
                    accion = 3;
                    band = true;
                    AgregaRelacion.Checked = true;
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                    fl.StartCap = LineCap.NoAnchor;
                    fl.Width = 4;
                    tipoarista = 2;
                    grafo.desseleccionar();
                    break;

            }
        }

        private void RelacionClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            accion = 3;
            band = true;
            AgregaRelacion.Checked = true;
            switch (e.ClickedItem.Name)
            {
                case "Dirigida":
                case "AristaDirigida":
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    fl.StartCap = LineCap.RoundAnchor;
                    fl.Width = 4;
                    tipoarista = 1;
                    grafo.desseleccionar();
                    break;
                case "NoDirigida":
                case "AristaNoDirigida":
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                    fl.StartCap = LineCap.NoAnchor;
                    fl.Width = 4;
                    tipoarista = 2;
                    grafo.desseleccionar();
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
              
                        tipoarista = 2;
                  
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
               
               
                        tipoarista = 2;
                
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
          
                        tipoarista = 2;
                
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

                    {
                    }
                        accion = 1;
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
             
                        {
                 
                        }
              
                        
                        accion = 1;
             
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
          
                   {
                  
                   }
     
                  
                   accion = 1;
            
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
                        AgregaRelacion.Enabled= true;
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
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
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
            grafo.desseleccionar();
        }

        private void EliminaAris_Click(object sender, EventArgs e)
        {
            accion = 6;
            grafo.desseleccionar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
      
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            grafo.abarcador(grafo[0],"");
            foreach(NodoP des in grafo)
            {
                des.VISITADO = false;
            }
        }





    }
}
