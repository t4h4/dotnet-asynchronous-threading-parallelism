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

            var product = (from p in context.Products.AsParallel().AsOrdered() // karisik degil, veritabani sirasinda verir. ama sonrasinda for each kullanmak daha mantikli.
                           where p.ListPrice > 10M
                           select p).Take(10);
            product.ForAll(x =>
           {
               Console.WriteLine(x.Name);
           });
        }
    }
}
