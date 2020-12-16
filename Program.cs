using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace oop_15
{
    class Program
    {
        static void Even()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i * 2);
                Thread.Sleep(10);  
            }
        }

        static void Odd()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i * 2 - 1);
            }
        }


        static AutoResetEvent AutoReset1 = new AutoResetEvent(true), AutoReset2 = new AutoResetEvent(true);
        public static void EvenAutoReset()
        {
            for (int i = 0; i < 10; i++)
            {
                AutoReset2.WaitOne();
                Console.WriteLine(i * 2);
                Thread.Sleep(10);
                AutoReset1.Set();
            }

        }
        public static void OddAutoReset()
        {
            for (int i = 1; i <= 10; i++)
            {
                AutoReset1.WaitOne();
                Console.WriteLine(i * 2 - 1);
                Thread.Sleep(100);
                AutoReset2.Set();
            }
        }


        static void Main(string[] args)
        {
            /*foreach (Process process in Process.GetProcesses())
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
*/
            ///

            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"ID: {domain.Id}");
            Console.WriteLine($"Application Name: {domain.SetupInformation.ApplicationName}");
            Console.WriteLine($"Application Base: {domain.SetupInformation.ApplicationBase}");
            Console.WriteLine($"Configuration File: {domain.SetupInformation.ConfigurationFile}");
            foreach (Assembly assembly in domain.GetAssemblies())
                Console.WriteLine(assembly.GetName());
            Console.WriteLine();

            ///

            AppDomain newDomain = AppDomain.CreateDomain("Kasperovich");
            newDomain.AssemblyLoad += (sender, e) => Console.WriteLine($"Сборка {e.LoadedAssembly.GetName().Name} загружена");
            newDomain.Load("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            
            foreach (Assembly assembly in newDomain.GetAssemblies())
                Console.WriteLine(assembly.GetName().Name);

            newDomain.DomainUnload += (sender, e) => Console.WriteLine($"Домен {((AppDomain)sender).FriendlyName} выгружен");
            AppDomain.Unload(newDomain);
            Console.WriteLine();

            /// 

            Thread thread = new Thread(() => { for (int i = 1; i <= 10; i++) { Console.WriteLine(i); } }  );
            Console.WriteLine($"ID: {thread.ManagedThreadId}");
            Console.WriteLine($"Name: {thread.Name}");
            Console.WriteLine($"Proirity: {thread.Priority}");
            Console.WriteLine($"State: {thread.ThreadState}");
            thread.Start();
            thread.Suspend();
            Console.WriteLine($"State: {thread.ThreadState}");
            thread.Resume();
            Console.WriteLine($"State: {thread.ThreadState}");
            Thread.Sleep(100);
            Console.WriteLine($"State: {thread.ThreadState}");
            Console.WriteLine();

            /// 

            // вперемешку
            /*Thread even = new Thread(Even);
            Thread odd = new Thread(Odd);
            even.Start();
            odd.Start();
            Console.WriteLine();
            Console.WriteLine();*/

            /*   Thread even1 = new Thread(Even);
               Thread odd1 = new Thread(Odd);
               even1.Priority = ThreadPriority.Highest;
               odd1.Priority = ThreadPriority.Lowest;
               even1.Start();
               odd1.Start();

               Thread.Sleep(2200);
               Console.WriteLine();

               Thread OddThread2 = new Thread(Odd);
               Thread EvenThread2 = new Thread(Even);
               OddThread2.Start();
               OddThread2.Join();
               EvenThread2.Start();*/

            Thread evenAutoRThread = new Thread(EvenAutoReset);
            Thread oddAutoRThread = new Thread(OddAutoReset);
            oddAutoRThread.Start();
            evenAutoRThread.Start();

            /// 



            Console.ReadKey();
        }
    }
}
