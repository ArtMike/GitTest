using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace nugetTest
{
    public class MyTestClasss
    {

        public void DownloadAsyncTask()
        {
            Console.WriteLine("Hello from packege");
            //HttpClient httpClient = new HttpClient();
            //await httpClient.GetStringAsync("Hi From Package");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

    }
}
