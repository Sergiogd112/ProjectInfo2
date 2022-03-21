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
<<<<<<< HEAD
        PictureBox[] plane = new PictureBox[2];
        public Espacioaerio(FlightPlanList l,double c)
        {
            this.lista = l;
            this.ciclo = c;
            InitializeComponent();
=======
        PictureBox[] plane;
        Graphics[] distanciaSeguridadArea;
        FlightPlan plan;
        public Espacioaerio(FlightPlanList l, double c)
        {
            this.lista = l;
            this.plane = new PictureBox[lista.GetMaxLen()];
            this.distanciaSeguridadArea = new Graphics[lista.GetMaxLen()];
            this.ciclo = c;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

>>>>>>> main
        }

        private void Espacioaerio_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < lista.GetLen(); i++)
            {
<<<<<<< HEAD
                plane[i] = new PictureBox();
                plane[i].Location = new Point(Convert.ToInt32(lista.GetFlightAtIndex(i).GetInitialPosition().GetX()), Convert.ToInt32(lista.GetFlightAtIndex(i).GetInitialPosition().GetY()));
                plane[i].ClientSize = new Size(40, 40);
                plane[i].SizeMode = PictureBoxSizeMode.StretchImage;
                plane[i].Image = (Image)new Bitmap("plane.png");
=======
                plan = lista.GetFlightAtIndex(i);
                plane[i] = new PictureBox();
                plane[i].Location = new Point(Convert.ToInt32(plan.GetInitialPosition().GetX()), Convert.ToInt32(plan.GetInitialPosition().GetY()));
                plane[i].ClientSize = new Size(40, 40);
                plane[i].SizeMode = PictureBoxSizeMode.StretchImage;
                plane[i].BackColor = Color.Transparent;
                plane[i].Image = new Bitmap(@"..\..\Properties\plane.png");
                Color newColor = Color.FromArgb(128, Color.Green);
                SolidBrush myBrush = new SolidBrush(newColor);
                distanciaSeguridadArea[i] = panel2.CreateGraphics();
                distanciaSeguridadArea[i].FillEllipse(myBrush, new Rectangle(Convert.ToInt32(plan.GetInitialPosition().GetX())- Convert.ToInt32(lista.GetDistanciaSeguridad()),
                    Convert.ToInt32(plan.GetInitialPosition().GetY())- Convert.ToInt32(lista.GetDistanciaSeguridad()),
                    Convert.ToInt32(plan.GetInitialPosition().GetX())+ Convert.ToInt32(lista.GetDistanciaSeguridad()), 
                    Convert.ToInt32(plan.GetInitialPosition().GetY())+ Convert.ToInt32(lista.GetDistanciaSeguridad())));
                myBrush.Dispose();
                distanciaSeguridadArea[i].Dispose();
>>>>>>> main
                panel2.Controls.Add(plane[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lista.MoveAll(Convert.ToInt32(ciclo)); //he mogut la posició dels avions però no del PictureBox
<<<<<<< HEAD
            for(int i = 0; i < lista.GetLen(); i++) //aquí moc el PictureBox
=======
            for (int i = 0; i < lista.GetLen(); i++) //aquí moc el PictureBox
>>>>>>> main
            {
                plane[i].Location = new Point(Convert.ToInt32(lista.GetFlightAtIndex(i).GetCurrentPosition().GetX()), Convert.ToInt32(lista.GetFlightAtIndex(i).GetCurrentPosition().GetY()));
            }
        }
    }
}
