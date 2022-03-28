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
        Position plane0;
        Position plane1;
        double dist;

        PictureBox[] plane;
        FlightPlan plan;

        int butt = 1;

        public Espacioaerio(FlightPlanList l, double c)
        {
            this.lista = l;
            this.plane = new PictureBox[lista.GetMaxLen()];
            this.ciclo = c;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

        }

        private void Espacioaerio_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < lista.GetLen(); i++)
            {
                plan = lista.GetFlightAtIndex(i);
                plane[i] = new PictureBox();
                plane[i].Location = new Point(Convert.ToInt32(plan.GetInitialPosition().GetX()), Convert.ToInt32(plan.GetInitialPosition().GetY()));
                plane[i].ClientSize = new Size(40, 40);
                plane[i].SizeMode = PictureBoxSizeMode.StretchImage;
                plane[i].BackColor = Color.Transparent;
                plane[i].Image = new Bitmap(@"..\..\Properties\avion.gif");
                
                //mostramos trayectoria en ponernos sobre uno de los aviones
                plane


                panel2.Controls.Add(plane[i]);
            }
             
        }


        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            //cada vez que el ratón se mueva por el panel, se disparará un evento, nos lleva a esta funcion
            //el evento e son las coordenadas donde esta en ese momento el cursor

            //sobre la etiqueta vamos a poner un texto que nos indique las coordenadas del cursor en ese momento
            coordenadas.Text = "X= " + e.X + " Y= " + e.Y;
            if (e.X == 0 || e.X == panel2.Size.Width)
            {
                coordenadas.Text = "Cursor fuera del panel.";
            }
            else if (e.Y == 0 || e.Y == panel2.Size.Height)
            {
                coordenadas.Text = "Cursor fuera del panel.";
            }
        }

        private void manualButton_Click(object sender, EventArgs e)
        {
            this.lista.MoveAll(Convert.ToInt32(ciclo)); //he mogut la posició dels avions però no del PictureBox

            for (int i = 0; i < this.lista.GetLen(); i++) //aquí moc el PictureBox

            {
                plane[i].Location = new Point(Convert.ToInt32(this.lista.GetFlightAtIndex(i).GetCurrentPosition().GetX()), Convert.ToInt32(lista.GetFlightAtIndex(i).GetCurrentPosition().GetY()));
                Position position = this.lista.GetFlightAtIndex(i).GetCurrentPosition();

                if ((position.GetX() >= panel2.Width) || (position.GetX() <= 0))
                {
                    Label label = new Label();
                    label.Text = "El avión no aparece en el panel";
                }
                else if ((position.GetY() >= panel2.Height) || (position.GetY() <= 0))
                {
                    Label label = new Label();
                    label.Text = "El avión no aparece en el panel";
                }
            }
            if (distanciaInferior())
                this.Close();

        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            //queremos que en picar automatico se empiecen a mover los vuelos pero que el propio botón cambie su funcionalidad a 'parar'
            //si muestra automatico: butt=0; si se pica automatico (butt=1)

            if (butt == 1)
            {
                //cuando picamos al botón automático, la funcion debe iniciar el reloj
                //lo que tiene que hacer debe hacerlo periódicamente
                //definimos el intervalo de tiempo en el que va a trabajar
                reloj.Interval = 1000;          //unidades en ms
                                                //inicio
                reloj.Start();
                //como hemos picado sobre el botón, debemos cambiar el estado de 1 a 0
                //mostrar 'parar'
                autoButton.Text = "Parar";
                autoButton.BackColor = Color.Red;
                autoButton.ForeColor = Color.Black;
                butt = 0;
            }

            else if (butt == 0)
            {
                //hemos picado a parar
                //mostramos 'automatico'
                //dejamos de mover la lista
                //cambiamos estado
                butt = 1;
                autoButton.Text = "Automático";
                autoButton.BackColor = Color.Blue;
                autoButton.ForeColor = Color.White;
                reloj.Stop();
            }
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            //qué queremos que suceda cada intervalo de tiempo?
            //mover los puntos y la localización de los picturebox

            this.lista.MoveAll(Convert.ToInt32(this.ciclo));
            for (int i = 0; i < this.lista.GetLen(); i++)
            {
                //vector de picturebox con posiciones actualizadas
                //imponemos la posicion de la lista (Actualizada) al picturebox
                Position pos = this.lista.GetFlightAtIndex(i).GetCurrentPosition();
                plane[i].Location = new Point(Convert.ToInt32(pos.GetX()), Convert.ToInt32(pos.GetY()));


                //comprobamos que los picturebox no se salgan del panel
                //en caso de hacerlo, avisamos y paramos simulacion
                if ((pos.GetX() >= panel2.Width) || (pos.GetX() <= 0))
                {
                    Label label = new Label();
                    label.Text = "El avión no aparece en el panel";
                    this.butt = 0;
                }
                else if ((pos.GetY() >= panel2.Height) || (pos.GetY() <= 0))
                {
                    Label label = new Label();
                    label.Text = "El avión no aparece en el panel";
                    this.butt = 0;
                }
            }
            if (distanciaInferior())
                this.Close();
        }
        private bool distanciaInferior()
        {
            plane0 = lista.GetFlightAtIndex(0).GetCurrentPosition();
            plane1 = lista.GetFlightAtIndex(1).GetCurrentPosition();
            dist = lista.GetDistanciaSeguridad();
            if (plane0.Distancia(plane1) <= dist)
            {
                MessageBox.Show("WARNING!!! LOS AVIONES VAN A COLISIONAR");
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plane0 = lista.GetFlightAtIndex(0).GetCurrentPosition();
            plane1 = lista.GetFlightAtIndex(1).GetCurrentPosition();
            int distplane0 = Convert.ToInt32(lista.GetFlightAtIndex(0).GetFinalPosition().Distancia(plane0));
            int distplane1 = Convert.ToInt32(lista.GetFlightAtIndex(1).GetFinalPosition().Distancia(plane1));

            for (int i = 1; distplane0 != 0 && distplane1 != 0; i++)
            {
                this.lista.MoveAll(Convert.ToInt32(ciclo * i));// moure l'avió i no el picturebox
                dist = lista.GetDistanciaSeguridad(); // agafo la distancia de segurertat que han introduit
                plane0 = lista.GetFlightAtIndex(0).GetCurrentPosition(); // agafo la posició actual de l'avió prmier
                plane1 = lista.GetFlightAtIndex(1).GetCurrentPosition(); // agafo la posició actual de l'avió segon
                distplane0 = Convert.ToInt32(lista.GetFlightAtIndex(0).GetFinalPosition().Distancia(plane0));
                distplane1 = Convert.ToInt32(lista.GetFlightAtIndex(1).GetFinalPosition().Distancia(plane1));
                if (plane0.Distancia(plane1) <= dist) // comparo si la distància de seguretat és mes gran que la distància entre els avions
                {
                    MessageBox.Show("WARNING!!! LOS AVIONES VAN A COLISIONAR");
                    return;
                }
            }
            MessageBox.Show("LOS AVIONES NO VAN A COLISIONAR");
            return;
        }
    }
}
