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
using GestionUsuarios;
using System.Media;


namespace Flight_Forms
{
    public partial class ResolverConflicto : Form
    {
        SoundPlayer musica;
        FlightPlanList ListaVuelos = new FlightPlanList();//Crea una objeto de clase flightplanslist
        double distanciadeseguridad;
        bool Resuelto = false;
        //StreamWriter fichero = new StreamWriter("Cambiosdevelocidad.txt");
        Gestion G;
        DataTable compañias;

        public ResolverConflicto(double dist ,FlightPlanList lista)
        {
            InitializeComponent();
            this.ListaVuelos =lista;
            this.distanciadeseguridad=dist;
        }
       
        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetDistanciaSeguridad(double DistanciaSeguridad)
        {
            this.distanciadeseguridad = DistanciaSeguridad;
        }

        //Obtener la lista de flightplans
        public void GetListFlights(FlightPlanList listavuelos)
        {
            this.ListaVuelos = listavuelos;
        }

        public void SetGestor(Gestion G1)
        {
            this.G = G1;
        }
        private void Si_Click(object sender, EventArgs e)
        {
            bool Reinicio = false;
            int TiempoCiclo = 1;
            List<double> Listavelocidades = new List<double>();

            for (int k = 0; k < ListaVuelos.GetLen(); k++)
            {
                Listavelocidades.Add(ListaVuelos.GetFlightAtIndex(k).GetVelocidad());
            }



            // Bucle para ver de anticipada si va a haber conflictos 
            while (Resuelto == false)
            {
                ListaVuelos.MoveAll(TiempoCiclo); // Movemos la simulacion 

                for (int i = 0; i < ListaVuelos.GetLen(); i++)
                {
                    for (int n = i + 1; n < ListaVuelos.GetLen(); n++)
                    {
                        // Si hay conflicto la velocidad de avion n dismunuye 
                        if (ListaVuelos.GetFlightAtIndex(i).ConflictoTotal(ListaVuelos.GetFlightAtIndex(n), distanciadeseguridad) == true)
                        {
                            double VelocidadNueva = ListaVuelos.GetFlightAtIndex(n).GetVelocidad() - 1;
                            Reinicio = true;
                            if (VelocidadNueva < 1) // Cuando no haya solucion 
                            {
                                Resuelto = true;
                                MessageBox.Show("No se puede resolver el conflicto");
                            }
                            else
                            {
                                ListaVuelos.GetFlightAtIndex(n).SetVelocidad(VelocidadNueva); // Posible velocidad que soluciona el conflicto
                            }

                        }
                    }
                }

                if (Reinicio == true) // Si ha habido un cambio de velocidad se reinicia el bucle 
                {
                    for (int m = 0; m < ListaVuelos.GetLen(); m++)
                    {
                        ListaVuelos.GetFlightAtIndex(m).Restart();
                    }

                    Reinicio = false;
                }

                // Cuando todos los aviones esten en la posicion final el bucle acaba
                if (ListaVuelos.EstaDestinoLista() == true)
                {

                    Resuelto = true; 
                  
                    MessageBox.Show("Conflicto resuleto, documento Cambiosdevelocidad.txt creado.");


                }
                Close();
            }

        }
        public bool VerSiEstaResuelto() // Para que nos devulva a ver si esta resulto
        {
            return Resuelto;
        }

        private void ResolverConflicto_Load(object sender, EventArgs e)
        {
            try
            {
                musica = new SoundPlayer(@"c:Unstoppable.wav");
                musica.Play();
            }
            catch
            { }
        }

        public void PararMusica()
        {
            musica.Stop();
        }
    }
}
