using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Drawing;

namespace ZGE.Components
{
    public enum LightKind
    {
        Directional, Point, Spot
    }

    class Light : ZComponent
    {
        public Vector4 Position; 
        public Color Color; 
        //public bool Enabled; 
        public LightKind Kind;

        public Vector3 SpotDirection;
        public float SpotExponent;
        public float SpotCutoff;

        public Light()
        {
            Enabled = true;
            SpotDirection = new Vector3(0, 0, -1);
            SpotCutoff = 45;
        }

        /*void ApplyLight(int LightId)
        {
            int Id = (int)EnableCap.Light0 + LightId;
            if (Enabled)
                GL.Enable(Id);
            else
                GL.Disable(Id);

            if (Kind == LightKind.Directional)
                Position = new Vector4(Position.X, Position.Y, Position.Z, 0.0f);
            else
            {
                Position = new Vector4(Position.X, Position.Y, Position.Z, 1.0f);
                float cutOff = 180.0f;
                if (Kind == LightKind.Spot)
                {
                    cutOff = SpotCutoff;
                    GL.Light(Id, LightParameter.SpotDirection, ref SpotDirection.X);
                    GL.Light(Id, LightParameter.SpotExponent, SpotExponent);
                }
                GL.Light(Id, LightParameter.SpotCutoff, cutOff);
            }
            GL.Light(Id, LightParameter.Position, Position);

            Color4 c4 = new Color4(Color);
            GL.Light(Id, LightParameter.Diffuse, c4);
            GL.Light(Id, LightParameter.Specular, c4);
        }

        void RemoveLight(int LightId)
        {
            //Leave light0 on as this is the default in ZGE
            //Turn the others off
            int Id = EnableCap.Light0 + LightId;

            if (LightId == 0)
            {
                //Also restore diffuse color
                GL.Light(Id, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
                GL.Enable(Id);
            }
            else
                GL.Disable(Id);
        }*/
    }
}
