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
    public partial class TablaAviones : Form
    {
        public TablaAviones()
        {
            InitializeComponent();
        }

        FlightPlanList ListaVuelos = new FlightPlanList();

        public void SetListFlights(FlightPlanList listavuelos) //Obtenemos la lista
        {
            this.ListaVuelos = listavuelos;
        }

        private void MostrarPuntos_Load(object sender, EventArgs e)
        {
        }

        private void Cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
        }

        private void dataGridView1_CellContentClick_1(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
        }

        private void TablaAviones_Load(object sender, EventArgs e)
        {
            if (this.ListaVuelos.GetAmountFlights() != 0)
            {
                try
                {
                    dataGridView1.ColumnCount = 5;
                    dataGridView1.RowCount =
                        this.ListaVuelos.GetAmountFlights() + 1;
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.AutoSizeRowsMode =
                        DataGridViewAutoSizeRowsMode.AllCells;

                    dataGridView1[0, 0].Value = "Id";
                    dataGridView1[1, 0].Value = "Posición inicial";
                    dataGridView1[2, 0].Value = "Posición actual";
                    dataGridView1[3, 0].Value = "Posición final";
                    dataGridView1[4, 0].Value = "Velocidad";

                    int i = 0;
                    while (i < this.ListaVuelos.GetAmountFlights())
                    {
                        FlightPlan flight =
                            this.ListaVuelos.GetFlightAtIndex(i);
                        dataGridView1[0, i + 1].Value = flight.GetId();
                        dataGridView1[1, i + 1].Value =
                            "X: " +
                            Math.Round(flight.GetInitialPosition().GetX(), 2) +
                            "Y: " +
                            Math.Round(flight.GetInitialPosition().GetY(), 2);
                        dataGridView1[2, i + 1].Value =
                            "X: " +
                            Math.Round(flight.GetCurrentPosition().GetX(), 2) +
                            "Y: " +
                            Math.Round(flight.GetCurrentPosition().GetY(), 2);
                        dataGridView1[3, i + 1].Value =
                            "X: " +
                            Math.Round(flight.GetFinalPosition().GetX(), 2) +
                            "Y: " +
                            Math.Round(flight.GetFinalPosition().GetY(), 2);
                        dataGridView1[4, i + 1].Value = flight.GetVelocidad();
                        i++;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error de formato");
                    this.Close();
                }
            }
            else
            {
                this.Close();
                MessageBox.Show("La lista de vuelos no debe estar vacía");
            }
        }
    }
}
