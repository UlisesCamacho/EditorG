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
    public partial class Form2 : Form
    {
        Grafo grafo;
        public Form2(Grafo g)
        {
            InitializeComponent();
            grafo = g;
            foreach (NodoP n in grafo)
            {
                comboNodos.Items.Add(n.NOMBRE.ToString());
            }
            foreach (Arista n in grafo.Aristas)
            {
               // comboAristas.Items.Add(n.NOMBRE.ToString()+" ("+n.Origen.NOMBRE.ToString()+","+n.Destino.NOMBRE.ToString()+")");
                comboAristas.Items.Add(n.NOMBRE.ToString());
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboNodos_TextChanged(object sender, EventArgs e)
        {
            textBoxNodos.Text = grafo.Find(delegate(NodoP r) { if (r.NOMBRE.ToString() == comboNodos.Text)return true; else return false; }).NOMBRE.ToString();
        }

        private void comboAristas_TextChanged(object sender, EventArgs e)
        {
            textBoxAristas.Text = grafo.Aristas.Find(delegate(Arista r) { if (r.NOMBRE.ToString() == comboAristas.Text)return true; else return false; }).PESO.ToString();
        }

        private void textBoxAristas_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAristas.Text.Length > 0)
            {
                try
                {
                    grafo.Aristas.Find(delegate(Arista r) { if (r.NOMBRE.ToString() == comboAristas.Text)return true; else return false; }).PESO = int.Parse(textBoxAristas.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor introduzca un numero entero");
                }
            }
        }

        private void textBoxNodos_TextChanged(object sender, EventArgs e)
        {
           
                if (textBoxNodos.Text.Length > 0)
                {
                    try
                    {
                        grafo.Find(delegate(NodoP n) { if (n.NOMBRE.ToString() == comboNodos.Text)return true; else return false; }).NOMBRE = textBoxNodos.Text;

                    }
                    catch
                    {
                    MessageBox.Show("Introduzca solamente un caracter");
                    }
                }
        }

    }
}
