﻿using System;
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
    public partial class Form3 : Form
    {
        Grafo grafo;
        Graphics g;
        int tipo;
        private bool band;
        private int accion;
        public Form3(Grafo gra,int tip)
        {
            tipo=tip;
            grafo = new Grafo();
            bool enco=false;

            InitializeComponent();
            g=CreateGraphics();
            Relaciones.Select();
            band = false;
            accion =0;
            label2.Visible = Componentes.Visible = false;
            grafo = gra;
            AutoScroll = true;
            Vertices.Text = grafo.Count().ToString();
            Aristas.Text = grafo.Aristas.Count().ToString();
            if (grafo.Aristas.Count > 0)
                if (grafo.Aristas.ToArray()[0].Tipo == 2)
                    Grado.Text = ((grafo.Aristas.Count()) * 2).ToString();
            else
                Grado.Text = ((grafo.Aristas.Count())).ToString();
  

            List<List<NodoP>> componentes=new List<List<NodoP>>();
            List<NodoP> nue=new List<NodoP>();
            if (tipo == 2)
            {
                Text = "Grafo - Propiedades (No Dirigido)";
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
                Componentes.Visible = true;
                label2.Visible = true;

            }
 
                label6.Visible = true;
                label7.Visible = true;
                Interno.Visible = true;
                Externo.Visible = true;
                Interno.Items.Clear();
                Externo.Items.Clear();
                foreach(NodoP nodo in grafo)
                {
                    Interno.Items.Add(nodo.NOMBRE.ToString());
                    Externo.Items.Add(nodo.NOMBRE.ToString());
                }
                
           foreach (NodoP re in grafo)
           {
               foreach (NodoRel rela in re.relaciones)
               {
                 rela.VISITADA = false;
               }
           }
           Componentes.Text = componentes.Count.ToString();
           dataGridView1.ColumnCount = grafo.Count+1;
           dataGridView1.RowCount = grafo.Count+1;
  
           grafo.CreaMatriz();
           for (int i = 0; i <= grafo.Count; i++)
           {
             for (int j = 0; j <= grafo.Count ; j++)
             {
               if (i == 0 && j>0)
               {
                  dataGridView1.Rows[i].Cells[j].Value = grafo[j-1].NOMBRE.ToString();
               }
               else
                if (j == 0 && i>0)
                    dataGridView1.Rows[i].Cells[j].Value = grafo[i-1].NOMBRE.ToString();
                else 
                    if(i!=0 && j!=0)
                        dataGridView1.Rows[i].Cells[j].Value = grafo.MATRIZ[i-1][j-1].ToString();
             }
           }
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = ClientSize.Width - 30;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Interno_TextChanged(object sender, EventArgs e)
        {
            LabInterno.Text = grafo.Find(delegate(NodoP a) { if (a.NOMBRE.ToString() == Interno.Text)return true; else return false; }).GradoInterno.ToString() ;
        }

        private void Externo_TextChanged(object sender, EventArgs e)
        {
            LabExterno.Text = grafo.Find(delegate(NodoP a) { if (a.NOMBRE.ToString() == Externo.Text)return true; else return false; }).GradoExterno.ToString();
        }

        private void Relaciones_CheckedChanged(object sender, EventArgs e)
        {
            band = false;
            accion = 0;
            g.Clear(BackColor);
            dataGridView1.ColumnCount = grafo.Count + 1;
            dataGridView1.RowCount = grafo.Count + 1;
            dataGridView1.Visible = true;
            for (int i = 0; i <= grafo.Count; i++)
            {
                for (int j = 0; j <= grafo.Count; j++)
                {
                    if (i == 0 && j > 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = grafo[j - 1].NOMBRE.ToString();
                    }
                    else
                        if (j == 0 && i > 0)
                            dataGridView1.Rows[i].Cells[j].Value = grafo[i - 1].NOMBRE.ToString();
                        else
                            if (i != 0 && j != 0)
                                dataGridView1.Rows[i].Cells[j].Value = grafo.MATRIZ[i - 1][j - 1].ToString();
                }
            }
        }

        private void Adyacencia_CheckedChanged(object sender, EventArgs e)
        {
            accion = 1;
            band = true;
            this.Form3_Paint(this, null);
           
            
        }

        private void Incidencia_CheckedChanged(object sender, EventArgs e)
        {
            
            dataGridView1.ColumnCount = grafo.Aristas.Count+1;
            dataGridView1.RowCount = grafo.Count + 1;
            dataGridView1.Visible = true;
            band = false;
            accion = 0;
            g.Clear(BackColor);
            int rel=0;
            for (int i = 0; i <= grafo.Count; i++)
            {
                for (int j = 0; j <= grafo.Aristas.Count; j++)
                {
                    if (j == 0 && i > 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = grafo[i - 1].NOMBRE.ToString();
                    }
                    else
                        if (i == 0 && j > 0)
                            dataGridView1.Rows[i].Cells[j].Value = grafo.Aristas[j - 1].NOMBRE.ToString();
                        else
                            if (i != 0 && j != 0)
                            {
                                if (grafo.Aristas[j - 1].Origen.NOMBRE.ToString().CompareTo(grafo[i - 1].NOMBRE.ToString()) == 0 || grafo.Aristas[j - 1].Destino.NOMBRE.ToString().CompareTo(grafo[i - 1].NOMBRE.ToString()) == 0)
                                    rel = 1;
                                else
                                    rel = 0;
                                dataGridView1.Rows[i].Cells[j].Value = rel.ToString();
                            }
                }
            }
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            if (band)
            {
                switch(accion)
                {
                    case 1:
                         int x, y;
                    g = CreateGraphics();
                    x = Relaciones.Location.X;
                    y = Relaciones.Location.Y + 30;
                    dataGridView1.Visible = false;
                    this.Size = new Size(Width, this.Height + grafo.Count * 20);
                    if (this.Size.Height > 300)
                        VerticalScroll.Enabled = true;
                    g = CreateGraphics();
            
                    foreach (NodoP nod in grafo)
                    {
                        g.DrawString(nod.NOMBRE.ToString() + "->",new Font("Arial",10),Brushes.Black,x,y);
                        x += 20;
                        foreach(NodoRel re in nod.relaciones)
                        {
                            x += 15;
                            g.DrawString(re.ARRIBA.NOMBRE.ToString() + ",", new Font("Arial", 10), Brushes.Black, x, y);
                        }
                        x = Relaciones.Location.X;
                        y += 20;

                    }
                    break;
                }
            }
        }

    }
}
