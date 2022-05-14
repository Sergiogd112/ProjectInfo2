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
    public partial class IntroducirDatosForm : Form
    {
        public IntroducirDatosForm()
        {
            InitializeComponent();
        }

        private FlightPlanList lista = new FlightPlanList();
        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = idBox.Text;
                double xIn = Convert.ToDouble(xInBox.Text);
                double yIn = Convert.ToDouble(yInBox.Text);
                double xFin = Convert.ToDouble(xFinBox.Text);
                double yFin = Convert.ToDouble(yFinBox.Text);
                double vel = Convert.ToDouble(velocidadBox.Text);

                FlightPlan flight =
                    new FlightPlan(id, xIn, yIn, xFin, yFin, vel);
                this.ResetParametros();

                if (this.lista.GetAmountFlights() < 2)
                {
                    //la lista todavía no se ha llenado con 2 planes de vuelo
                    this.lista.AddFlightPlan(flight);
                }
            }
            catch (FormatException)
            {
                MessageBox
                    .Show("Error en el formato introducido de los datos. Intente de nuevo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
        }

        public FlightPlanList DameLista()
        {
            return this.lista;
        }

        private void IntroducirDatosForm_Load(object sender, EventArgs e)
        {
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
