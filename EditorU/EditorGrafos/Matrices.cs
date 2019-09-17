using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafos
{
    partial class Matrices : Form
    {
        Grafo grafo;
        Grafo grafog;
        Grafo grafox;
        Graphics g;
        int tipo;
        private bool band;
        private int accion;
        public Matrices(Grafo grafoP, int tipe)
        {
            InitializeComponent();
            grafo = grafoP;
            grafog = grafoP;
            grafox = grafoP;
            tipo = tipe;
            MessageBox.Show(tipe.ToString());
            MessageBox.Show(tipo.ToString()); 

        }

        private void matrizp_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            if (tipo == 2)
            {
                foreach (NodoP nodo in grafo)
                {
                    dataGridView1.Columns.Add(nodo.nombre.ToString(), nodo.nombre.ToString());
                }
                foreach (NodoP nodo in grafo)
                {
                    dataGridView1.Rows.Add();

                }
                for (int i = 0; i < grafo.Count; i++)
                {
                    dataGridView1.Rows[i].HeaderCell.Value = grafo[i].nombre.ToString();
                }
                for (int i = 0; i < grafo.Count; i++)
                {
                    for (int j = 0; j < grafo[i].aristas.Count; j++)
                    {
                        dataGridView1.Rows[grafo[i].aristas[j].origen.nombre - 1].Cells[grafo[i].aristas[j].destino.nombre - 1].Value = grafo[i].aristas[j].peso;
                        //dataGridView1.Rows[grafo[i].aristas[j].destino.nombre - 1].Cells[grafo[i].aristas[j].origen.nombre - 1].Value = grafo[i].aristas[j].peso;

                    }

                }
                for (int i = 0; i < grafo.Count; i++)
                {
                    for (int j = 0; j < grafo[i].aristas.Count; j++)
                    {
                        //dataGridView1.Rows[grafo[i].aristas[j].origen.nombre - 1].Cells[grafo[i].aristas[j].destino.nombre - 1].Value = grafo[i].aristas[j].peso;
                        dataGridView1.Rows[grafo[i].aristas[j].destino.nombre - 1].Cells[grafo[i].aristas[j].origen.nombre - 1].Value = grafo[i].aristas[j].peso;

                    }

                }
                for (int i = 0; i < grafo.Count; i++)
                {
                    for (int j = 0; j < grafo.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = -1;
                        }
                    }

                }
            }
            else
            {
                if (tipo == 3)
                {
                    foreach (NodoP nodo in grafo)
                    {
                        dataGridView1.Columns.Add(nodo.nombre.ToString(), nodo.nombre.ToString());
                    }
                    foreach (NodoP nodo in grafo)
                    {
                        dataGridView1.Rows.Add();

                    }
                    for (int i = 0; i < grafo.Count; i++)
                    {
                        dataGridView1.Rows[i].HeaderCell.Value = grafo[i].nombre.ToString();
                    }
                    for (int i = 0; i < grafo.Count; i++)
                    {
                        for (int j = 0; j < grafo[i].aristas.Count; j++)
                        {
                            dataGridView1.Rows[grafo[i].aristas[j].origen.nombre - 1].Cells[grafo[i].aristas[j].destino.nombre - 1].Value = grafo[i].aristas[j].peso;
                        }

                    }
                    for (int i = 0; i < grafo.Count; i++)
                    {
                        for (int j = 0; j < grafo.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value == null)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = -1;
                            }
                        }

                    }
                }
            }
            
        }

        private void gradosGrafo_CheckedChanged(object sender, EventArgs e)
        {
            int contador = 0;
            dataGridView1.Visible = true;
            dataGridView1.Columns.Add("Vertice", "vertice");
            dataGridView1.Columns.Add("Grado", "grado");
            grafox = grafo;
            foreach (NodoP nod in grafox)
            {
                dataGridView1.Rows.Add();
            }
            for (int i = 0; i < grafox.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = grafox[i].nombre;
                dataGridView1.Rows[i].Cells[1].Value = grafox[i].aristas.Count;
                contador = contador + grafox[i].aristas.Count;
            }
            grado.Text = contador.ToString();
           
        }

       

        private void LimpiarData_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            grado.Text = "";
        }

        private void MatrizAyasencia_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            foreach (NodoP nodo in grafo)
            {
                dataGridView1.Columns.Add(nodo.nombre.ToString(), nodo.nombre.ToString());
            }
            foreach (NodoP nodo in grafo)
            {
                dataGridView1.Rows.Add();

            }
            for (int i = 0; i < grafo.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = grafo[i].nombre.ToString();
            }
            for (int i = 0; i < grafo.Count; i++)
            {
                for (int j = 0; j < grafo[i].aristas.Count; j++)
                {
                    dataGridView1.Rows[grafo[i].aristas[j].origen.nombre - 1].Cells[grafo[i].aristas[j].destino.nombre - 1].Value = 1;
                }

            }
            for (int i = 0; i < grafo.Count; i++)
            {
                for (int j = 0; j < grafo.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                    }
                }

            }
        }
    }



    
    }


