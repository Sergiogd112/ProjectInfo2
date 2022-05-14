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
    public partial class PrincipalForm : Form
    {
        //double distSeg;
        double ciclo;

        State state;

        public PrincipalForm()
        {
            InitializeComponent();
            this.state = new State();
        }

        private void introducirParametrosToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            IntroducirParametrosForm form2 = new IntroducirParametrosForm();
            form2.ShowDialog();
            form2.Visible = true;

            double[] parametros = form2.DameParametros();
            this.state.GetCurrentList().SetDistanciaSeguridad(parametros[0]); //la distància que escriu la persona
            this.ciclo = parametros[1];
            form2.Visible = false;
        }

        private void oPCIONESToolStripMenuItem1_Click(
            object sender,
            EventArgs e
        )
        {
        }

        private void introducirDatosDeVueloToolStripMenuItem1_Click(
            object sender,
            EventArgs e
        )
        {
            IntroducirDatosForm form1 = new IntroducirDatosForm();
            form1.ShowDialog();
            form1.Visible = true;

            this.state.SetCurrent(form1.DameLista());
            form1.Visible = false;
        }

        /*
        private void ClickInformacionVuelo(object sender, EventArgs e) 
        {
            PictureBox avion = (PictureBox)sender;
            int i = (int)avion.Tag - 1;
            Informaciónvuelo formulario = new Informaciónvuelo();
            formulario.ClickedFlight(this.lista.GetFlightAtIndex(i)); 
            formulario.ShowDialog(); 

        }

        */
        private void leerDeFicheroToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            string defaultpath = @"..\..\..\SimulatorConsole\data.txt";
            try
            {
                this.state.GetCurrentList().AddFromFile(defaultpath);
            }
            catch (Exception)
            {
                FlightPlanList lista = this.state.GetCurrentList();

                lista.AddFromFile (defaultpath);
            }
        }

        private void iniciarSimulacionToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            Espacioaerio espacioaerio = new Espacioaerio(this.state, ciclo);
            espacioaerio.ShowDialog();
        }

        private void listaDeVuelosToolStripMenuItem_Click_1(
            object sender,
            EventArgs e
        )
        {
            TablaAviones aparece = new TablaAviones();
            aparece.SetListFlights(this.state.GetCurrentList());
            aparece.ShowDialog();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
        }

        private void cargarFicheroToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                int error = 0;
                this.state.GetCurrentList().AddFromFile(cargar.FileName);
                if (error == -1)
                    MessageBox.Show("No se encontró el fichero de los vuelos");
                else if (error == -2)
                    MessageBox.Show("Hay un error en el formato de los datos");
            }
        }

        private void guardarFicheroToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            if (this.state.GetCurrentList().GetAmountFlights() != 0)
            {
                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    this.state.Dump(guardar.FileName);
                }
            }
            else
            {
                MessageBox.Show("No hay datos para guardar");
            }
        }

        private void PrincipalForm_Load_1(object sender, EventArgs e)
        {
        }

        private void generarVariosPlanesToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            GenerarVuelos generar = new GenerarVuelos();
            this.Visible = false;
            generar.ShowDialog();
            generar.Visible = true;
            int n = generar.N;
            double[] rangoDistancia = generar.RangoDistancia;
            double[] rangoVelocidad = generar.RangoVelocidad;
            int reintentos = generar.Reintentos;
            int[,] tamMapa = new int[2, 2];
            tamMapa[0, 0] = 0;
            tamMapa[0, 1] = 0;
            tamMapa[1, 0] = 500;
            tamMapa[1, 1] = 500;
            this
                .state
                .GetCurrentList()
                .GenerateN(n,
                rangoDistancia,
                rangoVelocidad,
                tamMapa,
                reintentos);
        }
    }
}
