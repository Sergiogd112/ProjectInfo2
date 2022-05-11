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

namespace Flight_Forms
{
    public partial class IntroducirParametrosForm : Form
    {
        //creamos un vector que contenga los parámetros de simulación (atributo)
        double[] parametros = new double[2];

        public IntroducirParametrosForm()
        {
            InitializeComponent();
        }

        private void IntroducirParametrosForm_Load(object sender, EventArgs e)
        {
        }

        //lo que pasa cuando se clica el boton aceptar
        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                double distSeg = Convert.ToDouble(distanciaSeguridadBox.Text);
                double ciclo = Convert.ToDouble(cicloBox.Text);
                if (
                    this.parametros.Length == 0 //this hace referencia al objeto
                )
                {
                    this.parametros[this.parametros.Length] = distSeg;
                    this.parametros[this.parametros.Length] = ciclo;

                    MessageBox
                        .Show("Los parámetros de simulación ya han sido introducidos.");
                }
                else
                {
                    MessageBox
                        .Show("Los parámetros de simulación ya han sido introducidos.");
                }

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

        public double[] DameParametros()
        {
            return this.parametros;
        }

        private void rellenarButton_Click(object sender, EventArgs e)
        {
            cicloBox.Text = "2";
            distanciaSeguridadBox.Text = "50";
        }
    }
}
