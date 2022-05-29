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
    public partial class EliminarAvion : Form
    {
        FlightPlanList ListaVuelos = new FlightPlanList();
        int numerodevuelo;
        public EliminarAvion()
        {
            InitializeComponent();
        }
        public void SetListaVuelos(FlightPlanList p) // Obtenemos la lista de vuelos
        {
            this.ListaVuelos = p;
        }

        private void Acceptar_Click(object sender, EventArgs e) // Eliminamos el avion especificado
        {
            bool encotrado = false;

            for (int i = 0; i < ListaVuelos.GetLen(); i++)
            {
                if (ListaVuelos.GetFlightAtIndex(i).GetId() == NombreVuelo.Text)
                {
                    encotrado = true;
                    MessageBox.Show("Vuelo " + ListaVuelos.GetFlightAtIndex(i).GetId() + " eliminado.");
                    ListaVuelos.EliminirVueloParticular(i);
                    numerodevuelo = i;
                }
            }

            if (encotrado == false)
            {
                MessageBox.Show("Por favor verifique el nombre del vuelo.");
            }
            Close();
        }

        public FlightPlanList GetListaVuelos()
        {
            return ListaVuelos;
        }

        public int GetNumeroVuelo()
        {
            return numerodevuelo;
        }
    }
}
