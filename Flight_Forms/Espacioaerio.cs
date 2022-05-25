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
using GestionUsuarios;
using System.IO;

namespace Flight_Forms
{
    /// <summary>
    /// Formulario para visualizar la simulación
    /// </summary>
    public partial class Espacioaerio : Form
    {
        

        int ciclo;

        double dist;
        
        int numAviones = 0;

        Gestion G = new Gestion();
       
        Stack<List<int[]>> PilaAnteriores = new Stack<List<int[]>>();

        FlightPlanList Vuelos = new FlightPlanList(); //Crea objeto flightplanlist        
        List<PictureBox> misAviones = new List<PictureBox>();

        Pen lapizConflicto = new Pen(Color.Red, 8);
        Pen lapiz = new Pen(Color.NavajoWhite, 8); // El lapiz para poder dibujar las lineas

        TextWriter GuardarAviones; //Fichero para guardar
        TextReader CargarAviones;


        public Espacioaerio()
        {
            InitializeComponent();
        }

        private void Espacioaerio_Load(object sender, EventArgs e)
        {
            G.Iniciar();
            IntroducirParametrosForm parametros = new IntroducirParametrosForm();
            parametros.ShowDialog();
            ciclo = parametros.GetTiempoCiclo();
            dist = parametros.GetDistanciaSeguridad();
            AVISO.Size = new Size(0, 0);
            LabelConflicto.Text = " ";
        }
        private void nuevoAvionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Iniciamos Form de NuevoAvion 
            IntroducirDatosForm aparece = new IntroducirDatosForm();
            aparece.ShowDialog();
            FlightPlan vuelos = aparece.GetPlan(); // Obtenemos el nuevo avion 

            Graphics g = panel2.CreateGraphics();

            if (vuelos != null)
            {
                Vuelos.AddFlightPlan(vuelos);  // Añadimos a la lista 

                // Pintamos avion 
                PictureBox avion = new PictureBox();
                avion.ImageLocation = @"Avion.gif";
                avion.SizeMode = PictureBoxSizeMode.StretchImage;
                avion.Size = new Size(30, 30);
                avion.Location = new Point((int)vuelos.GetCurrentPosition().GetX() - 15, (int)vuelos.GetCurrentPosition().GetY() - 15);
                avion.Tag = Vuelos.GetLen();
                avion.BackColor = Color.DarkSlateGray;

                //Sirve para que al clickar nos de la informacion de este avion en cualquier momento
                avion.Click += new System.EventHandler(this.ClickFlight);

                g.DrawLine(lapiz, (float)vuelos.GetInitialPosition().GetX(), (float)vuelos.GetInitialPosition().GetY(), (float)vuelos.GetFinalPosition().GetX(), (float)vuelos.GetFinalPosition().GetY());
                g.DrawEllipse(lapiz, new RectangleF((float)vuelos.GetFinalPosition().GetX(), (float)vuelos.GetFinalPosition().GetY(), 12, 12));

                panel2.Controls.Add(avion);
                misAviones.Add(avion);
                numAviones++;
            }

            if (Vuelos.GetLen() > 1) //Vemos si va a haber conflictos
            {
                bool Conflicto = false;
                while (Conflicto != true)
                {
                    Vuelos.MoveAll(1);
                    if (Vuelos.ConflictoF(dist) == true)
                    {
                        Conflicto = true;
                        AVISO.BackColor = Color.Red;
                        AVISO.Size = new Size(100, 50);
                        for (int m = 0; m < Vuelos.GetLen(); m++)
                        {
                            for (int n = m + 1; n < Vuelos.GetLen(); n++)
                            {
                                if (Vuelos.GetFlightAtIndex(m).ConflictoTotal(Vuelos.GetFlightAtIndex(n), dist) == true)
                                {
                                    g.DrawLine(lapizConflicto, (float)Vuelos.GetFlightAtIndex(m).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(m).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(m).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(m).GetFinalPosition().GetY());
                                    g.DrawLine(lapizConflicto, (float)Vuelos.GetFlightAtIndex(n).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(n).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(n).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(n).GetFinalPosition().GetY());
                                }
                            }

                        }

                    }
                    if (Vuelos.EstaDestinoLista() == true)
                    {
                        Conflicto = true;
                    }
                }
            }

        }


      
        
       
        

