using System;
using System.Collections.Generic;

namespace Mars_Rover_Assessment
{
    class Coordinates
    {
        private string Movement;
        private int MaxX;
        private int MaxY;
        private int CurrentX;
        private int CurrentY;
        private char CurrentDirection;
        private List<Tuple<int, int>> Visited;
        private char[,] Grid;

        public Coordinates() { }

        public void SetMax(string UpperRight)
        {
            //splits upper right coordinate into highest x and y values
            string[] tokens = UpperRight.Split(' ');
            MaxX = int.Parse(tokens[0]);
            MaxY = int.Parse(tokens[1]);
        }

        public void SetStart(string StartPoint)
        {
            //splits starting point into starting x-value, y-value and direction
            string[] tokens = StartPoint.Split(' ');
            CurrentX = int.Parse(tokens[0]);
            CurrentY = int.Parse(tokens[1]);
            CurrentDirection = char.Parse(tokens[2]);
        }

        public void SetMovement(string Movement)
        { this.Movement = Movement; }

        public string GetMovement()
        {return this.Movement;}

        public char GetCurrentDirection()
        {return this.CurrentDirection;}

        public int GetCurrentX()
        {return this.CurrentX;}

        public void SetCurrentX(int X)
        {this.CurrentX = X;}

        public int GetCurrentY()
        {return this.CurrentY;}

        public void SetCurrentY(int Y)
        {this.CurrentY = Y;}

        public int GetMaxX()
        {return this.MaxX;}

        public int GetMaxY()
        {return this.MaxY;}

        public List<Tuple<int,int>> GetVisited()
        {return this.Visited;}

        public void InitialiseGrid()
        {
            Visited = new List<Tuple<int, int>>();
            //ensures that the 0 column and row is included
            Grid = new char[MaxY+2, MaxX+2];
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    //unvisited
                    Grid[y, x] = '-';
                }
            }
        }

        public char[,] GetGrid()
        {return this.Grid;}

        public void DisplayVisited()
        {
            Console.WriteLine();
            Console.WriteLine("Visited Coordinates:");
            foreach (var coordinate in Visited)
            {
                Console.WriteLine($"({coordinate.Item1}, {coordinate.Item2})");
            }
        }

        public void DisplayGrid()
        {
            Console.WriteLine();
            Console.WriteLine("Grid:");
            for (int y = 0; y <= MaxY; y++)
            {
                for (int x = 0; x <= MaxX; x++)
                {
                    if (Grid[y, x] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (Grid[y, x] == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(Grid[y, x] + " ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }


        public void CalculateLeft(char StartDirection)
        {
            //chooses direction one left of the current one
            char[] Left = { 'N', 'W', 'S', 'E' };
            int CurrentIndex = Array.IndexOf(Left, StartDirection);
            //circular array
            if (CurrentIndex == 3)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex++;
            }
            CurrentDirection = Left[CurrentIndex];
        }

        public void CalculateRight(char StartDirection)
        {
            //chooses direction one right of the current one
            char[] Right = { 'N', 'E', 'S', 'W' };
            int CurrentIndex = Array.IndexOf(Right, StartDirection);
            if (CurrentIndex == 3)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex++;
            }
            CurrentDirection = Right[CurrentIndex];

        }
    }
}