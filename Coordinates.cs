using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        private int[,] Visited;

        public Coordinates() { }

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

        public void SetVisited(int X, int Y)
        {
            Visited = new int[MaxX*MaxY, 2];
            Visited[Visited.Length, 0] = X;
            Visited[Visited.Length, 1] = Y;
        }

        public void DisplayVisited()
        {
            foreach (int X in Visited)
            {
                foreach (int Y in Visited)
                {
                    Console.WriteLine("({X}, {Y})");
                }
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