        /// <summary>
        /// Al pulsar sobre un avion abre un form con la informacion del fligthplan
        /// </summary>
        /// <param name="flight">objeto de tipo FligthPlan</param>
        private void ClickFlight(object sender, EventArgs e)
        {
            PictureBox avion = (PictureBox)sender;
            int i = (int)avion.Tag - 1; //intervalo de tags 
            Informaciónvuelo formulario = new Informaciónvuelo();
            formulario.ClickedFlight(Vuelos.GetFlightAtIndex(i)); //Obtenemos la informacion del FlightPlan
            formulario.ShowDialog();
            formulario.Visible = true;//Abre el forms ClickInformacionVuelo 
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
                
                FlightPlan flight = Vuelos.GetFligthWithID(avion.Name);
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
                            avion.Width / 2 - 5,
                        (int)flight.GetFinalPosition().GetY() +
                            avion.Height / 2 - 5,
                        10,
                        10);
                    SolidBrush dist = new SolidBrush(Color.FromArgb(200, 200, 20, 20));
                    int d = (int)Vuelos.GetDistanciaSeguridad();
                    g.FillEllipse(dist, (int)flight.GetCurrentPosition().GetX() +
                            avion.Width / 2 - d / 2,
                            (int)flight.GetCurrentPosition().GetY() +
                            avion.Height / 2 - d / 2, d, d);
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
            Graphics g = panel2.CreateGraphics();

            Vuelos.MoveAll(1);

