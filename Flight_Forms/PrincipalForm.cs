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
        double distSeg;
        double ciclo;
        FlightPlanList lista;
        IntroducirParametrosForm form2;

        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void introducirParametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new IntroducirParametrosForm();
            form2.ShowDialog(); 
            form2.Visible = true;

            double[] parametros = form2.DameParametros();
            distSeg = parametros[0];
            ciclo = parametros[1];
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

            lista = form1.DameLista();
            form1.Visible = false;
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {

        }

        private void iniciarSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Espacioaerio espacioaerio = new Espacioaerio(lista,ciclo);
            espacioaerio.ShowDialog(); 
        }

        private void leerDeFicheroDeMuestraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string defaultpath = @"..\..\..\SimulatorConsole\data.txt";
            try
            {
                lista.AddFromFile(defaultpath);
            }catch (Exception ex)
            {
                lista = new FlightPlanList();
                lista.AddFromFile(defaultpath);
            }
        }
    }
}
