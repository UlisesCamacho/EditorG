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
    public partial class Caminos : Form 
    {
        #region Variables de Instancia
        private string titulo;
        private List<string> recorrido;
        private Timer reloj;
        public delegate void Borra_Recorrido();
        public event Borra_Recorrido borra_Recorrido;
     
       
        #endregion

        #region Constructores

        public Caminos(List<string> recorrido, string titulo, Timer reloj)
        {
            this.recorrido = recorrido;
            this.titulo = titulo;
            this.reloj = reloj;
            InitializeComponent();
        }

      
        #endregion

        #region Eventos

        #region Botones
     
      
        #endregion

        #region TrackBar
        private void BarVelocidad_Scroll(object sender, EventArgs e)
        {
            this.reloj.Interval = BarVelocidad.Value * 100;
        }
        #endregion

        #endregion

        private void Cerrar_Click_1(object sender, EventArgs e)
        {
            this.reloj.Enabled = false;
            borra_Recorrido();
            this.Close();
        }

        private void play_Click_1(object sender, EventArgs e)
        {

            this.reloj.Enabled = true;
        }

        private void pausa_Click_1(object sender, EventArgs e)
        {
            this.reloj.Enabled = false;
        }

        private void Caminos_Load_1(object sender, EventArgs e)
        {
            List<string> recorridoaux,apoyo;
            recorridoaux = new List<string>();
            apoyo = recorrido;
            this.Text = titulo;
            BarVelocidad.Value = this.reloj.Interval / 100;
            int limite;
            limite = recorrido.Count;
            int contador = 0;
            string ultimo = "";
            for (int j = 0; j < limite - 1; j++)
            {

                for (int i = 0; i < limite - 1; i++)
                {
                    recorridoaux.Add(apoyo[i + 1]);
                    listBoxNodos.Items.Add(apoyo[i]);                  
                }
                recorridoaux.Add(recorridoaux[0]);
                apoyo = recorridoaux;
            }
            for (int j = 0; j < limite-1 ; j++)
            {

                for (int i = 0; i < limite-1 ; i++)
                {
                    if(i==0)
                    {
                        ultimo = apoyo[i + contador].ToString();
                    }
                    this.richTextBoxCamino.Text += apoyo[i+contador];
                    this.richTextBoxCamino.Text += "->";
                }
                //this.richTextBoxCamino.Text += apoyo.Last();
                this.richTextBoxCamino.Text += ultimo;
                this.richTextBoxCamino.Text += "\n";
                contador++;
            }


        }
        private void Ordenar_Click(object sender, EventArgs e)
        {
            String[] n1 = listBoxNodos.Items.Cast<string>().ToArray();
            listBoxNodos.Items.Clear();
            var n2 = n1.OrderBy(n3=> int.Parse(n3));
            foreach(var item in n2)
            {
                listBoxOrdenados.Items.Add(item.ToString());
            }
        }

        private void listBoxOrdenados_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}

