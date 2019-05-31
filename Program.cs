using System;
using System.Net;
using System.Net.Sockets;

using LG.Royale.Network;


namespace LG.Royale
{
    class Program
    {

        /// <summary>
        /// Application's entry point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Gateway.Start(new Configuration(IPAddress.Any, 9339));
        }
    }
}
