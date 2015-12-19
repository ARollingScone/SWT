using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWT.Game
{
    interface IGameNetwork
    {
        // Converts details of self into packet
        // Used for connections etc
        IGamePacket LocalInfo();

        void Send(object data, string ip, int port);
        void Recieve(object data);
    }

    interface IGamePacket
    {
        byte[] Serialize();
        object Deserialize();
    }
}
