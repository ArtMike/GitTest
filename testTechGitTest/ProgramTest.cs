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
        static TextWriter m_normalOutput;
        static StringWriter m_testingConsole;
        static StringBuilder m_testingSB;

        [ClassInitialize]
        public static void TestFixtureSetUp(TestContext context)
        {
            // Set current folder to testing folder
            string assemblyCodeBase =
                System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            // Get directory name
            string dirName = Path.GetDirectoryName(assemblyCodeBase);

            // remove URL-prefix if it exists
            if (dirName.StartsWith("file:\\"))
                dirName = dirName.Substring(6);

            // set current folder
            Environment.CurrentDirectory = dirName;

            //// Initialize string builder to replace console
            //m_testingSB = new StringBuilder();
            //m_testingConsole = new StringWriter(m_testingSB);

            //// swap normal output console with testing console - to reuse 
            //// it later
            //m_normalOutput = System.Console.Out;
            //System.Console.SetOut(m_testingConsole);
        }
        //[ClassCleanup]
        //public static void TestFixtureTearDown()
        //{
        //    // set normal output stream to the console
        //    System.Console.SetOut(m_normalOutput);
        //}

        //[TestInitialize]
        //public void SetUp()
        //{
        //    // clear string builder
        //    m_testingSB.Remove(0, m_testingSB.Length);
        //}

        //[TestCleanup]
        //public void TearDown()
        //{
        //    // Verbose output in console
        //    m_normalOutput.Write(m_testingSB.ToString());
        //}

        private int StartConsoleApplication(string arguments)
        {
            // Initialize process here
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
            //Console.WriteLine("Exit");
            proc.WaitForExit();

            //get output to testing console.
            System.Console.WriteLine(proc.StandardOutput.ReadToEnd());
            System.Console.Write(proc.StandardError.ReadToEnd());

            // return exit code
            return proc.ExitCode;
        }

        [DataTestMethod]
        [DataRow("R Exit", RoverFacing.East, 1, 1)]
        [DataRow("R R Exit", RoverFacing.South, 1, 1)]
        [DataRow("R R R Exit", RoverFacing.West, 1, 1)]
        [DataRow("R R R R Exit", RoverFacing.North, 1, 1)]
        public void Execute_command_right(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX, int expectedRroverPositionY)
        {
            var expectedConsoleOut = $"Rover is now at {expectedRoverPositionX}, {expectedRroverPositionY} - facing {expectedRoverFacing}";
            int consoleExitCode;
            using (var consoleOutput = new ConsoleOutput())
            {
                consoleExitCode = StartConsoleApplication(commands);
                Assert.AreEqual(0, consoleExitCode);
                Assert.AreEqual(expectedConsoleOut, consoleOutput.GetOuput().TrimEnd('\r', '\n'));
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
