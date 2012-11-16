using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using ZGE.Components;


namespace ZGE
{
    class Small: ZApplication
    {
        //Triangle tri;
        //public Shape cube;
        public Mesh mesh1;
        public Model model1;
        MeshSphere prod;
        
        public Small()
        {
            Title = "Small Game";
            //VSync = VSyncMode.On;           

            //tri = new Triangle();
            //cube = new Cube();
            mesh1 = new Mesh(null);
            prod = new MeshSphere(null);
            prod.ZSamples = 4;
            prod.RadialSamples = 10;
            mesh1.Producers.Add(prod);

            model1 = new Model(null);
            //model1.Position.X = -1.0f;
           // model1.OnRender.Add(new RenderSetColor(Color.Red));
           // model1.OnRender.Add(new RenderMesh(mesh1));

            var spawn1 = new SpawnModel(null);
            spawn1.Model = model1;
            spawn1.Position = new Vector3(-1, 0, 0);
            OnLoad.Add(spawn1);                        
        }        
        
        /*void Small_OnUpdate(FrameEventArgs e)
        {
            model1.Rotation.Y += 180.0f * (float)e.Time;
            model2.Rotation.Y -= 180.0f * (float) e.Time;
        }*/       

        /*void Small_OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (frame != null)
            {
                if (e.Key == Key.Escape)
                    frame.Exit();

                if (e.Key == Key.F11)
                    if (frame.WindowState == WindowState.Fullscreen)
                        frame.WindowState = WindowState.Normal;
                    else
                        frame.WindowState = WindowState.Fullscreen;

            }
        }*/      

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // The 'using' idiom guarantees proper resource cleanup.
            // We request 30 UpdateFrame events per second, and unlimited
            // RenderFrame events (as fast as the computer can handle).
            ZApplication app = new Small();
            using (Standalone game = new Standalone(app))
            {
                game.Run(app.UpdateFrequency);
            }
        }        
    }   
}
