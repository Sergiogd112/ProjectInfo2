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
        FlightPlanList ListaVuelos = new FlightPlanList();
        public TablaAviones()
        {
            InitializeComponent();
        }
        
        public void GetListFlights(FlightPlanList listavuelos) //Obtenemos la lista 
        {
            this.ListaVuelos = listavuelos;
        }
             
        private void MostrarPuntos_Load(object sender, EventArgs e)
        {
            if (ListaVuelos.GetAmountFlights() != 0)
            {
                try
                {
                                     
                    for (int numeros = 0; numeros < 7; numeros++)
                    {
                        dataGridView1.ColumnCount = 6;
                        dataGridView1.RowCount = ListaVuelos.GetAmountFlights();
                        dataGridView1.Columns[0].Name = "Id";                       
                        dataGridView1.Columns[1].Name = "X actual";
                        dataGridView1.Columns[2].Name = "Y actual";
                        dataGridView1.Columns[3].Name = "X final";
                        dataGridView1.Columns[4].Name = "Y final";
                        dataGridView1.Columns[5].Name = "Velocidad";
                       
                        int i = 0;
                        while (i < ListaVuelos.GetAmountFlights())
                        {
                            dataGridView1.Rows[i].Cells[0].Value = ListaVuelos.GetFlightAtIndex(i).GetId();                           
                            dataGridView1.Rows[i].Cells[1].Value = ListaVuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX();
                            dataGridView1.Rows[i].Cells[2].Value = ListaVuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY();
                            dataGridView1.Rows[i].Cells[3].Value = ListaVuelos.GetFlightAtIndex(i).GetFinalPosition().GetX();
                            dataGridView1.Rows[i].Cells[4].Value = ListaVuelos.GetFlightAtIndex(i).GetFinalPosition().GetY();
                            dataGridView1.Rows[i].Cells[5].Value = ListaVuelos.GetFlightAtIndex(i).GetVelocidad();                         
                            i++;
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error de formato");
                    Close();
                }
            }
            else
            {
                Close();
                MessageBox.Show("Tiene que haber mas de un avion");
            }
        }

        private void Cerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int j = e.RowIndex;
           
        }
    }
}

    
