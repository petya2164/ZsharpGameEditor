using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenTK;
//using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using Gwen.Control;
using Gwen.Input;

namespace ZGE.Components
{

    public class GwenExample: ZContent   
    {
//         private Gwen.Input.OpenTKInput input;
//         private Gwen.Renderer.OpenTKRenderer renderer;
//         private Gwen.Skin.Base skin;
//         private Gwen.Control.Canvas canvas;
        private Gwen.UnitTest.UnitTest test;
        
        
        private bool altDown = false;

        public GwenExample(ZComponent parent): base(parent)
        {
                       
        }

//         GwenExample()  // originally Dispose
//         {
//             if (canvas != null) canvas.Dispose();
//             if (skin != null) skin.Dispose();
//             if (renderer != null) renderer.Dispose();            
//         }

        /// <summary>
        /// Occurs when a key is pressed.
        /// </summary>
        /// <param name="sender">The KeyboardDevice which generated this event.</param>
        /// <param name="e">The key that was pressed.</param>
//         void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
//         {
//             /*if (e.Key == global::OpenTK.Input.Key.Escape)
//                 Exit();
//             else if (e.Key == global::OpenTK.Input.Key.AltLeft)
//                 altDown = true;
//             else if (altDown && e.Key == global::OpenTK.Input.Key.Enter)
//                 if (WindowState == WindowState.Fullscreen)
//                     WindowState = WindowState.Normal;
//                 else
//                     WindowState = WindowState.Fullscreen;*/
// 
//             input.ProcessKeyDown(e);
//         }
// 
//         void Keyboard_KeyUp(object sender, KeyboardKeyEventArgs e)
//         {
//             altDown = false;
//             input.ProcessKeyUp(e);
//         }
// 
//         void Mouse_ButtonDown(object sender, MouseButtonEventArgs args)
//         {
//             input.ProcessMouseMessage(args);
//         }
// 
//         void Mouse_ButtonUp(object sender, MouseButtonEventArgs args)
//         {
//             input.ProcessMouseMessage(args);
//         }
// 
//         void Mouse_Move(object sender, MouseMoveEventArgs args)
//         {
//             input.ProcessMouseMessage(args);
//         }
// 
//         void Mouse_Wheel(object sender, MouseWheelEventArgs args)
//         {
//             input.ProcessMouseMessage(args);
//         }

        public override void RefreshFromProducers()
        {
            if (App.Canvas != null)
            {
                test = new Gwen.UnitTest.UnitTest(App.Canvas);
            }
            

//             Keyboard.KeyDown += Keyboard_KeyDown;
//             Keyboard.KeyUp += Keyboard_KeyUp;
// 
//             Mouse.ButtonDown += Mouse_ButtonDown;
//             Mouse.ButtonUp += Mouse_ButtonUp;
//             Mouse.Move += Mouse_Move;
//             Mouse.WheelChanged += Mouse_Wheel;            
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        public void ResizeCanvas(int x, int y, int width, int height)
        {
//             GL.Viewport(0, 0, Width, Height);
//             GL.MatrixMode(MatrixMode.PROJECTION);
//             GL.LoadIdentity();
//             GL.Ortho(0, Width, Height, 0, -1, 1);
// 
            //canvas.SetSize(width, height);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected void OnUpdateFrame(FrameEventArgs e)
        {
//             if (ftime.Count == fps_frames)
//                 ftime.RemoveAt(0);
// 
//             ftime.Add(stopwatch.ElapsedMilliseconds - lastTime);
//             lastTime = stopwatch.ElapsedMilliseconds;
// 
//             if (stopwatch.ElapsedMilliseconds > 1000)
//             {
//                 test.Note = String.Format("String Cache size: {0} Draw Calls: {1} Vertex Count: {2}", renderer.TextCacheSize, renderer.DrawCallCount, renderer.VertexCount);
//                 test.Fps = 1000f * ftime.Count / ftime.Sum();
//                 stopwatch.Stop();
//                 stopwatch.Start();
// 
//                 if (renderer.TextCacheSize > 1000) // each cached string is an allocated texture, flush the cache once in a while in your real project
//                     renderer.FlushTextCache();
//             }
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        public void RenderCanvas()
        {
            //GL.Clear(ClearBufferMask.DEPTH_BUFFER_BIT | ClearBufferMask.COLOR_BUFFER_BIT);
            

            //SwapBuffers();
        }        
    }
}
