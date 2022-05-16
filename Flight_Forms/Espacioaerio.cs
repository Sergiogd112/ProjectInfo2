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
    /// <summary>
    /// Formulario para visualizar la simulación
    /// </summary>
    public partial class Espacioaerio : Form
    {
        public State state;

        double ciclo;

        double dist;

        private PictureBox[] plane;

        int butt = 1;

        /// <summary>
        /// Constructor del espacio aereo donde se instancia la lista de imagenes de aviones.
        /// </summary>
        /// <param name="l">objeto FligthPlanList</param>
        /// <param name="c">numero de doble precison que indica la duración del ciclo</param>
        public Espacioaerio(State state, double c)
        {
            this.state = state;
            this.plane = new PictureBox[state.GetCurrentList().GetLen()];
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
            planeImg.Visible = false;
            FlightPlan avion = new FlightPlan();
            plane = new PictureBox[this.state.GetCurrentList().GetLen()];
            FlightPlanList current = state.GetCurrentList();
            for (int i = 0; i < current.GetLen(); i++)
            {
                avion = current.GetFlightAtIndex(i);
                plane[i] = new PictureBox();
                plane[i].Location = new Point((int)avion.GetCurrentPosition().GetX() - 15, (int)avion.GetCurrentPosition().GetY() - 15);

                plane[i].Size = planeImg.Size;
                plane[i].SizeMode = PictureBoxSizeMode.StretchImage;
                plane[i].BackColor = planeImg.BackColor;
                plane[i].Image = planeImg.Image;
                plane[i].BackgroundImage = planeImg.BackgroundImage;
                plane[i].BackgroundImageLayout = planeImg.BackgroundImageLayout;
                plane[i].Name = avion.GetId();
                this.panel2.Controls.Add(plane[i]);
                //showRecorrido(avion, true, sender);
                //agregamos método en clicar sobre el flightplan
                plane[i].DoubleClick +=
                    delegate (object s, EventArgs events)
                    {
                        ClickFlight(s);
                    };


                plane[i].MouseEnter +=
                    delegate (object s, EventArgs events)
                    {
                        //si estamos sobre el avión:
                        showRecorrido(true, s);
                    };
                plane[i].MouseLeave +=
                    delegate (object s, EventArgs events)
                    {
                        //si estamos sobre el avión:
                        showRecorrido(false, s);
                    };
            }
        }

        private void UpdatePlanes()
        {
            FlightPlanList current = state.GetCurrentList();

            for (
                int i = 0;
                i < current.GetLen();
                i++ //aquí moc el PictureBox
            )
            {
                plane[i].Location =
                    new Point((int)current
                                .GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15,
                        (int)current
                                .GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15);
                Position position =
                    current.GetFlightAtIndex(i).GetCurrentPosition();
                Label label;
                if ((position.GetX() >= panel2.Width) || (position.GetX() <= 0))
                {
                    label = new Label();
                    label.Text = "El avión no aparece en el panel";
                }
                else if (
                    (position.GetY() >= panel2.Height) || (position.GetY() <= 0)
                )
                {
                    label = new Label();
                    label.Text = "El avión no aparece en el panel";
                }
            }
        }

        /// <summary>
        /// Al pulsar sobre un avion abre un form con la informacion del fligthplan
        /// </summary>
        /// <param name="flight">objeto de tipo FligthPlan</param>
        private void ClickFlight(object sender)
        {
            PictureBox p = (PictureBox)sender;
            FlightPlan flight = state.GetCurrentList().GetFligthWithID(p.Name);
            //en hacer click sobre el plan de vuelo del panel de simulacion, mostramos un formulario con la info del mismo
            Informaciónvuelo info = new Informaciónvuelo(flight);

            info.ShowDialog();
            info.Visible = true;
        }

        /// <summary>
        /// Muestra el recorrido del avión
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="isEnter"></param>
        /// <param name="sender"></param>
        void showRecorrido(bool isEnter, object sender) //Cuando el cursor pasa sobre un avión, se observa una línea que indica la trayectoria
        {
            //el booleano isEnter nos indica si estamos posicionados sobre un picturebox
            if (isEnter)
            {
                Label label = new Label();
                PictureBox p = (PictureBox)sender;
                FlightPlan flight = state.GetCurrentList().GetFligthWithID(p.Name);
                label.Text = flight.GetId();
                label.Location =
                    new Point(Convert
                            .ToInt32(flight.GetCurrentPosition().GetX() + 25),
                        Convert
                            .ToInt32(flight.GetCurrentPosition().GetY() + 11));
                label.Size = new System.Drawing.Size(45, 12);
                label.Name = "labelId";
                label.ForeColor = System.Drawing.Color.Black;
                this.panel2.Controls.Add(label);


                using (Graphics g = this.panel2.CreateGraphics())
                {
                    Pen P = new Pen(Color.Purple, 2);
                    SolidBrush B = new SolidBrush(Color.MidnightBlue);

                    Point PuntoDestino =
                        new Point((int)flight.GetFinalPosition().GetX() +
                            p.Width / 2,
                            (int)flight.GetFinalPosition().GetY() +
                            p.Height / 2);
                    Point PuntoOrigen =
                        new Point((int)flight.GetInitialPosition().GetX() +
                            p.Width / 2,
                            (int)flight.GetInitialPosition().GetY() +
                            p.Height / 2);

                    g.DrawLines(P, new Point[] { PuntoOrigen, PuntoDestino });
                    g
                        .FillEllipse(B,
                        (int)flight.GetFinalPosition().GetX() +
                            p.Width / 2 - 5,
                        (int)flight.GetFinalPosition().GetY() +
                            p.Height / 2 - 5,
                        10,
                        10);
                    SolidBrush dist = new SolidBrush(Color.FromArgb(200, 200, 20, 20));
                    int d = (int)state.GetCurrentList().GetDistanciaSeguridad();
                    g.FillEllipse(dist, (int)flight.GetCurrentPosition().GetX() +
                            p.Width / 2 - d / 2,
                            (int)flight.GetCurrentPosition().GetY() +
                            p.Height / 2 - d / 2, d, d);
                }
            }
            else
            {
                foreach (Control
                    item
                    in
                    this.panel2.Controls.OfType<Control>().ToList()
                )
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
            if (manualButton.Text != "Calculando")
            {
                manualButton.Text = "Calculando";
                manualButton.BackColor = Color.Red;
                this.state.Move(Convert.ToInt32(ciclo)); //he mogut la posició dels avions però no del PictureBox          
                this.UpdatePlanes();
                if (distanciaInferior())
                {
                    Console.WriteLine("distancia inferior");
                }
                manualButton.BackColor = Color.LightSteelBlue;
                manualButton.Text = "Manual";
            }
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
                reloj.Interval = Convert.ToInt32(this.ciclo); //unidades en ms

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
            this.state.Move(Convert.ToInt32(this.ciclo));
            this.UpdatePlanes();
            if (distanciaInferior()) this.Close();
        }

        /// <summary>
        /// Comprueva si la distancia entre aviones es menor a la de seguridad
        /// </summary>
        /// <returns><see langword="true"/>si la distancia es menor a la de seguridad</returns>
        private bool distanciaInferior()
        {
            FlightPlanList current = state.GetCurrentList();
            for (int i = 0; i < current.GetLen(); i++)
            {
                for (int j = i + 1; j < current.GetLen(); j++)
                {
                    if (current.GetFlightAtIndex(i).Distanciaentrevuelos(current.GetFlightAtIndex(i), current.GetFlightAtIndex(j)) <= dist)
                    {
                        MessageBox.Show("WARNING!!! LOS AVIONES VAN A COLISIONAR");
                        return true;
                    }
                }
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
            if (button1.Text != "Calculando")
            {


                button1.Text = "Calculando";
                button1.BackColor = Color.Red;
                FlightPlanList current = state.GetCurrentList();
                Console.WriteLine("Comprovando Conflictos");
                current.CheckConflicts(true); // Comprueva si hay conflictos
                current.WriteAll();
                List<List<double>> conflicts = current.GetConflictd(); // Devuleve conflictos
                Console.WriteLine("Analyzing results");
                for (
                    int i = 0;
                    i < current.GetLen();
                    i++ // Miro el primer avió i amb el següent for el comprovaré amb tots els avions
                )
                {
                    for (
                        int j = i + 1;
                        j < current.GetLen();
                        j++ //Tots els altres avions
                    )
                    {
                        Console.WriteLine("{0}, {1}", i, j);
                        if (conflicts[i][j] <= this.dist && conflicts[i][j] != -1)
                        {
                            label9.Text = "WARNING!!! LOS AVIONES VAN A COLISIONAR";
                            button1.BackColor = Color.LightSteelBlue;
                            button1.Text = "Comprovar";

                            return;
                        }
                    }
                }
                button1.Text = "Finalizado";
                label9.Text = "LOS AVIONES NO VAN A COLISIONAR";
                button1.BackColor = Color.LightSteelBlue;
                button1.Text = "Comprovar";

            }
        }

        /// <summary>
        /// Reiniciar la simulación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reiniciarButton_Click(object sender, EventArgs e)
        {
            this.state.Restart();
            FlightPlanList current = state.GetCurrentList();
            UpdatePlanes();
        }

        /// <summary>
        /// Retrocede la simulación un ciclo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retroButt_Click(object sender, EventArgs e)
        {
            this.state.Deshacer();
            UpdatePlanes();
        }

        private void ResolverConf_Click(object sender, EventArgs e)
        {
            if (ResolverConf.Text == "Resolver")
            {
                ResolverConf.Text = "Processando";
                ResolverConf.BackColor = Color.Red;
                Console.WriteLine("Resolviendo");
                this.state.GetCurrentList().SolveConflicts();
                Console.WriteLine("hecho");
                ResolverConf.Text = "Finalizado";
                resLab.Text="Resuelto";
                ResolverConf.Text = "Resolver";
                ResolverConf.BackColor = Color.LightSteelBlue;
            }

        }
    }
}
