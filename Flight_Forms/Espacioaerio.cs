﻿using System;
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
    /// <summary>
    /// Formulario para visualizar la simulación
    /// </summary>
    public partial class Espacioaerio : Form
    {
        public FlightPlanList lista;
        double ciclo;
        Position plane0;
        Position plane1;
        double dist;

        private PictureBox[] plane;
        FlightPlan plan;

        int butt = 1;

        /// <summary>
        /// Constructor del espacio aereo donde se instancia la lista de imagenes de aviones.
        /// </summary>
        /// <param name="l">objeto FligthPlanList</param>
        /// <param name="c">numero de doble precison que indica la duración del ciclo</param>
        public Espacioaerio(FlightPlanList l, double c)
        {
            this.lista = l;
            this.plane = new PictureBox[lista.GetMaxLen()];
            this.ciclo = c;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

        }

        /// <summary>
        /// Prepara el panel para la simulación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Espacioaerio_Load(object sender, EventArgs e)
        {
            FlightPlan avion = new FlightPlan();
            plane = new PictureBox[this.lista.GetLen()];
            for (int i = 0; i < this.lista.GetLen(); i++)
            {
                avion = this.lista.GetFlightAtIndex(i);
                PictureBox pic = new PictureBox();
                pic.Location = new Point(Convert.ToInt32(avion.GetInitialPosition().GetX()), Convert.ToInt32(avion.GetInitialPosition().GetY()));
                pic.ClientSize = new Size(40, 40);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BackColor = Color.Transparent;
                pic.Image = new Bitmap(@"..\..\Properties\avion.gif");
                this.panel2.Controls.Add(pic);
                //agregamos método en clicar sobre el flightplan
                pic.DoubleClick += delegate (object s, EventArgs events)
                {
                    ClickFlight(avion);
                };

                plane[i] = pic;
                pic.MouseEnter += delegate (object s, EventArgs events)
                {
                    //si estamos sobre el avión:
                    showRecorrido(avion, true, s);
                };
                pic.MouseLeave += delegate (object s, EventArgs events)
                {
                    //si estamos sobre el avión:
                    showRecorrido(avion, false, s);
                };



            }

        }

        /// <summary>
        /// Al pulsar sobre un avion abre un form con la informacion del fligthplan
        /// </summary>
        /// <param name="flight">objeto de tipo FligthPlan</param>
        private void ClickFlight(FlightPlan flight)
        {
            //en hacer click sobre el plan de vuelo del panel de simulacion, mostramos un formulario con la info del mismo
            Informaciónvuelo info = new Informaciónvuelo();

            info.SetFlight(flight);
            info.ShowDialog();
            info.Visible = true;
        }

        /// <summary>
        /// Muestra el recorrido del avión
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="isEnter"></param>
        /// <param name="sender"></param>
        void showRecorrido(FlightPlan flight, bool isEnter, object sender)
        //Cuando el cursor pasa sobre un avión, se observa una línea que indica la trayectoria
        {       //el booleano isEnter nos indica si estamos posicionados sobre un picturebox


            if (isEnter)
            {
                Label label = new Label();
                label.Text = flight.GetId();
                label.Location = new Point(Convert.ToInt32(flight.GetCurrentPosition().GetX() + 25), Convert.ToInt32(flight.GetCurrentPosition().GetY() + 11));
                label.Size = new System.Drawing.Size(45, 12);
                label.Name = "labelId";
                label.ForeColor = System.Drawing.Color.Black;
                this.panel2.Controls.Add(label);

                PictureBox p = (PictureBox)sender;

                using (Graphics g = this.panel2.CreateGraphics())
                {
                    Pen P = new Pen(Color.Purple, 2);
                    SolidBrush B = new SolidBrush(Color.MidnightBlue);

                    Point PuntoDestino = new Point((int)flight.GetFinalPosition().GetX() + p.Width / 2, (int)flight.GetFinalPosition().GetY() + p.Height / 2);
                    Point PuntoOrigen = new Point((int)flight.GetInitialPosition().GetX() + p.Width / 2, (int)flight.GetInitialPosition().GetY() + p.Height / 2);


                    g.DrawLines(P, new Point[] { PuntoOrigen, PuntoDestino });
                    g.FillEllipse(B, (int)flight.GetFinalPosition().GetX() + 5, (int)flight.GetFinalPosition().GetY() + 5, 10, 10);
                }
            }
            else
            {
                foreach (Control item in this.panel2.Controls.OfType<Control>().ToList())
                {
                    if (item.Name == "labelId") panel2.Controls.Remove(item);
                }


                panel2.Invalidate();
            }
        }

        /// <summary>
        /// Muestra la posición del raton sobre el panel de simulacón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Avanza la simulación un ciclo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manualButton_Click(object sender, EventArgs e)
        {
            this.lista.MoveAll(Convert.ToInt32(ciclo)); //he mogut la posició dels avions però no del PictureBox

            for (int i = 0; i < this.lista.GetLen(); i++) //aquí moc el PictureBox

            {
                plane[i].Location = new Point(Convert.ToInt32(this.lista.GetFlightAtIndex(i).GetCurrentPosition().GetX()), Convert.ToInt32(lista.GetFlightAtIndex(i).GetCurrentPosition().GetY()));
                Position position = this.lista.GetFlightAtIndex(i).GetCurrentPosition();
                Label label;
                if ((position.GetX() >= panel2.Width) || (position.GetX() <= 0))
                {
                    label = new Label();
                    label.Text = "El avión no aparece en el panel";
                }
                else if ((position.GetY() >= panel2.Height) || (position.GetY() <= 0))
                {
                    label = new Label();
                    label.Text = "El avión no aparece en el panel";
                }
            }
            if (distanciaInferior())
                this.Close();

        }

        /// <summary>
        /// Al pulsar el boton, la simulación avanza de forma automática
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// A cada tick de la simulación avanza los ciclos y actualiza el panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Comprueva si la distancia entre aviones es menor a la de seguridad
        /// </summary>
        /// <returns><see langword="true"/>si la distancia es menor a la de seguridad</returns>
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

        /// <summary>
        /// Al pulsar el boton comprueva los conflictos de forma continua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            lista.CheckConflicts(false);
            for (int i = 0; i < lista.GetAmountFlights() - 1; i++)
            {
                for (int j = i + 1; j < lista.GetAmountFlights(); j++)
                {
                    if (lista.GetConflicts()[i, j])
                    {
                        MessageBox.Show("WARNING!!! LOS AVIONES VAN A COLISIONAR");
                        return;
                    }
                }
            }
            MessageBox.Show("LOS AVIONES NO VAN A COLISIONAR");

        }

        /// <summary>
        /// Reiniciar la simulación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reiniciarButton_Click(object sender, EventArgs e)
        {
            this.lista.Restart();
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
        }

        /// <summary>
        /// Retrocede la simulación un ciclo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retroButt_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.lista.GetMaxLen(); i++)
                {
                    FlightPlan f = lista.GetFlightAtIndex(i);
                    f.GetLastPosition(ciclo);
                    plane[i].Location = new Point(Convert.ToInt32(f.GetCurrentPosition().GetX()), Convert.ToInt32(f.GetCurrentPosition().GetY()));
                }

            }
            catch (OverflowException)
            {
                MessageBox.Show("Desbordamiento de operaciones!!!");
            }
        }
    }
}
