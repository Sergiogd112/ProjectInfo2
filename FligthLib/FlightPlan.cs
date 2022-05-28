using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos
        string id; // identificador

        Position initialPosition;

        Position currentPosition; // posicion actual

        Position finalPosition; // posicion final

        double velocidad;

        string company;

        // Constructures




        public FlightPlan(
            string id,
            double ipx,
            double ipy,
            double cpx,
            double cpy,
            double fpx,
            double fpy,
            double velocidad
        )
        {
            this.id = id;
            this.initialPosition = new Position(ipx, ipy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        public FlightPlan(string id, string c, double ipx, double ipy, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.company = c;
            this.initialPosition = new Position(ipx, ipy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }
        // Constructures
        public FlightPlan()
        {
            this.id = "";
            this.initialPosition = new Position(0, 0);
            this.currentPosition = new Position(0, 0);
            this.finalPosition = new Position(0, 0);
            this.velocidad = 0;
        }

        public FlightPlan(
            string id,
            double cpx,
            double cpy,
            double fpx,
            double fpy,
            double velocidad
        )
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        // GETTER
        /// <summary>
        /// Getter del identificador
        /// </summary>
        /// <returns>Identificador</returns>
        public string GetId()
        {
            return this.id;
        }

        /// <summary>
        /// Getter de la velocidad
        /// </summary>
        /// <returns>velocidad</returns>
        public double GetVelocidad()
        {
            return this.velocidad;
        }

        public Position GetInitialPosition()
        {
            return this.initialPosition;
        }

        public Position GetCurrentPosition()
        {
            return this.currentPosition;
        }

        public Position GetFinalPosition()
        {
            return this.finalPosition;
        }
        public string GetCompany()
        {
            return this.company;
        }

        public bool ConflictoTotal(FlightPlan b, double distanciaSeguridad)
        {
            double Time;
            double DistanciaMenor;

            double Velocidad1 = velocidad / 60;
            double Velocidad2 = b.GetVelocidad() / 60;

            double hipotenusa1 = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double hipotenusa2 = Math.Sqrt((b.GetFinalPosition().GetX() - b.GetCurrentPosition().GetX()) * (b.GetFinalPosition().GetX() - b.GetCurrentPosition().GetX()) + (b.GetFinalPosition().GetY() - b.GetCurrentPosition().GetY()) * (b.GetFinalPosition().GetY() - b.GetCurrentPosition().GetY()));

            double C = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa1;
            double C2 = (b.GetFinalPosition().GetX() - b.GetCurrentPosition().GetX()) / hipotenusa2;

            double S = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa1;
            double S2 = (b.GetFinalPosition().GetY() - b.GetCurrentPosition().GetY()) / hipotenusa2;

            Time = -((Velocidad1 * C - Velocidad2 * C2) * (currentPosition.GetX() - b.GetCurrentPosition().GetX()) + (Velocidad1 * S - Velocidad2 * S2) * (currentPosition.GetY() - b.GetCurrentPosition().GetY())) / ((Velocidad1 * S - Velocidad2 * S2) * (Velocidad1 * S - Velocidad2 * S2) + (Velocidad1 * C - Velocidad2 * C2) * (Velocidad1 * C - Velocidad2 * C2));
            double X1 = currentPosition.GetX() + Velocidad1 * Time * C;
            double Y1 = currentPosition.GetY() + Velocidad1 * Time * S;
            double X2 = b.GetCurrentPosition().GetX() + Velocidad2 * Time * C2;
            double Y2 = b.GetCurrentPosition().GetY() + Velocidad2 * Time * S2;

            DistanciaMenor = Math.Sqrt(((X1 - X2) * (X1 - X2)) + (Y1 - Y2) * (Y1 - Y2));
            if (DistanciaMenor < distanciaSeguridad)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Genera un vector de doubles[3,2] con las tres posiciones: start, current y end.
        /// </summary>
        /// <returns>[[startx,starty],[currentx,currenty],[endx,endy]]</returns>
        public double[,] GetPositions()
        {
            double[,] data = new double[3, 2];
            data[0, 0] = this.initialPosition.GetX();
            data[0, 1] = this.initialPosition.GetY();
            data[1, 0] = this.currentPosition.GetX();
            data[1, 1] = this.currentPosition.GetY();
            data[2, 0] = this.finalPosition.GetX();
            data[2, 1] = this.finalPosition.GetY();
            return data;
        }

        /// <summary>
        /// Calcula la distancia entre la posicion actual y destino
        /// </summary>
        /// <returns>Distancia al destino</returns>
        public double getDistanciaDestino()
        {
            return Math
                .Sqrt((
                this.finalPosition.GetX() - this.currentPosition.GetX()
                ) *
                (this.finalPosition.GetX() - this.currentPosition.GetX()) +
                (this.finalPosition.GetY() - this.currentPosition.GetY()) *
                (this.finalPosition.GetY() - currentPosition.GetY()));
        }

        public void GetLastPosition(double cicle)
        {
            if (
                (
                this.currentPosition == null ||
                this.currentPosition == this.initialPosition
                )
            )
            {
                this.currentPosition = this.initialPosition;
            }
            else
            {
                double d = cicle * this.velocidad / 60;
                double hyp =
                    Math
                        .Sqrt(Math
                            .Pow(this.finalPosition.GetX() -
                            this.currentPosition.GetX(),
                            2) +
                        Math
                            .Pow(this.finalPosition.GetY() -
                            this.currentPosition.GetY(),
                            2));
                double cos =
                    (this.finalPosition.GetX() + this.currentPosition.GetX()) /
                    hyp;
                double sin =
                    (this.finalPosition.GetY() + this.currentPosition.GetY()) /
                    hyp;
                double x = currentPosition.GetX() - d * cos;
                double y = currentPosition.GetY() - d * sin;
                SetCurrentPosition(x, y);
            }
            return;
        }

        // SETTERS
        /// <summary>
        /// Setter para Id
        /// </summary>
        /// <param name="identificator">Identificador del avion</param>
        public double Distanciaentrevuelos(FlightPlan a, FlightPlan b)
        {
            return Math
                .Sqrt((
                Convert
                    .ToInt32(a.GetCurrentPosition().GetX() -
                    b.GetCurrentPosition().GetX()) ^
                2
                ) +
                (
                Convert
                    .ToInt32(a.GetCurrentPosition().GetY() -
                    b.GetCurrentPosition().GetY()) ^
                2
                ));
        }

        public void SetId(string identificator)
        {
            this.id = identificator;
        }

        /// <summary>
        /// Setter para la posicion incial
        /// </summary>
        /// <param name="x">coordenada en x</param>
        /// <param name="y">coordenada en y</param>
        public void SetInitialPosition(double x, double y)
        {
            this.initialPosition = new Position(x, y);
        }

        /// <summary>
        /// Setter para la posición actual
        /// </summary>
        /// <param name="x">coordenada en x</param>
        /// <param name="y">coordenada en y</param>
        public void SetCurrentPosition(double x, double y)
        {
            Position p = new Position(x, y);
            this.currentPosition = p;
        }

        /// <summary>
        /// Setter para la posición final
        /// </summary>
        /// <param name="x">coordenada en x</param>
        /// <param name="y">coordenada en y</param>
        public void SetFinalPosition(double x, double y)
        {
            this.finalPosition = new Position(x, y);
        }

        /// <summary>
        /// Setter de la velocidad
        /// </summary>
        /// <param name="velocidad"></param>
        public void SetVelocidad(double v)
        {
            this.velocidad = v;
        }

        // CHECKERS
        /// <summary>
        /// Comprueva si el avion está en destino
        /// </summary>
        /// <returns>true si esta en destinos</returns>
        public bool EstaDestino()
        {
            return this.currentPosition == this.finalPosition;
        }

        /// <summary>
        /// Comprueva si ha llegado
        /// </summary>
        /// <returns><see langword="true"/>si ha llegado</returns>
        public Boolean HasArrived()
        {
            bool success;
            if (EstaDestino() == false)
            {
                success = false;
            }
            else
            {
                success = true;
            }
            return success;
        }

        /// <summary>
        /// Determina la distancia mas corta entre trayectorias. Convertido de Python a C//.
        /// Codigo original en: https://stackoverflow.com/questions/2824478/shortest-distance-between-two-line-segments
        /// </summary>
        /// <param name="b">Segundo avion</param>
        /// <param name="clampAll">Si solo se pueden coger puntos dentro de los segmentos</param>
        /// <param name="clampA0">Puntos a la distancia no antes de la inicial de este avion</param>
        /// <param name="clampA1">Puntos a la distancia no despues de la final de este avion</param>
        /// <param name="clampB0">Puntos a la distancia no antes de la inicial del otro avion</param>
        /// <param name="clampB1">Puntos a la distancia no despues de la final del otro avion</param>
        /// <returns>[primer punto, segundo punto, [distancia minima,(no assignado)]]</returns>
        public double[,]
        ShortestDistanceBetweenPaths(
            FlightPlan b,
            bool clampAll = false,
            bool clampA0 = false,
            bool clampA1 = false,
            bool clampB0 = false,
            bool clampB1 = false,
            double magA = -1,
            double magB = -1
        )
        {
            // If clampAll=True, set all clamps to True
            if (clampAll)
            {
                clampA0 = true;
                clampA1 = true;
                clampB0 = true;
                clampB1 = true;
            }
            double[] a0 = new double[2];
            a0[0] = this.currentPosition.GetX();
            a0[1] = this.currentPosition.GetY();
            double[] a1 = new double[2];
            a1[0] = this.finalPosition.GetX();
            a1[1] = this.finalPosition.GetY();
            double[] b0 = new double[2];
            b0[0] = b.currentPosition.GetX();
            b0[1] = b.currentPosition.GetY();
            double[] b1 = new double[2];
            b1[0] = b.finalPosition.GetX();
            b1[1] = b.finalPosition.GetY();

            // Calculate denomitator
            double[] A = new double[2];
            A[0] = a1[0] - a0[0];
            A[1] = a1[1] - a0[1];
            double[] B = new double[2];
            B[0] = b1[0] - b0[0];
            B[1] = b1[1] - b0[1];

            // get the magnitudes
            if (magA == -1)
            {
                magA = this.getDistanciaDestino();
            }
            if (magB == -1)
            {
                magB = this.getDistanciaDestino();
            }

            double[] _A = new double[2];
            _A[0] = A[0] / magA;
            _A[1] = A[1] / magA;
            double[] _B = new double[2];
            _B[0] = B[0] / magB;
            _B[1] = B[1] / magB;

            double cross = _A[0] * _B[1] - _A[1] * _B[0];
            double denom = cross;

            double[,] result = new double[3, 2];

            // If lines are parallel (denom=0) test if lines overlap.
            // If they don't overlap then there is a closest point solution.
            // If they do overlap, there are infinite closest positions, but there is a closest distance
            double
                d0,
                d1,
                tempx,
                tempy;
            if (denom == 0)
            {
                d0 = _A[0] * (b0[0] - a0[0]) + _A[1] * (b0[1] - a0[1]);

                // Overlap only possible with clamping
                if (clampA0 || clampA1 || clampB0 || clampB1)
                {
                    d1 = _A[0] * (b1[0] - a0[0]) + _A[1] * (b1[1] - a0[1]);

                    // Is segment B before A?
                    if (d0 <= 0 && 0 >= d1)
                    {
                        if (clampA0 && clampB1)
                        {
                            if (Math.Abs(d0) < Math.Abs(d1))
                            {
                                result[0, 0] = a0[0];
                                result[0, 1] = a0[1];
                                result[1, 0] = b0[0];
                                result[1, 1] = b0[1];
                                result[2, 0] =
                                    Math
                                        .Sqrt((a0[0] - b0[0]) *
                                        (a0[0] - b0[0]) +
                                        (a0[1] - b0[1]) * (a0[1] - b0[1]));
                                return result;
                            }
                            result[0, 0] = a0[0];
                            result[0, 1] = a0[1];
                            result[1, 0] = b1[0];
                            result[1, 1] = b1[1];
                            result[2, 0] =
                                Math
                                    .Sqrt((a0[0] - b1[0]) *
                                    (a0[1] - b1[1]) *
                                    (a0[1] - b1[1]));
                            return result;
                        }
                    } // Is segment B after A?
                    else if (d0 >= magA && magA <= d1)
                    {
                        if (clampA1 && clampB0)
                        {
                            if (Math.Abs(d0) < Math.Abs(d1))
                            {
                                result[0, 0] = a1[0];
                                result[0, 1] = a1[1];
                                result[1, 0] = b0[0];
                                result[1, 1] = b0[1];
                                result[2, 0] =
                                    Math
                                        .Sqrt((a1[0] - b0[0]) *
                                        (a1[0] - b0[0]) +
                                        (a1[1] - b0[1]) * (a1[1] - b0[1]));
                                return result;
                            }
                            result[0, 0] = a1[0];
                            result[0, 1] = a1[1];
                            result[1, 0] = b1[0];
                            result[1, 1] = b1[1];
                            result[2, 0] =
                                Math
                                    .Sqrt((a1[0] - b1[0]) * (a1[0] - b1[0]) +
                                    (a1[1] - b1[1]) * (a1[1] - b1[1]));
                            return result;
                        }
                    }
                }

                //result[0, 0] = 0;
                //result[0, 1] = 0;
                //result[1, 0] = 0;
                //result[1,1]=0;
                tempx = d0 * _A[0] + a0[0] - b0[0];
                tempy = d0 * _A[1] + a0[1] - b0[1];
                result[2, 0] = Math.Sqrt(tempx * tempx + tempy * tempy);

                // Segments overlap, return distance between parallel segments
                return result;
            }

            // Lines criss-cross: Calculate the projected closest points
            double[] t = new double[2];
            t[0] = (b0[0] - a0[0]);
            t[1] = (b0[1] - a0[1]);
            double detA = 0;
            double detB = 0;

            double t0 = detA / denom;
            double t1 = detB / denom;

            double[] pA = new double[2]; // Projected closest point on segment A
            pA[0] = a0[0] + _A[0] * t0;
            pA[1] = a0[1] + _A[1] * t0;
            double[] pB = new double[2]; // Projected closest point on segment B
            pB[0] = b0[0] + _B[0] * t0;
            pB[1] = b0[1] + _B[1] * t0;

            // Clamp projections
            if (clampA0 | clampA1 | clampB0 | clampB1)
            {
                if (clampA0 & t0 < 0)
                {
                    pA = a0;
                }
                else if (clampA1 & t0 > magA)
                {
                    pA = a1;
                }

                if (clampB0 & t1 < 0)
                {
                    pB = b0;
                }
                else if (clampB1 & t1 > magB)
                {
                    pB = b1;
                }

                // Clamp projection A
                if ((clampA0 & t0 < 0) | (clampA1 & t0 > magA))
                {
                    double dot =
                        _B[0] * (pA[0] - b0[0]) + _B[1] * (pA[1] - b0[1]);
                    if (clampB0 & dot < 0)
                    {
                        dot = 0;
                    }
                    else if (clampB1 & dot > magB)
                    {
                        dot = magB;
                        pB[0] = b0[0] + dot * _B[0];
                        pB[1] = b0[1] + dot * _B[1];
                    }
                }

                // Clamp projection B
                if ((clampB0 & t1 < 0) | (clampB1 & t1 > magB))
                {
                    double dot =
                        _A[0] * (pB[0] - a0[0]) + _A[1] * (pB[1] - a0[1]);
                    if (clampA0 & dot < 0)
                    {
                        dot = 0;
                    }
                    else if (clampA1 & dot > magA)
                    {
                        dot = magA;
                        pA[0] = a0[0] + dot * _A[0];
                        pA[1] = a0[1] + dot * _A[1];
                    }
                }
            }
            result[0, 0] = pA[0];
            result[0, 1] = pA[1];
            result[1, 0] = pB[0];
            result[1, 1] = pB[1];
            tempx = pA[0] - pB[0];
            tempy = pA[1] - pB[1];
            result[2, 0] = Math.Sqrt(tempx * tempx + tempy * tempy);

            return result;
        }

        /// <summary>
        /// Determina si la modificación de la velocidad de uno puede afectar directamente al otro, generando conflictos
        /// </summary>
        /// <param name="b">segundo avion</param>
        /// <returns>[distancia minima, interaccionan(0 o 1)]</returns>
        public double[]
        Interaction(FlightPlan b, double distanciaSeguridad, bool clamp = true)
        {
            double[,] data = new double[3, 2];
            data = this.ShortestDistanceBetweenPaths(b, clamp);

            //bool defined = true;
            //try
            //{
            //    double[] p0 = new double[2];
            //    p0[0] = data[0, 0];
            //    p0[1] = data[0, 1];
            //    double[] p1 = new double[2];
            //    p1[0] = data[1, 0];
            //    p1[1] = data[1, 1];
            //}
            //catch (Exception ex)
            //{
            //    defined = false;
            //}
            double d = data[2, 0];
            double[] result = new double[2];
            result[0] = d;
            if (d <= distanciaSeguridad)
            {
                result[1] = 1;
            }
            else
            {
                result[1] = 0;
            }
            return result;
        }

        /// <summary>
        /// Determinal la distancia minima entre aviones en funcion de sus velocidades y si estos entran en conflicto.
        /// </summary>
        /// <param name="b">segundo avion</param>
        /// <param name="distanciaSeguridad">distancia de seguridad</param>
        /// <param name="minimumDistance2"> por defecto es -1 y implica que se quiere recalcular la misma</param>
        /// <returns>[distancia,conflicto]: conflicto es 0 o 1</returns>
        public double[]
        Conflicto(
            FlightPlan b,
            double distanciaSeguridad,
            double minimumDistance2 = -1
        )
        {
            if (minimumDistance2 < 0)
            {
                // preparamos las variables de este avion
                double vf = this.velocidad;
                double hipotenusaf = this.getDistanciaDestino();
                double cosenof =
                    (finalPosition.GetX() - currentPosition.GetX()) /
                    hipotenusaf;
                double senof =
                    (finalPosition.GetY() - currentPosition.GetY()) /
                    hipotenusaf;
                double vfx = vf * cosenof;
                double vfy = vf * senof;
                double vfx2 = vfx * vfx;
                double vfy2 = vfy * vfy;
                double xf0 = this.currentPosition.GetX();
                double yf0 = this.currentPosition.GetY();

                // preparamos las variables del avion b
                double vg = b.velocidad;
                double hipotenusag = b.getDistanciaDestino();
                double cosenog =
                    (b.finalPosition.GetX() - b.currentPosition.GetX()) /
                    hipotenusag;
                double senog =
                    (b.finalPosition.GetY() - b.currentPosition.GetY()) /
                    hipotenusag;
                double vgx = vg * cosenog;
                double vgy = vg * senog;
                double vgx2 = vgx * vgx;
                double vgy2 = vgy * vgy;
                double xg0 = b.currentPosition.GetX();
                double yg0 = b.currentPosition.GetY();

                // Parte paralela al eje x
                double fracX1 =
                    (
                    vfx *
                    (
                    -vfx * xf0 +
                    vfx * xg0 -
                    vfy * yf0 +
                    vfy * yg0 +
                    vgx * xf0 -
                    vgx * xg0 +
                    vgy * yf0 -
                    vgy * yg0
                    ) /
                    (vfx2 - 2 * vfx * vgx + vfy2 - 2 * vfy * vgy + vgx2 + vgy2)
                    );
                double fracX2 =
                    (
                    vgx *
                    (
                    -vfx * xf0 +
                    vfx * xg0 -
                    vfy * yf0 +
                    vfy * yg0 +
                    vgx * xf0 -
                    vgx * xg0 +
                    vgy * yf0 -
                    vgy * yg0
                    ) /
                    (vfx2 - 2 * vfx * vgx + vfy2 - 2 * vfy * vgy + vgx2 + vgy2)
                    );
                double xSide2 =
                    (fracX1 - fracX2 + xf0 - xg0) *
                    (fracX1 - fracX2 + xf0 - xg0);

                // Parte paralela al eje y
                double fracY1 =
                    (
                    vfy *
                    (
                    -vfx * xf0 +
                    vfx * xg0 -
                    vfy * yf0 +
                    vfy * yg0 +
                    vgx * xf0 -
                    vgx * xg0 +
                    vgy * yf0 -
                    vgy * yg0
                    ) /
                    (vfx2 - 2 * vfx * vgx + vfy2 - 2 * vfy * vgy + vgx2 + vgy2)
                    );

                double fracY2 =
                    (
                    vgy *
                    (
                    -vfy * xf0 +
                    vfx * xg0 -
                    vfy * yf0 +
                    vfy * yg0 +
                    vgx * xf0 -
                    vgx * xg0 +
                    vgy * yf0 -
                    vgy * yg0
                    ) /
                    (vfx2 - 2 * vfx * vgx + vfy2 - 2 * vfy * vgy + vgx2 + vgy2)
                    );
                double ySide2 =
                    (fracY1 - fracY2 + yf0 - yg0) *
                    (fracY1 - fracY2 + yf0 - yg0);

                // distancia minima ^2
                minimumDistance2 = xSide2 + ySide2;
            }

            // si la distancia minima ^2 es menor o igual a la distancia de seguridad, se produce un conflicto y devulve true
            double[] result = new double[2];
            result[0] = minimumDistance2;
            if (minimumDistance2 <= (distanciaSeguridad * distanciaSeguridad))
            {
                result[1] = 1;
            }
            else
            {
                result[1] = 0;
            }
            return result;
        }

        // METODOS
        /// <summary>
        /// Desplaza el avion durante un tiempo dado
        /// </summary>
        /// <param name="tiempo">numero de segundos</param>
        public void Mover(double tiempo)
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa =
                Math
                    .Sqrt((finalPosition.GetX() - currentPosition.GetX()) *
                    (finalPosition.GetX() - currentPosition.GetX()) +
                    (finalPosition.GetY() - currentPosition.GetY()) *
                    (finalPosition.GetY() - currentPosition.GetY()));
            double coseno =
                (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno =
                (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            Position nextPosition = new Position(x, y);
            if (this.currentPosition.Distancia(nextPosition) < hipotenusa)
            {
                this.currentPosition = nextPosition;
            }
            else
            {
                this.currentPosition = this.finalPosition;
            }
        }

        /// <summary>
        /// Reinicia las posiciones de los aviones
        /// </summary>
        public void Restart()
        {
            this.currentPosition = this.initialPosition;
        }

        /// <summary>
        /// Generates a deep copy of the fligth plan
        /// </summary>
        /// <returns>a copy of the fligth plan</returns>
        public FlightPlan Copy()
        {
            FlightPlan copy =
                new FlightPlan(this.id,
                    this.initialPosition.GetX(),
                    this.initialPosition.GetY(),
                    this.currentPosition.GetX(),
                    this.currentPosition.GetY(),
                    this.finalPosition.GetX(),
                    this.currentPosition.GetY(),
                    this.velocidad);
            return copy;
        }

        /// <summary>
        /// Generates a string of the data in the fligth plan
        /// </summary>
        /// <returns>a string of the fligth plan</returns>
        public string DumpString()
        {
            string dump =
                string
                    .Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                    this.id,
                    this.initialPosition.GetX(),
                    this.initialPosition.GetY(),
                    this.currentPosition.GetX(),
                    this.currentPosition.GetY(),
                    this.finalPosition.GetX(),
                    this.currentPosition.GetY(),
                    this.velocidad);
            return dump;
        }

        public static FlightPlan LoadString(string s)
        {
            string[] data = s.Split(',');
            FlightPlan plan =
                new FlightPlan(data[0],
                    Convert.ToDouble(data[1]),
                    Convert.ToDouble(data[2]),
                    Convert.ToDouble(data[3]),
                    Convert.ToDouble(data[4]),
                    Convert.ToDouble(data[5]),
                    Convert.ToDouble(data[6]),);
            return plan;
        }

        // CONSOLE
        /// <summary>
        /// Escribe los datos del FligthPlan por consola
        /// </summary>
        public void EscribeConsola() // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console
                .WriteLine("Posición actual: ({0:F2};{1:F2})",
                currentPosition.GetX(),
                currentPosition.GetY());
            if (this.EstaDestino())
            {
                Console.WriteLine("Ha llegado a su destino");
            }
            else
            {
                Console.WriteLine("No ha llegado a su destino");
            }
            Console.WriteLine("******************************");
        }
    }
}
