using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWT.Game
{
    public class GameWindow
    {
        //Drawing / Rendering
        //protected TextureManager textureManager;
        protected RenderWindow renderWindow { get; private set; }
        protected View view { get; private set; }

        // Updating main control
        public GameDirector GameDirector { get; private set; }

        //Begin ren
        public GameWindow(GameDirector gameDirector)
        {
            GameDirector = gameDirector;

            renderWindow = new RenderWindow(new SFML.Window.VideoMode(800, 640), "SWT GAME WINDOW");
            renderWindow.SetActive(true);

            renderWindow.Closed += new EventHandler(Event_OnClose);
            renderWindow.Resized += new EventHandler<SizeEventArgs>(Event_OnResize);
            //renderWindow.KeyPressed += new EventHandler<KeyEventArgs>(Event_OnKeyPush);
            //renderWindow.KeyReleased += new EventHandler<KeyEventArgs>(Event_OnKeyPop);
            //renderWindow.LostFocus += new EventHandler(Event_OnLostFocus);

            view = new View(new FloatRect(0, 0, 800, 640));

            RenderLoop();
        }


        public virtual void Event_OnClose(object sender, EventArgs e)
        {
            renderWindow.Close();
            Environment.Exit(0);
        }

        public virtual void Event_OnResize(object sender, EventArgs e) { }

        public virtual void RenderLoop()
        {
            while (renderWindow.IsOpen)
            {               
                //Dispatch Events and Clear the screen
                renderWindow.DispatchEvents();
                renderWindow.Clear(Color.Black);

                //Adjust and Set the view
                //Adjust view to player location
                renderWindow.SetView(view);
                
                // Update
                GameDirector.UpdateGameState();

                // Draw

                //Draw frame on screen
                renderWindow.Display();
            }
        }

        public void Shutdown()
        {
            if(renderWindow != null)
                renderWindow.Close();
        }
    }
}
