using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EditorGrafos
{
    public partial class EditorGrafo : Form
    {


        // Variables para Kruskal
        int iKruskal = 0;
        List<Arista> rel;
        #region Inicialziacion

        Grafo grafo;
        bool intercambiaColor;
        NodoP nodoP, nodoAux, nodoW;
        bool activa;
        Arista nodoR;
        Graphics g;
        int opcion;
        Bitmap bmp1;
        bool band, bandF, bandA, bandI, bpar;
        Point p1, p2;
        Random rnd = new Random();
       
        AdjustableArrowCap arrow;
        bool grafoEspecial;
        #endregion
        #region Propiedades
        int radio;
        int nomb;
        string nameF;
        Color cRelleno;
        Color colorFuente;
        Color cNodo;
        float width;
        float widthA;
        Color cArista;
        Pen penN;
        SolidBrush brushN;
        SolidBrush brushF;
        Font font;
        Pen penA;

        #endregion
        #region Principal
        // VARIABLES EXTRAS
        //MuestraCadena muestra;

        public EditorGrafo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            intercambiaColor = false;
            grafo = new Grafo();
            opcion = 0;
            g = CreateGraphics();
            bmp1 = new Bitmap(ClientSize.Width, ClientSize.Height);
            band = false;
            bandI = false;
            bandF = false;
            bpar = false;
            arrow = new AdjustableArrowCap(5, 5);
            timer1.Enabled = false;
           
           
            grafoEspecial = false;
            
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
            Graphics ga = CreateGraphics();
            ga = Graphics.FromImage(bmp1);
            ga.Clear(BackColor);
            

            if (bandF || band)
            {
                switch (opcion)
                {
                    case 1:
                        ga.FillEllipse(grafo.brushN, p1.X - grafo.radio, p1.Y - grafo.radio, grafo.radio * 2, grafo.radio * 2);
                        ga.DrawEllipse(grafo.penN, p1.X - grafo.radio + (grafo.penN.Width / 2), p1.Y - grafo.radio + (grafo.penN.Width / 2), grafo.radio * 2 - (grafo.penN.Width / 2), grafo.radio * 2 - (grafo.penN.Width / 2));
                        ga.DrawString(nodoP.nombre.ToString(), grafo.font, grafo.brushF, p1.X - 6, p1.Y - 6);
                        break;

                    case 2:
                        if (bandF)
                        {
                            if (nodoP.Equals(nodoAux))
                                ga.DrawBezier(grafo.penA, nodoP.centro.X - 15, nodoP.centro.Y - 15, nodoP.centro.X - 20, nodoP.centro.Y - 60, nodoP.centro.X + 20, nodoP.centro.Y - 60, nodoP.centro.X + 15, nodoP.centro.Y - 15);
                            else
                                ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, nodoAux.centro), grafo.BuscaInterseccion(nodoAux.centro, nodoP.centro));
                        }
                        if (band)
                            ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, p2), p2);
                        break;

                    case 9:
                        if (bandF)
                        {
                            if (nodoP.Equals(nodoAux))
                                ga.DrawBezier(grafo.penA, nodoP.centro.X - 15, nodoP.centro.Y - 15, nodoP.centro.X - 20, nodoP.centro.Y - 60, nodoP.centro.X + 20, nodoP.centro.Y - 60, nodoP.centro.X + 15, nodoP.centro.Y - 15);
                            else
                                ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, nodoAux.centro), grafo.BuscaInterseccion(nodoAux.centro, nodoP.centro));
                        }
                        if (band)
                            ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, p2), p2);
                        break;
                }
                bandF = false;
            }

            if (bandI)
            {
                ga.Clear(BackColor);
                grafo.ImprimirGrafo(ga, bpar);
                bandI = false;
            }

            if (opcion == 6 || opcion == 7)
            {
                ga.Clear(BackColor);
                grafo.Clear();
                grafo.numN = 1;
                grafo.edoNom = false;
                if (opcion == 7)
                {
                    grafo = new Grafo();
                    
                }
            }
            if (opcion != 6)
                if (opcion != 7)
                    grafo.ImprimirGrafo(ga, bpar);
            g.DrawImage(bmp1, 0, 0);

        }

        #endregion 

        #region Mouse_Events

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            if (activa)
            {
                nodoW = grafo.BuscaNodo(p1);
                activa = false;
            }

            switch (opcion)
            {
                case 1:
                    if (/*grafo.Count == 1 &&*/ grafo.numN == 1)
                       
                    grafo.numN++;
                    if (grafo.Count > 0)
                        nodoP = new NodoP(grafo.Count - 1, p1);
                    else
                        nodoP = new NodoP(grafo.numN - 1, p1);
                    grafo.Add(nodoP);
                    grafo.nomb = nodoP.nombre;
                    nodoP.nombre = grafo.Count;
                    band = false;
                    bandF = true;
                    if (grafo.numN == 28 && grafo.Count == 28)
                    {
                        bandI = true;
                        grafo.edoNom = true;
                    }
                    else
                        bandI = false;
                    Form1_Paint(this, null);
                    break;

                case 2:
                case 9:
                    nodoP = grafo.BuscaNodo(p1);
                    if (nodoP != null)
                    {
                        band = true;
                        bandA = true;
                    }
                    else
                    {
                        band = false;
                    }
                    break;

                case 3:
                    nodoP = grafo.BuscaNodo(p1);
                    if (nodoP != null)
                        bandA = true;
                    else band = false;
                    break;

                case 8:
                    p1 = e.Location;

                    
                    break;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button.Equals(MouseButtons.Left) && (opcion == 2 || opcion == 9) && bandA)
            {
                p2 = e.Location;
                
                Form1_Paint(this, null);
            }

            if (e.Button.Equals(MouseButtons.Left) && opcion == 3 && bandA)
            {
                band = false;
                bandF = false;
                bandI = true;
                nodoP.centro = e.Location;
                quitaPesos();
                quitaNumeric();
                quitaTexaux();//cambio
               
                Form1_Paint(this, null);
            
            }

            if (e.Button.Equals(MouseButtons.Left) && opcion == 8)
            {
                int distx, disty;

                distx = e.Location.X - p1.X;
                disty = e.Location.Y - p1.Y;
                grafo.MueveGrafo(distx, disty);
                p1 = e.Location;
                if (intercambiaColor == true)
                    quitaPesos();
                bandI = true;
                band = false;
                bandF = false;
                bandA = false;
                
                Form1_Paint(this, null);

            }
            if (opcion == 41) // agregar Peso a Arista
            {

               // quitaPesos();
              //  quitaNumeric();
                //asignaPesos(e.Location);
               // muestraPeso();
                //bandF = false;

            }
           
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            activa = true;
            
                //asignaPesos(e.Location);
            if (bandA && band && (opcion == 2 || opcion == 9))
            {
                p2 = e.Location;
                nodoAux = grafo.BuscaNodo(p2);
                
                if (nodoAux != null)
                {
                    if (opcion == 2)
                    {
                        
                        //  grafo = new GrafoNoDirigido(grafo);
                        nodoR = new Arista(0);
                        nodoR.destino = nodoAux;
                        nodoR.origen = nodoP;
                        nodoP.aristas.Add(nodoR);


                        nodoR = new Arista(0);//(rnd.Next(100));

                        nodoR.destino = nodoP;
                        nodoR.origen = nodoAux;

                        nodoAux.aristas.Add(nodoR);
                    }

                    else if (opcion == 9)
                    {
                       
                        //    grafo = new GrafoDirigido(grafo);
                        grafo.penA.CustomEndCap = arrow;

                        nodoR = new Arista(0);
                        nodoR.destino = nodoAux;
                        nodoR.origen = nodoP;

                        nodoP.aristas.Add(nodoR);

                        



                    }

                    bandF = true;
                    bandA = false;
                }
                else
                {
                    bandF = false;
                }
            }

            if (opcion == 4)
            {
                grafo.BorrarNodo(e.Location);
                bandF = false;
            }

            if (opcion == 5)
            {
                grafo.BorrarArista(e.Location);
                quitaNumeric();
                quitaTexaux();//cambios
                quitaPesos();
                
                bandF = false;
            }
            if(opcion == 41 || intercambiaColor == true) // agregar Peso a Arista
            {

                quitaPesos();
                quitaNumeric();//
                quitaTexaux();
                // asignaPesos(e.Location);
                asignaPesos2(e.Location);
                muestraPeso();
                bandF = false;

            }


            band = false;
            bandA = false;
            Form1_Paint(this, null);
        }

        #endregion
        Arista temp, temp2;
        NumericUpDown numeric;
        private void asignaPesos(Point p) // pesos
        {
            int pmx, pmy; // PUNTO MEDIO EN X Y PUNTO MEDIO EN Y 
            
             temp = grafo.encuentraArista(p);
            if(grafo.tipo == 2)
            temp2 = grafo.encuentraSegundaArista(p);
            if(temp != null)
            {
                // MessageBox.Show("Nodo Origen " + temp.origen.nombre + "\nNodo Destino " + temp.destino.nombre);
                  numeric = new NumericUpDown();
                  numeric.Maximum = 100;
                  numeric.Minimum = 1;
              

                if (temp.peso != 0)
                    numeric.Value = temp.peso;
               
                pmx = (temp.origen.centro.X + temp.destino.centro.X) / 2;
                pmy = (temp.origen.centro.Y + temp.destino.centro.Y) / 2;
                pmx += 5;
                pmy += 5;
                numeric.Name = "numeric";
                numeric.Width = 40;
                numeric.Location = new Point(pmx, pmy);
                numeric.ValueChanged += Numeric_ValueChanged;
                temp.peso = Convert.ToInt32(numeric.Value);
                if (grafo.tipo == 2)
                temp2.peso = Convert.ToInt32(numeric.Value); // 
                Controls.Add(numeric); //
            }
            
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
           
            if(temp != null  && numeric != null)
            {
                temp.peso = Convert.ToInt32(numeric.Value);
                if (grafo.tipo == 2)
                    temp2.peso = Convert.ToInt32(numeric.Value);
            }
        }
        
        #region Manejadores_Clicked


        private void agregaPesoArista()
        {
            


        }
        
        private void Configuracion_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
            
        }
        private void Nodo_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            band = false;
            bandA = false;
            bandF = false;
            bandI = false;
           
            switch (e.ClickedItem.AccessibleName)
            {
                case "CrearNodo":
                    opcion = 1;
                    activa = true;
                    break;
                
                case "MoverNodo":
                    opcion = 3;
                    break;

                case "BorrarNodo":
                    opcion = 4;
                    break;
                
            }
        }
     
        private int buscaPeso(NodoP origen, NodoP destino)
        {
            foreach(NodoP np in grafo)
            {
                foreach(Arista nr in np.aristas)
                {
                    if(nr.origen.nombre == origen.nombre && nr.destino.nombre == destino.nombre)
                    {
                        return nr.peso;
                    }
                }
            }
            return 0;
        }
        private void Next_Click(object sender, EventArgs e)
        {
            
            if(iKruskal == rel.Count)
            {

                asignaPropiedades();
                foreach (NodoP np in grafo)
                {
                    foreach (Arista nr in np.aristas)
                    {
                        np.colorN = new SolidBrush(Color.White);
                        nr.colorA = new Pen(Color.Black, 1);
                    }
                }
                grafo.coloreate();
                tope = 0;

                Form1_Paint(this, null);
                iKruskal = 0;
            }
             if (iKruskal < rel.Count)
            {
                foreach (NodoP np in grafo)
                {
                    foreach (Arista nr in np.aristas)
                    {
                        if (nr.origen == rel[iKruskal].origen && nr.destino == rel[iKruskal].destino)
                        {

                            grafo.coloreate();
                            nr.colorA = new Pen(new SolidBrush(Color.Orange), 8);
                            break;


                        }



                    }
                }
                grafo.ImprimirGrafo(g, true);
                iKruskal++;
            }

        }

        
        public void Ciclo()
        {
            bool camino = false;
            string cadena = "";
            int pares = 0;
            int impares = 0;
            List<Arista> caminos;
            List<NodoP> circuit;

            foreach (NodoP np in grafo){
                if (np.aristas.Count % 2 == 0){
                    pares++;
                }
                if (np.aristas.Count % 2 != 0){
                    impares++;
                }
            }
            if (pares == grafo.Count) // SI TODOS LOS NODOS SON DE GRADO PAR ENTONCES TIENE CIRCUITO EULERIANO
            {
                
                MessageBox.Show("Grafo ciclo");
                
            }

            else if (impares == 2) // SI TIENE DOS NODOS DE GRADO IMPAR, ENTONCES TIENE CAMINO EULERIANO
            {
                
                MessageBox.Show("Grafo Ciclo");
                
               
                
            }
            else
                MessageBox.Show("No es grafo ciclo");
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        int tope = 1;

        private void Timer1_Tick(object sender, EventArgs e)
        {
          

        }

        public List<Color> coloreate()
        {
            List<Color> color = new List<Color>();
            color.Add(Color.Red);
            color.Add(Color.Blue);
            color.Add(Color.Green);
            color.Add(Color.Yellow);
            color.Add(Color.Violet);
            color.Add(Color.DarkKhaki);
            color.Add(Color.DarkOrange);
            color.Add(Color.YellowGreen);
            color.Add(Color.DarkCyan);

            return color;

        }



        private void Arista_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            band = false;
            bandA = false;
            bandF = false;
            bandI = false;
            
          
            switch (e.ClickedItem.AccessibleName)
            {
                case "AristaNoDirigida":
                    opcion = 2;
                    obtenPropiedades();
                    grafo = new GrafoNoDirigido(grafo);
                    grafo.tipo = 2;
                    asignaPropiedades();
                    
                    break;

                case "BorrarArista":
                    opcion = 5;
                    break;

                case "AristaDirigida":
                    opcion = 9;
                    obtenPropiedades();
                    grafo = new GrafoDirigido(grafo);
                    grafo.tipo = 3;

                    asignaPropiedades();
                    grafo.penA.CustomEndCap = arrow;
                    
                    

                    break;
                case "agregaPeso":
                    opcion = 41;
                break;
                
            }
        }

        private void Archivo_Click(object sender, ToolStripItemClickedEventArgs e)
        {

           
                 
        }

        #endregion
        #region numericGrafosEspeciales
        private void numericKn(object sender, EventArgs e)
        {
            
            obtenPropiedades();
            grafo = new GrafoNoDirigido(grafo);
            grafo.tipo = 2;
            asignaPropiedades();
            grafo.Clear();
           
            grafo.numN = grafo.Count;
            quitaNumeric();
            quitaTexaux();
            quitaPesos();
            intercambiaColor = false;
            Form1_Paint(this, null);
            
            

        }

        private void Nombre_Click(object sender, EventArgs e)
        {
          
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("nuevo");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            // menu principal
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void moverGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 8;
        }

        private void crearNodoConPesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void agregarPesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 41;
        }

        private void numericCn(object sender, EventArgs e)
        {

            obtenPropiedades();
            grafo = new GrafoNoDirigido(grafo);
            grafo.tipo = 2;
            asignaPropiedades();
            grafo.Clear();
            quitaNumeric();
            quitaTexaux();
            quitaPesos();
           // grafo.grafoCn((int)numericUpDown2.Value, g);
            grafo.numN = grafo.Count;
            intercambiaColor = false;
            
            Form1_Paint(this, null);
        }

        private void matrizDePesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matrices v = new Matrices(grafo, grafo.tipo);
            v.ShowDialog();
        }

        private void agregarNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 1;
            activa = true;
        }

        private void mueveNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 3;
        }

        private void eliminaAristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 5;
        }

        private void noDirigidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 2;
          
            obtenPropiedades();
            grafo = new GrafoNoDirigido(grafo);
            grafo.tipo = 2;
            asignaPropiedades();
        }

        private void dirigidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 9;
           
            obtenPropiedades();
            grafo = new GrafoDirigido(grafo);
            grafo.tipo = 3;

            asignaPropiedades();
            grafo.penA.CustomEndCap = arrow;
        }

        private void eliminaNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 4;
        }

        private void mueveGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 8;
        }

        private void nombreDeAristasToolStripMenuItem_Click(object sender, EventArgs e)
        { // ver pesos
            if(intercambiaColor==true)
            {
                quitaPesos();
                intercambiaColor = false;
            }
            else
            {
                muestraPeso();
                intercambiaColor = true;
            }
        }

        private void propiedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matrices v = new Matrices(grafo, grafo.tipo);
            v.ShowDialog();
        //    MatrizAdyacencya v = new MatrizAdyacencya(grafo);
         //   v.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrir
            MessageBox.Show("Abrir");
            opcion = 0;
            NodoP A = null;
            bool band = false;
            int i = 0;
            iKruskal = 0;
            bpar = false;
            intercambiaColor = false;

            quitaNumeric();
            quitaTexaux();
            if (bpar == false)
                grafo.ImprimirGrafo(g, bpar);

            IFormatter formatter = new BinaryFormatter();
            String directorio = Environment.CurrentDirectory + "..\\Grafos";
            //String directorio = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\Grafos"));

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.grafo)|*.grafo";
            openFileDialog1.InitialDirectory = directorio;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                g.Clear(BackColor);
                grafo.Clear();
                Stream stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.None);

                grafo = (Grafo)formatter.Deserialize(stream);
                

                if (grafo.tipo == 2) // GRAFO NO DIRIGIDO
                {
                    obtenPropiedades();
                    asignaPropiedades();
                    grafo = new GrafoNoDirigido(grafo);

                }
                else if (grafo.tipo == 3) // GRAFO DIRIGIDO
                {
                    obtenPropiedades();
                    asignaPropiedades();
                    grafo = new GrafoDirigido(grafo);
                    grafo.penA.CustomEndCap = arrow;
                }

                stream.Close();



                band = false;
                bandA = false;
                bandF = false;
                bandI = false;


                Invalidate();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = 0;
            NodoP A = null;
            bool band = false;
            int i = 0;
            iKruskal = 0;
            bpar = false;
            intercambiaColor = false;

            quitaPesos();
            quitaNumeric();
            if (bpar == false)
                grafo.ImprimirGrafo(g, bpar);

            IFormatter formatter = new BinaryFormatter();
            String directorio = Environment.CurrentDirectory + "..\\Grafos";
            //String directorio = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\Grafos"));


            saveFileDialog1.InitialDirectory = directorio;
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "(*.grafo)|*.grafo";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);


                if (grafo.tipo == 1)
                    formatter.Serialize(stream, (Grafo)grafo);
                else if (grafo.tipo == 2)
                    formatter.Serialize(stream, (GrafoNoDirigido)grafo);
                else if (grafo.tipo == 3)
                    formatter.Serialize(stream, (GrafoDirigido)grafo);


                stream.Close();

            }
        }

        private void borrarGrafoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            opcion = 7;
           
            quitaNumeric();
            quitaTexaux();
            quitaPesos();
           
            quitaPesos();
            quitaNumeric();
            quitaTexaux();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

      

        private void button11_Click(object sender, EventArgs e)
        {
            Matrices v = new Matrices(grafo, grafo.tipo);
            v.ShowDialog();
        }

        private void numericWn(object sender, EventArgs e)
        {
            obtenPropiedades();
            grafo = new GrafoNoDirigido(grafo);
            grafo.tipo = 2;
            asignaPropiedades();
            grafo.Clear();
           
            grafo.numN = grafo.Count;
            quitaNumeric();
            quitaTexaux();
            quitaPesos();
            intercambiaColor = false;
            
            Form1_Paint(this, null);
        }


        private int CambiaNombre()
        {
            if (grafo.edoNom && grafo.numN < 28 && grafo.nomb < 28)
            {
                grafo.edoNom = false;
                Invalidate();
                bandI = true;
                return 1;
            }

            if (grafo.numN > 27 && grafo.edoNom && grafo.nomb > 27)
                MessageBox.Show("No se puede cambiar el nombre de los nodos de numeros a letras porque hay demasiados nodos", "Error");

            if (grafo.numN <= 27 && !grafo.edoNom)
            {
                grafo.edoNom = true;
                Invalidate();
            }

            bandI = true;
            return 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }




        #endregion

        #region MetodosPropiedades
        public void obtenPropiedades()
        {
            radio = grafo.radio;
            nomb = grafo.nomb;
            nameF = grafo.nameF;
            cRelleno = grafo.cRelleno;
            colorFuente = grafo.colorFuente;
            cNodo = grafo.cNodo;
            width = grafo.width;
            widthA = grafo.widthA;
            cArista = grafo.cArista;
            penN = new Pen(grafo.cNodo, grafo.width);
            brushN = new SolidBrush(grafo.cRelleno);
            brushF = new SolidBrush(grafo.colorFuente);
            font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
            penA = new Pen(grafo.cArista, grafo.widthA);
        }

        private void texaux_TextChanged(object sender, EventArgs e)
        {
            if (aux != null && texaux != null)
            {
                aux.peso = Convert.ToInt32(texaux.Text);
                if (grafo.tipo == 2)
                { try { aux2.peso = Convert.ToInt32(texaux.Text); }
                    catch(Exception ex)
                    {

                    }
                }
            }
        }

        private void completoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool completo = false;
            bool incompleto = false;
            bool oreja = false;
            foreach (NodoP nod in grafo)
            {
                foreach (Arista ar in nod.aristas)
                {
                    if (ar.origen == ar.destino)
                        oreja = true;

                }

                foreach (Arista aris in nod.aristas)
                {
                    if (oreja)
                    {
                        if (nod.aristas.Count - 1 == grafo.Count - 1)
                        {
                            completo = true;
                        }
                        else
                        {
                            incompleto = true;
                            break;
                        }
                    }
                    else
                    {
                        if (nod.aristas.Count == grafo.Count - 1)
                        {
                            completo = true;
                        }
                        else
                        {
                            incompleto = true;
                            break;
                        }
                    }

                }
                if (incompleto)
                {
                    MessageBox.Show("Grafo No completo");
                    break;
                }

            }
            if (completo && (incompleto == false))
            {
                MessageBox.Show("Grafo completo aristas= n (n-1)/2");
            }
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditorGrafo_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void isoformismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //isomorfismo
           
            Panel pa = new Panel();
            pa.Name = "Isomorfimo";
            pa.Height = 700;
            pa.Width = 500;
            pa.Location = new Point(500, 0);
            pa.BackColor = Color.GhostWhite;
            Controls.Add(pa);
            Panel_Paint(this, null);
           
            
            
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            intercambiaColor = false;
            grafo = new Grafo();
            opcion = 0;
            g = CreateGraphics();
            bmp1 = new Bitmap(ClientSize.Width, ClientSize.Height);
            band = false;
            bandI = false;
            bandF = false;
            bpar = false;
            arrow = new AdjustableArrowCap(5, 5);
            timer1.Enabled = false;


            grafoEspecial = false;
            Graphics ga = CreateGraphics();
            ga = Graphics.FromImage(bmp1);
            ga.Clear(BackColor);


            if (bandF || band)
            {
                switch (opcion)
                {
                    case 1:
                        ga.FillEllipse(grafo.brushN, p1.X - grafo.radio, p1.Y - grafo.radio, grafo.radio * 2, grafo.radio * 2);
                        ga.DrawEllipse(grafo.penN, p1.X - grafo.radio + (grafo.penN.Width / 2), p1.Y - grafo.radio + (grafo.penN.Width / 2), grafo.radio * 2 - (grafo.penN.Width / 2), grafo.radio * 2 - (grafo.penN.Width / 2));
                        ga.DrawString(nodoP.nombre.ToString(), grafo.font, grafo.brushF, p1.X - 6, p1.Y - 6);
                        break;

                    case 2:
                        if (bandF)
                        {
                            if (nodoP.Equals(nodoAux))
                                ga.DrawBezier(grafo.penA, nodoP.centro.X - 15, nodoP.centro.Y - 15, nodoP.centro.X - 20, nodoP.centro.Y - 60, nodoP.centro.X + 20, nodoP.centro.Y - 60, nodoP.centro.X + 15, nodoP.centro.Y - 15);
                            else
                                ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, nodoAux.centro), grafo.BuscaInterseccion(nodoAux.centro, nodoP.centro));
                        }
                        if (band)
                            ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, p2), p2);
                        break;

                    case 9:
                        if (bandF)
                        {
                            if (nodoP.Equals(nodoAux))
                                ga.DrawBezier(grafo.penA, nodoP.centro.X - 15, nodoP.centro.Y - 15, nodoP.centro.X - 20, nodoP.centro.Y - 60, nodoP.centro.X + 20, nodoP.centro.Y - 60, nodoP.centro.X + 15, nodoP.centro.Y - 15);
                            else
                                ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, nodoAux.centro), grafo.BuscaInterseccion(nodoAux.centro, nodoP.centro));
                        }
                        if (band)
                            ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, p2), p2);
                        break;
                }
                bandF = false;
            }

            if (bandI)
            {
                ga.Clear(BackColor);
                grafo.ImprimirGrafo(ga, bpar);
                bandI = false;
            }

            if (opcion == 6 || opcion == 7)
            {
                ga.Clear(BackColor);
                grafo.Clear();
                grafo.numN = 1;
                grafo.edoNom = false;
                if (opcion == 7)
                {
                    grafo = new Grafo();

                }
            }
            if (opcion != 6)
                if (opcion != 7)
                    grafo.ImprimirGrafo(ga, bpar);
            g.DrawImage(bmp1, 0, 0);


        }



        public void asignaPropiedades()
        {
            grafo.widthA = widthA;
            grafo.radio = radio;
            grafo.nomb = nomb;
            grafo.nameF = nameF;
            grafo.cRelleno = cRelleno;
            grafo.colorFuente = colorFuente;
            grafo.cNodo = cNodo;
            grafo.width = width;
            grafo.cArista = cArista;
            grafo.penN = new Pen(grafo.cNodo, grafo.width);
           
            grafo.brushN = new SolidBrush(grafo.cRelleno);
            grafo.brushF = new SolidBrush(grafo.colorFuente);
            grafo.font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
            grafo.penA = new Pen(grafo.cArista, grafo.widthA);


        }
        #endregion

        public void quitaPesos()
        {
            List<Control> control = new List<Control>();
            foreach (Control c in Controls)
            {
                if (c.Name == "peso")
                {
                    control.Add(c);

                }
            }
            foreach (Control c in control)
                Controls.Remove(c);
        }
       
        public void quitaNumeric()
        {
            List<Control> control = new List<Control>();
            foreach (Control c in Controls)
            {
                if (c.Name == "numeric")
                    control.Add(c);
            }
            foreach (Control c in control)
                Controls.Remove(c);
        }

        private void muestraPeso()
        {
            int pmx, pmy;

            Label label;
            foreach (NodoP np in grafo)
            {
                foreach (Arista nr in np.aristas)
                {
                    pmx = (nr.origen.centro.X + nr.destino.centro.X) / 2;
                    pmy = (nr.origen.centro.Y + nr.destino.centro.Y) / 2;
                    pmx += 5;
                    pmy += 5;
                    label = new Label();
                    label.ForeColor = Color.Blue;
                    label.Font = new System.Drawing.Font(label.Font, FontStyle.Bold);
                    label.Name = "peso";
                    label.Visible = true;
                    label.Width = 25;
                    label.Location = new Point(pmx, pmy);
                    label.Text = nr.peso.ToString();
                    
                    Controls.Add(label);


                }
            }
        }
        //textbox
        Arista aux, aux2;
        TextBox texaux;
        private void asignaPesos2(Point p) // pesos
        {
            int pmx, pmy; // PUNTO MEDIO EN X Y PUNTO MEDIO EN Y 

            aux = grafo.encuentraArista(p);
            if (grafo.tipo == 2)
                aux2 = grafo.encuentraSegundaArista(p);
            if (aux != null)
            {
                // MessageBox.Show("Nodo Origen " + temp.origen.nombre + "\nNodo Destino " + temp.destino.nombre);
                //  numeric = new NumericUpDown();
                //  numeric.Maximum = 100;
                // numeric.Minimum = 1;
                texaux = new TextBox();
                texaux.Text="1";


                if (aux.peso != 0)
                    texaux.Text = aux.peso.ToString();

                pmx = (aux.origen.centro.X + aux.destino.centro.X) / 2;
                pmy = (aux.origen.centro.Y + aux.destino.centro.Y) / 2;
                pmx += 5;
                pmy += 5;
                texaux.Name = "texaux";
                texaux.Width = 40;
                texaux.Location = new Point(pmx, pmy);
                texaux.TextChanged += texaux_TextChanged;
                aux.peso = int.Parse(texaux.Text);
                if (grafo.tipo == 2)
                {
                    try { aux2.peso = int.Parse(texaux.Text); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Area No Valida");
                    }
                }
                //aux2.peso = int.Parse(texaux.Text); // 
                Controls.Add(texaux); //
            }

        }
        public void quitaTexaux()
        {
            List<Control> control = new List<Control>();
            foreach (Control c in Controls)
            {
                if (c.Name == "texaux")
                    control.Add(c);
            }
            foreach (Control c in control)
                Controls.Remove(c);
        }






    }
}

