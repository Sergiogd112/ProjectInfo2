using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Flight_Forms
{
    public partial class GenerarVuelos : Form
    {
        SoundPlayer musica;
        int n;
        double[] rangoDistancia = new double[2];
        double[] rangoVelocidad = new double[2];
        int reintentos;
        public GenerarVuelos()
        {
            InitializeComponent();
        }

        public int N { get => n; }
        public double[] RangoDistancia { get => rangoDistancia; }
        public double[] RangoVelocidad { get => rangoVelocidad; }
        public int Reintentos { get => reintentos; }

        private void GenerarButton_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(NumeroIn.Value);
            rangoDistancia[0] = Convert.ToDouble(DistMinIn.Value);
            rangoDistancia[1] = Convert.ToDouble(DistMaxIn.Value);
            rangoVelocidad[0] = Convert.ToDouble(VelocidadMinIn.Value);
            rangoVelocidad[1] = Convert.ToDouble(VelocidadMaxIn.Value);
            reintentos = Convert.ToInt32(ReintentosIn.Value);
            if (rangoDistancia[0] >= rangoDistancia[1] || rangoVelocidad[0] >= rangoVelocidad[1])
            {
                MessageBox.Show("Rango de velociades o distancias, el mínimo es mayor que el máximo");
            }
            else
            {
                this.Close();
            }

        }

        private void GenerarVuelos_Load(object sender, EventArgs e)
        {
            try
            {
                musica = new SoundPlayer(@"c:TongueTied.wav");
                musica.Play();
            }
            catch
            { }
        }

        public void PararMusica()
        {
            musica.Stop();
        }
    }
}
