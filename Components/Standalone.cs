using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


// using SharpGL.SceneGraph;
// using SharpGL.SceneGraph.Primitives;
// using SharpGL.SceneGraph.Quadrics;
// using SharpGL.SceneGraph.Assets;

using ZGE.Components;

namespace ZGE
{
    [HideComponent]
    public class Standalone : GameWindow
    {
        ZApplication app;
        MouseDescriptor md = new MouseDescriptor();

        //const float rotation_speed = 180.0f;
        //float angle;
        //Scene scene = new Scene();
        //Cube cube;
        //Texture texture = new Texture();

        /// <summary>Creates a 800x600 window with the specified title.</summary>
        public Standalone(ZApplication _app)
            : base(_app.Width, _app.Height, _app.Mode, _app.Title)
        {
            app = _app;
            app.frame = this;
            VSync = app.VSync;
            this.Title = app.Title;

            Keyboard.KeyDown += Keyboard_KeyDown;
            Keyboard.KeyUp += Keyboard_KeyUp;
            Mouse.ButtonDown += Mouse_ButtonDown;
            Mouse.ButtonUp += Mouse_ButtonUp;
            Mouse.Move += Mouse_Move;
            Mouse.WheelChanged += Mouse_WheelChanged;
        }

        void Mouse_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            md.X = e.X; md.Y = e.Y;
            md[e.Button] = true;
            md.Button = e.Button;
            app.MouseDown(sender, md);
        }
        void Mouse_ButtonUp(object sender, MouseButtonEventArgs e)
        {
            md.X = e.X; md.Y = e.Y;
            md[e.Button] = false;
            md.Button = e.Button;
            app.MouseUp(sender, md);
        }
        void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            md.X = e.X; md.Y = e.Y;            
            app.MouseMove(sender, md);
        }
        void Mouse_WheelChanged(object sender, MouseWheelEventArgs e)
        {
            md.X = e.X; md.Y = e.Y;
            md.WheelDelta = e.Delta * 120;            
            app.MouseWheel(sender, md);
        }        

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            app.KeyDown(sender, e);
            //if (Keyboard[Key.Escape])  Exit();
        }

        void Keyboard_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            app.KeyUp(sender, e); 
        }

        /// <summary>Load resources here.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            app.Load();                   
        }

        /// <summary>
        /// Called when your window is resized. Set your viewport here. It is also
        /// a good place to set up your projection matrix (which probably changes
        /// along when the aspect ratio of your window).
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            app.Resize(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);            
        }

        /// <summary>
        /// Called when it is time to setup the next frame. Add you game logic here.
        /// </summary>
        /// <param name="e">Contains timing information for framerate independent logic.</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            app.Update();            
        }

        /// <summary>
        /// Called when it is time to render the next frame. Add your rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {              
            base.OnRenderFrame(e);

            app.Render();
            //this.Title = "FPS: " + app.FpsCounter.ToString("0.") + " / " + (1 / e.Time).ToString("0.");
            SwapBuffers();            
        }        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /*[STAThread]
        static void Main()
        {
            // The 'using' idiom guarantees proper resource cleanup.
            // We request 30 UpdateFrame events per second, and unlimited
            // RenderFrame events (as fast as the computer can handle).
            using (Standalone game = new Standalone(new ZApplication()))
            {
                game.Run(30.0);
            }
        }*/
    }
}
