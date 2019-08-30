using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    [Serializable()]
    public class Arista
    {
        private int tipo;
        private NodoP origen;
        private NodoP destino;
        private string nombre;
        private int peso;
        private bool pintada;
        private bool visitada;
        private bool camino;

        public int bosqueT;

        public NodoP Origen{get{return origen;}set{origen=value;}}
        public NodoP Destino{ get { return destino; } set { destino = value; } }
        public int Tipo { get { return tipo; } }
        public string NOMBRE{get{return nombre;}set{nombre=value;}}
        public int PESO { get { return peso; } set { peso = value; } }
        public bool PINTADA { get { return pintada; } set { pintada = value; } }
        public bool VISITADA { get { return visitada; } set { visitada = value; } }
        public bool CAMINO { get { return camino; } set { camino = value; } }

        public Arista()
        {
           
        }


        public Arista(int ti, NodoP o, NodoP d,string nomb)
        {
            tipo = ti;
            origen = o;
            destino = d;
            nombre = nomb;
            peso = 0;
            visitada = false;
            bosqueT = 0;
        }

        public Arista(Arista a)
        {
            tipo = a.tipo;
            origen = a.origen;
            destino = a.destino;
            peso = a.PESO;
            visitada = a.VISITADA;
        }
        private PointF Punto(double angulo,int tip)
        {
            double dy, dx;
            double an, ang, d, r;
            double p3x, p3y, p4x, p4y;
            PointF A, B;
            dy = dx = 0;
            if (tip == 1)
            {
                PointF pF = new PointF();
                float x1 = Origen.POS.X + (float)((Math.Cos(angulo * Math.PI / 180)) * (15));
                float y1 = Origen.POS.Y + (float)((Math.Sin(angulo * Math.PI / 180)) * (15));
                pF.X = x1;
                pF.Y = y1;
                return pF;
            }
            else
            {
                dy = Destino.POS.Y - Origen.POS.Y;
                dx = Destino.POS.X - Origen.POS.X;
                p3x = (dx * 1 / 3) + Origen.POS.X;
                p3y = (dy * 1 / 3) + Origen.POS.Y;
                p4x = (dx * 2 / 3) + Origen.POS.X;
                p4y = (dy * 2 / 3) + Origen.POS.Y;
                d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                r = .35 * d;
                if (Destino.POS.X != Origen.POS.X)
                    ang = Math.Atan((double)((double)dy / (double)dx));
                else
                    ang = 90;

                if (Destino.POS.X > Origen.POS.X)
                    an = ang + 90;
                else
                    an = ang - 90;
                B = new PointF((float)((r * Math.Cos(an)) + p4x), (float)((r * Math.Sin(an)) + p4y /*+ 15 * (an / Math.Abs(an))*/));
                A = new PointF((float)((r * Math.Cos(an)) + p3x), (float)((r * Math.Sin(an)) + p3y /*+ 15 * (an / Math.Abs(an))*/));                

                if (tip == 2)
                {
                    return A;
                }
                else
                    return B;
                     
            }
        }

        public bool toca(Point pos)
        {
            Rectangle mouse = new Rectangle(pos.X, pos.Y, 3, 3);
            Rectangle pix = new Rectangle(Origen.POS.X, Origen.POS.Y, 3, 3);

            PointF p1 = Punto(-50,1);
            PointF p2 = Punto(-140,1);
            

            int x0 = Origen.POS.X;
            int y0 = Origen.POS.Y;
            int x1 = Destino.POS.X;
            int y1 = Destino.POS.Y;

            int dx = Destino.POS.X - Origen.POS.X;
            int dy = Destino.POS.Y - Origen.POS.Y;
            if (Math.Abs(dx) > Math.Abs(dy))
            {          
                float m = (float)dy / (float)dx;
                float b = y0 - m * x0;
                if (dx < 0)
                    dx = -1;
                else
                    dx = 1;
                while (x0 != x1)
                {
                    x0 += dx;
                    y0 = (int)Math.Round(m * x0 + b);
                    pix.X = x0;
                    pix.Y = y0;

                    if (mouse.IntersectsWith(pix))
                        return true;
                }
            }
            else
                if (dy != 0)
                {                              
                    float m = (float)dx / (float)dy;      
                    float b = x0 - m * y0;
                    if (dy < 0)
                        dy = -1;
                    else
                        dy = 1;
                    while (y0 != y1)
                    {
                        y0 += dy;
                        x0 = (int)Math.Round(m * y0 + b);
                        pix.X = x0;
                        pix.Y = y0;

                        if (mouse.IntersectsWith(pix))
                            return true;
                    }
                }

            if (Destino == Origen)
            {
                List<double> ptList = new List<double>();
               

                ptList.Add(p1.X);
                ptList.Add(p1.Y);
                ptList.Add(p1.X + 20);
                ptList.Add(p1.Y - 50);
                ptList.Add(p1.X - 50);
                ptList.Add(p1.Y - 50);
                ptList.Add(p2.X);
                ptList.Add(p2.Y);


                const int Puntos = 200;
                double[] ptind = new double[ptList.Count];
                double[] p = new double[Puntos];
                ptList.CopyTo(ptind, 0);
              

                for (int i = 1; i != Puntos - 1; i += 2)
                {
                    if (mouse.IntersectsWith(new Rectangle((int)p[i + 1], (int)p[i], 10, 10)))
                        return true;
                }
            }
            else
            {
                p1 = Punto(1, 2);
                p2 = Punto(1, 3);
                List<double> ptList = new List<double>();
               

                ptList.Add(Origen.POS.X);
                ptList.Add(Origen.POS.Y);
                ptList.Add(p1.X);
                ptList.Add(p1.Y);
                ptList.Add(p2.X);
                ptList.Add(p2.Y);
                ptList.Add(destino.POS.X);
                ptList.Add(destino.POS.Y);
               
                const int Puntos = 200;
                double[] ptind = new double[ptList.Count];
                double[] p = new double[Puntos];
                ptList.CopyTo(ptind, 0);
               
                for (int i = 1; i != Puntos - 1; i += 2)
                {
                    if (mouse.IntersectsWith(new Rectangle((int)p[i + 1], (int)p[i], 10, 10)))
                        return true;
                }
            }

            return false;
        }

    }
}
