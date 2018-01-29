using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTechGit
{
    public class Program
    {
        public const string ExitCommandConst = "Exit";

        public static void Main(string[] args)
        {
            var rover = new Rover();
            string command = null;
            var index = 0;
            while (true)
            {
                try
                {
                    if (args.Length > 0 )
                    {
                        command = args.ToArray()[index];
                        index++;
                    }
                    else
                    {
                        command = Console.ReadLine();
                    }
                    if(command == ExitCommandConst)
                        break;
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

