using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;
using GestionUsuarios;

namespace Flight_Forms
{
    /// <summary>
    /// Formulario para visualizar la simulación
    /// </summary>
    public partial class Espacioaerio : Form
    {
        SoundPlayer musica;

        State state;

        int ciclo;

        double dist;

        int numAviones = 0;

        Gestion G = new Gestion();

        List<PictureBox> misAviones = new List<PictureBox>();

        Pen lapizConflicto = new Pen(Color.Red, 8);

        Pen lapiz = new Pen(Color.NavajoWhite, 8); // El lapiz para poder dibujar las lineas

        TextWriter GuardarAviones; //Fichero para guardar

        TextReader CargarAviones;

        public Espacioaerio()
        {
            InitializeComponent();
            state = new State();
        }

        private void Espacioaerio_Load(object sender, EventArgs e)
        {
            G.Iniciar();
            IntroducirParametrosForm parametros =
                new IntroducirParametrosForm();
            parametros.ShowDialog();
            ciclo = parametros.GetTiempoCiclo();
            dist = parametros.GetDistanciaSeguridad();
            parametros.PararMusica();
            AVISO.Size = new Size(0, 0);
            LabelConflicto.Text = " ";
            try
            {
                musica = new SoundPlayer(@"c:ComeFlyWithMe.wav");
                musica.Play();
            }
            catch
            {
            }
        }

        private void nuevoAvionToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            musica.Stop();

            //Iniciamos Form de NuevoAvion
            IntroducirDatosForm aparece = new IntroducirDatosForm();
            aparece.ShowDialog();
            FlightPlan vuelos = aparece.GetPlan(); // Obtenemos el nuevo avion

            Graphics g = panel2.CreateGraphics();

            if (vuelos != null)
            {
                state.GetCurrentList().AddFlightPlan(vuelos); // Añadimos a la lista

                // Pintamos avion
                PictureBox avion = new PictureBox();
                avion.ImageLocation = @"Avion.gif";
                avion.SizeMode = PictureBoxSizeMode.StretchImage;
                avion.Size = new Size(30, 30);
                avion.Location =
                    new Point((int)vuelos.GetCurrentPosition().GetX() - 15,
                        (int)vuelos.GetCurrentPosition().GetY() - 15);
                avion.Tag = state.GetCurrentList().GetLen();
                avion.BackColor = Color.DarkSlateGray;

                //Sirve para que al clickar nos de la informacion de este avion en cualquier momento
                avion.Click += new System.EventHandler(this.ClickFlight);

                g
                    .DrawLine(lapiz,
                    (float)vuelos.GetInitialPosition().GetX(),
                    (float)vuelos.GetInitialPosition().GetY(),
                    (float)vuelos.GetFinalPosition().GetX(),
                    (float)vuelos.GetFinalPosition().GetY());
                g
                    .DrawEllipse(lapiz,
                    new RectangleF((float)vuelos.GetFinalPosition().GetX(),
                        (float)vuelos.GetFinalPosition().GetY(),
                        12,
                        12));

                panel2.Controls.Add(avion);
                misAviones.Add(avion);
                numAviones++;
            }

            if (
                state.GetCurrentList().GetLen() > 1 //Vemos si va a haber conflictos
            )
            {
                state.GetCurrentList().CheckConflicts();
                bool conflicto = state.GetCurrentList().AnyConflict();
                if (conflicto)
                {
                    state.GetCurrentList().SolveConflicts();
                }
            }
        }

        /// <summary>
        /// Al pulsar sobre un avion abre un form con la informacion del fligthplan
        /// </summary>
        /// <param name="flight">objeto de tipo FligthPlan</param>
        private void ClickFlight(object sender, EventArgs e)
        {
            musica.Stop();
            PictureBox avion = (PictureBox)sender;
            int i = (int)avion.Tag - 1; //intervalo de tags
            Informaciónvuelo formulario = new Informaciónvuelo();
            formulario
                .ClickedFlight(state.GetCurrentList().GetFlightAtIndex(i)); //Obtenemos la informacion del FlightPlan
            formulario.ShowDialog();
            formulario.Visible = true; //Abre el forms ClickInformacionVuelo
        }

