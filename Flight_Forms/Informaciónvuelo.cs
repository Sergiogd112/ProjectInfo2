using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FligthLib;

namespace Flight_Forms
{
    public partial class Informaciónvuelo : Form
    {
        FlightPlan Vuelos;
        public Informaciónvuelo()
        {
            InitializeComponent();
        }
        public void ClickedFlight(FlightPlan f) //Constructor
        {
            this.Vuelos = f;
        }

       
        //Muestra en las labels los atributos del flightplan clicado mediante los gets
        private void ClickInformacionVuelo_Load(object sender, EventArgs e)
        {

            id.Text = Vuelos.GetId();
            Xbox.Text = Convert.ToString(Vuelos.GetCurrentPosition().GetX());
            Ybox.Text = Convert.ToString(Vuelos.GetCurrentPosition().GetY());
            Velocidad.Text = Convert.ToString(Vuelos.GetVelocidad());          
            
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
