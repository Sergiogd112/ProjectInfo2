using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight_Library;

namespace Flight_Forms
{
    public partial class IntroducirParametrosForm : Form
    {
        //creamos un vector que contenga los parámetros de simulación
        double[] parametros = new double[2];


        public IntroducirParametrosForm()
        {
            InitializeComponent();
        }

        private void IntroducirParametrosForm_Load(object sender, EventArgs e)
        {

        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                double distSeg = Convert.ToDouble(distanciaSeguridadBox.Text);
                double ciclo = Convert.ToDouble(cicloBox.Text);
                if (this.parametros.Length == 0)
                {
                    this.parametros[this.parametros.Length - 1] = distSeg;
                    this.parametros[this.parametros.Length] = ciclo;
                    
                    MessageBox.Show("Los parámetros de simulación ya han sido introducidos.");
                    
                }
                else
                {
                    MessageBox.Show("Los parámetros de simulación ya han sido introducidos.");
                }

                Close();
                this.Visible = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato de los parámetros no es correcto. Intente de nuevo.");
                //reseteamos cuadros de texto
                distanciaSeguridadBox.Text = " ";
                cicloBox.Text = " ";
            }
        }
        public double[] DameParametros()
        {
            return this.parametros;
        }
    }
}
