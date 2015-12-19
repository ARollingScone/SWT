using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;

namespace SWT.Game.Network
{
    public class GameClient : GameNetworkBase
    {
        public IPEndPoint Host; 

        public bool Connect(string ipadress, string port)
        {
            var result = false;

            try
            {
                var iPort = 0;
                var ip = IPAddress.Parse(ipadress);

                if (Int32.TryParse(port, out iPort))
                {
                    Local = new IPEndPoint(IPAddress.Any, iPort);
                    Host = new IPEndPoint(ip, iPort);

                    Client.Connect(Host);
                    result = true;
                }

                return result;
            }
            catch
            {
                return result;
            }            
        }

        
    }
}
