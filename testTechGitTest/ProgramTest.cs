using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testTechGit;


namespace testTechGitTest
{
    [TestClass]
    public class ProgramTest
    {
        [ClassInitialize]
        public static void TestFixtureSetUp(TestContext context)
        {
            string assemblyCodeBase =
                System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            string dirName = Path.GetDirectoryName(assemblyCodeBase);

            if (dirName.StartsWith("file:\\"))
                dirName = dirName.Substring(6);

            Environment.CurrentDirectory = dirName;
        }

        private int StartConsoleApplication(string arguments)
        {
            var proc = new Process
            {
                StartInfo =
                {
                    FileName = "testTechGit.exe",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = Environment.CurrentDirectory
                }
            };


            proc.Start();
            proc.WaitForExit();

            Console.WriteLine(proc.StandardOutput.ReadToEnd());
            Console.Write(proc.StandardError.ReadToEnd());

            return proc.ExitCode;
        }

        [DataTestMethod]
        [DataRow("R Exit", RoverFacing.East, 1, 1)]
        public void Execute_command_right(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX,
            int expectedRroverPositionY)
        {
            var expectedConsoleOut =
                $"Rover is now at {expectedRoverPositionX}, {expectedRroverPositionY} - facing {expectedRoverFacing}";
            int consoleExitCode;
            using (var consoleOutput = new ConsoleOutput())
            {
                consoleExitCode = StartConsoleApplication(commands);
                Assert.AreEqual(0, consoleExitCode);
                Assert.AreEqual(expectedConsoleOut, consoleOutput.GetOuput().Replace("\r", string.Empty).Replace("\n", string.Empty));
            }
        }

        [DataTestMethod]
        [DataRow("L Exit", RoverFacing.West, 1, 1)]
        public void Execute_command_left(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX,
            int expectedRroverPositionY)
        {
            var expectedConsoleOut =
                $"Rover is now at {expectedRoverPositionX}, {expectedRroverPositionY} - facing {expectedRoverFacing}";
            int consoleExitCode;
            using (var consoleOutput = new ConsoleOutput())
            {
                consoleExitCode = StartConsoleApplication(commands);
                Assert.AreEqual(0, consoleExitCode);
                Assert.AreEqual(expectedConsoleOut, consoleOutput.GetOuput().Replace("\r", string.Empty).Replace("\n", string.Empty));
            }
        }

        [DataTestMethod]
        [DataRow("F Exit", RoverFacing.North, 0, 1)]
        public void Execute_command_forward(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX,
            int expectedRroverPositionY)
        {
            var expectedConsoleOut =
                $"Rover is now at {expectedRoverPositionX}, {expectedRroverPositionY} - facing {expectedRoverFacing}";
            int consoleExitCode;
            using (var consoleOutput = new ConsoleOutput())
            {
                consoleExitCode = StartConsoleApplication(commands);
                Assert.AreEqual(0, consoleExitCode);
                Assert.AreEqual(expectedConsoleOut, consoleOutput.GetOuput().Replace("\r", string.Empty).Replace("\n", string.Empty));
            }
        }

        [DataTestMethod]
        [DataRow("K Exit", RoverFacing.North, 0, 1)]
        public void Execute_invalid_command(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX,
            int expectedRroverPositionY)
        {
            var expectedConsoleOut = "Invalid Command";
            int consoleExitCode;
            using (var consoleOutput = new ConsoleOutput())
            {
                consoleExitCode = StartConsoleApplication(commands);
                Assert.AreEqual(0, consoleExitCode);
                Assert.AreEqual(expectedConsoleOut, consoleOutput.GetOuput().Replace("\r", string.Empty).Replace("\n", string.Empty));
            }
        }

        [DataTestMethod]
        [DataRow("Exit", RoverFacing.North, 0, 1)]
        public void Execute_Exit_command(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX,
            int expectedRroverPositionY)
        {
            var expectedConsoleOut = string.Empty;
            int consoleExitCode;
            using (var consoleOutput = new ConsoleOutput())
            {
                consoleExitCode = StartConsoleApplication(commands);
                Assert.AreEqual(0, consoleExitCode);
                Assert.AreEqual(expectedConsoleOut, consoleOutput.GetOuput().Replace("\r", string.Empty).Replace("\n", string.Empty));
            }
        }
    }


    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}