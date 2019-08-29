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
    public partial class Form5 : Form
    {
        private string box;
        private int n;
        private int desde;
        public Form5(int des)
        {
            InitializeComponent();
            desde = des;
        }
        public int N { get { return n; } }
        private void Form5_Load(object sender, EventArgs e)
        {
            for (int i = desde; i < 50; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                n = int.Parse(comboBox1.Text.ToString());
            }
            catch
            {
            }
            this.Close();
        }
    }
}
