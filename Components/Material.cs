using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace ZGE.Components
{
    public enum MaterialTexCoords
    { Generated, ModelDefined }
    public enum BlendType
    { NoBlend, A_1MSA, A_1, C_1MSC, AlphaSat_1 } //'None','Alpha/OneMinusSourceAlpha','Alpha/One','Color/OneMinusSourceColor','AlphaSaturate/One'


    public class Material : ZComponent
    {
        [Browsable(false)]
        public List<Texture> Textures = new List<Texture>();
        public ShadingModel Shading = ShadingModel.SMOOTH;
        public Color Color = Color.White;
        public bool Lighting = true;
        public BlendType Blend = BlendType.NoBlend;
        public bool ZBuffer = true;
        public bool DrawBackFace = false;
        // public Font Font;
        // public Shader Shader;
        public bool Wireframe = false;
        public float WireframeWidth = 1.0f;
        public Color SpecularColor;
        public Color EmissionColor;
        public int Shininess;

        public Material()
        {

        }

        public void Apply(Material oldMat)
        {
            GL.Color4(Color);

            //Test for equal material after setting color
            //This is because r}ersetcolor may have been called so we need reset material.color
            if (oldMat == this) return;

            bool oldNull = (oldMat == null);

            Renderer.currentMaterial = this;

            //GL.Material(All.FRONT, All.SPECULAR, SpecularColor);
            //GL.Material(All.FRONT, All.EMISSION, EmissionColor);
            //GL.Material(All.FRONT, All.SHININESS, Shininess);

            if (oldNull || Shading != oldMat.Shading)
                GL.ShadeModel(Shading);

            if (oldNull || Wireframe != oldMat.Wireframe)
            {
                if (Wireframe)
                    GL.PolygonMode(All.FRONT_AND_BACK, All.LINE);
                else
                    GL.PolygonMode(All.FRONT_AND_BACK, All.FILL);
            }

            if (oldNull || WireframeWidth != oldMat.WireframeWidth)
                GL.LineWidth(WireframeWidth);

            if (oldNull || Lighting != oldMat.Lighting)
            {
                if (Lighting && App.Lighting)
                    GL.Enable(All.LIGHTING);
                else
                    GL.Disable(All.LIGHTING);
            }

            if (oldNull || ZBuffer != oldMat.ZBuffer)
            {
                if (ZBuffer)
                {
                    GL.DepthFunc(All.LEQUAL);
                    GL.DepthMask(true);
                }
                else
                {
                    //Disable z-buffer: Skip depth-test
                    GL.DepthFunc(All.ALWAYS);
                    GL.DepthMask(false);
                }
            }

            /*if (oldNull || DrawBackFace != oldMat.DrawBackFace)
            {
                if (DrawBackFace)
                    GL.Disable(All.CULL_FACE);
                else
                    GL.Enable(All.CULL_FACE);
            }*/

            /*if (oldNull || (Blend!=oldMat.Blend)
            {
              if Blend=mbNoBlend
                GL.Disable(All.BLEND)
              else
              {
                GL.Enable(All.BLEND);
                case Blend of
                  mbA_1MSA : GL.BlendFunc(All.SRC_ALPHA, All.ONE_MINUS_SRC_ALPHA);
                  mbA_1 : GL.BlendFunc(All.SRC_ALPHA,All.ONE);
                  mbC_1MSC : GL.BlendFunc(All.SRC_COLOR,All.ONE_MINUS_SRC_COLOR);
                  mbAlphaSat_1 : GL.BlendFunc(All.SRC_ALPHA_SATURATE,All.ONE);
                }
              }
            }*/

            int texCount = Textures.Count;
            if (!oldNull && oldMat.Textures.Count > texCount)
                texCount = oldMat.Textures.Count;
            //Count backwards so that activetexture is zero on loop exit
            for (int i = texCount - 1; i >= 0; i--)
            {
                /*if MultiTextureSupported
                  GL.ActiveTexture($84C0 + I)
                else if I>0 Continue;*/

                // The textures from the previous material must be disabled
                if (i >= Textures.Count)
                {
                    GL.BindTexture(All.TEXTURE_2D, 0);
                    GL.Disable(All.TEXTURE_2D);
                    continue;
                }

                Texture tex = Textures[i];

                if (tex != null)
                {
                    GL.Enable(All.TEXTURE_2D);
                    tex.Bind();
                }
                /*else if Tex.RenderTarget!=nil
                {
                  GL.Enable(All.TEXTURE_2D);
                  Tex.RenderTarget.UseTextureBegin;
                }*/


                //Texture matrix
                //Denna ||dning är nödvändig för att scale och rotate ska ske kring texture center (0.5)
                /*GL.MatrixMode(All.TEXTURE);
                GL.LoadIdentity();
                  GL.Translatef(Tex.TextureX+0.5,Tex.TextureY+0.5,0);
                  GL.Scalef(Tex.TextureScale[0],Tex.TextureScale[1],1);
                  GL.Rotatef(Tex.TextureRotate*360,0,0,1);
                  GL.Translatef(-0.5,-0.5,0);
                GL.MatrixMode(All.MODELVIEW);

                if (Tex.TexCoords==Generated)
                {                 
                  GL.Enable(All.TEXTURE_GEN_S);
                  GL.Enable(All.TEXTURE_GEN_T);
                  GL.TexGeni(All.S,All.TEXTURE_GEN_MODE, All.OBJECT_LINEAR);
                  GL.TexGeni(All.T,All.TEXTURE_GEN_MODE, All.OBJECT_LINEAR);                  
                }
                else
                {
                  GL.Disable(All.TEXTURE_GEN_S);
                  GL.Disable(All.TEXTURE_GEN_T);
                }*/

                //This is a local parameter for every texture                
                GL.TexParameter(All.TEXTURE_2D, All.TEXTURE_WRAP_S, (int) tex.WrapMode);
                GL.TexParameter(All.TEXTURE_2D, All.TEXTURE_WRAP_T, (int) tex.WrapMode);
            }
            if (texCount == 0)
            {
                GL.BindTexture(All.TEXTURE_2D, 0);
                GL.Disable(All.TEXTURE_2D);
            }

            /*if (ShadersSupported && (oldNull || (Shader!=oldMat.Shader))
            {
              if (!oldNull) && (oldMat.Shader!=nil)
                oldMat.Shader.DetachArrayVariables;
              if Shader!=nil
                Shader.UseShader
              else
                GL.UseProgram(0);
            }*/

        }
    }

    public class Texture : ZComponent, INeedRefresh
    {
        private bool initialized = false;
        [Browsable(false)]
        public int TextureID;
        public string FileName;
        public Bitmap Bitmap;
        //public RenderTarget RenderTarget; 
        public Vector3 TextureScale;
        public float TextureX;
        public float TextureY;
        public float TextureRotate;
        public TextureWrapMode WrapMode = TextureWrapMode.REPEAT;
        public MaterialTexCoords TexCoords;
        [ReadOnlyAttribute(true)]
        public int Width;
        [ReadOnlyAttribute(true)]
        public int Height;

        public Texture()
        {
        }

        public void Refresh()
        {
            initialized = false;
        }

        public void Bind()
        {
            if (!initialized) Init();

            GL.BindTexture(All.TEXTURE_2D, TextureID);
        }

        public void Init()
        {
            initialized = true;
            if (FileName == null || FileName.Length == 0) return;

            //  Try && load the bitmap. Return false on failure.
            Bitmap image = new Bitmap(App.AssetsPath + FileName);
            if (image == null) return;
            Console.WriteLine("Texture loaded: {0}", App.AssetsPath + FileName);

            //  If the texture currently exists in OpenGL, destroy it.
            if (TextureID != 0) GL.DeleteTexture(TextureID);

            //  Generate && store a texture identifier.
            TextureID = GL.GenTexture();

            //	Get the maximum texture size supported by OpenGL.
            int textureMaxSize;
            GL.GetInteger(All.MAX_TEXTURE_SIZE, out textureMaxSize);

            //	Find the target width && height sizes, which is just the highest
            //	possible power of two that'll fit into the image.
            int targetWidth = textureMaxSize;
            int targetHeight = textureMaxSize;

            for (int size = 1; size <= textureMaxSize; size *= 2)
            {
                if (image.Width < size)
                {
                    targetWidth = size / 2;
                    break;
                }
                if (image.Width == size)
                    targetWidth = size;
            }

            for (int size = 1; size <= textureMaxSize; size *= 2)
            {
                if (image.Height < size)
                {
                    targetHeight = size / 2;
                    break;
                }
                if (image.Height == size)
                    targetHeight = size;
            }

            //  If need to scale, do so now.
            if (image.Width != targetWidth || image.Height != targetHeight)
            {
                //  Resize the image.
                Image newImage = image.GetThumbnailImage(targetWidth, targetHeight, null, IntPtr.Zero);

                //  Destory the old image, && reset.
                image.Dispose();
                image = (Bitmap) newImage;
            }

            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //	Set the width && height.
            Width = image.Width;
            Height = image.Height;

            //	Bind our texture object (make it the current texture).
            GL.BindTexture(All.TEXTURE_2D, TextureID);

            //  Set the image data.
            GL.TexImage2D(All.TEXTURE_2D, 0, All.RGBA, Width, Height, 0, All.BGRA, All.UNSIGNED_BYTE, bitmapData.Scan0);

            //  Unlock the image.
            image.UnlockBits(bitmapData);

            //  Dispose of the image file.
            image.Dispose();

            //  Set linear filtering mode.
            GL.TexParameter(All.TEXTURE_2D, All.TEXTURE_MIN_FILTER, All.LINEAR);
            GL.TexParameter(All.TEXTURE_2D, All.TEXTURE_MAG_FILTER, All.LINEAR);
        }
    }


    public class UseMaterial : ZCommand
    {
        public Material Material;

        public override void Execute(ZComponent caller)
        {
            if (Material != null)
                Renderer.ApplyMaterial(Material);
        }
    }
}
