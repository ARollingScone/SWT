using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SWT.Game.Network
{
    public class Packet
    {
        public Packet(IPEndPoint ipe, string data)
        {
            Sender = ipe;
            Message = data;
        }

        public IPEndPoint Sender;
        public string Message;
    }

    public class NetworkToken
    {
        public bool bListen = true;
    }

    public abstract class GameNetworkBase
    {
        protected UdpClient Client;
        protected IPEndPoint Local;
        protected NetworkToken ListenToken;

        protected GameNetworkBase()
        {
            Client = new UdpClient();
        }

        public virtual void Disconnect()
        {
            ListenToken.bListen = false;
        }
    }
}
