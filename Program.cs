using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mars_Rover_Assessment
{
    internal class Program
    {
        public static Coordinates Coords = new Coordinates();

        static void Main(string[] args)
        {
            AskUpperRight();
        }

        private static void AskUpperRight()
        {
            Console.WriteLine("Insert upper right coordinates of plateau:");
            string UpperRight = Console.ReadLine();
            CheckUpperRight(UpperRight);
        }

        private static void CheckUpperRight(string UpperRight)
        {
            //checks that input is in the form number,space,number
            if (Regex.IsMatch(UpperRight, @"^\d+\s\d+$"))
            {
                Coords.SetMax(UpperRight);
                Coords.InitialiseGrid();
                AskStartPoint();
            }
            else
            {
                Console.WriteLine("Invalid format.");
                AskUpperRight();
            }
        }

        private static void AskStartPoint()
        {
            Console.WriteLine();
            Console.WriteLine("Insert rover start point and heading:");
            string StartPoint = Console.ReadLine();
            CheckStartPoint(StartPoint);
        }

        private static void CheckStartPoint(string StartPoint)
        {
            //checks that input is in the form number,space,number,space,capital letter
            if (Regex.IsMatch(StartPoint, @"^\d+\s\d+\s[NSEW]$"))
            {
                Coords.SetStart(StartPoint);
                if (Coords.GetCurrentX() > Coords.GetMaxX() || Coords.GetCurrentY() > Coords.GetMaxY())
                {
                    Console.WriteLine("Starting position is not within the bounds of the plateau.");
                    AskStartPoint();
                }
                else
                {
                    AskMovement();
                    
                }
            }
            else
            {
                Console.WriteLine("Invalid format.");
                AskStartPoint();
            }
        }

        private static void AskMovement()
        {
            Console.WriteLine();
            Console.WriteLine("Insert movement commands:");
            string Movement = Console.ReadLine();
            CheckMovement(Movement);
        }

        private static void CheckMovement(string Movement)
        {
            //should only contain the characters 'L', 'M' and 'R'
            if (Regex.IsMatch(Movement, @"^[LMR]+$"))
            {
                Coords.SetMovement(Movement);
            }
            else
            {
                Console.WriteLine("Invalid format.");
                AskMovement();
            }

            foreach (char c in Coords.GetMovement())
            {
                if (c == 'L')
                {
                    Coords.CalculateLeft(Coords.GetCurrentDirection());
                }
                else if (c == 'R')
                {
                    Coords.CalculateRight(Coords.GetCurrentDirection());
                }
                else if (c == 'M')
                {
                    char direction = Coords.GetCurrentDirection();
                    int x = Coords.GetCurrentX();
                    int y = Coords.GetCurrentY();
                    //adds coordinate to an array to display later
                    SetVisited(x, y);
                    if (direction == 'N')
                    {
                        if (Coords.GetMaxY() >= y + 1)
                        {
                            //moves 1 unit upwards
                            Coords.SetCurrentY(y + 1);
                        }
                    }
                    else if (direction == 'S')
                    {
                        if (0 <= y - 1)
                        {
                            //moves 1 unit downwards
                            Coords.SetCurrentY(y - 1);
                        }
                    }
                    else if (direction == 'E')
                    {
                        if (Coords.GetMaxX() >= x + 1)
                        {
                            //moves 1 unit to the right
                            Coords.SetCurrentX(x + 1);
                        }
                    }
                    else if (direction == 'W')
                    {
                        if (0 <= x - 1)
                        {
                            //moves 1 unit to the right
                            Coords.SetCurrentX(x - 1);
                        }
                    }

                }
            }
            Console.WriteLine();
            //outputs final coordinates and direction
            Console.Write("Final Coordinates: "+Coords.GetCurrentX());
            Console.Write(Coords.GetCurrentY());
            Console.Write(Coords.GetCurrentDirection());
            //adds final coordinate to array of visited coordinates
            SetVisited(Coords.GetCurrentX(),Coords.GetCurrentY());
            Console.WriteLine();
            //displays visited coordinates
            Coords.DisplayVisited();
            //displays grid visualising visited coordinates
            Coords.DisplayGrid();
            //asks if there are more rovers
            MoreRovers();
        }

        public static void SetVisited(int X, int Y)
        {
            List<Tuple<int, int>> Visited = Coords.GetVisited();
            //adds visited coordinates to a list of tuples
            Visited.Add(new Tuple<int, int>(X, Y));
            char[,] Grid = Coords.GetGrid();
            //flips y coordinate so bottom right coordinate is (0, 0)
            int FlipY = Coords.GetMaxY() - Y;
            Grid[FlipY, X] = 'X';
        }

        private static void MoreRovers()
        {
            Console.WriteLine();
            Console.WriteLine("Any more rovers? yes(1) or no(2)");
            int more = int.Parse(Console.ReadLine());
            if (more == 1)
            {
                AskStartPoint();
            }
            else if (more == 2)
            {
                
            }
            else
            {
                Console.WriteLine("Invalid format.");
                MoreRovers();
            }
        }
    }
}
