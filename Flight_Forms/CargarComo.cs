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
    public partial class CargarComo : Form
    {
        SoundPlayer musica;
        string Fichero;
        public CargarComo()
        {
            InitializeComponent();
        }

        private void NombreFichero_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cargarfichero_Click(object sender, EventArgs e)
        {
            Fichero = NombreFichero.Text;
            Close();
        }
        public string GetNombreFichero()
        {
            return Fichero;
        }

        private void CargarComo_Load(object sender, EventArgs e)
        {
            try
            {
                musica = new SoundPlayer(@"c:MerryGoRoundOfLife.wav");
                musica.Play();
            }
            catch (Exception ex)
            { }
        }

        public void PararMusica()
        {
            musica.Stop();
        }
    }
}
