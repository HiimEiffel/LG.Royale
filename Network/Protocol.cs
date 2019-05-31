using System;

using LG.Royale.Hype;
using LG.Royale.Packets;

namespace LG.Royale.Network
{
    class Protocol
    {

        /// <summary>
        /// Protocol's decrypter.
        /// </summary>
        public static Encrypter Encrypter = new Encrypter();

        /// <summary>
        /// Follows the protocol.
        /// </summary>
        public static void Follow()
        {
            Encrypter Decrypter = new Encrypter();

            while (true)
            {
                byte[] Packet  = Encrypter.Process(Gateway.Receive(), Decrypter);
                int Identifier = Hype.Packet.GetIdentifier(Packet);

                if (Identifier == Login.Identifier)
                {
                    new Login();
                }

                if (Identifier == KeepAlive.Identifier)
                {
                    new KeepAlive();
                }

                if (Identifier == RequestNewName.Identifier)
                {
                    new RequestNewName(Packet);
                }

                if (Identifier == EndClientTurn.Identifier)
                {
                    new EndClientTurn(Packet);
                }

                if (Identifier == 14104)
                {
                    Console.WriteLine(BitConverter.ToString(Packet));
                }
            }
        }
    }
}
