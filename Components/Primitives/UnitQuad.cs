using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTK;
using System.Runtime.InteropServices;

namespace ZGE.Components
{
    public class UnitQuad : Shape
    {
        public UnitQuad()
        {
            Vertices = new Vector3[]
            {
                new Vector3(-0.5f, -0.5f,  0.0f),
                new Vector3( 0.5f, -0.5f,  0.0f),
                new Vector3( 0.5f,  0.5f,  0.0f),
                new Vector3(-0.5f,  0.5f,  0.0f),                
            };

            Indices = new int[]
            {
                // CCW direction to get a front-facing polygon
                0, 1, 2, 0, 2, 3,                
            };

            Normals = new Vector3[]
            {
                new Vector3(0.0f, 0.0f,  1.0f),
                new Vector3(0.0f, 0.0f,  1.0f),
                new Vector3(0.0f, 0.0f,  1.0f),
                new Vector3(0.0f, 0.0f,  1.0f),                
            };            

            Texcoords = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1),                
            };
        }
    }
}