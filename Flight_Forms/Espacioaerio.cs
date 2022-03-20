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
    public partial class Espacioaerio : Form
    {
        FlightPlanList lista;
        double ciclo;
        PictureBox[] plane = new PictureBox[2];
        public Espacioaerio(FlightPlanList l,double c)
        {
            this.lista = l;
            this.ciclo = c;
            InitializeComponent();
        }

        private void Espacioaerio_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < lista.GetLen(); i++)
            {
                plane[i] = new PictureBox();
                plane[i].Location = new Point(Convert.ToInt32(lista.GetFlightAtIndex(i).GetInitialPosition().GetX()), Convert.ToInt32(lista.GetFlightAtIndex(i).GetInitialPosition().GetY()));
                plane[i].ClientSize = new Size(40, 40);
                plane[i].SizeMode = PictureBoxSizeMode.StretchImage;
                plane[i].Image = (Image)new Bitmap("plane.png");
                panel2.Controls.Add(plane[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lista.MoveAll(Convert.ToInt32(ciclo)); //he mogut la posició dels avions però no del PictureBox
            for(int i = 0; i < lista.GetLen(); i++) //aquí moc el PictureBox
            {
                plane[i].Location = new Point(Convert.ToInt32(lista.GetFlightAtIndex(i).GetCurrentPosition().GetX()), Convert.ToInt32(lista.GetFlightAtIndex(i).GetCurrentPosition().GetY()));
            }
        }
    }
}
