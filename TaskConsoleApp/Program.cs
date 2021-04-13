using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    public class Status
    {
        public int threadId { get; set; }
        public DateTime date { get; set; }
    }

    internal class Program
    {
        private async static Task Main(string[] args)
        {
            var myTask = Task.Factory.StartNew((Obj) =>
            {
                Console.WriteLine("myTask calisti.");
                var status = Obj as Status; // status'e cevir, ceviremezsen null donder. 

                status.threadId = Thread.CurrentThread.ManagedThreadId;
                status.date = DateTime.Now;

            }, new Status());

            await myTask;

            Status s = myTask.AsyncState as Status;

            Console.WriteLine(s.date);
            Console.WriteLine(s.threadId);
           
        }    
    }
}