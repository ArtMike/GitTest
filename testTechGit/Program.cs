using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTechGit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rover = new Rover();
            string command = null;
            while (command  != "Exit")
            {
                try
                {
                    command = Console.ReadLine();
                    rover.Execute(command);
                    Console.WriteLine(rover);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}

