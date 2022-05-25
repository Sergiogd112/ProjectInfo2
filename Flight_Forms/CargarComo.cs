using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight_Forms
{
    public partial class CargarComo : Form
    {
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
    }
}
