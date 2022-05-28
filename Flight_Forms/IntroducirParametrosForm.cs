using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;
using System.Media;

namespace Flight_Forms
{
    public partial class IntroducirParametrosForm : Form
    {
        //creamos un vector que contenga los parámetros de simulación (atributo)
        double[] parametros = new double[2];
        int tiempociclo;
        double distanciaseguridad;
        SoundPlayer musica;

        public IntroducirParametrosForm()
        {
            InitializeComponent();
        }

        private void IntroducirParametrosForm_Load(object sender, EventArgs e)
        {
            try
            {
                musica = new SoundPlayer(@"c:LoveMeLikeThere’sNoTomorrow.wav");
                musica.Play();
            }
            catch
            {}
        }

        public void PararMusica()
        {
            musica.Stop();
        }

        //lo que pasa cuando se clica el boton aceptar
        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                distanciaseguridad = Convert.ToDouble(distanciaSeguridadBox.Value);
                tiempociclo = Convert.ToInt32(cicloBox.Value);

                this.parametros[0] = distanciaseguridad;
                this.parametros[1] = tiempociclo;

                MessageBox
                    .Show("Los parámetros de simulación ya han sido introducidos.");

                Close();
                this.Visible = false;
            }
            catch (FormatException)
            {
                MessageBox
                    .Show("El formato de los parámetros no es correcto. Intente de nuevo.");

                //reseteamos cuadros de texto
                distanciaSeguridadBox.Text = " ";
                cicloBox.Text = " ";
            }
        }
        public double GetDistanciaSeguridad()
        {
            return distanciaseguridad;
        }

        public int GetTiempoCiclo()
        {
            return tiempociclo;
        }
        public double[] DameParametros()
        {
            return this.parametros;
        }
    }
}
