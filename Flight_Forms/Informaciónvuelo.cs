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
    public partial class Informaciónvuelo : Form
    {
        FlightPlan vuelo;
        SoundPlayer musica;

        public Informaciónvuelo()
        {
            
            InitializeComponent();
        }

        public void SetFlight(FlightPlan v)
        {
            this.vuelo = v;
        }
        public void ClickedFlight(FlightPlan f) //Constructor
        {
            this.vuelo = f;
        }

        //Muestra en las labels los atributos del flightplan clicado mediante los gets
        private void ClickInformacionVuelo_Load(object sender, EventArgs e)
        {
            try
            {
                musica = new SoundPlayer(@"c:Dynamite.wav");
                musica.Play();
            }
            catch (Exception)
            { }
        }

        public void PararMusica()
        {
            musica.Stop();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;
        }

        private void Informaciónvuelo_Load(object sender, EventArgs e)
        {
            idBox.Text = this.vuelo.GetId();
            velBox.Text = Convert.ToString(this.vuelo.GetVelocidad());
            inPosBox.Text =
                Convert
                    .ToString("X: " +
                    Math.Round(this.vuelo.GetInitialPosition().GetX(), 2) +
                    "Y: " +
                    Math.Round(this.vuelo.GetInitialPosition().GetY(), 2));
            currPosBox.Text =
                Convert
                    .ToString("X: " +
                    Math.Round(this.vuelo.GetCurrentPosition().GetX(), 2) +
                    "Y: " +
                    Math.Round(this.vuelo.GetCurrentPosition().GetY(), 2));
            finPosBox.Text =
                Convert
                    .ToString("X: " +
                    Math.Round(this.vuelo.GetFinalPosition().GetX(), 2) +
                    "Y: " +
                    Math.Round(this.vuelo.GetFinalPosition().GetY(), 2));
        }

        private void Cambiar_Click(object sender, EventArgs e)
        {
            this.vuelo.SetVelocidad(Convert.ToDouble(velBox.Text));
        }
    }
}
