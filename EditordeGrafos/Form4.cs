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
    public partial class Form4 : Form
    {
        private int[][] mat;
        Grafo grafo;
        public Form4(Grafo g)
        {
            InitializeComponent();
            grafo = new Grafo(g);
            mat = new int[g.Count+1][];
            for (int x = 0; x < g.Count+1; x++)
            {
                mat[x] = new int[g.Count];
            }
            mat= grafo.FLoyd();
            dataGridView1.ColumnCount = grafo.Count + 1;
            dataGridView1.RowCount = grafo.Count + 1;
            dataGridView1.Visible = true;
            dataGridView1.Font = new Font("Arial", 15);
            dataGridView1.AutoSize = true;
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
                            {
                                if (mat[i - 1][j - 1] != 10000000)
                                    dataGridView1.Rows[i].Cells[j].Value = mat[i - 1][j - 1].ToString();
                                else
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = "∞";
                                }
                            }
                }
            }
            dataGridView1.Size = new Size(grafo.Count + 1 * dataGridView1.Rows[0].Cells[1].Size.Width, grafo.Count + 1 * dataGridView1.Rows[1].Height);
            this.Size = new Size(dataGridView1.Size.Width - 200, dataGridView1.Size.Height + 100);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
    }
}
