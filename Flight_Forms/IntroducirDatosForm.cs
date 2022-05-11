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

        int butt = 1;

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
                if (this.lista.GetAmountFlights() == 2)
                {
                    Close();
                    MessageBox
                        .Show("Los 2 vuelos fueron guardados.",
                        "Completado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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

        private void rellenoButton_Click(object sender, EventArgs e)
        {
            if (this.butt == 1)
            {
                idBox.Text = "IB123";
                velocidadBox.Text = "150";
                xInBox.Text = "15";
                yInBox.Text = "33";
                xFinBox.Text = "201";
                yFinBox.Text = "300";

                this.butt = 0;
            }
            else
            {
                idBox.Text = "NW550";
                velocidadBox.Text = "90";
                xInBox.Text = "100";
                yInBox.Text = "20";
                xFinBox.Text = "350";
                yFinBox.Text = "144";

                this.butt = 1;
            }
        }
    }
}
