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
            var index = 0;
            while (command != "Exit")
            {
                try
                {
                    if (!string.IsNullOrEmpty(args?.ToArray()[index]))
                    {
                        command = args.ToArray()[index];
                        index++;
                    }
                    else
                    {
                        command = Console.ReadLine();
                    }
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

