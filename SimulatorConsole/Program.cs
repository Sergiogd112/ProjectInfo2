using FlightLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            // instanciar la FligthPlanList
            FlightPlanList fligthList = new FlightPlanList();
<<<<<<< HEAD
=======

>>>>>>> main


            // Determinar el numero de iteraciones en la simulación

            Console.WriteLine("Escribe el numero de ciclos");
            int ciclos;
            try
            {
                ciclos = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato");

                ciclos = Convert.ToInt32(Console.ReadLine());
            }

            // Determinar la distancia

            Console.WriteLine("Escribe la distancia de seguridad");
            double distanciaSeguridad;
            try
            {
                distanciaSeguridad = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato");

                distanciaSeguridad = Convert.ToDouble(Console.ReadLine());
            }

            fligthList.SetDistanciaSeguridad(distanciaSeguridad);
            // leer el numero de aviones a añadir
            /*            Console.WriteLine("Escribe el numero de aviones");
                        int nAviones;
                        try
                        {
                            nAviones = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error de formato");

                            nAviones = Convert.ToInt32(Console.ReadLine());
                        }
                        // Añadir los FligthPlans
                        fligthList.AddNConsole(nAviones);
            */
            // Añadiendo desde fichero
            string filename = @"C:\Users\sergi\Documents\GitHub\ApuntesUni\Q2A\I2\TEMA1\Your first project in C#-20220220\1.- PrimerProyectoBefore\PrimerProyectoSergio\SimulatorConsole\data.txt";
            fligthList.AddFromFile(filename);

            // bucle de simulación

            int ciclo = 0;
            /*            int i;
                        int j;*/
            Console.WriteLine("Start");
            fligthList.WriteAll();

            while (ciclo < ciclos)
            {
                fligthList.MoveAll(10);

                /*i = 0;
                while (i < nAviones)
                {
                    j = i;
                    while (j < nAviones)
                    {
                        if (fligthList.GetFlightAtIndex(i).Conflicto(fligthList.GetFlightAtIndex(j), distanciaSeguridad)[1]==1)
                        {
                            Console.WriteLine("El avion {0} y {1} estan en conflicto",
                                fligthList.GetFlightAtIndex(i).GetId(),
                                fligthList.GetFlightAtIndex(j).GetId());
                        }
                        j++;
                    }
                    i++;
                }*/
                ciclo++;
            }
            Console.WriteLine("End");
            fligthList.WriteAll();
            Console.WriteLine("Hoa");

            Console.ReadLine();


        }
    }
}
