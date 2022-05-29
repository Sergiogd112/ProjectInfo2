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
    public partial class IntroducirDatosForm : Form
    {
        SoundPlayer musica;
        public IntroducirDatosForm()
        {
            InitializeComponent();
        }

        private FlightPlanList lista = new FlightPlanList();
        FlightPlan flight;
        
        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                flight = new FlightPlan(idBox.Text, Compañia.Text, Convert.ToDouble(xInBox.Text), Convert.ToDouble(yInBox.Text), Convert.ToDouble(xInBox.Text), Convert.ToDouble(yInBox.Text), Convert.ToDouble(xFinBox.Text), Convert.ToDouble(yFinBox.Text), Convert.ToDouble(velocidadBox.Text));

                Close();
            }
            catch (FormatException) //Control de errores de formato al introducir datos 
            {
                MessageBox.Show("Error de formato al introducir datos");
            }
        }

        public void ResetParametros()
        {
            idBox.Text = " ";
            velocidadBox.Text = " ";
            xInBox.Text = " ";
            yInBox.Text = " ";
            xFinBox.Text = " ";
            yFinBox.Text = " ";
            Compañia.Text = " ";
        }
        public FlightPlan GetPlan()
        {
            return this.flight;
        }
        public FlightPlanList DameLista()
        {
            return this.lista;
        }

        private void IntroducirDatosForm_Load(object sender, EventArgs e)
        {
            try
            {
                musica = new SoundPlayer(@"c:VientoyArena.wav");
                musica.Play();
            }
            catch
            { }
        }

        public void PararMusica()
        {
            musica.Stop();
        }

        //Pasar de un textbox al siguiente al clicar Enter en el teclado
        private void idBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                NombreCompañia.Focus();
            }
        }

        //Pasar de un textbox al siguiente al clicar Enter en el teclado
        private void NombreCompañia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                xInBox.Focus();
            }
        }

        //Pasar de un textbox al siguiente al clicar Enter en el teclado
        private void xInBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                yInBox.Focus();
            }
        }

        //Pasar de un textbox al siguiente al clicar Enter en el teclado
        private void yInBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                xFinBox.Focus();
            }
        }

        //Pasar de un textbox al siguiente al clicar Enter en el teclado
        private void xFinBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                yFinBox.Focus();
            }
        }

        //Pasar de un textbox al siguiente al clicar Enter en el teclado
        private void yFinBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                velocidadBox.Focus();
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
