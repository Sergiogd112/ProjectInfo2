using System;
using System.Collections.Generic;
using System.Text;

namespace FligthLib
{
    /// <summary>
    /// Clase en la que se guarda una lista de FligthPlans y como se afectan los unos a los otros.
    /// </summary>
    public class FligthPlanList
    {
        private int number;
        const int maxLen = 1000;
        private FlightPlan[] flights;
        private bool[,] interactions;
        private double[,] mind;
        private bool[,] conflicts;
        private double[,] confd;
        private double distanciaSeguridad;

        // CONSTRUCTOR

        /// <summary>
        /// Constructor
        /// </summary>
        public FligthPlanList()
        {
            this.number = 0;
            this.flights = new FlightPlan[maxLen];
            this.interactions = new bool[maxLen, maxLen];
            this.conflicts = new bool[maxLen, maxLen];
            this.mind = new double[maxLen, maxLen];
            this.confd = new double[maxLen, maxLen];
            this.distanciaSeguridad = 0.0;
        }

        // GETTERS

        /// <summary>
        /// Leer el numero de FligthPlans añadidos a la lista
        /// </summary>
        /// <returns></returns>
        public int GetLen()
        {
            return number;
        }

        /// <summary>
        /// Leer el numero de fligthplans añadidos a la lista
        /// </summary>
        /// <returns></returns>
        public int GetAmountFlights()
        {
            return this.number;
        }

        /// <summary>
        /// Leer la distancia de seguridad
        /// </summary>
        /// <returns></returns>
        public double GetDistanciaSeguridad()
        {
            return this.distanciaSeguridad;
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
        public int AddFligthPlan(FlightPlan fligth)
        {
            if (number == maxLen)
            {
                return -1;
            }
            this.flights[number] = fligth;
            this.number++;
            return this.number;
        }

        /// <summary>
        /// Añadir un FligthPlan desde consola
        /// </summary>
        /// <param name="checkInteractions"></param>
        /// <returns></returns>
        public FlightPlan AddFromConsole(bool checkInteractions = true)
        {
            string identificador;
            string linea;
            string[] trozos;
            double velocidad;
            double ix, iy;
            double fx, fy;
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

            Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
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

            Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
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
            FlightPlan fligth = new FlightPlan(identificador, ix, iy, fx, fy, velocidad);
            this.AddFligthPlan(fligth);
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
        public void AddFromfile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            string[] data = new string[6];
            double[] coordsAndSpeed = new double[5];
            foreach (string line in lines)
            {
                data = line.Split(' ');
                for (int j = 1; j < data.Length; j++)
                {
                    coordsAndSpeed[j - 1] = Convert.ToDouble(data[j]);
                }
                this.AddFligthPlan(new FlightPlan(data[0], coordsAndSpeed[0], coordsAndSpeed[1], coordsAndSpeed[2], coordsAndSpeed[3], coordsAndSpeed[4]));
            }
            this.CheckInteractions();
            this.CheckConflicts();
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
            for (int i = 0; i < this.number; i++)
            {
                for (int j = i; j < this.number; j++)
                {
                    data = this.flights[i].Interaction(this.flights[j], this.distanciaSeguridad, true);
                    this.interactions[i, j] = Math.Abs(data[0]) <= this.distanciaSeguridad;
                    Console.WriteLine("{0} and {1} are at {2} and is {3}", this.flights[i].GetId(), this.flights[j].GetId(),
                        data[0], data[0] <= this.distanciaSeguridad);
                    this.interactions[j, i] = Math.Abs(data[0]) <= this.distanciaSeguridad;
                    this.mind[i, j] = data[0];
                    this.mind[j, i] = data[0];
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
                for (int j = i; j < this.number; j++)
                {
                    if (this.interactions[i, j] || checkAll)
                    {
                        data = this.flights[i].Conflicto(this.flights[j], this.distanciaSeguridad);
                        this.conflicts[i, j] = data[0] <= this.distanciaSeguridad * this.distanciaSeguridad;
                        this.conflicts[j, i] = data[0] <= this.distanciaSeguridad * this.distanciaSeguridad;
                        this.confd[i, j] = data[0];
                        this.confd[j, i] = data[0];
                    }
                    else
                    {
                        this.conflicts[i, j] = false;
                        this.conflicts[j, i] = false;
                        this.confd[i, j] = this.mind[i, j];
                        this.confd[j, i] = this.mind[i, j];
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
            string row, separator;
            for (int i = 0; i < this.number; i++)
            {
                if (interactions[i, 0])
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

                    if (interactions[i, j])
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
            string row, separator;
            for (int i = 0; i < this.number; i++)
            {
                if (this.conflicts[i, 0])
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

                    if (this.conflicts[i, j])
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
            Console.WriteLine("Distancia de seguridad: {0}", this.distanciaSeguridad);
            Console.WriteLine("Numero de aviones: {0}", this.number);
            this.WriteFligthPlans();
            Console.WriteLine("Interacciones:");
            this.WriteInteractions();
            Console.WriteLine("Conflictos:");
            this.WriteConflicts();
        }
    }
}
