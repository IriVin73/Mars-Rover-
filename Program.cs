using System;
using System.Collections.Generic;
using System.Linq;
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
                AskMovement();
            }
            else
            {
                Console.WriteLine("Invalid format.");
                AskStartPoint();
            }
        }

        private static void AskMovement()
        {
            Console.WriteLine("Insert movement commands:");
            string Movement = Console.ReadLine();
            CheckMovement(Movement);
        }

        private static void CheckMovement(string Movement)
        {
            if(Regex.IsMatch(Movement, @"^[LMR]+$"))
            {
                Coords.SetMovement(Movement);
            }
            else
            {
                Console.WriteLine("Invalid format.");
                AskMovement();
            }
        }
    }
}
