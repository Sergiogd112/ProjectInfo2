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
    public partial class GuardarComo : Form
    {
        SoundPlayer musica;
        string NombreFichero;
        public GuardarComo()
        {
            InitializeComponent();
        }

      

        private void Aceptar_Click(object sender, EventArgs e)
        {
            NombreFichero = Nombre.Text;
            MessageBox.Show("Fichero guardado exitosamente");
            Close();
        }

        public string GetNombreFichero()
        {
            return NombreFichero;
        }
        private void Nombrefichero_TextChanged(object sender, EventArgs e)
        {

        }

        private void GuardarComo_Load(object sender, EventArgs e)
        {
            try
            {
                musica = new SoundPlayer(@"c:Africa.wav");
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
