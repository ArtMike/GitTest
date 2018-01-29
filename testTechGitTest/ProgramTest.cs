using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace testTechGitTest
{
    [TestClass]
    public class ProgramTest
    {
        TextWriter m_normalOutput;
        StringWriter m_testingConsole;
        StringBuilder m_testingSB;

        [TestInitialize]
        public void TestFixtureSetUp()
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

            // Initialize string builder to replace console
            m_testingSB = new StringBuilder();
            m_testingConsole = new StringWriter(m_testingSB);

            // swap normal output console with testing console - to reuse 
            // it later
            m_normalOutput = System.Console.Out;
            System.Console.SetOut(m_testingConsole);
        }

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

            // add arguments as whole string

            // use it to start from testing environment

            // redirect outputs to have it in testing console

            // set working directory

            // start and wait for exit
            proc.Start();
            Console.WriteLine("Exit");
            proc.WaitForExit();

            // get output to testing console.
            System.Console.WriteLine(proc.StandardOutput.ReadToEnd());
            System.Console.Write(proc.StandardError.ReadToEnd());

            // return exit code
            return proc.ExitCode;
        }

        [TestMethod]
        public void ShowCmdHelpIfNoArguments()
        {
            // Check exit is normal
            Assert.AreEqual(0, StartConsoleApplication("Exit"));

            // Check that help information shown correctly.
            Assert.IsTrue(m_testingSB.ToString().Contains(
                ""));
        }
        //[TestFixtureTearDown]
        //public void TestFixtureTearDown()
        //{
        //    // set normal output stream to the console
        //    System.Console.SetOut(m_normalOutput);
        //}

        //[SetUp]
        //public void SetUp()
        //{
        //    // clear string builder
        //    m_testingSB.Remove(0, m_testingSB.Length);
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    // Verbose output in console
        //    m_normalOutput.Write(m_testingSB.ToString());
        //}
    }
    
}
