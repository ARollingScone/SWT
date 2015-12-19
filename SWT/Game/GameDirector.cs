using SFML.Graphics;
using SFML.Window;
using SWT.Game.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWT.Game
{
    public class GameDirector
    {
        public GameWindow GameWindow { get; private set; }

        public GameHost NetworkHost;
        public GameClient NetworkClient;

        public GameDirector(bool bIsHost, string ipaddress, string port)
        {
            // Setup as host or client seperately
            if(bIsHost)
            {
                // Host Network system
                NetworkHost = new GameHost(port);
            }
            else
            {
                // Client Network System
                NetworkClient = new GameClient();
                if (!NetworkClient.Connect(ipaddress, port))
                    Shutdown();
            }

            // All duplicated following setup here (aka input management)

            // Input Manager

            // Final Step create the window and start the render loop
            GameWindow = new GameWindow(this);
        }

        public void UpdateGameState()
        {

        }

        public void ClientUpdate()
        {

        }

        public void HostUpdate()
        {

        }

        public void Shutdown()
        {
            if(GameWindow != null)
                GameWindow.Shutdown();
        }
    }
}
