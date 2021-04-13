using System;
using System.Net.Http;

namespace TaskResultConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetData());
        }

        public static string GetData()
        {
            var task = new HttpClient().GetStringAsync("http://www.google.com");

            return task.Result;
        }
    }
}
