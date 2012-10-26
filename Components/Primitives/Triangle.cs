using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace ZGE.Components
{
    public class Triangle
    {
        public float Scale { get; set; }
        
        public void Render()
        {            
            GL.Begin(BeginMode.TRIANGLES);
            GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex3(-1.0f, -1.0f, 0.0f);
            GL.Color3(1.0f, 0.0f, 0.0f); GL.Vertex3(1.0f, -1.0f, 0.0f);
            GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.End();
        }
    }
}
