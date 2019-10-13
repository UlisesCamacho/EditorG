using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeGrafos
{
    public partial class Euler : Form
    {
        //
        private string titulo;
        private List<string> recorrido;
        private Timer reloj;
        public delegate void Borra_Recorrido();
        public event Borra_Recorrido borra_Recorrido;

        public Euler(List<string> recorrido, string titulo, Timer reloj)
        {
            this.recorrido = recorrido;
            this.titulo = titulo;
            this.reloj = reloj;
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.reloj.Enabled = false;
            borra_Recorrido();
            this.Close();
        }

        private void Euler_Load(object sender, EventArgs e)
        {
            this.Text = titulo;
            BarVelocidad.Value = this.reloj.Interval / 100;
            for (int i = 0; i < recorrido.Count - 1; i++)
            {
                this.richTextBoxCamino.Text += recorrido[i];
                this.richTextBoxCamino.Text += "->";
            }
            this.richTextBoxCamino.Text += recorrido.Last();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            this.reloj.Enabled = true;
        }

        private void pausa_Click(object sender, EventArgs e)
        {
            this.reloj.Enabled = false;
        }

        private void BarVelocidad_Scroll(object sender, EventArgs e)
        {
            this.reloj.Interval = BarVelocidad.Value * 100;
        }
    }
}
