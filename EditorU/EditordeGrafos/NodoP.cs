﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    [Serializable()]
    public class NodoP
    {
        private Point pos;
        private string nombre;
        private bool Seleccionado;

        private int gradoExterno;
        private int gradoInterno;
        private int grado;
        private Color color;
        private bool visitado;
        public List<NodoRel> relaciones;
        public Point POS { get { return pos; } set { pos = value; } }
        public string NOMBRE { get { return nombre; } set { nombre = value; } }
        public int GRADO { get { return grado; } set { grado = value; } }
        public Color COLOR{get{return color;} set {color=value;}}
        public int GradoInterno { get { return gradoInterno; } set { gradoInterno = value; } }
        public int GradoExterno { get { return gradoExterno; } set { gradoExterno = value; } }
        public bool SELECCIONADO{get{return Seleccionado;}set{Seleccionado=value;}}
        public bool VISITADO { get { return visitado; } set { visitado = value; } }

        #region constructores
        public NodoP()
        {

        }

        public NodoP(NodoP co)
        {
            pos = co.POS;
            nombre = co.NOMBRE;
            relaciones = new List<NodoRel>();
            grado = co.GRADO;
            gradoExterno = co.gradoExterno;
            gradoInterno = co.GradoInterno;
            color = co.COLOR;
            Seleccionado = false;
        }

 
        public NodoP(Point p, char n)
        {
            pos = p;
            nombre = n.ToString();
            relaciones = new List<NodoRel>();
            grado = 0;
            color = Color.White;
            Seleccionado = false;
        }
        #endregion
        #region operaciones
        public bool insertaRelacion(NodoP nueva,int num)
        {
            NodoRel n,e;
            n=new NodoRel(nueva,"e"+num.ToString());
           // e = relaciones.Find(delegate(NodoRel a) { if (a.ARRIBA == n.ARRIBA)return true; else return false; });
           // if (e == null)
           // {
                relaciones.Add(n);
                return true;
           // }
           // else
           // return false;
        }
        #endregion


    }
}