        private void UpdatePlanes(object sender, EventArgs e)
        {
            FlightPlanList current = state.GetCurrentList();
            Graphics g = panel2.CreateGraphics();
            for (
                int i = 0;
                i < numAviones;
                i++ // Bucle para poder mover la simulacion
            )
            {
                if (
                    state.GetCurrentList().GetLen() > 1 // Para mas de 1 vuelo
                )
                {
                    int n = 1;

                    if (
                        state
                            .GetCurrentList()
                            .GetFlightAtIndex(n - 1)
                            .ConflictoTotal(state
                                .GetCurrentList()
                                .GetFlightAtIndex(n),
                            dist) ==
                        false // Miramos conflictos
                    )
                    {
                        misAviones[i].Location =
                            new Point((int)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(i)
                                    .GetCurrentPosition()
                                    .GetX() -
                                15,
                                (int)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(i)
                                    .GetCurrentPosition()
                                    .GetY() -
                                15);
                        LabelConflicto.Text = " ";
                        g
                            .DrawLine(lapiz,
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetInitialPosition()
                                .GetX(),
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetInitialPosition()
                                .GetY(),
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetFinalPosition()
                                .GetX(),
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetFinalPosition()
                                .GetY());
                        g
                            .DrawEllipse(lapiz,
                            new RectangleF((float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(i)
                                    .GetFinalPosition()
                                    .GetX(),
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(i)
                                    .GetFinalPosition()
                                    .GetY(),
                                10,
                                10));
                    }
                    else
                    // Si tiene conflictos nos lo dira en un label.
                    {
                        misAviones[i].Location =
                            new Point((int)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(i)
                                    .GetCurrentPosition()
                                    .GetX() -
                                15,
                                (int)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(i)
                                    .GetCurrentPosition()
                                    .GetY() -
                                15);
                        LabelConflicto.Text = "Conflicto";
                        g
                            .DrawLine(lapizConflicto,
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetInitialPosition()
                                .GetX(),
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetInitialPosition()
                                .GetY(),
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetFinalPosition()
                                .GetX(),
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetFinalPosition()
                                .GetY());
                        g
                            .DrawEllipse(lapiz,
                            new RectangleF((float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(i)
                                    .GetFinalPosition()
                                    .GetX(),
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(i)
                                    .GetFinalPosition()
                                    .GetY(),
                                10,
                                10));
                    }
                } // Para solo 1 vuelo
                else
                {
                    // Pintamos la simulacion en su nueva posicion.
                    misAviones[i].Location =
                        new Point((int)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetCurrentPosition()
                                .GetX() -
                            15,
                            (int)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetCurrentPosition()
                                .GetY() -
                            15);
                    g
                        .DrawLine(lapiz,
                        (float)
                        state
                            .GetCurrentList()
                            .GetFlightAtIndex(i)
                            .GetInitialPosition()
                            .GetX(),
                        (float)
                        state
                            .GetCurrentList()
                            .GetFlightAtIndex(i)
                            .GetInitialPosition()
                            .GetY(),
                        (float)
                        state
                            .GetCurrentList()
                            .GetFlightAtIndex(i)
                            .GetFinalPosition()
                            .GetX(),
                        (float)
                        state
                            .GetCurrentList()
                            .GetFlightAtIndex(i)
                            .GetFinalPosition()
                            .GetY());
                    g
                        .DrawEllipse(lapiz,
                        new RectangleF((float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetFinalPosition()
                                .GetX(),
                            (float)
                            state
                                .GetCurrentList()
                                .GetFlightAtIndex(i)
                                .GetFinalPosition()
                                .GetY(),
                            10,
                            10));
                }
            }
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
                PictureBox avion = (PictureBox)sender;

                FlightPlan flight =
                    state.GetCurrentList().GetFligthWithID(avion.Name);
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
                            avion.Width / 2,
                            (int)flight.GetFinalPosition().GetY() +
                            avion.Height / 2);
                    Point PuntoOrigen =
                        new Point((int)flight.GetInitialPosition().GetX() +
                            avion.Width / 2,
                            (int)flight.GetInitialPosition().GetY() +
                            avion.Height / 2);

                    g.DrawLines(P, new Point[] { PuntoOrigen, PuntoDestino });
                    g
                        .FillEllipse(B,
                        (int)flight.GetFinalPosition().GetX() +
                        avion.Width / 2 -
                        5,
                        (int)flight.GetFinalPosition().GetY() +
                        avion.Height / 2 -
                        5,
                        10,
                        10);
                    SolidBrush dist =
                        new SolidBrush(Color.FromArgb(200, 200, 20, 20));
                    int d =
                        (int)state.GetCurrentList().GetDistanciaSeguridad();
                    g
                        .FillEllipse(dist,
                        (int)flight.GetCurrentPosition().GetX() +
                        avion.Width / 2 -
                        d / 2,
                        (int)flight.GetCurrentPosition().GetY() +
                        avion.Height / 2 -
                        d / 2,
                        d,
                        d);
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
            state.Move(1);
            UpdatePlanes(sender, e);
        }

        /// <summary>
        /// Al pulsar el boton, la simulación avanza de forma automática
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoButton_Click(object sender, EventArgs e)
        {
            reloj.Interval = Convert.ToInt32(ciclo);
            reloj.Start();
        }

        /// <summary>
        /// A cada tick de la simulación avanza los ciclos y actualiza el panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloj_Tick(object sender, EventArgs e)
        {
            state.Move(Convert.ToInt32(ciclo)); // Movera la simulacion
            if (state.GetCurrentList().EstaDestinoLista())
            {
                reloj.Stop();
            }
            state.GetCurrentList().CheckDistanciaActual();
            bool conflicto = state.GetCurrentList().CheckConflicActual();
            if (conflicto)
            {
                Console.WriteLine("conflicto");
            }
            UpdatePlanes(sender, e);
        }

        /// <summary>
        /// Comprueva si la distancia entre aviones es menor a la de seguridad
        /// </summary>
        /// <returns><see langword="true"/>si la distancia es menor a la de seguridad</returns>
        private bool distanciaInferior()
        {
            for (int i = 0; i < state.GetCurrentList().GetLen(); i++)
            {
                for (int j = i + 1; j < state.GetCurrentList().GetLen(); j++)
                {
                    if (
                        state
                            .GetCurrentList()
                            .GetFlightAtIndex(i)
                            .Distanciaentrevuelos(state
                                .GetCurrentList()
                                .GetFlightAtIndex(i),
                            state.GetCurrentList().GetFlightAtIndex(j)) <=
                        dist
                    )
                    {
                        MessageBox
                            .Show("WARNING!!! LOS AVIONES VAN A COLISIONAR");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Reiniciar la simulación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reiniciarButton_Click(object sender, EventArgs e)
        {
            Graphics l = panel2.CreateGraphics();
            for (int i = 0; i < state.GetCurrentList().GetLen(); i++)
            {
                misAviones[i].Location =
                    new Point((int)
                        state
                            .GetCurrentList()
                            .GetFlightAtIndex(i)
                            .GetInitialPosition()
                            .GetX() -
                        15,
                        (int)
                        state
                            .GetCurrentList()
                            .GetFlightAtIndex(i)
                            .GetInitialPosition()
                            .GetY() -
                        15);
                state.GetCurrentList().GetFlightAtIndex(i).Restart();
            }
        }

        /// <summary>
        /// Retrocede la simulación un ciclo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retroButt_Click(object sender, EventArgs e)
        {
            reloj.Stop(); // Paramos timerAutomatica
            Graphics g = panel2.CreateGraphics();
            bool deshacer = state.Deshacer();
            if (deshacer)
            {
                UpdatePlanes(sender, e);
            }
        }

        private void Conflicto_Click(object sender, EventArgs e)
        {
            if (state.GetCurrentList().GetLen() == 0)
            {
                MessageBox
                    .Show("Introduzco dos aviones para poder utilizar esta funcion");
            }
            if (state.GetCurrentList().GetLen() == 1)
            {
                MessageBox.Show("No habra conflicto porque solo hay un avion");
            }
            else
            {
                if (state.GetCurrentList().EstaDestinoLista())
                {
                    reloj.Stop();
                }
                state.SaveState();
                ResolverConflicto aparece =
                    new ResolverConflicto(dist, state.GetCurrentList());
                aparece.ShowDialog();
                bool Resuelto = aparece.VerSiEstaResuelto();
                string email = aparece.GetEmail();
                if (Resuelto)
                {
                    Companys companys = new Companys();
                    companys.Iniciar();
                    DataTable dt = companys.ShowCompanys();
                    string report = state.GenerateReport(dt);
                    companys.Cerrar();
                    Email mail = new Email("m2.i2.2b.2022@gmail.com", "espacioaereo", "Simulador", email, "");
                    mail.Body = report;
                    mail.Subject = "Report Simulador";
                    mail.Send();
                    StreamWriter w = new StreamWriter("report.html");
                    w.Write(mail.Body);
                    w.Close();
                }
            }
        }

        private void timerconflictos_Tick(object sender, EventArgs e)
        {
            bool Prueba = false;
            int tiempociclos = 1;

            Graphics g = panel2.CreateGraphics();

            state.Move(Convert.ToInt32(tiempociclos)); // Movera la simulacion
            if (state.GetCurrentList().EstaDestinoLista())
            {
                reloj.Stop();
            }
            state.GetCurrentList().CheckDistanciaActual();
            bool conflicto = state.GetCurrentList().CheckConflicActual();
            if (conflicto)
            {
                timerconflictos.Stop();
                Prueba = true;
                Console.WriteLine("conflicto");
            }

            // Al haber conflicto se abrira el form de ConflictoResolver
            if (Prueba == true)
            {
                state.SaveState();
                ResolverConflicto aparece =
                    new ResolverConflicto(dist, state.GetCurrentList());

                aparece.ShowDialog();
                bool Resuelto = aparece.VerSiEstaResuelto(); // Para ver si el conflicto esta resuelto

                if (Resuelto != false)
                {

                    AVISO.Size = new Size(0, 0);

                    for (int m = 0; m < state.GetCurrentList().GetLen(); m++)
                    {
                        for (
                            int n = m + 1;
                            n < state.GetCurrentList().GetLen();
                            n++
                        )
                        {
                            g
                                .DrawLine(lapiz,
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(m)
                                    .GetInitialPosition()
                                    .GetX(),
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(m)
                                    .GetInitialPosition()
                                    .GetY(),
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(m)
                                    .GetFinalPosition()
                                    .GetX(),
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(m)
                                    .GetFinalPosition()
                                    .GetY());
                            g
                                .DrawLine(lapiz,
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(n)
                                    .GetInitialPosition()
                                    .GetX(),
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(n)
                                    .GetInitialPosition()
                                    .GetY(),
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(n)
                                    .GetFinalPosition()
                                    .GetX(),
                                (float)
                                state
                                    .GetCurrentList()
                                    .GetFlightAtIndex(n)
                                    .GetFinalPosition()
                                    .GetY());
                        }
                    }
                }

                // Reiniciaremos la simulacion al acabar
                state.Restart();
            }
        }

        private void Parar_Click(object sender, EventArgs e)
        {
            reloj.Stop();
        }

        private void listaDeVuelosToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            musica.Stop();
            TablaAviones aparece = new TablaAviones();
            aparece.SetListFlights(state.GetCurrentList());
            aparece.ShowDialog();
            aparece.PararMusica();
            musica.Play();
        }

        private void parametrosDelVueloToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            musica.Stop();
            IntroducirParametrosForm parametros =
                new IntroducirParametrosForm();
            parametros.ShowDialog();
            ciclo = parametros.GetTiempoCiclo();
            dist = parametros.GetDistanciaSeguridad();
            parametros.PararMusica();
            musica.Play();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pLen = state.GetCurrentList().GetLen();
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                int error = 0;
                this.state = State.Load(cargar.FileName);
                if (error == -1)
                    MessageBox.Show("No se encontró el fichero de los vuelos");
                else if (error == -2)
                    MessageBox.Show("Hay un error en el formato de los datos");
            }
            state.GetCurrentList().CheckConflicts();
            bool conflicto = state.GetCurrentList().AnyConflict();
            if (conflicto)
            {
                state.GetCurrentList().SolveConflicts();
            }
            Graphics g = panel2.CreateGraphics();

            for (int i = pLen; i < this.state.GetCurrentList().GetLen(); i++)
            {
                // Pintamos avion
                PictureBox avion = new PictureBox();
                FlightPlan vuelos = state.GetCurrentList().GetFlightAtIndex(i);
                avion.ImageLocation = @"Avion.gif";
                avion.SizeMode = PictureBoxSizeMode.StretchImage;
                avion.Size = new Size(30, 30);
                avion.Location =
                    new Point((int)vuelos.GetCurrentPosition().GetX() - 15,
                        (int)vuelos.GetCurrentPosition().GetY() - 15);
                avion.Tag = state.GetCurrentList().GetLen();
                avion.BackColor = Color.DarkSlateGray;

                //Sirve para que al clickar nos de la informacion de este avion en cualquier momento
                avion.Click += new System.EventHandler(this.ClickFlight);

                g
                    .DrawLine(lapiz,
                    (float)vuelos.GetInitialPosition().GetX(),
                    (float)vuelos.GetInitialPosition().GetY(),
                    (float)vuelos.GetFinalPosition().GetX(),
                    (float)vuelos.GetFinalPosition().GetY());
                g
                    .DrawEllipse(lapiz,
                    new RectangleF((float)vuelos.GetFinalPosition().GetX(),
                        (float)vuelos.GetFinalPosition().GetY(),
                        12,
                        12));

                panel2.Controls.Add(avion);
                misAviones.Add(avion);
                numAviones++;
            }
            UpdatePlanes(sender, e);
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void generarVuelosToolStrip_Click(object sender, EventArgs e)
        {
            GenerarVuelos generar = new GenerarVuelos();
            this.Visible = false;
            generar.ShowDialog();
            this.Visible = true;
            int n = generar.N;
            double[] rangoDistancia = generar.RangoDistancia;
            double[] rangoVelocidad = generar.RangoVelocidad;
            int reintentos = generar.Reintentos;
            int[,] tamMapa = new int[2, 2];
            tamMapa[0, 0] = 0;
            tamMapa[0, 1] = 0;
            tamMapa[1, 0] = 500;
            tamMapa[1, 1] = 500;
            int pLen = this.state.GetCurrentList().GetLen();
            this
                .state
                .GetCurrentList()
                .GenerateN(n,
                rangoDistancia,
                rangoVelocidad,
                tamMapa,
                reintentos);
            Graphics g = panel2.CreateGraphics();

            for (int i = pLen; i < this.state.GetCurrentList().GetLen(); i++)
            {
                // Pintamos avion
                PictureBox avion = new PictureBox();
                FlightPlan vuelos = state.GetCurrentList().GetFlightAtIndex(i);
                avion.ImageLocation = @"Avion.gif";
                avion.SizeMode = PictureBoxSizeMode.StretchImage;
                avion.Size = new Size(30, 30);
                avion.Location =
                    new Point((int)vuelos.GetCurrentPosition().GetX() - 15,
                        (int)vuelos.GetCurrentPosition().GetY() - 15);
                avion.Tag = state.GetCurrentList().GetLen();
                avion.BackColor = Color.DarkSlateGray;

                //Sirve para que al clickar nos de la informacion de este avion en cualquier momento
                avion.Click += new System.EventHandler(this.ClickFlight);

                g
                    .DrawLine(lapiz,
                    (float)vuelos.GetInitialPosition().GetX(),
                    (float)vuelos.GetInitialPosition().GetY(),
                    (float)vuelos.GetFinalPosition().GetX(),
                    (float)vuelos.GetFinalPosition().GetY());
                g
                    .DrawEllipse(lapiz,
                    new RectangleF((float)vuelos.GetFinalPosition().GetX(),
                        (float)vuelos.GetFinalPosition().GetY(),
                        12,
                        12));

                panel2.Controls.Add(avion);
                misAviones.Add(avion);
                numAviones++;
            }
            UpdatePlanes(sender, e);
        }

        private void eliminarUnAvionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = panel2.CreateGraphics();
            FlightPlanList ListaVuelos = state.GetCurrentList();
            
            EliminarAvion aparece = new EliminarAvion();
            aparece.SetListaVuelos(ListaVuelos);
            aparece.ShowDialog();
            aparece.GetListaVuelos();
            if (ListaVuelos.GetLen() != numAviones)
            {
                
                int i = aparece.GetNumeroVuelo();
                misAviones.RemoveAt(i);
                panel2.Controls.RemoveAt(i);
                numAviones = numAviones - 1;

                for (int m = 0; m < ListaVuelos.GetLen(); m++)
                {
                    g.DrawLine(lapiz, (float)ListaVuelos.GetFlightAtIndex(m).GetInitialPosition().GetX(), (float)ListaVuelos.GetFlightAtIndex(m).GetInitialPosition().GetY(), (float)ListaVuelos.GetFlightAtIndex(m).GetFinalPosition().GetX(), (float)ListaVuelos.GetFlightAtIndex(m).GetFinalPosition().GetY());
                    g.DrawEllipse(lapiz, (float)ListaVuelos.GetFlightAtIndex(m).GetFinalPosition().GetX(), (float)ListaVuelos.GetFlightAtIndex(m).GetFinalPosition().GetY(), 10, 10);
                }
            }
        }

        private void eliminarlosTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightPlanList ListaVuelos = state.GetCurrentList();
            ListaVuelos.EliminarTodoVuelo();
            
            for (int i = numAviones - 1; i > -1; i = i - 1)
            {
                misAviones.RemoveAt(i);
                panel2.Controls.RemoveAt(i);
            }

            AVISO.Size = new Size(0, 0);
            
            numAviones = 0;
        }

        // private void guardarComoToolStripMenuItem_Click(
        //     object sender,
        //     EventArgs e
        // )
        // {
        //     musica.Stop();
        //     GuardarComo aparece = new GuardarComo(); // Form de GuardarComo aparece
        //     aparece.ShowDialog();
        //     string Nombre = aparece.GetNombreFichero();
        //     aparece.PararMusica();
        //     musica.Play();

        //     GuardarAviones = new StreamWriter(Nombre + ".txt"); // Fichero con nombre del usuario deseado

        //     for (int i = 0; i < state.GetCurrentList().GetLen(); i++)
        //     {
        //         GuardarAviones
        //             .WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} ",
        //             state.GetCurrentList().GetFlightAtIndex(i).GetId(),
        //             state.GetCurrentList().GetFlightAtIndex(i).GetCompany(),
        //             state
        //                 .GetCurrentList()
        //                 .GetFlightAtIndex(i)
        //                 .GetInitialPosition()
        //                 .GetX(),
        //             state
        //                 .GetCurrentList()
        //                 .GetFlightAtIndex(i)
        //                 .GetInitialPosition()
        //                 .GetY(),
        //             state
        //                 .GetCurrentList()
        //                 .GetFlightAtIndex(i)
        //                 .GetCurrentPosition()
        //                 .GetX(),
        //             state
        //                 .GetCurrentList()
        //                 .GetFlightAtIndex(i)
        //                 .GetCurrentPosition()
        //                 .GetY(),
        //             state
        //                 .GetCurrentList()
        //                 .GetFlightAtIndex(i)
        //                 .GetFinalPosition()
        //                 .GetX(),
        //             state
        //                 .GetCurrentList()
        //                 .GetFlightAtIndex(i)
        //                 .GetFinalPosition()
        //                 .GetY(),
        //             state.GetCurrentList().GetFlightAtIndex(i).GetVelocidad());
        //     }

        //     GuardarAviones.Close();
        // }

        // private void cargarComoToolStripMenuItem_Click(
        //     object sender,
        //     EventArgs e
        // )
        // {
        //     musica.Stop();
        //     CargarComo aparece = new CargarComo();
        //     aparece.ShowDialog();
        //     string NombreFichero = aparece.GetNombreFichero();
        //     aparece.PararMusica();
        //     musica.Play();
        //     Graphics g = panel2.CreateGraphics();

        //     string[] trozos;
        //     string LineaDevVueloCargado;

        //     try
        //     {
        //         CargarAviones = new StreamReader(NombreFichero + ".txt"); // Fichero del usuario deseado

        //         LineaDevVueloCargado = CargarAviones.ReadLine();
        //         int i = 0;
        //         bool FalloDatosFicheros = false; // Para ver si algunos datos del fichero estan bien o mal

        //         while (LineaDevVueloCargado != null &
        //             FalloDatosFicheros == false
        //         )
        //         {
        //             trozos = LineaDevVueloCargado.Split();
        //             try
        //             {
        //                 FlightPlan vuelos =
        //                     new FlightPlan(trozos[0],
        //                         trozos[1],
        //                         Convert.ToDouble(trozos[2]),
        //                         Convert.ToDouble(trozos[3]),
        //                         Convert.ToDouble(trozos[4]),
        //                         Convert.ToDouble(trozos[5]),
        //                         Convert.ToDouble(trozos[6]),
        //                         Convert.ToDouble(trozos[7]),
        //                         Convert.ToDouble(trozos[8]));
        //                 state.GetCurrentList().AddFlightPlan(vuelos);

        //                 PictureBox avion = new PictureBox();
        //                 avion.ImageLocation = @"Avion.gif";
        //                 avion.SizeMode = PictureBoxSizeMode.StretchImage;

        //                 avion.Size = new Size(30, 30);
        //                 avion.Location =
        //                     new Point((int)
        //                         state
        //                             .GetCurrentList()
        //                             .GetFlightAtIndex(i)
        //                             .GetCurrentPosition()
        //                             .GetX() -
        //                         15,
        //                         (int)
        //                         state
        //                             .GetCurrentList()
        //                             .GetFlightAtIndex(i)
        //                             .GetCurrentPosition()
        //                             .GetY() -
        //                         15);
        //                 avion.BackColor = Color.Red;

        //                 panel2.Controls.Add (avion); //Pinta otro avion
        //                 misAviones.Add (avion);

        //                 g
        //                     .DrawLine(lapiz,
        //                     (float) vuelos.GetInitialPosition().GetX(),
        //                     (float) vuelos.GetInitialPosition().GetY(),
        //                     (float) vuelos.GetFinalPosition().GetX(),
        //                     (float) vuelos.GetFinalPosition().GetY());
        //                 g
        //                     .DrawEllipse(lapiz,
        //                     new RectangleF((float)
        //                         state
        //                             .GetCurrentList()
        //                             .GetFlightAtIndex(i)
        //                             .GetFinalPosition()
        //                             .GetX(),
        //                         (float)
        //                         state
        //                             .GetCurrentList()
        //                             .GetFlightAtIndex(i)
        //                             .GetFinalPosition()
        //                             .GetY(),
        //                         10,
        //                         10));

        //                 avion.Tag = state.GetCurrentList().GetLen();
        //                 avion.Click +=
        //                     new System.EventHandler(this.ClickFlight); //Esto no va al dar click solo da un avion.
        //                 numAviones++;
        //                 i++;
        //             }
        //             catch (FormatException)
        //             {
        //                 MessageBox
        //                     .Show("Fallo en los datos del fichero, si se a cargado algun avion reinicie el programa");
        //                 FalloDatosFicheros = true;
        //             }

        //             LineaDevVueloCargado = CargarAviones.ReadLine();
        //         }

        //         CargarAviones.Close();

        //         bool Conflictom = false;
        //         while (Conflictom != true)
        //         {
        //             state.GetCurrentList().MoveAll(1);
        //             if (state.GetCurrentList().ConflictoF(dist) == true)
        //             {
        //                 Conflictom = true;
        //                 AVISO.BackColor = Color.Red;
        //                 AVISO.Size = new Size(100, 50);
        //                 for (int m = 0; m < state.GetCurrentList().GetLen(); m++
        //                 )
        //                 {
        //                     for (
        //                         int n = m + 1;
        //                         n < state.GetCurrentList().GetLen();
        //                         n++
        //                     )
        //                     {
        //                         if (
        //                             state
        //                                 .GetCurrentList()
        //                                 .GetFlightAtIndex(m)
        //                                 .ConflictoTotal(state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(n),
        //                                 dist) ==
        //                             true
        //                         )
        //                         {
        //                             g
        //                                 .DrawLine(lapizConflicto,
        //                                 (float)
        //                                 state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(m)
        //                                     .GetInitialPosition()
        //                                     .GetX(),
        //                                 (float)
        //                                 state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(m)
        //                                     .GetInitialPosition()
        //                                     .GetY(),
        //                                 (float)
        //                                 state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(m)
        //                                     .GetFinalPosition()
        //                                     .GetX(),
        //                                 (float)
        //                                 state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(m)
        //                                     .GetFinalPosition()
        //                                     .GetY());
        //                             g
        //                                 .DrawLine(lapizConflicto,
        //                                 (float)
        //                                 state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(n)
        //                                     .GetInitialPosition()
        //                                     .GetX(),
        //                                 (float)
        //                                 state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(n)
        //                                     .GetInitialPosition()
        //                                     .GetY(),
        //                                 (float)
        //                                 state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(n)
        //                                     .GetFinalPosition()
        //                                     .GetX(),
        //                                 (float)
        //                                 state
        //                                     .GetCurrentList()
        //                                     .GetFlightAtIndex(n)
        //                                     .GetFinalPosition()
        //                                     .GetY());
        //                         }
        //                     }
        //                 }
        //             }
        //             if (state.GetCurrentList().EstaDestinoLista() == true)
        //             {
        //                 Conflictom = true;
        //             }
        //         }
        //     }
        //     catch (
        //         FileNotFoundException //Fichero no encontrado o mal cargado
        //     )
        //     {
        //         MessageBox.Show("Error al cargar fichero");
        //     }

        //     bool Conflicto = false;
        //     while (Conflicto != true)
        //     {
        //         state.GetCurrentList().MoveAll(1);
        //         if (state.GetCurrentList().ConflictoF(dist) == true)
        //         {
        //             Conflicto = true;
        //             AVISO.BackColor = Color.Red;
        //             AVISO.Size = new Size(100, 50);
        //         }
        //         if (state.GetCurrentList().EstaDestinoLista() == true)
        //         {
        //             Conflicto = true;
        //         }
        //     }
        // }
    }
}
