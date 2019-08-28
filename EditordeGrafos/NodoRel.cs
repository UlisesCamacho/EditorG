﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    [Serializable()]
    public class NodoRel
    {
        private NodoP arriba;
        int peso;
        private bool visitada;
        private string nombre;

        public NodoRel(NodoP np,string nam)
        {
            arriba = np;
            visitada = false;
            nombre = nam;
        }

        public string NOMBRE { get { return nombre; } set { nombre = value; } }
        public NodoP ARRIBA{get{return arriba;}}
        public bool VISITADA { get { return visitada; } set { visitada = value; } }
    }
}
