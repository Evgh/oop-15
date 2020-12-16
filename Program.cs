using System;
using System.Diagnostics;

namespace oop_15
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Process process in Process.GetProcesses())
            {

                try
                {
                    Console.WriteLine($"ID: {process.Id}");
                    Console.WriteLine($"Name: { process.ProcessName} ");
                    Console.WriteLine($"Physical memory usage: {process.WorkingSet64}");
                    Console.WriteLine($"Base priority: {process.BasePriority}");
                    Console.WriteLine($"Virtual memory size: {process.VirtualMemorySize64}");
                    Console.WriteLine($"Paged system memory size: {process.PagedSystemMemorySize64}");
                    Console.WriteLine($"Paged memory size: {process.PagedMemorySize64}");
                    Console.WriteLine($"Start Time: {process.StartTime}");
                    Console.WriteLine($"Priority class: {process.PriorityClass}");
                    Console.WriteLine($"User processor time: {process.UserProcessorTime}");
                    Console.WriteLine($"Privileged processor time: {process.PrivilegedProcessorTime}");
                    Console.WriteLine($"Total processor time: {process.TotalProcessorTime}");
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine();
                }

                
            }



            Console.ReadKey();
        }
    }
}
