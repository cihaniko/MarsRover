using MarsRover.Models;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Point sizeRectangle = new Point { X = 5, Y = 5 };

            MarsRover mr = new MarsRover(sizeRectangle);

            Location rover1 = new Location()
            {
                X = 1,
                Y = 2,
                Direction = "N"
            };
            mr.RoboticRoversDirection(rover1, "LMLMLMLMM");

            Location rover2 = new Location()
            {
                X = 3,
                Y = 3,
                Direction = "E"
            };
            mr.RoboticRoversDirection(rover2, "MMRMMRMRRM");


            Console.ReadKey();
        }
    }
}
