using PLINQApp.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace PLINQApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorks2017Context context = new AdventureWorks2017Context();
            context.Products.Take(10).ToList().ForEach(x => // 10 tanesini al
           {
               Console.WriteLine(x.Name);
           });
        }
    }
}
