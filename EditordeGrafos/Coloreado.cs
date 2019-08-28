using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class Coloreado : Form
    {
        int numeroCromatico;
        private bool band;
        List<List<NodoP>> conj;
        int contador;
        public Coloreado(List<List<NodoP>>conjuntos)
        {
            InitializeComponent();
            numeroCromatico = conjuntos.Count;
            numero.Text = numeroCromatico.ToString();
            band = false;
            conj = conjuntos;
            contador=1;
            this.AutoScroll = true;
            foreach(List<NodoP> con in conj)
            {
                label3.Text+=contador.ToString()+": ";
                foreach (NodoP nodo in con)
                {
                    label3.Text += nodo.NOMBRE.ToString() + " ";
                }
                label3.Text += "\n";
                contador++;
            }
            button1.Visible = false;
        }

        private void Coloreado_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
