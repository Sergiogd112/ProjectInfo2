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

        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void introducirParametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntroducirParametrosForm form2 = new IntroducirParametrosForm();
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

            FligthPlanList lista = form1.DameLista();
            form1.Visible = false;
        }
    }
}
