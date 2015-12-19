using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;

namespace SWT.Game.Network
{
    public class ConnectedClient
    {
        public IPEndPoint ClientInfo;
        public string Username;
    }

    public class GameHost : GameNetworkBase
    {
        public List<Packet> Recieved;

        public List<ConnectedClient> Clients;
        public Thread ListenThread; 

        public GameHost(string port)
        {
            ListenToken = new NetworkToken();
            var iPort = 0;

            if(Int32.TryParse(port, out iPort))
            {
                Local = new IPEndPoint(IPAddress.Any, iPort);
                BeginListen();
            }            
        }

        public virtual void BeginListen()
        {
            ListenThread = new Thread(() => Listen(ListenToken));
            ListenThread.Start();
        }

        public void Listen(NetworkToken listenToken)
        {
            while(listenToken.bListen)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Listening");

                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, Local.Port);
                Byte[] receiveBytes = Client.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);

                Recieved.Add(new Packet(RemoteIpEndPoint, returnData));
            }

            Console.WriteLine("Disconnected");
        }
    }
}
