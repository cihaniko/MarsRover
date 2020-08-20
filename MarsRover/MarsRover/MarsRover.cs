using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class MarsRover
    {
        Models.Point _sizeRectangle;
        string[] _compass;
        LinkedList<string> _compassPoints;

        public MarsRover(Models.Point sizeRectangle)
        {
            _sizeRectangle = sizeRectangle;
            _compass = new string[] { "N", "E", "S", "W" };
            _compassPoints = new LinkedList<string>(_compass);
        }


        public void RoboticRoversDirection(Location location, string roadMap)
        {
            for (int i = 0; i < roadMap.Length; i++)
            {
                location = CalculateLocation(location, roadMap.Substring(i, 1));
            }

            Console.WriteLine($"Robotic Rover Last Location : {location.X} {location.Y} {location.Direction} ");
        }
        /// <summary>
        /// Calculate Location method.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Location CalculateLocation(Location location, string direction)
        {
            switch (direction)
            {
                case "L":
                    location.Direction = _compassPoints.Find(location.Direction).Previous == null ? _compassPoints.Last.Value : _compassPoints.Find(location.Direction).Previous.Value;
                    return location;
                case "R":
                    location.Direction = _compassPoints.Find(location.Direction).Next == null ? _compassPoints.First.Value : _compassPoints.Find(location.Direction).Next.Value;
                    return location;
                case "M":
                    return CalculatePoint(location);
                default:
                    return location;
            }

        }

        /// <summary>
        /// Calculated Point coordinates.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Location CalculatePoint(Location location)
        {
            switch (location.Direction)
            {
                case "N":
                    location.Y += 1;
                    break;
                case "E":
                    location.X += 1;
                    break;
                case "S":
                    location.Y -= 1;
                    break;
                case "W":
                    location.X -= 1;
                    break;
                default:
                    break;
            }

            //Belirlenen bölgenin dışında kalıyor mu ?
            if ((location.X > _sizeRectangle.X || location.X < 0) || (location.Y > _sizeRectangle.Y || location.Y < 0))
            {
                Console.WriteLine("Belirlenen bölgenin dışına çıkamazsınız");
                throw new Exception("Out of range area.");
            }

            return location;
        }

    }
}
