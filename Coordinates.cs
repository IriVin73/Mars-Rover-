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

        public Coordinates() 
        { 
            
        }

        public void SetMax(string UpperRight)
        {
            string[] tokens = UpperRight.Split(' ');
            MaxX = int.Parse(tokens[0]);
            MaxY = int.Parse(tokens[1]);
        }

        public void SetStart(string StartPoint)
        {
            string[] tokens = StartPoint.Split(' ');
            CurrentX = int.Parse(tokens[0]);
            CurrentY = int.Parse(tokens[1]);
            CurrentDirection = char.Parse(tokens[2]);
            Program.SetVisited(CurrentX, CurrentY);
        }

        public void SetMovement(string Movement)
        { this.Movement = Movement; }

        public string GetMovement()
        {
            return this.Movement;
        }

        public char GetCurrentDirection()
        {
            return this.CurrentDirection;
        }

        public int GetCurrentX()
        {
            return this.CurrentX;
        }
        public void SetCurrentX(int X)
        {
            this.CurrentX = X;
        }
        public int GetCurrentY()
        {
            return this.CurrentY;
        }
        public void SetCurrentY(int Y)
        {
            this.CurrentY = Y;
        }
        public int GetMaxX()
        {
            return this.MaxX;
        }
        public int GetMaxY()
        {
            return this.MaxY;
        }

        public List<Tuple<int,int>> GetVisited()
        {
            return this.Visited;
        }

        public void InitialiseGrid()
        {
            Visited = new List<Tuple<int, int>>();
            Grid = new char[MaxY+1, MaxX+1];
            for (int y = 0; y <= MaxY; y++)
            {
                for (int x = 0; x <= MaxX; x++)
                {
                    //unvisited
                    Grid[y, x] = '-';
                }
            }
        }

        public char[,] GetGrid()
        {
            return this.Grid;
        }

        public void DisplayVisited()
        {
            Console.WriteLine("Visited Coordinates:");
            foreach (var coordinate in Visited)
            {
                Console.WriteLine($"({coordinate.Item1}, {coordinate.Item2})");
            }
        }

        public void DisplayGrid()
        {
            Console.WriteLine("Grid:");
            for (int y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    Console.Write(Grid[y, x] + " ");
                }
                Console.WriteLine();
            }
        }


        public void CalculateLeft(char StartDirection)
        {
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