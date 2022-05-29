using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;


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

        private List<List<double>> distActual = new List<List<double>>();

        private List<List<bool>> confActual = new List<List<bool>>();

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

        /// <summary>
        /// Leer el FligthPlan en un indice
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public FlightPlan GetFlightAtIndex(int index)
        {
            return flights[index];
        }

        public bool EstaDestinoLista()
        {
            bool finalpositon = false;
            int numerodevuelosdestino = 0;

            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].HasArrived())
                {
                    numerodevuelosdestino++;
                }
            }

            if (numerodevuelosdestino == flights.Count)
            {
                finalpositon = true;
                return finalpositon;
            }
            else
            {
                return finalpositon;
            }
        }

        public bool ConflictoF(double distanciaSeguridad)
        {
            int i = 1;
            bool VuelosConflictivos = false;
            while (i < flights.Count)
            {
                for (int n = 0; n < flights.Count; n++)
                {
                    VuelosConflictivos =
                        flights[i]
                            .ConflictoTotal(flights[n], distanciaSeguridad);
                    if (VuelosConflictivos == true)
                    {
                        i = flights.Count;
                        return VuelosConflictivos;
                    }
                }
                i++;
            }
            return VuelosConflictivos;
        }

        public FlightPlan GetFligthWithID(string id)
        {
            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].GetId().Equals(id))
                {
                    return flights[i];
                }
            }
            return null;
        }

        public List<List<double>> GetDistanciaActual()
        {
            return distActual;
        }

        // Generate
        public void GenerateN(
            int n,
            double[] lenRange,
            double[] speedRange,
            int[,] mapRange,
            int retry = 100
        )
        {
            Random random = new Random();
            StreamReader R = new StreamReader("names.txt");
            string text = R.ReadToEnd();
            string[] names = text.Split('\n');
            if (
                lenRange[0] * lenRange[0] >=
                (mapRange[0, 0] - mapRange[1, 0]) *
                (mapRange[0, 0] - mapRange[1, 0]) +
                (mapRange[0, 1] - mapRange[1, 1]) *
                (mapRange[0, 1] - mapRange[1, 1])
            )
            {
                retry = 1;
            }
            for (int i = 0; i < n; i++)
            {
                int idx = random.Next(0, names.Length - 1);
                int idn = random.Next(0, 999);
                double speed =
                    random.NextDouble() * (speedRange[1] - speedRange[0]) +
                    speedRange[0];
                double x0 =
                    Convert
                        .ToDouble(random.Next(mapRange[0, 0], mapRange[1, 0]));
                double y0 =
                    Convert
                        .ToDouble(random.Next(mapRange[0, 1], mapRange[1, 1]));
                double x = 0.0;
                double y = 0.0;
                for (int j = 0; j < retry; j++)
                {
                    double len =
                        random.NextDouble() * (lenRange[1] - lenRange[0]) +
                        lenRange[0];
                    double angle = random.NextDouble() * Math.PI;
                    x = x0 + len * Math.Cos(angle);
                    y = y0 + len * Math.Sin(angle);
                    if (
                        mapRange[0, 0] <= x &&
                        x <= mapRange[1, 0] &&
                        mapRange[0, 1] <= y &&
                        y <= mapRange[1, 1]
                    )
                    {
                        break;
                    }
                }
                string fname = names[idx];
                this
                    .AddFlightPlan(new FlightPlan(fname +
                        Convert.ToString(idn), fname,
                        x0,
                        y0,
                        x,
                        y,
                        speed));
            }
        }

        // Load an save files
        /// <summary>
        /// Añadir un FligthPlan
        /// </summary>
        /// <param name="fligth"></param>
        /// <returns></returns>
        public int
        AddFlightPlan(FlightPlan fligth, bool checkinteracions = true)
        {
            List<double> tmpd1 = new List<double>();
            List<bool> tmpb1 = new List<bool>();
            List<double> tmpd2 = new List<double>();
            List<bool> tmpb2 = new List<bool>();
            List<double> tmpd3 = new List<double>();
            List<bool> tmpb3 = new List<bool>();
            for (int i = 0; i < flights.Count; i++)
            {
                tmpd1.Add(-1);
                tmpb1.Add(false);
                tmpd2.Add(-1);
                tmpb2.Add(false);
                tmpd3.Add(-1);
                tmpb3.Add(false);
                this.interactions[i].Add(false);
                this.mind[i].Add(-1);
                this.conflicts[i].Add(false);
                this.confActual[i].Add(false);
                this.confd[i].Add(-1);
                this.distActual[i].Add(-1);
            }
            tmpd1.Add(-1);
            tmpb1.Add(false);
            tmpd2.Add(-1);
            tmpb2.Add(false);
            tmpd3.Add(-1);
            tmpb3.Add(false);
            this.flights.Add(fligth);
            this.interactions.Add(tmpb1);
            this.mind.Add(tmpd1);
            this.conflicts.Add(tmpb2);
            this.confActual.Add(tmpb3);
            this.confd.Add(tmpd2);
            this.distActual.Add(tmpd3);
            if (checkinteracions)
            {
                this.CheckInteractions();
            }
            return 0;
        }

        /// <summary>
        /// Lee los planes en del fichero txt
        /// </summary>
        /// <param name="filename">Path del fichero</param>
        /// <summary>
        /// Guarda el fichero con un nombre
        /// </summary>
        /// <param name="nombre"></param>
        public void Dump(string nombre)
        {
            StreamWriter W = new StreamWriter(nombre);
            W.WriteLine(this.DumpString());
        }

        public string DumpString()
        {
            string dump = "";
            foreach (FlightPlan fligth in flights)
            {
                dump += fligth.DumpString() + ";";
            }
            dump = dump.Remove(dump.Length - 1);

            return dump;
        }

        public static FlightPlanList Load(string file)
        {
            StreamReader R = new StreamReader(file);
            string text = R.ReadToEnd();
            return FlightPlanList.Load(text);
        }

        public static FlightPlanList LoadString(string s)
        {
            string[] data = s.Split(';');
            FlightPlanList list = new FlightPlanList();
            foreach (string planString in data)
            {
                list.AddFlightPlan(FlightPlan.LoadString(planString));
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
                for (int j = i; j < this.flights.Count; j++)
                {
                    data =
                        this
                            .flights[i]
                            .Interaction(this.flights[j],
                            this.distanciaSeguridad,
                            true);

                    this.interactions[i][j] =
                        Math.Abs(data[0]) <= this.distanciaSeguridad;
                    Console
                        .WriteLine("{0} and {1} are at {2} and is {3}",
                        this.flights[i].GetId(),
                        this.flights[j].GetId(),
                        data[0],
                        data[0] <= this.distanciaSeguridad);
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
            for (int i = 0; i < this.flights.Count; i++)
            {
                for (int j = i + 1; j < this.flights.Count; j++)
                {
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

        public bool AnyConflict()
        {
            foreach (var row in this.confd)
            {
                foreach (double d in row)
                {
                    if (d <= this.distanciaSeguridad)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckDistanciaActual()
        {
            for (int i = 0; i < this.flights.Count - 1; i++)
            {
                distActual[i][i] = 0.0;
                for (int j = i + 1; j < this.flights.Count; j++)
                {
                    distActual[i][j] =
                        this
                            .flights[i]
                            .GetCurrentPosition()
                            .Distancia(this.flights[j].GetCurrentPosition());
                }
            }
        }

        public bool CheckConflicActual()
        {
            bool conflict = false;
            bool inconf = false;
            for (int i = 0; i < this.flights.Count - 1; i++)
            {
                confActual[i][i] = false;
                for (int j = i + 1; j < this.flights.Count; j++)
                {
                    inconf =
                        this.distActual[i][j] < distanciaSeguridad ||
                        this.distActual[j][i] < distanciaSeguridad;
                    confActual[i][j] =
                        this.distActual[i][j] < distanciaSeguridad;
                    confActual[j][i] =
                        this.distActual[j][i] < distanciaSeguridad;
                    if (inconf)
                    {
                        conflict = true;
                    }
                }
            }
            return conflict;
        }

        public void MoveAll(int moves)
        {
            for (int i = 0; i < this.flights.Count; i++)
            {
                this.flights[i].Mover(moves);
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

        public FlightPlanList Copy()
        {
            FlightPlanList copy = new FlightPlanList();
            foreach (FlightPlan plan in this.flights)
            {
                copy.AddFlightPlan(plan.Copy());
            }
            copy.SetDistanciaSeguridad(distanciaSeguridad);
            return copy;
        }

        public void SolveConflicts()
        {
            bool conf = true;
            for (int i = 1; i < this.flights.Count; i++)
            {
                conf = true;
                Console.WriteLine(flights[i].GetId());
                while (conf)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (
                            interactions[i][j] &&
                            flights[i]
                                .Conflicto(flights[j], distanciaSeguridad)[0] <=
                            distanciaSeguridad * distanciaSeguridad
                        )
                        {
                            Console
                                .WriteLine("{0} vel: {1}",
                                flights[i].GetId(),
                                flights[i].GetVelocidad());
                            flights[i]
                                .SetVelocidad(flights[i].GetVelocidad() - 1);
                        }
                        else
                        {
                            conf = false;
                        }
                    }
                }
            }
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
                Console.WriteLine(row);
                Console.WriteLine(separator);
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
                Console.WriteLine(row);
                Console.WriteLine(separator);
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
