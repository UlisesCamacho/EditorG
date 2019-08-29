using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EditordeGrafos
{
    [Serializable()]
    public class Grafo:List<NodoP>
    {
        private List<Arista> aristas;
        private Color aridi;
        private Color arino;
        private Color CNod;
        public bool bosque;
        private int[][] Matriz;
        private int[][] MatrizCostos;
        private bool nombreAristasVisble;
        private bool pesoAristasVisible;
        private NodoP[][] P;

        #region get's & set's
        public Color ColorAristaDi { get { return aridi; } set { aridi = value; } }
        public Color ColorAristaNoDi { get { return arino; } set { arino = value; } }
        public Color ColorNodo { set { CNod = value; } }
        public List<Arista> Aristas { get { return aristas; } }
        public int[][] MATRIZ { get { return Matriz; } }
        public bool NombreAristasVisible { get { return nombreAristasVisble; } set { nombreAristasVisble = value; } }
        public bool PesoAristasVisible { get { return pesoAristasVisible; } set { pesoAristasVisible = value; } }
        #endregion
        #region constructores
        public Grafo()
        {
            aristas = new List<Arista>();
            bosque = false;
            aridi=Color.Black;
            arino = Color.Black;
            nombreAristasVisble=false;
            pesoAristasVisible = false;
            CNod = Color.White;
        }

        public Grafo(Grafo gr)
        {
            aristas = new List<Arista>();
            bosque = gr.bosque;
            aridi = gr.ColorAristaDi;
            arino = gr.ColorAristaNoDi;
            CNod = gr.CNod;
            NodoP aux1,aux2;
            Arista k = new Arista();
            nombreAristasVisble = gr.NombreAristasVisible;
            pesoAristasVisible = gr.PesoAristasVisible;
            foreach (NodoP n in gr)
            {
                this.Add(new NodoP(n));
            }
            foreach(NodoP n in gr)
            {
                aux1 = Find(delegate(NodoP bu) { if (bu.NOMBRE == n.NOMBRE)return true; else return false; });
                foreach (NodoRel rel in n.relaciones)
                {
                    aux2 = Find(delegate(NodoP je) { if (je.NOMBRE == rel.ARRIBA.NOMBRE)return true; else return false; });
                    aux1.insertaRelacion(aux2, Aristas.Count);
                }
            }
            foreach (Arista ar in gr.aristas)
            {
                aux1 = Find(delegate(NodoP bu) { if (bu.NOMBRE == ar.Origen.NOMBRE)return true; else return false; });
                aux2 = Find(delegate(NodoP bu) { if (bu.NOMBRE == ar.Destino.NOMBRE)return true; else return false; });
                k = new Arista(ar.Tipo, aux1, aux2, ar.NOMBRE);
                k.PESO = ar.PESO;
                AgregaArista(k);
            }
        }
        #endregion
        #region operaciones
        public void AgregaNodo(NodoP n)
        { 
            Add(n);
        }

        public void AgregaArista(Arista A)
        {
            aristas.Add(A);
        }
        public void RemueveArista(Arista ar)
        {
            NodoRel rel;
            rel = ar.Origen.relaciones.Find(delegate(NodoRel np) { if (np.ARRIBA.NOMBRE==ar.Destino.NOMBRE)return true; else return false; });
            if (rel != null)
            {
                ar.Origen.relaciones.Remove(rel);
                ar.Origen.GRADO--;
                ar.Destino.GRADO--;
                ar.Origen.GradoExterno--;
                ar.Destino.GradoInterno--;
            }
            if (ar.Tipo == 2)
            {
                rel = ar.Destino.relaciones.Find(delegate(NodoRel np) { if (np.ARRIBA.NOMBRE==ar.Origen.NOMBRE)return true; else return false; });
                if (rel != null)
                {
                    ar.Destino.relaciones.Remove(rel);
                    ar.Destino.GradoExterno--;
                    ar.Origen.GradoInterno--;
                }
            }
            aristas.Remove(ar);
        }
        public void RemueveNodo(NodoP rem)
        {
            NodoRel rel;
            List<Arista>remover;
            remover=new List<Arista>();
            
            foreach (NodoP a in this)
            {
                rel = a.relaciones.Find(delegate(NodoRel np) { if (np.ARRIBA.NOMBRE==rem.NOMBRE)return true; else return false; });
                if (rel != null)
                {
                    a.relaciones.Remove(rel);
                    a.GRADO--;
                    a.GradoExterno--;
                    if (aristas[0].Tipo == 0 || aristas[0].Tipo == 2)
                        a.GradoInterno--;
                }
            }
            remover=aristas.FindAll(delegate(Arista ar){if(ar.Origen.NOMBRE==rem.NOMBRE||ar.Destino.NOMBRE==rem.NOMBRE)return true;else return false;});
            if(remover!=null)
                foreach(Arista re in remover)
                {
                    aristas.Remove(re);
                }
            this.Remove(rem);
        }
        #endregion
        #region paint
        public void pinta(Graphics g)
        {
            Pen pendi = new Pen(aridi);
            Pen pendiCa = new Pen(Color.Red);
            Pen penNdi = new Pen(arino);
            Pen penNdiCa = new Pen(Color.Red);
            Pen pen = new Pen(Color.Black);
            AdjustableArrowCap end=new AdjustableArrowCap(6,6);
            SolidBrush nod;
            pen.Width = 1;
            penNdi.Width = 1;
            penNdiCa.Width = 3;
            pendiCa.CustomEndCap = end;
            pendiCa.Width = 3;
            pendi.CustomEndCap = end;
            pendi.Width =1;
            Size s = new Size(30, 30);
            double p3x,p3y, p4x,p4y;
            double ang;
            PointF A, B;
            A = new PointF();
            double d;
            double r;
            double an;
            int multi;
            double dy,dx;
            dy = dx=0;
            List<Arista> repetidas=new List<Arista>();
            if(bosque)
            {
                g.DrawRectangle(new Pen(Brushes.Black), 60,50 , 100, 100);
                g.DrawString("Arista de Arbol",SystemFonts.DialogFont,Brushes.Brown,61,55);
                g.DrawString("Arista de Retroceso", SystemFonts.DialogFont, Brushes.Red, 61, 70);
                g.DrawString("Arista de Avance", SystemFonts.DialogFont, Brushes.Green, 61, 85);
                g.DrawString("Arista Cruzada", SystemFonts.DialogFont, Brushes.Purple, 61, 100);
            }
            if (aristas.Count > 0)
                foreach (Arista a in aristas)
                {
                    
                    if (a.Tipo != 1)
                    {
                        if (a.Origen.NOMBRE == a.Destino.NOMBRE)
                        {
                            g.DrawBezier(penNdi, new Point(a.Origen.POS.X-10,a.Origen.POS.Y-5), new Point(a.Origen.POS.X-40 , a.Origen.POS.Y -60), new Point(a.Origen.POS.X+40,a.Destino.POS.Y-60), new Point(a.Destino.POS.X+10,a.Destino.POS.Y-5));
                        }
                        else
                        {
                            if (!a.CAMINO)
                            {
                                g.DrawLine(penNdi, a.Origen.POS.X, a.Origen.POS.Y, a.Destino.POS.X, a.Destino.POS.Y);
                            }
                            else
                                g.DrawLine(penNdiCa, a.Origen.POS.X, a.Origen.POS.Y, a.Destino.POS.X, a.Destino.POS.Y);
                            
                               
                        }
                        repetidas = aristas.FindAll(delegate(Arista repe) { if (repe.Origen.NOMBRE == a.Origen.NOMBRE && repe.Destino.NOMBRE == a.Destino.NOMBRE || (a.Origen.NOMBRE == repe.Destino.NOMBRE && a.Destino.NOMBRE == repe.Origen.NOMBRE))return true;else return false; });
                        if (repetidas.Count > 1 && a.PINTADA==false)
                        {
                            if ((a.Destino.POS.Y - a.Origen.POS.Y) != 0 )
                            {
                                g.DrawString(repetidas.Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Origen.POS.X + ((a.Destino.POS.X - a.Origen.POS.X) / 2) + 4, a.Origen.POS.Y + ((a.Destino.POS.Y - a.Origen.POS.Y) / 2) + 4);                                foreach (Arista re in repetidas)
                                    re.PINTADA = true;
                            }
                        }
                    }
                    else
                    {
                        if (a.Origen.NOMBRE == a.Destino.NOMBRE)
                        {
                            g.DrawBezier(pendi, new Point(a.Origen.POS.X - 10, a.Origen.POS.Y - 5), new Point(a.Origen.POS.X - 40, a.Origen.POS.Y - 60), new Point(a.Origen.POS.X + 40, a.Destino.POS.Y - 60), new Point(a.Destino.POS.X + 10, a.Destino.POS.Y - 10));
                        }
                        else
                        {
                            if (aristas.Find(delegate(Arista bus) { if (bus.Origen.NOMBRE == a.Destino.NOMBRE && bus.Destino.NOMBRE == a.Origen.NOMBRE)return true; else return false; }) == null)
                            {
                                double teta1 = Math.Atan2((double)(a.Destino.POS.Y - a.Origen.POS.Y),(double)( a.Destino.POS.X - a.Origen.POS.X));
                                float x1 = a.Origen.POS.X + (float)((Math.Cos(teta1)) * 15);
                                float y1 = a.Origen.POS.Y + (float)((Math.Sin(teta1)) * 15);

                                double teta2 = Math.Atan2(a.Origen.POS.Y - a.Destino.POS.Y, a.Origen.POS.X - a.Destino.POS.X);
                                float x2 = a.Destino.POS.X + (float)((Math.Cos(teta2)) * 15);
                                float y2 = a.Destino.POS.Y + (float)((Math.Sin(teta2)) * 15);
                                if (!a.CAMINO)
                                {
                                    pendi.Width = 2;
                                    if (a.bosqueT == 1)
                                        pendi.Color = Color.Brown; //arbol
                                    if (a.bosqueT == 2)
                                        pendi.Color = Color.Red;// retroceso
                                    if (a.bosqueT == 3)
                                        pendi.Color = Color.Green; // avance
                                    if (a.bosqueT == 4)
                                        pendi.Color = Color.Purple; // cruzada
                                    if (a.bosqueT == 0)
                                    {
                                        pendi.Width = 1;
                                        pendi.Color = Color.Black;
                                    }

                                    g.DrawLine(pendi, x1, y1, x2, y2);

                                }
                                else
                                    g.DrawLine(pendiCa, x1, y1, x2, y2);
                                if (aristas.FindAll(delegate(Arista repe) { if (repe.Origen.NOMBRE == a.Origen.NOMBRE && repe.Destino.NOMBRE == a.Destino.NOMBRE)return true; else return false; }).Count > 1)
                                {
                                    if ((a.Destino.POS.Y - a.Origen.POS.Y) != 0)
                                        g.DrawString(aristas.FindAll(delegate(Arista repe) { if (repe.Origen.NOMBRE == a.Origen.NOMBRE && repe.Destino.NOMBRE == a.Destino.NOMBRE)return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Origen.POS.X + ((a.Destino.POS.X - a.Origen.POS.X) / 2) + 4, a.Origen.POS.Y + ((a.Destino.POS.Y - a.Origen.POS.Y) / 2) + 4);
                                }

                            }
                            else
                            {
                                if (a.PINTADA == false)
                                {
                                    dy = a.Destino.POS.Y - a.Origen.POS.Y;
                                    dx = a.Destino.POS.X - a.Origen.POS.X;
                                    p3x = (dx * 1 / 3) + a.Origen.POS.X;
                                    p3y = (dy * 1 / 3) + a.Origen.POS.Y;
                                    p4x = (dx * 2 / 3) + a.Origen.POS.X;
                                    p4y = (dy * 2 / 3) + a.Origen.POS.Y;
                                    d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                                    r = .35 * d;
                                    if (a.Destino.POS.X != a.Origen.POS.X)
                                        ang = Math.Atan((double)((double)dy / (double)dx));
                                    else
                                        ang = 90;

                                    if (a.Destino.POS.X > a.Origen.POS.X)
                                        an = ang + 89.8;
                                    else
                                        an = ang - 89.8;
                                   // if (a.Destino.POS.X < a.Origen.POS.X)
                                     //   g.DrawString(ang.ToString(), new Font("Bold", 10), Brushes.Red, a.Destino.POS.X - 60, a.Destino.POS.Y - 60);
                                    B = new PointF((float)((r * Math.Cos(an)) + p4x), (float)((r * Math.Sin(an)) + p4y /*+ 15 * (an / Math.Abs(an))*/));
                                    A = new PointF((float)((r * Math.Cos(an)) + p3x), (float)((r * Math.Sin(an)) + p3y /*+ 15 * (an / Math.Abs(an))*/));
                                    if (a.Destino.POS.X > a.Origen.POS.X)
                                        an = ang + 89.56;
                                    else
                                        an = ang - 89.56;
                                    g.DrawBezier(pendi, new PointF(a.Origen.POS.X + (float)((Math.Cos(an)) * 15), a.Origen.POS.Y + (float)((Math.Sin(an)) * 15)), A, B, new PointF(a.Destino.POS.X  + (float)((Math.Cos(an)) * 15), a.Destino.POS.Y  + (float)((Math.Sin(an)) * 15)));
                                  

                                    a.PINTADA = true;                   
                                }
                            }
                            if (aristas.FindAll(delegate(Arista repe) { if (repe.Origen.NOMBRE == a.Origen.NOMBRE && repe.Destino.NOMBRE == a.Destino.NOMBRE)return true; else return false; }).Count > 1)
                            {
                                if((a.Destino.POS.Y - a.Origen.POS.Y)!=0)
                              g.DrawString(aristas.FindAll(delegate(Arista repe) { if (repe.Origen.NOMBRE == a.Origen.NOMBRE && repe.Destino.NOMBRE == a.Destino.NOMBRE)return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Destino.POS.X,A.Y-10);
                            }
                        }
                    }
                   

                    if (nombreAristasVisble)
                        g.DrawString(a.NOMBRE, new Font("Bold", 10), Brushes.Blue, a.Origen.POS.X + ((a.Destino.POS.X - a.Origen.POS.X) / 3) + 4, a.Origen.POS.Y + ((a.Destino.POS.Y - a.Origen.POS.Y) / 2) + 1);
                    else
                    {
                        if (pesoAristasVisible)
                        {
                            if (aristas.Find(delegate(Arista bus) { if (bus.Origen.NOMBRE == a.Destino.NOMBRE && bus.Destino.NOMBRE == a.Origen.NOMBRE)return true; else return false; }) == null)
                            {
                                g.DrawString(a.PESO.ToString(), new Font("Bold", 10), Brushes.Blue, a.Origen.POS.X + ((a.Destino.POS.X - a.Origen.POS.X) / 2) + 4, a.Origen.POS.Y + ((a.Destino.POS.Y - a.Origen.POS.Y) / 2) + 4);
                            }
                            else
                            {
                                g.DrawString(a.PESO.ToString(), new Font("Bold", 10), Brushes.Blue, a.Destino.POS.X, A.Y - 10);
                            }
                        }
                    }
                   
                    }
            foreach (Arista des in aristas)
                des.PINTADA = false;
            foreach (NodoP n in this)
            {   
                pendi.Width = 3;
                if(n.SELECCIONADO==false)
                    nod = new SolidBrush(n.COLOR);
                else
                    nod = new SolidBrush(Color.Red);
                Rectangle re = new Rectangle(n.POS.X - 15, n.POS.Y - 15, s.Width, s.Height);
                
                g.FillEllipse(nod, re);
                g.DrawEllipse(pen, re);
                g.DrawString(n.NOMBRE.ToString(), new Font("Bold", 10), Brushes.Black, n.POS.X -5, n.POS.Y -7);            
            }
            pendi.Dispose();
            penNdi.Dispose();
            pen.Dispose();
           
        }
        #endregion
        #region algoritmos


        /// <summary>
        /// Regresa el color anterior a un nodo despues de haber hecho el metodo de coloreados y haberlo cerrado
        /// </summary>
        /// <param name="anterior"></param>
        public void desColorea(Color anterior)
        {
            foreach (NodoP desco in this)
                desco.COLOR = anterior;
        }
        /// <summary>
        /// Se crea la matriz relación
        /// </summary>
        public void CreaMatriz()
        {
            Matriz = new int[Count][];
            int i,j;
           
            
            for (int x = 0; x < Count; x++)
            {
                Matriz[x]=new int[Count];
            }
            i=0;
            this.Sort(delegate(NodoP a, NodoP b) { return a.NOMBRE.CompareTo(b.NOMBRE); });
            foreach(NodoP nod in this)
            {
                j=0;
                foreach(NodoP nod2 in this)
                {
                    if (nod.relaciones.Find(delegate(NodoRel r) { if (nod2.NOMBRE == r.ARRIBA.NOMBRE )return true; else return false; }) != null)
                    {
                        Matriz[i][j] = 1; //1

                    }
                    else
                    {
                        Matriz[i][j] = 0;   //0
                    }
                    j++;
                }
                i++;
            }
        }

        public int MatrizInfinita(NodoP origen,NodoP destino,int n,ToolStripProgressBar barra)
        {
            List<NodoP> res = new List<NodoP>();
            List<NodoP> aux = new List<NodoP>();
            barra.Step = 100/n;
            barra.Value=0;
            foreach (NodoRel r in origen.relaciones)
            {
                aux.Add(r.ARRIBA);
                res.Add(r.ARRIBA);
            }
            barra.Value += barra.Step;
            for (int i = 0; i < n - 1; i++)
            {
                barra.Value += barra.Step ;
                res = new List<NodoP>();
                foreach (NodoP j in this)
                {
                    foreach (NodoP k in aux)
                    {
                        if (j.relaciones.Find(delegate(NodoRel re) { if (re.ARRIBA.NOMBRE == k.NOMBRE)return true; else return false; }) != null)
                        {
                            res.Add(j);
                        }
                    }

                }
                aux = new List<NodoP>();
                foreach (NodoP resp in res)
                    aux.Add(resp);
            }
            aux = res.FindAll(delegate(NodoP f) { if (f.NOMBRE == destino.NOMBRE)return true; else return false; });
            return aux.Count;
        }

        public int CaminosRecursivo(NodoP origen,NodoP destino,int n)
        {
            int cam = 0;
            if (n == 0)
            {
                if (origen == destino)
                    return 1;
                else
                    return 0;
            }
            else
                foreach (NodoRel r in origen.relaciones)
                    cam += CaminosRecursivo(r.ARRIBA, destino, n - 1);
            return cam;  
        }

        public int Componentes2(NodoP nodito,List<NodoP> compo)
        {
            if(nodito.relaciones.Find(delegate(NodoRel r) { if (r.VISITADA!=true )return true; else return false; }) == null )
                return 1;
            else
            {
                compo.Add(nodito);
                foreach (NodoRel a in nodito.relaciones)
                {
                    if (a.VISITADA == false)
                    {
                        a.VISITADA = true;
                        compo.Add(a.ARRIBA);
                        Componentes2(a.ARRIBA, compo);
                        
                    }
                    
                }
                
                return 0;
            }
        }
        /// <summary>
        /// Cuenta los componentes que tiene el grafo
        /// </summary>
        /// <returns></returns>
        public int Componentes()
        {
            List<List<NodoP>> componentes = new List<List<NodoP>>();
            List<NodoP> nue = new List<NodoP>();
            Grafo aux = new Grafo(this);
            bool enco = false;
            bool enco2=false;
            if (aristas.Count != 0)
            {
                foreach (NodoP nod in this)
                {
                    foreach (List<NodoP> n in componentes)
                    {
                        if (enco == false)
                            if (n.Find(delegate(NodoP f) { if (f.NOMBRE == nod.NOMBRE)return true; else return false; }) != null)
                                enco = true;
                    }
                    if (enco == false)
                    {
                        if (aristas[0].Tipo == 1)
                        {
                            foreach (List<NodoP> n in componentes)
                            {
                                foreach (NodoP ee in n)
                                {
                                    foreach (NodoRel r in ee.relaciones)
                                    {
                                        if (enco2 == false)
                                            if (n.Find(delegate(NodoP f) { if (f.NOMBRE == r.ARRIBA.NOMBRE)return true; else return false; }) != null)
                                                enco2 = true;
                                    }
                                }
                            }
                            if (enco2 == false)
                            {
                                nue = new List<NodoP>();
                                this.Componentes2(nod, nue);
                                componentes.Add(nue);
                            }

                            enco2 = false;
                        }
                        else
                        {
                            nue = new List<NodoP>();
                            this.Componentes2(nod, nue);
                            componentes.Add(nue);
                        }
                    }
                    enco = false;

                }
                foreach (NodoP re in this)
                {
                    foreach (NodoRel rela in re.relaciones)
                    {
                        rela.VISITADA = false;
                    }
                }

                return componentes.Count;
            }
            else
                return this.Count;
        }

        public void desseleccionar()
        {
            foreach (NodoP r in this)
            {
                r.SELECCIONADO = false;
            }
        }
        /// <summary>
        /// Crea los conjuntos de nodos en base al algoritmo de coloreados 
        /// </summary>
        /// <returns></returns>
        public List<List<NodoP>> colorear()
        {
            Color co;
            int re,g,b;
            re = 0;
            g = 0;
            b = 255;
            co = Color.FromArgb(re, g, b);
            
            bool found = false;
            List<List<NodoP>> listas=new List<List<NodoP>>();
            List<NodoP> au = new List<NodoP>();
            foreach(NodoP nodin in this)
            {
                foreach(List<NodoP> c in listas )
                {
                    if(found==false)
                        if (c.Find(delegate(NodoP a) { if (a.relaciones.Find(delegate(NodoRel r) { if (r.ARRIBA.NOMBRE == nodin.NOMBRE)return true; else return false; }) != null || nodin.relaciones.Find(delegate(NodoRel rela){if(rela.ARRIBA.NOMBRE==a.NOMBRE)return true;else return false;})!=null)return true; else return false; }) == null)
                        {
                            c.Add(nodin);
                            found = true;
                        }
                }
                if (found == false)
                {
                    au = new List<NodoP>();
                    au.Add(nodin);
                    listas.Add(au);
                }
                found = false;
            }
            foreach(List<NodoP> a in listas)
            {
                foreach (NodoP n in a)
                {
                    n.COLOR = co;
                }
                if (re + 100 >= 255)
                {
                    re = 0;
                    if (g + 100 >= 255)
                    {
                        g = 0;
                        if (b + 150 >= 255)
                        {
                            b = 0;
                        }
                        else
                            b += 150;
                    }
                    else
                        g += 100;
                }
                else
                {
                    re += 100;
                    b = 180;
                }
                co = Color.FromArgb(co.R-co.R+re, co.G-co.G+g, co.B-co.B+b );      
            }
            return listas;

        }


        /// <summary>
        /// Verifica si el grafo tiene un circuito eulereano 
        /// </summary>
        /// <param name="origen">para saber de donde viene</param>
        /// <param name="destino">para saber a donde va</param>
        /// <param name="n">iterador para contar la recursion</param>
        /// <param name="caminito">donde se devuelve la lista con los nodos a visitar</param>
        /// <returns></returns>
        public int Circuito(NodoP origen, NodoP destino, int n,List<NodoP>caminito)
        {
            int cam = 0,j=0;
            bool ya=true;
            NodoP nodi = new NodoP() ;
            List<NodoP> otra = new List<NodoP>();
            foreach (NodoP k in this)
            {
                k.relaciones.Sort(delegate(NodoRel a, NodoRel b) { return b.ARRIBA.GRADO.CompareTo(a.ARRIBA.GRADO); });
            }
            if (n == 0)
            {
               
                foreach (NodoP no in this)
                {
                    foreach (NodoRel r in no.relaciones)
                    {
                        if (r.VISITADA ==false && ya==true)
                            ya = false;       
                    }
                }
                if (ya == true)
                {
                    if (origen.NOMBRE == destino.NOMBRE)
                    {
                       
                        return 1;
                    }
                    else
                        return 0;
                }
            }
            else
                foreach (NodoRel r in origen.relaciones)
                {
                    if (r.ARRIBA.relaciones.Find(delegate(NodoRel je) { if (je.ARRIBA == origen)return true; else return false; }) != null)
                        r.ARRIBA.relaciones.Find(delegate(NodoRel je) { if (je.ARRIBA == origen)return true; else return false; }).VISITADA = true;
                    if (r.VISITADA != true)
                    {
                        r.VISITADA = true;
                        j = Circuito(r.ARRIBA, destino, n - 1, caminito);
                        if (j == 0)
                        {
                            r.VISITADA = false;
                           
                        }
                        else
                        {
                            cam += j;
                            caminito.Add(r.ARRIBA);
                            
                        }
                    }
                }

               
                

            
            return cam;
        }
        /// <summary>
        /// Para simular el camino de euler 
        /// </summary>
        /// <param name="orden">nos devuelve el orden</param>
        /// <param name="grafico">tipo grafo</param>
        public void Simula(List<NodoP>orden,Graphics grafico)
        {
            Arista ari;
            Grafo grafi = new Grafo(this);
            aristas.Clear();
            foreach (NodoP no in this)
            {
                no.relaciones.Clear();
            }
            for (int i = orden.Count-1; i >=0 ; i--)
            {
                if (i > 0)
                {
                    Find(delegate(NodoP d) { if (d.NOMBRE == orden[i].NOMBRE)return true; else return false; }).insertaRelacion(Find(delegate(NodoP o) { if (o.NOMBRE == orden[i - 1].NOMBRE)return true; else return false; }), Aristas.Count);
                    ari = new Arista(1, Find(delegate(NodoP d) { if (d.NOMBRE == orden[i].NOMBRE)return true; else return false; }), Find(delegate(NodoP o) { if (o.NOMBRE == orden[i - 1].NOMBRE)return true; else return false; }), "e"+(orden.Count-i).ToString());
                    ari.PESO = grafi.aristas.Find(delegate(Arista aris) { if (aris.Origen.NOMBRE == ari.Origen.NOMBRE && aris.Destino.NOMBRE == ari.Destino.NOMBRE)return true; else return false; }).PESO;
                    if(ari!=null)
                        AgregaArista(ari);
              
                }
            }
            pesoAristasVisible = true;
        }

        /// <summary>
        /// Sirve para crear la matriz de costos 
        /// </summary>
           public void creaMatrizCostos()
        {
            MatrizCostos = new int[Count][];
            int i = 0;
            int j = 0;
            string cad = "";
            Arista ari,aris;
            for (int x = 0; x < Count; x++)
            {
                MatrizCostos[x] = new int[Count];
            }

            foreach(NodoP a in this)
            {
                foreach(NodoP b in this)
                {
                    if (i != j)
                    {

                        if (a.relaciones.Find(delegate(NodoRel r) { if (r.ARRIBA == b) { return true; } else return false; }) != null)
                        {
                            aris = aristas.Find(delegate(Arista ar) { if (ar.Origen.NOMBRE == a.NOMBRE && ar.Destino.NOMBRE == b.NOMBRE)return true; else return false; });
                            if(aris==null)
                                aris = aristas.Find(delegate(Arista ar) { if (ar.Origen.NOMBRE == b.NOMBRE && ar.Destino.NOMBRE == a.NOMBRE)return true; else return false; });
                            if(aris!=null)    
                                MatrizCostos[i][j] = aris.PESO;

                        }
                        else
                            MatrizCostos[i][j] = 10000000;                
                    }
                    else
                        MatrizCostos[i][j] = 0;
                    j++;
                }
                i++;
                j = 0;
            }
        }

        /// <summary>
        /// Algoritmo de Dijkstra 
        /// </summary>
        /// <param name="origen">para saber de donde viene</param>
        /// <param name="caminos">para saber a donde va </param>
        /// <returns></returns>
        public int[] Dijkstra(NodoP origen,ref List<string[]>caminos)
        {
            int[] D=new int[Count];
            List<NodoP> S = new List<NodoP>();
            List<NodoP> VmS = new List<NodoP>();
            NodoP w=new NodoP();
            string[] orDon=null;
           
            Arista ar = new Arista();
            int ant = 100000000;
            int pw;
            int pv;
            int iO = FindIndex(delegate(NodoP a) { if (a == origen)return true; else return false; }); ;
            caminos = new List<string[]>();

            foreach (NodoP e in this)
            {
                VmS.Add(e);
            }
            S.Add(origen);
            VmS.Remove(origen);
            creaMatrizCostos();
            for (int i = 0; i < Count; i++)
            {
                D[i] = MatrizCostos[iO][i];
            }
            for (int i = 0; i < Count; i++)
            {
                if (i != iO)
                {
                    foreach (NodoP x in VmS)
                    {
                        pw=this.FindIndex(delegate(NodoP a){if(a==x)return true;else return false;});
                        if(D[pw]<ant)
                        {
                            ant = D[pw];
                            w = x;
                        }
                       
                    }
                    S.Add(w);
                    VmS.Remove(w);
                    ant = 100000000;
                    pw = this.FindIndex(delegate(NodoP a) { if (a == w)return true; else return false; });
                    if (pw > 0)
                    {
                        foreach (NodoP v in VmS)
                        {
                            if (v.relaciones.Find(delegate(NodoRel rel) { if (rel.ARRIBA == w)return true; else return false; }) != null || w.relaciones.Find(delegate(NodoRel rel) { if (rel.ARRIBA == v)return true; else return false; }) != null)
                            {
                                pv = this.FindIndex(delegate(NodoP a) { if (a == v)return true; else return false; });
                                if (D[pv] > (D[pw] + MatrizCostos[pw][pv]))
                                {
                                    D[pv] = (D[pw] + MatrizCostos[pw][pv]);
                                    foreach(string[] bu in caminos)
                                    {
                                        if (bu[0].CompareTo(this[pv].NOMBRE) == 0)
                                            orDon = bu;
                                    }
                                    if(orDon==null)
                                    {
                                        orDon = new string[2];
                                        caminos.Add(orDon);
                                    }
                                    orDon[0] = this[pv].NOMBRE;
                                    orDon[1] = this[pw].NOMBRE;
                                    orDon=null;

                                    
                                    
                                }
                            }
                        }
                    }
                }
            }


           return D;
          /*  List<NodoP> S = new List<NodoP>();
            int []D=new int[Count];
            int iO=this.FindIndex(delegate(NodoP a){if(a==origen)return true;else return false;});
            int pw = 0;
            int pv = 0;
            int t;
            Arista ar = new Arista();
            NodoP w=new NodoP();
            int ant = 100000000;
            List<NodoP>VmS=new List<NodoP>();
            List<NodoP>camino=new List<NodoP>();
            foreach (NodoP e in this)
            {
                VmS.Add(e);
            }
            S.Add(origen);
            VmS.Remove(origen);
            creaMatrizCostos();
            for(int i=0;i<Count;i++)
            {
                D[i]=MatrizCostos[iO][i];
                }           
            for (int i =0; i < Count; i++)
            {
                
                if (i != iO)
                {
                    foreach (NodoP x in VmS)
                    {
                        ar=aristas.Find(delegate(Arista a){if(a.Origen.NOMBRE==origen.NOMBRE && a.Destino.NOMBRE==x.NOMBRE)return true;else return false;});
                        
                        if (ar != null)
                        {
                            if (ar.PESO == 100)
                                t = 1;
                            if (ar.PESO < ant)
                            {
                                ant = ar.PESO;
                                w = x;
                            }
                        }
                    }
                    S.Add(w);
                    VmS.Remove(w);
                    ant = 100000000;
                    pw = this.FindIndex(delegate(NodoP a) { if (a == w)return true; else return false; });
                    if (pw > 0)
                    {
                        foreach (NodoP v in VmS)
                        {
                            if (v.relaciones.Find(delegate(NodoRel rel) { if (rel.ARRIBA == w)return true; else return false; }) != null || w.relaciones.Find(delegate(NodoRel rel) { if (rel.ARRIBA == v)return true; else return false; }) != null)
                            {
                                pv = this.FindIndex(delegate(NodoP a) { if (a == v)return true; else return false; });
                                if (D[pv] > (D[pw] + MatrizCostos[pw][pv]))
                                {
                                    D[pv] = (D[pw] + MatrizCostos[pw][pv]);
                                    camino.Add(this[pw]);
                                }
                            }
                        }
                    }
                }
            }
            return D;*/
        }   
        
        public void dejaCaminoDijkstra(List<string[]>caminos,int[] costos,NodoP origen,NodoP destino)
        {
            bool ya = false;
            int costo;   
            string[]x;
            //10000000
            int index;
            string destinAux=destino.NOMBRE;
            string camino = " " ;
            while(!ya)
            {
                x=caminos.Find(delegate(string[] bus){if(bus[0].CompareTo(destinAux)==0)return true;else return false;});
                if(x==null)
                {
                    index=FindIndex(delegate(NodoP b){if(b.NOMBRE.CompareTo(destinAux)==0)return true;else return false;});
                    if (index != -1)
                    {
                        costo = costos[index];
                        if(costo!=10000000 && costo!=0)
                        {
                            camino=camino.Insert(0,origen.NOMBRE);
                            ya=true;
                        }
                        else
                        {
                            MessageBox.Show("No hay camino a ese nodo");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay camino a ese nodo");
                        return;
                    }
                }
                else
                {
                    camino=camino.Insert(0, x[1] + x[0]);
                    destinAux = x[1];
                    caminos.Remove(x);
                }
            }
            ColoreaRuta(camino,destino.NOMBRE);
        }

        /// <summary>
        /// Colorea la ruta 
        /// </summary>
        /// <param name="ruta">lista de nodos </param>
        /// <param name="destino">para saber a donde va </param>
        public void ColoreaRuta(string ruta,string destino)
        {
            string or = "", des = "";
            bool ya = false;
            Arista a;
            string ruta2="";
            foreach(char c in ruta)
            {
                if(!ruta2.Contains(c))
                    ruta2 += c.ToString();
            }
            ruta = ruta2;
            or = ruta[0].ToString();
            des=ruta[1].ToString();
            if (des.CompareTo(" ")==0)
                des = destino; 
            ruta = ruta.Remove(0,2);
            

            while(!ya)
            {
                a = aristas.Find(delegate(Arista b) { if (b.Origen.NOMBRE.CompareTo(or) == 0 && b.Destino.NOMBRE.CompareTo(des) == 0)return true; else return false; });
                if(a==null)
                    a = aristas.Find(delegate(Arista b) { if (b.Origen.NOMBRE.CompareTo(des) == 0 && b.Destino.NOMBRE.CompareTo(or) == 0)return true; else return false; });
                a.CAMINO=true;
                or=des;
                if(ruta.Length>1)
                {
                    des=ruta[0].ToString();
                    ruta=ruta.Remove(0,1);
                }
                else
                    ya=true;
            }
            
        }

        /// <summary>
        /// Algoritmo de Floyd 
        /// </summary>
        /// <returns></returns>
        public int[][] FLoyd()
        {
            int[][] A;
            int i, j, k;
            P = new NodoP[Count][];
            creaMatrizCostos();
            A = new int[Count][];
            for (int x = 0; x < Count; x++)
            {
                A[x] = new int[Count];
                P[x]=new NodoP[Count];
            }
            for (i = 0; i < Count ; i++)
            {
                for (k= 0; k < Count ; k++)
                {
                    A[i][k] = MatrizCostos[i][k];
                }
            }
            for (k = 0; k < Count; k++)
            {
                for (i = 0; i < Count; i++)
                {
                    for (j = 0; j < Count; j++)
                    {
                        if (((A[i][k]) + (A[k][j])) < A[i][j])
                        {
                            A[i][j] = (A[i][k]) + (A[k][j]);
                            P[i][j] = this[k];
                        }
                    }
                }
            }

            return A;

        }
        /// <summary>
        /// Contiene la lista de nodos FLoyd 
        /// </summary>
        /// <param name="i">iterador matriz i</param>
        /// <param name="j">iterador matriz j</param>
        /// <returns></returns>
        public List<NodoP> imprimeFloyd(NodoP i,NodoP j)
        {
            List<NodoP> cami = new List<NodoP>();
            NodoP k;
            k=P[(this.FindIndex(delegate(NodoP a){ if (i.NOMBRE == a.NOMBRE)return true; else return false; }))][this.FindIndex(delegate(NodoP a){ if (j.NOMBRE == a.NOMBRE)return true; else return false; })];
            if (k == null)
            {
                cami.Add(j);
                return cami;

            }
                imprimeFloyd(i, k);
                cami.Add(k);
                imprimeFloyd(k, j);
            
            return cami;
        }

        public NodoP centroGrafo()
        {
            int [][]A;
            int posi=0;
            int[] excen;
            int may=0;
            excen = new int[Count];
            A = new int[Count][];
            for (int x = 0; x < Count; x++)
            {
                A[x] = new int[Count];
            }
            A=FLoyd();
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    if (A[j][i] > may)
                        may = A[j][i];
                }
                excen[i]=may;
                may=0;
            }
            may = 1000;
            for (int i = 0; i < Count; i++)
            {
                if (excen[i] < may)
                {
                    may = excen[i];
                    posi = i;
                }
            }
            return this[posi];

        }

        public string clasifiacionTopologica(NodoP v)
        {
            NodoP w;
            string a="";
            v.VISITADO = true;
            foreach (NodoRel l in v.relaciones)
            {
                w = l.ARRIBA;
                if (w.VISITADO==false)
                {
                    
                     a+=clasifiacionTopologica(w);
                    // a += v.NOMBRE.ToString();
                } 
            }
            a += v.NOMBRE.ToString();
            return a;
          //  MessageBox.Show(a);
        }

        public List<NodoP> verticesCut()
        {
            List<NodoP> cut = new List<NodoP>();
            bool enco = false;
            List<List<NodoP>> componentes = new List<List<NodoP>>();
            List<NodoP> nue = new List<NodoP>();
            Grafo aux = new Grafo(this);

            foreach(NodoP c in this)
            {
                aux.RemueveNodo(aux.Find(delegate(NodoP f){if(f.NOMBRE==c.NOMBRE)return true;else return false;}));
               /* foreach (NodoP nod in aux)
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
                        aux.Componentes(nod, nue);
                        componentes.Add(nue);
                    }
                    enco = false;

                }*/
                //if (componentes.Count > 1)
                if(aux.Componentes()>1)
                {
                    cut.Add(c);
                    aux = new Grafo(this);
                    enco = false;
                    componentes = new List<List<NodoP>>();
                    nue = new List<NodoP>();
                }
                else
                {
                    aux = new Grafo(this);
                    enco = false;
                    componentes = new List<List<NodoP>>();
                    nue = new List<NodoP>();
                }
                

            }
            return cut;
        }
        /// <summary>
        /// Algoritmo amplitud
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string amplitud(NodoP S)
        {
            string ret = "";
            NodoP origen = S,v;
            ret += origen.NOMBRE;
            origen.VISITADO = true;
            List<NodoP> faltantes=new List<NodoP>();
            faltantes.Add(origen);

            while(faltantes.Count>0)
            {
                v=faltantes[0];
                faltantes.Remove(v);
                foreach(NodoRel w in v.relaciones)
                {
                    if(!w.ARRIBA.VISITADO)
                    {
                        faltantes.Add(w.ARRIBA);
                        ret += w.ARRIBA.NOMBRE;
                    }
                }
            }
            
            return ret;
        }
        /// <summary>
        /// Algoritmo aciclíco
        /// </summary>
        /// <returns></returns>
        public bool aciclico()
        {
            bool ret=false;
           
            foreach(NodoP origen in this)
            {
                foreach (NodoP p in this)
                    p.VISITADO = false;
                ret = ciclo(origen, origen);
                if (ret)
                    break;
            }
            return !ret;

        }

        public bool ciclo(NodoP or,NodoP act)
        {
            bool ret=false;

            if(or.NOMBRE.CompareTo(act.NOMBRE)==0 && act.VISITADO)
            {
                return true;
            }

            act.VISITADO = true;

            foreach(NodoRel r in act.relaciones)
            {
                ret = ciclo(or, r.ARRIBA);
            }
            return ret;
        }

        public bool sucesor(NodoP or,NodoP hijo,int count)
        {
            bool ret = false;
            foreach(NodoRel w in or.relaciones)
            {
                if (hijo.NOMBRE.CompareTo(w.ARRIBA.NOMBRE) == 0 && count!=0)
                {
                    return true;
                }
                else
                    ret= sucesor(w.ARRIBA,hijo,count+1);
                if (ret)
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Algoritmo abarcador 
        /// </summary>
        /// <param name="or"></param>
        /// <param name="sucesores"></param>
        public void abarcador(NodoP or,string sucesores)
        {
            //1=arbol
            //2=retorceso
            //3=avance
            //4=cruzados
            bosque = true;
            or.VISITADO = true;
            Arista ari;

            foreach(NodoRel w in or.relaciones)
            {
                if(!w.ARRIBA.VISITADO)
                {
                    ari=aristas.Find(delegate(Arista a) { if (a.Origen.NOMBRE.CompareTo(or.NOMBRE) == 0 && a.Destino.NOMBRE.CompareTo(w.ARRIBA.NOMBRE)==0)return true; else return false; });
                    if (ari != null)
                        ari.bosqueT = 1;
                    abarcador(w.ARRIBA,sucesores+or.NOMBRE);
                }
                else
                {
                    if(sucesores.Contains(w.ARRIBA.NOMBRE))
                    {
                        ari=aristas.Find(delegate(Arista a) { if (a.Origen.NOMBRE.CompareTo(or.NOMBRE) == 0 && a.Destino.NOMBRE.CompareTo(w.ARRIBA.NOMBRE) == 0)return true; else return false; });
                        if (ari != null)
                            ari.bosqueT = 1;
                    }
                    else if (sucesor(or, w.ARRIBA, 0))
                    {
                        ari = aristas.Find(delegate(Arista a) { if (a.Origen.NOMBRE.CompareTo(or.NOMBRE) == 0 && a.Destino.NOMBRE.CompareTo(w.ARRIBA.NOMBRE) == 0)return true; else return false; });
                        if (ari != null)
                            ari.bosqueT = 3;
                    }
                    else
                    {
                        ari = aristas.Find(delegate(Arista a) { if (a.Origen.NOMBRE.CompareTo(or.NOMBRE) == 0 && a.Destino.NOMBRE.CompareTo(w.ARRIBA.NOMBRE) == 0)return true; else return false; });
                        if (ari != null)
                            ari.bosqueT = 4;
                    }
                }
            }


        }

        /// <summary>
        /// Algoritmo corolarios
        /// </summary>
        /// <returns></returns>
        public bool corolarios()
        {
            bool ret=false;
            if(aristas.Count<=((3*Count)-6))
            {
                ret = true;
            }
            else
            {
                if(aristas.Count<=((2*Count)-4))
                {
                    ret = true;
                }
            }
           
            return ret;
        }
        /// <summary>
        /// Algoritmo isomorfismo
        /// </summary>
        /// <param name="otro">lista de grafos </param>
        /// <returns></returns>
        public bool  isomorfo(Grafo otro)
        {
            bool ret=true;
            NodoP en;
            foreach(NodoP pr in this)
            {
                en = otro.Find(delegate(NodoP bu) { if (bu.GRADO == pr.GRADO && !bu.VISITADO) { return true; } else return false; });
                if (en == null)
                    ret = false;
                else
                {
                    en.VISITADO = true;
                    pr.VISITADO = true;
                }

            }

            if (otro.Find(delegate(NodoP d) { if(d.VISITADO==false)return true;else return false;})!=null)
                ret = false;
            else
                if (this.Find(delegate(NodoP d) { if (d.VISITADO == false)return true; else return false; }) != null)
                    ret = false;
            return ret;
        }
        /// <summary>
        /// ALgoritmo Kruskal
        /// </summary>
        /// <returns></returns>
        public Grafo Kruskal()
        {
            Grafo retur = new Grafo(this);
            retur.Aristas.Clear();
            Arista arista;
            NodoP o,d;
            int compoactuales=retur.Componentes();
            foreach (NodoP bor in retur)
            {
                bor.relaciones.Clear();
                bor.GRADO = 0;
                bor.GradoExterno = bor.GradoInterno = 0;
            }
            aristas.Sort(delegate(Arista a, Arista b) { return (a.PESO.CompareTo(b.PESO)); });
            for (int i = 0; i < aristas.Count; i++)
            {
                if(retur.Componentes()!=1)
                {
                    compoactuales=retur.Componentes();
                    o=retur.Find(delegate(NodoP a){if(a.NOMBRE==aristas[i].Origen.NOMBRE)return true;else return false;});
                    d=retur.Find(delegate(NodoP a){if(a.NOMBRE==aristas[i].Destino.NOMBRE)return true;else return false;});
                    arista = new Arista(2, o, d, "e");
                    arista.PESO = aristas[i].PESO;
                    o.insertaRelacion(d, i);
                    d.insertaRelacion(o, i);
                    retur.AgregaArista(arista);
                    if (retur.Componentes() == compoactuales)
                    {
                        retur.RemueveArista(arista);
                    }
                }
            }
            return retur;
        }
        #endregion
    }
}
   