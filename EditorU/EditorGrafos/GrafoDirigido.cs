using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafos
{
    [Serializable]
    class GrafoDirigido : Grafo
    {
        private Grafo grafo;
        List<List<int>> renglones = new List<List<int>>();
        List<int> renglon = new List<int>();
        [NonSerialized]List<NodoP> pila = new List<NodoP>();
        List<NodoP> caminos;
        List<List<NodoP>> DK = new List<List<NodoP>>();
       
        int peso;
        public GrafoDirigido(Grafo g)
        {

            grafo = g;
            foreach (NodoP n in g)
            {
                this.Add(n);

            }
            actualizaPropiedades(g);







        }
        public void actualizaPropiedades(Grafo g)
        {
            this.penN = new Pen(g.cNodo);
            this.penA = new Pen(g.cArista);
            this.width = g.width;
            this.widthA = g.widthA;
            this.font = g.font;
            this.brushN = new SolidBrush(g.cRelleno);
            //  this.brushF = new SolidBrush(g.)
        }

        public override Grafo complemento(Graphics g)
        {

            NodoP nn;
            Arista nnr;

            Grafo nuevo = new Grafo();
            foreach (NodoP np in this)
            {
                nn = new NodoP(np.nombre, np.centro);
                nuevo.Add(nn);
            }
            nuevo = new GrafoNoDirigido(nuevo);

            foreach (NodoP aux1 in this) // Ciclo que recorre los nodos del grafo
            {
                if (aux1.aristas.Count == 0) // si el nodo no tiene aristas
                {
                    foreach (NodoP aux2 in nuevo) // Ciclo que recorre los nodos del grafo "copia"
                    {
                        if (aux1.nombre != aux2.nombre) // Condición para que el nodo no apunte a si mismo
                        {
                            nnr = new Arista(0);
                            nnr.origen = nuevo.Find(x => x.nombre.Equals(aux1.nombre));
                            nnr.destino = aux2;

                            nuevo.Find(x => x.nombre.Equals(aux1.nombre)).aristas.Add(nnr);


                        }
                    }
                }

                else // Si el nodo ya tiene Aristas
                {
                    foreach (NodoP aux2 in nuevo) // Ciclo que recorre los nodos 
                    {
                        if (aux1.nombre != aux2.nombre) // Compara que el nodo no se apunte a si mismo
                        {
                            Arista r = new Arista(0);
                            r = aux1.aristas.Find(x => x.destino.nombre.Equals(aux2.nombre));
                            if (r == null)
                            {
                                nnr = new Arista(0);
                                nnr.origen = nuevo.Find(x => x.nombre.Equals(aux1.nombre));
                                nnr.destino = aux2;
                                if (nnr != null)

                                    nuevo.Find(x => x.nombre.Equals(aux1.nombre)).aristas.Add(nnr);

                            }
                            else
                            {
                                continue;
                            }


                        }

                    }
                }
            }
            
            base.complemento(g);

            return nuevo;
        }
        #region variables BOSQUE ABARCADOR
        public List<NodoP> nodos { get; set; }
        public List<List<NodoP>> bosque { get; set; }
        public List<Arista> arbol { get; set; }
        public List<Arista> avance { get; set; }
        public List<Arista> retroceso { get; set; }
        public List<Arista> cruce { get; set; }
        public List<Arista> visitado;
       
        #endregion


        public void bosqueAbarcador()
        {
            bosque = new List<List<NodoP>>();
            NodoP aux;
            aux = grafo[0];
            nodos = new List<NodoP>();
            bosque.Add(new List<NodoP>());

            while (aux != null)
            {
               
             //   NodoP existeP = stack.nodos.Find(x => x.Equals(aux));
               // if(existeP == null)
                {
                    bosque[0].Add(aux); // Se añade A
                 //   stack.push(aux);
                }
                bool tv2 = todoVisitado(aux);
                if (tv2 == true)
                {
          //          if (stack.tope == 1)
                        break;
            //        stack.pop();
            //        aux = stack.ultimo();
                }
                // Se recorren sus relaciones
                foreach (Arista nr in aux.aristas)
                {
                    // Verificar si la arista ha sido visitada 
                    if (visitado == null)
                        visitado = new List<Arista>();
                    Arista existeA = visitado.Find(x => x.Equals(nr));

                    if(existeA == null) // La arista aun no ha sido visitada 
                    {
                        //verificar si nodo destino existe 
                        bool existeNodo = encuentraEnBosque(bosque, nr.destino);

                        if(existeNodo == false)
                        {
                            if (arbol == null)
                                arbol = new List<Arista>();
                            arbol.Add(nr);
                            aux = nr.destino;
                        }
                        else // El nodo ya existe en el bosque 
                        {
                            // validar si es retroceso o avance
                            int posA = damePosicion(bosque, aux);
                            int posB = damePosicion(bosque, nr.destino);

                            if(posA < posB)
                            {
                                // avance
                                if (avance == null)
                                    avance = new List<Arista>();
                                avance.Add(nr);
                            }
                            else if(posA > posB)
                            {
                                // retroceso
                                if (retroceso == null)
                                    retroceso = new List<Arista>();
                                retroceso.Add(nr);
                            }

                        }
                        visitado.Add(nr);
                        // Si todas sus relaciones ya fueron visitadas
                        bool tv = todoVisitado(aux);
                        if(tv == true)
                        {
                            //stack.pop();
                            //aux = stack.ultimo();
                        }


                        break;
                    }
                }
            }
        }
        private bool todoVisitado(NodoP nodo)
        {
            if (visitado == null)
                visitado = new List<Arista>();
            foreach(Arista nr in nodo.aristas)
            {
                Arista existeA = visitado.Find(x => x.Equals(nr));
                if(existeA == null)
                {
                    return false;
                }
            }
            return true;
        }
        private int damePosicion(List<List<NodoP>> bosque, NodoP nodo)
        {
            int i = 0;
            foreach(List<NodoP> np in bosque)
            {
                i = 0;
                foreach(NodoP np2 in np)
                {
                    if(np2 == nodo)
                    {
                        return i;
                    }
                    i++;
                }
               
            }
            return i;
        }
        private bool encuentraEnBosque(List<List<NodoP>> bosque, NodoP busca)
        {
            foreach(List<NodoP> np1 in bosque)
            {
                foreach(NodoP np2 in np1)
                {
                    if (np2 == busca)
                        return true;
                }
            }
            return false;
        }
        
        /*fIN CLASE*/
    }

}
