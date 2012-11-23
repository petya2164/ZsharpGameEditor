using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.ComponentModel;

namespace ZGE.Components
{
    [ToolboxItem(false)]
    public static class Renderer
    {
        public static bool isRendering = false;
        public static Mesh unitQuad;
        public static Font defaultFont;
        public static Material defaultMaterial;
        public static Material GUIMaterial;
        public static Texture defaultTexture;
        public static Material currentMaterial;

        public static void Init(ZApplication app)
        {
            defaultMaterial = new Material(null);
            GUIMaterial = new Material(null);
            GUIMaterial.Lighting = false;            
            defaultTexture = new Texture(null);
            defaultFont = new Font(null);

            GL.MatrixMode(All.MODELVIEW);
          
            GL.Enable(All.DEPTH_TEST);           

            //Enable Light
            //Use default position
            GL.Enable(All.LIGHTING);
            GL.Enable(All.LIGHT0);

            //Use glColor to color materials. 
            //This eliminates the need to set ambient and diffuse separately.
            GL.Enable(All.COLOR_MATERIAL);
            GL.ColorMaterial(All.FRONT_AND_BACK, All.AMBIENT_AND_DIFFUSE);

            //glMaterialfv(GL_FRONT, GL_SPECULAR, Specular);
            //glMaterialf(GL_FRONT, GL_SHININESS, LowShininess);         

            // IMPORTANT: Otherwise light will arise with scaled vectors, e.g. with Scale=0.1 then it will be too bright
            // This is because gl scales the normals with glScale
            //GL.Enable(All.NORMALIZE);

            var shape = new UnitQuad();
            unitQuad = new Mesh(null) { Name = "UnitQuad" };            
            unitQuad.CreateVBO(shape);

            defaultMaterial.Apply(null);            
        }

        public static void ApplyGUIMaterial(bool forced)
        {
            if (forced)
                GUIMaterial.Apply(null);
            else
                GUIMaterial.Apply(currentMaterial);
        }

        public static void ApplyDefaultMaterial(bool forced)
        {
            if (forced)
                defaultMaterial.Apply(null);
            else
                defaultMaterial.Apply(currentMaterial);
        }

//         public static void ApplyMaterial(Material newMat)
//         {
//             if (newMat != null) newMat.Apply(currentMaterial);
//         }        

        public static void Begin()
        {
            isRendering = true;

            //Designer may have messed with default settings, restore
            //Must reset runtime also otherwise mirror_repeat fails
            //Not sure why this is needed
            defaultMaterial.Apply(null);            
        }

        public static void End()
        {
            //defaultMaterial.Apply(currentMaterial);         

            isRendering = false;
        }
    }


//     public class RenderSprite : ZCommand
//     {
//         public RenderSprite(ZComponent parent): base(parent) { }
//         public override void Execute(ZComponent caller)
//         {
//             if (Renderer.unitQuad != null) Renderer.unitQuad.Render();
//         }
//     }
// 
//     public class RenderMesh : ZCommand
//     {
//         public Mesh Mesh;
// 
//         public RenderMesh(ZComponent parent) : base(parent) { }        
// 
//         public override void Execute(ZComponent caller)
//         {
//             if (Mesh != null) Mesh.Render();
//         }
//     }
// 
//     public class RenderSetColor : ZCommand
//     {
//         //[DefaultValue(Color.White)]
//         public Color Color;
// 
//         public RenderSetColor(ZComponent parent)
//             : base(parent)
//         {
//             Color = Color.White;
//         }        
// 
//         public override void Execute(ZComponent caller)
//         {
//             GL.Color3(Color);
//         }
//     }
// 
//     public class RenderTransform : ZCommand
//     {
//         public Vector3 Translate;
//         public Vector3 Rotate;
//         public Vector3 Scale;
// 
//         public RenderTransform(ZComponent parent): base(parent) {}
// 
//         public override void Execute(ZComponent caller)
//         {
//             GL.Translate(Translate);
// 
//             //Reverse order to make XYZ-rotation  
//             GL.Rotate(Rotate.Z, Vector3.UnitZ);
//             GL.Rotate(Rotate.Y, Vector3.UnitY);
//             GL.Rotate(Rotate.X, Vector3.UnitX);
// 
//             GL.Scale(Scale);
//         }
//     }
// 
//     public class RenderNet : ZCommand
//     {
//         public Mesh Mesh;
//         public int XCount;
//         public int YCount;
//         public bool VertexColors;
//         //public delegate void ModelMethod(Model model);
//         //public ZCode VertexExpression;
// 
//         public RenderNet(ZComponent parent): base(parent) { }
// 
//         public override void Execute(ZComponent caller)
//         {
//             if (Mesh == null)
//             {
//                 Mesh = new Mesh(null); // Make it dynamic
//                 Shape shape = new Shape();
//                 shape.MakeNet(XCount, YCount);
//                 if (VertexColors && shape.Colors == null)
//                     shape.CreateColors();
//                 Mesh.CreateVBO(shape);
//             }
// 
//             /*if (VertexExpression != null)
//             {
//                 Mesh.ApplyExpression(VertexExpression);
//                 //Vertex, Tex, Color
//                 Mesh.ComputeNormals();
//             }*/
// 
//             if (Mesh != null) Mesh.Render();
//         }
//     }
}
