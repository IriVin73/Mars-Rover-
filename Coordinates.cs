using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Assessment
{
    class Coordinates
    {
        private string Movement;
        private int MaxX;
        private int MaxY;
        private int StartX;
        private int StartY;
        private char StartDirection;

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
            StartX = int.Parse(tokens[0]);
            StartY = int.Parse(tokens[1]);
            StartDirection = char.Parse(tokens[2]);
        }

        public void SetMovement(string Movement)
        { this.Movement = Movement; }
    }
}