            for (int i = 0; i < numAviones; i++) // Bucle para poder mover la simulacion
            {
                if (Vuelos.GetLen() > 1)  // Para mas de 1 vuelo
                {
                    int n = 1;

                    if (Vuelos.GetFlightAtIndex(n - 1).ConflictoTotal(Vuelos.GetFlightAtIndex(n), dist) == false) // Miramos conflictos
                    {
                        misAviones[i].Location = new Point((int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15, (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15);
                        LabelConflicto.Text = " ";
                        g.DrawLine(lapiz, (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY());
                        g.DrawEllipse(lapiz, new RectangleF((float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), 10, 10));
                    }

                    // Si tiene conflictos nos lo dira en un label.
                    else
                    {
                        misAviones[i].Location = new Point((int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15, (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15);
                        LabelConflicto.Text = "Conflicto";
                        g.DrawLine(lapizConflicto, (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY());
                        g.DrawEllipse(lapiz, new RectangleF((float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), 10, 10));
                    }
                }

                else // Para solo 1 vuelo
                {
                    // Pintamos la simulacion en su nueva posicion.
                    misAviones[i].Location = new Point((int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15, (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15);
                    g.DrawLine(lapiz, (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY());
                    g.DrawEllipse(lapiz, new RectangleF((float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), 10, 10));
                }
            }
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
            
            Vuelos.MoveAll(Convert.ToInt32(ciclo)); // Movera la simulacion
            List<int[]> A_Guardar = new List<int[]>();
            Graphics g = panel2.CreateGraphics();
            
            for (int i = 0; i < Vuelos.GetLen(); i++)
            {
                int[] Vectores = new int[2];
                if (Vuelos.GetLen() > 1)
                {
                    
                    // Al estar destino timerAutomatica se para 
                    if (Vuelos.EstaDestinoLista() == true)
                    {
                        reloj.Stop();
                    }
                    else
                    {
                        // Miramos posibles conflictos 
                        int n = 1;
                        if (Vuelos.GetFlightAtIndex(n - 1).ConflictoTotal(Vuelos.GetFlightAtIndex(n), dist) == false)
                        {
                            Vectores[0] = (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15;
                            Vectores[1] = (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15;
                            A_Guardar.Add(Vectores);
                            misAviones[i].Location = new Point(Vectores[0], Vectores[1]);
                            g.DrawLine(lapiz, (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY());
                            g.DrawEllipse(lapiz, new RectangleF((float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), 10, 10));
                            LabelConflicto.Text = " ";
                        }

                        else
                        {
                            // Al haber conflicto timerAutomatica se para 
                            Vectores[0] = (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15;
                            Vectores[1] = (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15;
                            A_Guardar.Add(Vectores);
                            misAviones[i].Location = new Point(Vectores[0], Vectores[1]);
                            
                            g.DrawEllipse(lapiz, new RectangleF((float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), 10, 10));
                            LabelConflicto.Text = "Conflicto";
                        }
                    }
                }

                else
                {
                    // Pintamos nuevas posiciones de simulacion 
                    Vectores[0] = (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15;
                    Vectores[1] = (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15;
                    A_Guardar.Add(Vectores);
                    misAviones[i].Location = new Point(Vectores[0], Vectores[1]);
                    
                    if (Vuelos.GetFlightAtIndex(0).EstaDestino())
                    {
                        reloj.Stop();
                    }
                }
            }
            PilaAnteriores.Push(A_Guardar);


        }

        /// <summary>
        /// Comprueva si la distancia entre aviones es menor a la de seguridad
        /// </summary>
        /// <returns><see langword="true"/>si la distancia es menor a la de seguridad</returns>
        private bool distanciaInferior()
        {
            
            for (int i = 0; i < Vuelos.GetLen(); i++)
            {
                for (int j = i + 1; j < Vuelos.GetLen(); j++)
                {
                    if (Vuelos.GetFlightAtIndex(i).Distanciaentrevuelos(Vuelos.GetFlightAtIndex(i), Vuelos.GetFlightAtIndex(j)) <= dist)
                    {
                        MessageBox.Show("WARNING!!! LOS AVIONES VAN A COLISIONAR");
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
            for (int i = 0; i < Vuelos.GetLen(); i++)
            {
                misAviones[i].Location = new Point((int)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetX() - 15, (int)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetY() - 15);
                Vuelos.GetFlightAtIndex(i).Restart();
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

            if (PilaAnteriores.Count() > 0)
            {
                List<int[]> Vectores = PilaAnteriores.Pop(); // Obtemos vectores 

                int i = 0;
                foreach (int[] vect in Vectores)
                {
                    Vuelos.GetFlightAtIndex(i).GetCurrentPosition().SetGetX((double)vect[0]);
                    Vuelos.GetFlightAtIndex(i).GetCurrentPosition().SetGetY((double)vect[1]);
                    misAviones[i].Location = new Point(vect[0], vect[1]);
                    g.DrawLine(lapiz, (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY());
                    g.DrawEllipse(lapiz, new RectangleF((float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), 10, 10));

                    i++;
                }
            }
        }


        private void Conflicto_Click(object sender, EventArgs e)
        {
            if (Vuelos.GetLen() == 0)
            {
                MessageBox.Show("Introduzco dos aviones para poder utilizar esta funcion");
            }
            if (Vuelos.GetLen() == 1)
            {
                MessageBox.Show("No habra conflicto porque solo hay un avion");
            }
            else
            {
                // Iniciamos timer para buscar conflictos 
                timerconflictos.Interval = 1;
                timerconflictos.Start();
            }

        }
        private void timerconflictos_Tick(object sender, EventArgs e)
        {
            bool Prueba = false;
            int tiempociclos = 1;

            Graphics g = panel2.CreateGraphics();


            Vuelos.MoveAll(tiempociclos); 

            // Vemos si habra conflcitos por cada uno de los aviones 
            for (int i = 0; i < Vuelos.GetLen(); i++)
            {
                for (int n = i + 1; n < Vuelos.GetLen(); n++)
                {
                    if (Vuelos.GetFlightAtIndex(i).ConflictoTotal(Vuelos.GetFlightAtIndex(n), dist) == true)
                    {
                        // Al haber confclitos el timer se para 
                        timerconflictos.Stop();
                        Prueba = true;
                    }
                }

                // Si no hay conflictos 
                if (Vuelos.GetFlightAtIndex(i).EstaDestino() != false)
                {
                    timerconflictos.Stop();
                    MessageBox.Show("No hay conflicto");
                    for (int p = 0; p < Vuelos.GetLen(); p++)
                    {
                        Vuelos.GetFlightAtIndex(p).Restart();
                    }

                }
            }

            // Al haber conflicto se abrira el form de ConflictoResolver 
            if (Prueba == true)
            {
                ResolverConflicto aparece = new ResolverConflicto();
                aparece.GetDistanciaSeguridad(dist);
                aparece.GetListFlights(Vuelos);
                
                aparece.ShowDialog();
                bool Resuelto = aparece.VerSiEstaResuelto(); // Para ver si el conflicto esta resuelto

                if (Resuelto != false)
                {
                    AVISO.Size = new Size(0, 0);

                    for (int m = 0; m < Vuelos.GetLen(); m++)
                    {
                        for (int n = m + 1; n < Vuelos.GetLen(); n++)
                        {
                            g.DrawLine(lapiz, (float)Vuelos.GetFlightAtIndex(m).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(m).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(m).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(m).GetFinalPosition().GetY());
                            g.DrawLine(lapiz, (float)Vuelos.GetFlightAtIndex(n).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(n).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(n).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(n).GetFinalPosition().GetY());

                        }

                    }
                }

                // Reiniciaremos la simulacion al acabar
                for (int i = 0; i < Vuelos.GetLen(); i++)
                {
                    Vuelos.GetFlightAtIndex(i).Restart();
                }
            }
        }

        private void Parar_Click(object sender, EventArgs e)
        {
            reloj.Stop();
        }

        private void listaDeVuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TablaAviones aparece = new TablaAviones();
            aparece.SetListFlights(Vuelos);
            aparece.ShowDialog();
        }

        private void parametrosDelVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntroducirParametrosForm parametros = new IntroducirParametrosForm();
            parametros.ShowDialog();
            ciclo = parametros.GetTiempoCiclo();
            dist = parametros.GetDistanciaSeguridad();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] trozos;
            string LineaDevVueloCargado;

            Graphics g = panel2.CreateGraphics();

            CargarAviones = new StreamReader("archivoguardar.txt"); // Fichero prederminado del programa 

            LineaDevVueloCargado = CargarAviones.ReadLine();
            int i = 0;
            while (LineaDevVueloCargado != null)
            {
                trozos = LineaDevVueloCargado.Split();
                FlightPlan vuelos = new FlightPlan(trozos[0], trozos[1], Convert.ToDouble(trozos[2]), Convert.ToDouble(trozos[3]), Convert.ToDouble(trozos[4]), Convert.ToDouble(trozos[5]), Convert.ToDouble(trozos[6]), Convert.ToDouble(trozos[7]), Convert.ToDouble(trozos[8]));
                Vuelos.AddFlightPlan(vuelos);

                PictureBox avion = new PictureBox();
                avion.ImageLocation = @"Avion.gif";
                avion.SizeMode = PictureBoxSizeMode.StretchImage;

                avion.Size = new Size(30, 30);
                avion.Location = new Point((int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15, (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15);
                panel2.Controls.Add(avion); //Pinta otro avion
                misAviones.Add(avion);
                avion.BackColor = Color.Red;
                avion.Tag = Vuelos.GetLen();
                avion.Click += new System.EventHandler(this.ClickFlight);
                g.DrawLine(lapiz, (float)vuelos.GetInitialPosition().GetX(), (float)vuelos.GetInitialPosition().GetY(), (float)vuelos.GetFinalPosition().GetX(), (float)vuelos.GetFinalPosition().GetY());
                g.DrawEllipse(lapiz, new RectangleF((float)vuelos.GetFinalPosition().GetX(), (float)vuelos.GetFinalPosition().GetY(), 10, 10));

                numAviones++;
                i++;

                LineaDevVueloCargado = CargarAviones.ReadLine();
            }
            CargarAviones.Close();

            bool Conflicto = false;
            while (Conflicto != true)
            {
                Vuelos.MoveAll(1);
                if (Vuelos.ConflictoF(dist) == true)
                {
                    Conflicto = true;
                    AVISO.BackColor = Color.Red;
                    AVISO.Size = new Size(100, 50);
                    for (int m = 0; m < Vuelos.GetLen(); m++)
                    {
                        for (int n = m + 1; n < Vuelos.GetLen(); n++)
                        {
                            if (Vuelos.GetFlightAtIndex(m).ConflictoTotal(Vuelos.GetFlightAtIndex(n), dist) == true)
                            {
                                g.DrawLine(lapizConflicto, (float)Vuelos.GetFlightAtIndex(m).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(m).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(m).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(m).GetFinalPosition().GetY());
                                g.DrawLine(lapizConflicto, (float)Vuelos.GetFlightAtIndex(n).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(n).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(n).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(n).GetFinalPosition().GetY());
                            }
                        }

                    }

                }
                if (Vuelos.EstaDestinoLista() == true)
                {
                    Conflicto = true;
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarAviones = new StreamWriter("archivoguardar.txt"); //Nombre del archivo

            for (int i = 0; i < Vuelos.GetLen(); i++)
            {
                GuardarAviones.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} ", Vuelos.GetFlightAtIndex(i).GetId(), Vuelos.GetFlightAtIndex(i).GetCompany(), Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetX(), Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetY(), Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX(), Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY(), Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), Vuelos.GetFlightAtIndex(i).GetVelocidad());
            }

            GuardarAviones.Close();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo aparece = new GuardarComo(); // Form de GuardarComo aparece 
            aparece.ShowDialog();
            string Nombre = aparece.GetNombreFichero();

            GuardarAviones = new StreamWriter(Nombre + ".txt"); // Fichero con nombre del usuario deseado 

            for (int i = 0; i < Vuelos.GetLen(); i++)
            {
                GuardarAviones.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} ", Vuelos.GetFlightAtIndex(i).GetId(), Vuelos.GetFlightAtIndex(i).GetCompany(), Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetX(), Vuelos.GetFlightAtIndex(i).GetInitialPosition().GetY(), Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX(), Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY(), Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), Vuelos.GetFlightAtIndex(i).GetVelocidad());
            }

            GuardarAviones.Close();
        }

        private void cargarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarComo aparece = new CargarComo();
            aparece.ShowDialog();
            string NombreFichero = aparece.GetNombreFichero();
            Graphics g = panel2.CreateGraphics();

            string[] trozos;
            string LineaDevVueloCargado;

            try
            {
                CargarAviones = new StreamReader(NombreFichero + ".txt"); // Fichero del usuario deseado 

                LineaDevVueloCargado = CargarAviones.ReadLine();
                int i = 0;
                bool FalloDatosFicheros = false; // Para ver si algunos datos del fichero estan bien o mal 

                while (LineaDevVueloCargado != null & FalloDatosFicheros == false)
                {
                    trozos = LineaDevVueloCargado.Split();
                    try
                    {
                        FlightPlan vuelos = new FlightPlan(trozos[0], trozos[1], Convert.ToDouble(trozos[2]), Convert.ToDouble(trozos[3]), Convert.ToDouble(trozos[4]), Convert.ToDouble(trozos[5]), Convert.ToDouble(trozos[6]), Convert.ToDouble(trozos[7]), Convert.ToDouble(trozos[8]));
                        Vuelos.AddFlightPlan(vuelos);

                        PictureBox avion = new PictureBox();
                        avion.ImageLocation = @"Avion.gif";
                        avion.SizeMode = PictureBoxSizeMode.StretchImage;

                        avion.Size = new Size(30, 30);
                        avion.Location = new Point((int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetX() - 15, (int)Vuelos.GetFlightAtIndex(i).GetCurrentPosition().GetY() - 15);
                        avion.BackColor = Color.Red;

                        panel2.Controls.Add(avion); //Pinta otro avion
                        misAviones.Add(avion);

                        g.DrawLine(lapiz, (float)vuelos.GetInitialPosition().GetX(), (float)vuelos.GetInitialPosition().GetY(), (float)vuelos.GetFinalPosition().GetX(), (float)vuelos.GetFinalPosition().GetY());
                        g.DrawEllipse(lapiz, new RectangleF((float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(i).GetFinalPosition().GetY(), 10, 10));

                        avion.Tag = Vuelos.GetLen();
                        avion.Click += new System.EventHandler(this.ClickFlight); //Esto no va al dar click solo da un avion.
                        numAviones++;
                        i++;
                    }

                    catch (FormatException)
                    {
                        MessageBox.Show("Fallo en los datos del fichero, si se a cargado algun avion reinicie el programa");
                        FalloDatosFicheros = true;
                    }

                    LineaDevVueloCargado = CargarAviones.ReadLine();
                }

                CargarAviones.Close();

                bool Conflictom = false;
                while (Conflictom != true)
                {
                    Vuelos.MoveAll(1);
                    if (Vuelos.ConflictoF(dist) == true)
                    {
                        Conflictom = true;
                        AVISO.BackColor = Color.Red;
                        AVISO.Size = new Size(100, 50);
                        for (int m = 0; m < Vuelos.GetLen(); m++)
                        {
                            for (int n = m + 1; n < Vuelos.GetLen(); n++)
                            {
                                if (Vuelos.GetFlightAtIndex(m).ConflictoTotal(Vuelos.GetFlightAtIndex(n), dist) == true)
                                {
                                    g.DrawLine(lapizConflicto, (float)Vuelos.GetFlightAtIndex(m).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(m).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(m).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(m).GetFinalPosition().GetY());
                                    g.DrawLine(lapizConflicto, (float)Vuelos.GetFlightAtIndex(n).GetInitialPosition().GetX(), (float)Vuelos.GetFlightAtIndex(n).GetInitialPosition().GetY(), (float)Vuelos.GetFlightAtIndex(n).GetFinalPosition().GetX(), (float)Vuelos.GetFlightAtIndex(n).GetFinalPosition().GetY());

                                }
                            }

                        }

                    }
                    if (Vuelos.EstaDestinoLista() == true)
                    {
                        Conflictom = true;
                    }
                }
            }

            catch (FileNotFoundException) //Fichero no encontrado o mal cargado
            {
                MessageBox.Show("Error al cargar fichero");
            }

            bool Conflicto = false;
            while (Conflicto != true)
            {
                Vuelos.MoveAll(1);
                if (Vuelos.ConflictoF(dist) == true)
                {
                    Conflicto = true;
                    AVISO.BackColor = Color.Red;
                    AVISO.Size = new Size(100, 50);
                }
                if (Vuelos.EstaDestinoLista() == true)
                {
                    Conflicto = true;
                }
            }
        }
    }
}
