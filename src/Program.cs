﻿using System;

namespace PortForwarder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var flag = false;
            int result1;
            int result2;
            if (args.Length == 3 && int.TryParse(args[0], out result1) && int.TryParse(args[2], out result2))
            {
                flag = true;
                var targetHost = args[1];
                new TcpPortForwarder(result1, result2, targetHost).Start();
                Console.WriteLine("Forwarding local port {0} to {1}:{2}", result1, targetHost, result2);
                Console.WriteLine("Press enter to terminate.");
                Console.ReadLine();
                Console.WriteLine("Terminated.");
            }

            if (flag)
                return;
            ShowUsage();
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Usage:   PortForwarder.exe LocalPort RemoteHost RemotePort");
            Console.WriteLine("Example: PortForwarder.exe 3390 192.168.15.7 3389");
        }
    }
}