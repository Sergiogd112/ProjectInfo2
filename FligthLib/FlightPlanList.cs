using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlightLib
{
    /// <summary>
    /// Clase en la que se guarda una lista de FligthPlans y como se afectan los unos a los otros.
    /// </summary>
    public class FlightPlanList
    {
        private int number;

        private List<FlightPlan> flights = new List<FlightPlan>();

        private List<List<bool>> interactions = new List<List<bool>>();

        private List<List<double>> mind = new List<List<double>>();

        private List<List<bool>> conflicts = new List<List<bool>>();

        private List<List<double>> confd = new List<List<double>>();

        private double distanciaSeguridad;

        int count;

        // CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        public FlightPlanList()
        {
            this.number = 0;
            this.distanciaSeguridad = 0.0;
        }

        // GETTERS
        /// <summary>
        /// Leer el numero de FligthPlans añadidos a la lista
        /// </summary>
        /// <returns></returns>
        public int GetLen()
        {
            return flights.Count;
        }

        /// <summary>
        /// Leer el numero de fligthplans añadidos a la lista
        /// </summary>
        /// <returns></returns>
        public int GetAmountFlights()
        {
            return flights.Count;
        }

        /// <summary>
        /// Leer la distancia de seguridad
        /// </summary>
        /// <returns></returns>
        public double GetDistanciaSeguridad()
        {
            return this.distanciaSeguridad;
        }

        public List<List<bool>> GetConflicts()
        {
            return this.conflicts;
        }

        public List<List<double>> GetConflictd()
        {
            return confd;
        }

        //SETTERS
        /// <summary>
        /// Leer el FligthPlan en un indice
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public FlightPlan GetFlightAtIndex(int index)
        {
            if (index < 0 || index >= number)
            {
                return null;
            }
            return flights[index];
        }

        /// <summary>
        /// Añadir un FligthPlan
        /// </summary>
        /// <param name="fligth"></param>
        /// <returns></returns>
        public int AddFlightPlan(FlightPlan fligth)
        {
            this.flights.Add(fligth);
            return 0;
        }

        /// <summary>
        /// Añadir un FlightPlan desde consola
        /// </summary>
        /// <param name="checkInteractions"></param>
        /// <returns></returns>
        public FlightPlan AddFromConsole(bool checkInteractions = true)
        {
            string identificador;
            string linea;
            string[] trozos;
            double velocidad;
            double
                ix,
                iy;
            double
                fx,
                fy;
            Console.WriteLine("Escribe el identificador");

            //   string nombre = Console.ReadLine();
            identificador = Console.ReadLine();

            Console.WriteLine("Escribe la velocidad");
            try
            {
                velocidad = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato");

                velocidad = Convert.ToDouble(Console.ReadLine());
            }

            Console
                .WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
            linea = Console.ReadLine();
            trozos = linea.Split(' ');
            try
            {
                ix = Convert.ToDouble(trozos[0]);
                iy = Convert.ToDouble(trozos[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato");

                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                ix = Convert.ToDouble(trozos[0]);
                iy = Convert.ToDouble(trozos[1]);
            }

            Console
                .WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
            try
            {
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                fx = Convert.ToDouble(trozos[0]);
                fy = Convert.ToDouble(trozos[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato");

                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                fx = Convert.ToDouble(trozos[0]);
                fy = Convert.ToDouble(trozos[1]);
            }
            FlightPlan fligth =
                new FlightPlan(identificador, ix, iy, fx, fy, velocidad);
            this.AddFlightPlan(fligth);
            if (checkInteractions)
            {
                this.CheckInteractions();
                this.CheckConflicts();
            }
            return fligth;
        }

        /// <summary>
        /// Añade n FligthPlans desde consola
        /// </summary>
        /// <param name="nAviones"></param>
        public void AddNConsole(int nAviones)
        {
            for (int i = 0; i < this.number; i++)
            {
                this.AddFromConsole(false);
            }
            this.CheckInteractions();
            this.CheckConflicts();
        }

        /// <summary>
        /// Lee los planes en del fichero txt
        /// </summary>
        /// <param name="filename">Path del fichero</param>
        public int AddFromFile(string filename)
        {
            string[] lines;
            try
            {
                lines = System.IO.File.ReadAllLines(filename);
            }
            catch (FileNotFoundException)
            {
                return -1;
            }
            string[] data = new string[6];
            double[] coordsAndSpeed = new double[5];
            try
            {
                foreach (string line in lines)
                {
                    data = line.Split(' ');
                    for (int j = 1; j < data.Length; j++)
                    {
                        coordsAndSpeed[j - 1] = Convert.ToDouble(data[j]);
                    }
                    this
                        .AddFlightPlan(new FlightPlan(data[0],
                            Convert.ToDouble(coordsAndSpeed[0]),
                            Convert.ToDouble(coordsAndSpeed[1]),
                            Convert.ToDouble(coordsAndSpeed[2]),
                            Convert.ToDouble(coordsAndSpeed[3]),
                            Convert.ToDouble(coordsAndSpeed[4])));
                }
            }
            catch (FormatException)
            {
                return -2;
            }
            this.CheckInteractions();
            this.CheckConflicts();
            return 1;
        }

        /// <summary>
        /// Guarda el fichero con un nombre
        /// </summary>
        /// <param name="nombre"></param>
        public void Dump(string nombre) //guardar el fichero con un nombe
        {
            StreamWriter W = new StreamWriter(nombre);
            W.WriteLine(this.DumpString());
        }

        public string DumpString()
        {
            string dump = "";
            foreach (FlightPlan fligth in flights)
            {
                dump += fligth.Dumps() + ";";
            }
            return dump;
        }

        public static FlightPlanList Load(string file){
            StreamReader R = new StreamReader(file);
            string text=R.ReadToEnd();
            return FlightPlanList.Load(text);
        }
        public static FlightPlanList LoadString(string s)
        {
            string[] data = s.Split(';');
            FlightPlanList list = new FlightPlanList();
            foreach (string planString in data)
            {
                list.AddFlightPlan(FlightPlan.Loads(planString));
            }
            return list;
        }

        /// <summary>
        /// Modificar la distancia de seguridad. Usa el valor absoluto
        /// </summary>
        /// <param name="d"></param>
        public void SetDistanciaSeguridad(double d)
        {
            this.distanciaSeguridad = Math.Abs(d);
        }

        // CHECKERS
        /// <summary>
        /// Comprueva las minimas distancias posibles entre aviones(independiente de velocidad)
        /// para determinar si la modificacion de la velocidad de uno puede generar un conflicto.
        /// Guarda 2 tablas:
        ///     * interactions: tabla booleana con las interacciones.
        ///     * mind: tabla de distancias minimas possibles (para no tener que recalcular en caso

        ///       de modificar la distancia de seguridad).
        /// </summary>
        public void CheckInteractions()
        {
            double[] data = new double[2];
            for (int i = 0; i < this.flights.Count; i++)
            {
                if (i >= this.interactions.Count)
                {
                    List<bool> temp = new List<bool>();
                    this.interactions.Add(temp);
                }
                for (int j = i; j < this.flights.Count; j++)
                {
                    data =
                        this
                            .flights[i]
                            .Interaction(this.flights[j],
                            this.distanciaSeguridad,
                            true);
                    if (j >= this.interactions[i].Count)
                    {
                        this.interactions[i].Add(false);
                    }
                    this.interactions[i][j] =
                        Math.Abs(data[0]) <= this.distanciaSeguridad;
                    Console
                        .WriteLine("{0} and {1} are at {2} and is {3}",
                        this.flights[i].GetId(),
                        this.flights[j].GetId(),
                        data[0],
                        data[0] <= this.distanciaSeguridad);
                    if (j >= this.interactions.Count)
                    {
                        List<bool> temp = new List<bool>();
                        this.interactions.Add(temp);
                    }
                    if (i >= this.interactions[j].Count)
                    {
                        this.interactions[i].Add(false);
                    }
                    this.interactions[j][i] =
                        Math.Abs(data[0]) <= this.distanciaSeguridad;
                    this.mind[i][j] = data[0];
                    this.mind[j][i] = data[0];
                }
            }
        }

        /// <summary>
        /// Comprueva si dos aviones interaccionan y si lo hacen, comprueva si entran en conflicto
        /// </summary>
        public void CheckConflicts(bool checkAll = false)
        {
            double[] data = new double[2];
            for (int i = 0; i < this.number; i++)
            {
                if (i >= this.interactions.Count)
                {
                    List<bool> temp = new List<bool>();
                    this.interactions.Add(temp);
                }
                for (int j = i; j < this.number; j++)
                {
                    if (j >= this.interactions[i].Count)
                    {
                        this.interactions[i].Add(false);
                    }
                    if (j >= this.interactions.Count)
                    {
                        List<bool> temp = new List<bool>();
                        this.interactions.Add(temp);
                    }
                    if (i >= this.interactions[j].Count)
                    {
                        this.interactions[i].Add(false);
                    }
                    if (this.interactions[i][j] || checkAll)
                    {
                        data =
                            this
                                .flights[i]
                                .Conflicto(this.flights[j],
                                this.distanciaSeguridad);
                        this.conflicts[i][j] =
                            data[0] <=
                            this.distanciaSeguridad * this.distanciaSeguridad;
                        this.conflicts[j][i] =
                            data[0] <=
                            this.distanciaSeguridad * this.distanciaSeguridad;
                        this.confd[i][j] = data[0];
                        this.confd[j][i] = data[0];
                    }
                    else
                    {
                        this.conflicts[i][j] = false;
                        this.conflicts[j][i] = false;
                        this.confd[i][j] = this.mind[i][j];
                        this.confd[j][i] = this.mind[i][j];
                    }
                }
            }
        }

        // METHODS
        /// <summary>
        /// Mueve todos los aviones n moves
        /// </summary>
        /// <param name="moves"></param>
        public void MoveAll(int moves)
        {
            for (int i = 0; i < this.number; i++)
            {
                this.flights[i].Mover(10);
            }
        }

        public void Restart()
        {
            for (int i = 0; i < this.number; i++)
            {
                this.flights[i].Restart();
            }
        }

        public int encuentraPlanesDestino()
        {
            int total = 0;
            for (int i = 0; i < this.number; i++)
            {
                if (
                    this.flights[i].GetCurrentPosition().GetX() >= 200 &
                    this.flights[i].GetCurrentPosition().GetY() >= 200
                )
                {
                    total += 1;
                }
            }
            return total;
        }

        // CONSOLE
        /// <summary>
        /// Escribe todos los FligthPlans por consola
        /// </summary>
        public void WriteFligthPlans()
        {
            for (int i = 0; i < this.number; i++)
            {
                this.flights[i].EscribeConsola();
            }
        }

        /// <summary>
        /// Escribe la tabla de interacciones en la consola
        /// </summary>
        public void WriteInteractions()
        {
            string
                row,
                separator;
            for (int i = 0; i < this.number; i++)
            {
                if (interactions[i][0])
                {
                    row = "|X";
                }
                else
                {
                    row = "|-";
                }

                separator = "-";
                for (int j = 1; j < this.number; j++)
                {
                    if (interactions[i][j])
                    {
                        row += "|X";
                    }
                    else
                    {
                        row += "|-";
                    }
                    separator += "+-";
                }
                Console.WriteLine (row);
                Console.WriteLine (separator);
            }
        }

        /// <summary>
        /// Escribe una tabla con los conflictos entre aviones
        /// </summary>
        public void WriteConflicts()
        {
            string
                row,
                separator;
            for (int i = 0; i < this.number; i++)
            {
                if (this.conflicts[i][0])
                {
                    row = "|X";
                }
                else
                {
                    row = "|-";
                }

                separator = "-";
                for (int j = 1; j < this.number; j++)
                {
                    if (this.conflicts[i][j])
                    {
                        row += "|X";
                    }
                    else
                    {
                        row += "|-";
                    }
                    separator += "+-";
                }
                Console.WriteLine (row);
                Console.WriteLine (separator);
            }
        }

        /// <summary>
        /// Escribe toda la informacion del objeto FligthList
        /// </summary>
        public void WriteAll()
        {
            Console
                .WriteLine("Distancia de seguridad: {0}",
                this.distanciaSeguridad);
            Console.WriteLine("Numero de aviones: {0}", this.number);
            this.WriteFligthPlans();
            Console.WriteLine("Interacciones:");
            this.WriteInteractions();
            Console.WriteLine("Conflictos:");
            this.WriteConflicts();
        }

        public string encuentraPlanVelocidad()
        {
            /*
            int count=0;
            while (count < 2)
            {
                
                FlightPlan a = this.flights[count];
                if (a.GetVelocidad()<=50)
                {
                    
                    found = null;

                }
                else
                {
                    //si se ha encontrado, guardamos el plan de vuelo
                    found = a.GetId();
                }

                count++;
              

            }
            return found;
            */
            FlightPlan a = this.flights[0];
            FlightPlan b = this.flights[1];

            if (a.GetVelocidad() > 50)
            {
                count = 0;
            }
            else
            {
                if (b.GetVelocidad() > 50)
                {
                    count = 1;
                }
                else
                {
                    count = -1;
                }
            }

            if (count == 0)
            {
                return a.GetId();
            }
            if (count == 1)
            {
                return b.GetId();
            }
            else
            {
                return null;
            }
        }
    }
}
