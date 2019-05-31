using System;
using System.Net;
using System.Net.Sockets;

using System.Diagnostics;

using LG.Royale.Hype;
using LG.Royale.Interface;

namespace LG.Royale.Network
{
    class Gateway
    {

        /// <summary>
        /// Gateway's sockets.
        /// </summary>
        public static Socket Server, Client;

        /// <summary>
        /// Listens on the specified address.
        /// </summary>
        /// <param name="Config"></param>
        public static void Start(Configuration Configuration)
        {
            Display.Load();

            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(new IPEndPoint(Configuration.IPAddress, Configuration.Port));
            Server.Listen(Configuration.MaxPeople);

            while (true)
            {
                Client = Server.Accept();
                break;
            }

            Display.Log("Client has connected.");
            Protocol.Follow();
        }

        /// <summary>
        /// Receives a packet.
        /// </summary>
        public static byte[] Receive()
        {
            byte[] Empty  = new byte[2048];
            byte[] Filled = Packet.Fill(Empty, Client.Receive(Empty));
            Debug.WriteLine("[+] Client: " + Packet.GetIdentifier(Filled));

            return Filled;
        }

        /// <summary>
        /// Sends a specified packet.
        /// </summary>
        public static int Send(byte[] Packet)
        {
            Client.Send(Packet);
            Debug.WriteLine("[+] Server: " + Hype.Packet.GetIdentifier(Packet));

            return Hype.Packet.GetIdentifier(Packet);
        }
    }
}
