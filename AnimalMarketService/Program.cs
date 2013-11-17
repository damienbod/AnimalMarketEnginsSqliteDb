using System;
using System.ServiceProcess;
using Unity.SelfHostWebApiOwin;

namespace AnimalMarketService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //ServiceBase.Run(new AnimalMarketWindowsService());

            if (args != null)
            {
                try
                {
                    Startup.StartServer();
                    Console.WriteLine("Started...");

                    Console.ReadKey();
                }
                finally
                {
                    Startup.StopServer();
                }
            }
        }
    }
}
