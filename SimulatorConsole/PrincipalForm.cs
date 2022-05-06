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
        FlightPlanList lista;
        bool vuelosguardados = false;

        public PrincipalForm()
        {
            InitializeComponent();
            lista = new FlightPlanList();
        }

        private void introducirParametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntroducirParametrosForm form2 = new IntroducirParametrosForm();
            form2.ShowDialog();
            form2.Visible = true;

            double[] parametros = form2.DameParametros();
            this.lista.SetDistanciaSeguridad(parametros[0]); //la distància que escriu la persona
            this.ciclo = parametros[1];
            form2.Visible = false;
        }

        private void oPCIONESToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void introducirDatosDeVueloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IntroducirDatosForm form1 = new IntroducirDatosForm();
            form1.ShowDialog();
            form1.Visible = true;

            this.lista = form1.DameLista();
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
        private void leerDeFicheroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string defaultpath = @"..\..\..\SimulatorConsole\data.txt";
            try
            {
                lista.AddFromFile(defaultpath);
            }
            catch
            {
                lista = new FlightPlanList();
                lista.AddFromFile(defaultpath);
            }
        }

        private void iniciarSimulacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Espacioaerio espacioaerio = new Espacioaerio(lista, ciclo);
            espacioaerio.ShowDialog();
        }

        private void listaDeVuelosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TablaAviones aparece = new TablaAviones();
            aparece.SetListFlights(this.lista);
            aparece.ShowDialog();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {

        }

        private void cargarFicheroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                int error = 0;
                lista.AddFromFile(cargar.FileName);
                if (error == -1)
                    MessageBox.Show("No se encontró el fichero de los vuelos");
                else if (error == -2)
                    MessageBox.Show("Hay un error en el formato de los datos");
            }
        }

        private void guardarFicheroToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lista.GetAmountFlights() != 0)
            {
                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    lista.Dump(guardar.FileName);
                }
            }
            else
            {
                MessageBox.Show("No hay datos para guardar");
            }

        }
    }
}
