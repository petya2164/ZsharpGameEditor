using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK;
using System.ComponentModel;
using OpenTK.Graphics;


namespace ZGE.Components
{
 /*   class Font
    {
        TFont = class(TZComponent)
  private
    IsInit : boolean;
    FontSizes : array[0..2] of TZComponentList;
    BmStruct :
      record
        ScaleX,ScaleY : single;
        TransX,TransY : single;
        TopLeftY : single;
        CharsPerRow : integer;
      end;
    procedure InitFromBitmap;
    procedure InitBuiltIn;
  private
    procedure Prepare;
  protected
    procedure RenderCharacter(Char : integer; Size : integer);
  
  public
    Bitmap : TZBitmap;
    CharPixelWidth : integer;
    CharPixelHeight : integer;
    FirstChar : integer;
    BorderPixels : integer;
    destructor Destroy; override;
  end;            
    }*/
  
 
    public class Font: ZComponent
    {  
        private bool initialized = false;
        private int charHeight;
        private Dictionary<char, int> charWidths = new Dictionary<char, int>();
        private Dictionary<char, RectangleF> charTexcoords = new Dictionary<char, RectangleF>();
        [Browsable(false)]
        public int TextureID;
        public string FontName;
        public string FileName;
        public int Size;
        public bool Bold;
        public bool Italic;


	    //float x, y;	          	

	    // Prints text at a specified position	    
        public void Print(float x1, float y1, float size, string txt)
        {
            float x = x1;
		    float y = y1;

            //txt += App.FpsCounter.ToString();
            //txt += App.FpsEstimated.ToString("F0");
            //txt += (App.Find("Camera1") as ProjectiveCamera).Position.ToString();

		    //size = size / (float)height;		    

            if (y < 0.0f)
                y = App.CurrentHeight - charHeight + y;
            if (x < 0.0f)
            {
                float totalWidth = 0.0f;
                foreach (char c in txt)
                {
                    int w = charWidths[c];
                    totalWidth += (w + 2) * size;
                }
                x = App.CurrentWidth - totalWidth + x;
            }

            GL.PushAttrib(AttribMask.CURRENT_BIT | AttribMask.TEXTURE_BIT | AttribMask.ENABLE_BIT | AttribMask.COLOR_BUFFER_BIT | AttribMask.DEPTH_BUFFER_BIT);

            GL.Color3(Color.White);
            GL.Enable(All.ALPHA_TEST);
		    GL.AlphaFunc(All.GEQUAL,0.5f);

 		    GL.Enable(All.BLEND);
            GL.BlendFunc(All.SRC_ALPHA, All.ONE_MINUS_SRC_ALPHA);
 		    
 		    GL.Enable(All.TEXTURE_2D);
 		    GL.Disable(All.DEPTH_TEST);
// 		    GL.BindTexture(All.TEXTURE_2D, tex);

		    // Draw the text
		    GL.Begin(All.QUADS);
		    foreach(char c in txt)
		    {
                int w = charWidths[c];
                RectangleF r = charTexcoords[c];
                //RectangleF r = new RectangleF(0,0,1.0f,1.0f);

                GL.TexCoord2(r.Left, r.Bottom); GL.Vertex2(x, y);
                GL.TexCoord2(r.Right, r.Bottom); GL.Vertex2(x + w * size, y);
                GL.TexCoord2(r.Right, r.Top); GL.Vertex2(x + w * size, y + charHeight * size);
                GL.TexCoord2(r.Left, r.Top); GL.Vertex2(x, y + charHeight * size);

			    /*GL.TexCoord2(coords[c][0]); GL.Vertex2f(x, y + height*size);
			    GL.TexCoord2(coords[c][1]); GL.Vertex2f(x + widths[c]*size, y + height*size);
			    GL.TexCoord2(coords[c][2]); GL.Vertex2f(x + widths[c]*size, y);
			    GL.TexCoord2(coords[c][3]); GL.Vertex2f(x, y);*/

			    x += (w+2)*size;
		    }               
		    GL.End();            

// 		    GL.Disable(All.BLEND);
// 	        GL.Enable(All.DEPTH_TEST);
// 	        GL.Disable(All.TEXTURE_2D);
// 	        //GL.Disable(All.ALPHA_TEST);

            GL.PopAttrib();
        }


        public Font()
        {
        }

        ~Font()
        {
            ReleaseTexture();
        }

        private void ReleaseTexture()
        {
            if (GraphicsContext.CurrentContext == null) return;
            //  If the texture currently exists in OpenGL, destroy it.
            if (TextureID != 0) GL.DeleteTexture(TextureID);
            //Console.WriteLine("Texture finalized");
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

        private Rectangle ScanCharacter(Bitmap image, int x, int y, Size range)
        {
            Rectangle res = new Rectangle(0, 0, range.Width, range.Height);
            int minx = range.Width;
            int maxx = 0;
            for (int j = 1; j < range.Height; j++)
                for (int i = 1; i < range.Width; i++)            
                {
                    if (image.GetPixel(x + i, y + j).G != 0)    // found a non-black pixel ?
                    {
                        if (i < minx) minx = i;
                        if (i > maxx) maxx = i;
                    }
                        
                }
            if (minx < maxx)
            {
                res.X = minx;
                res.Width = maxx - minx;
            }

            return res;
        }
        
        public void Init()
        {
            initialized = true;

            /*if (FileName != null && FileName.Length > 0)
            {
                //  Try & load the bitmap. 
                Bitmap image = new Bitmap(App.AssetsPath + FileName);
                if (image == null) return;
                Console.WriteLine("Font texture loaded: {0}", App.AssetsPath + FileName);
            }*/

            
            int texsize = 512;
            //int padding = Italic ? 4 : 2; // Italic fonts require more padding
            int padding = 0;
            
            var fnt = new System.Drawing.Font(FontFamily.GenericMonospace, 24f, FontStyle.Bold);
            //var fnt = new System.Drawing.Font(FontFamily.GenericSansSerif, 24f, FontStyle.Bold);

            Bitmap image = new Bitmap(texsize, texsize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(image);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.Clear(Color.Black);

            //g.DrawString("This is my text", fnt, Brushes.White, new Point(0, 0));
            //TextRenderer.DrawText(g, "This is my text", myFont, new Point(0, 0), Color.Red);            

            ReleaseTexture();

            //  Generate && store a texture identifier.
            TextureID = GL.GenTexture();

            CharacterRange[] characterRanges = { new CharacterRange(0, 1) };           
            RectangleF layoutRect = new RectangleF(0, 0, 1000, 1000);

            // Set string format.
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.NoClip;
            stringFormat.SetMeasurableCharacterRanges(characterRanges);

            // Render the characters to the bitmap
            char c = (char) 32;
            SizeF s = g.MeasureString(c.ToString(), fnt);            
            
            // Measure the range in string.
            //Region[] stringRegions = g.MeasureCharacterRanges(c.ToString(), fnt, layoutRect, stringFormat);            
            //RectangleF rect1 = stringRegions[0].GetBounds(g);           
            
            //int c_height = (int)rect1.Height;            
            charHeight = (int) s.Height;

            int x = 0, y = 0;
            int w = (int)s.Width;
            charWidths[c] = w;            
            g.DrawString(c.ToString(), fnt, Brushes.White, new Point(x, y));
            charTexcoords[c] = new RectangleF(x / (float) texsize, y / (float) texsize,
                w / (float) texsize, charHeight / (float) texsize);
            x += w + padding;            
            c++;

            while ((y < texsize - charHeight) && (c < 256))
            {
                
                while ((x < texsize - charHeight) && (c < 256))
                {                    
                    s = g.MeasureString(c.ToString(), fnt);
                    //stringRegions = g.MeasureCharacterRanges(c.ToString(), fnt, layoutRect, stringFormat);
                    //rect1 = stringRegions[0].GetBounds(g);
                    //w = (int)(rect1.Width);
                    //w = (int) s.Width;
                    //int right = (int) (rect1.Right);
                    
                    //TextRenderer.DrawText(g, c.ToString(), fnt,  new Point(x, y), Color.White);
                    g.DrawString(c.ToString(), fnt, Brushes.White, new Point(x, y));
                    Rectangle rect2 = ScanCharacter(image, x, y, s.ToSize());
                    w = rect2.Width;
                    charWidths[c] = w;
                    int right = rect2.Right;
                    int x_offset = x + rect2.Left;
                    charTexcoords[c] = new RectangleF(x_offset / (float) texsize, y / (float) texsize,
                        w / (float) texsize, charHeight / (float) texsize);
                    //Rectangle rect2 = Rectangle.Round(rect1);
                    rect2.Offset(x, y);
                    //g.DrawRectangle(new Pen(Color.Red, 1), rect2);
                    //g.DrawRectangle(new Pen(Color.Red, 1), x, y, w, charHeight);
                    x += right + padding;
                    c++;                    
                }
                y += charHeight;
                x = 0;
            }

            g.Dispose();

            image.Save("test.png");

            //  Lock the image bits (so that we can pass them to TexImage2D).
            System.Drawing.Imaging.BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, image.PixelFormat);        
		    
		    int pixelCount = image.Width * image.Height;
           
            // get source bitmap pixel format size
            int Depth = System.Drawing.Bitmap.GetPixelFormatSize(image.PixelFormat);
            int step = Depth / 8;
            // create byte array to copy pixel values
            byte[] pixels = new byte[pixelCount * step];            

            // Copy data from pointer to array
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, pixels, 0, pixels.Length);

            // Create a simple alpha channel only
            byte[] alpha = new byte[pixelCount];
		    for(int i = 0; i < pixelCount * 4; i += 4)
			    alpha[i/4] = pixels[i];

            //	Set the width && height.
            int Width = image.Width;
            int Height = image.Height;

            //	Bind our texture object (make it the current texture).
            GL.BindTexture(All.TEXTURE_2D, TextureID);

            //  Set the image data.
            //GL.TexImage2D(All.TEXTURE_2D, 0, All.RGBA, Width, Height, 0, All.BGRA, All.UNSIGNED_BYTE, bitmapData.Scan0);
            GL.TexImage2D(All.TEXTURE_2D, 0, All.ALPHA, Width, Height, 0, All.ALPHA, All.UNSIGNED_BYTE, alpha);

            //  Unlock the image.
            image.UnlockBits(bitmapData);

            //  Dispose of the image file.
            image.Dispose();

            //  Set linear filtering mode.
            GL.TexParameter(All.TEXTURE_2D, All.TEXTURE_MIN_FILTER, All.LINEAR);
            GL.TexParameter(All.TEXTURE_2D, All.TEXTURE_MAG_FILTER, All.LINEAR);            

            Console.WriteLine("Font initialized.");
        }
    }

    public class RenderText : ZCommand, IRenderable
    {
        public Font Font;
        public delegate string TextMethod(ZComponent caller, string original);
        public ZCode<TextMethod> TextExpression = new ZCode<TextMethod>();
        public string Text = "";
        public Vector3 Position;
        public Vector3 Rotation;
        public float Scale = 1.0f;

        public RenderText()
        {
            //TextExpression.Header = "public string #METHOD#(RenderText rt)";           
        }

        public override void Execute(ZComponent caller)
        {
            string txt = Text;
            if (TextExpression != null && TextExpression.callback != null)
                txt = TextExpression.callback(caller, Text);
            if (txt == null || txt.Length == 0) return;
            Font fnt = Font ?? Renderer.defaultFont;

            fnt.Bind();
            fnt.Print(Position.X, Position.Y, Scale, txt);
        }

        public void Render()
        {
            if (!Enabled) return;
            Execute(this);                        
        }
    }



/*    TRenderText = class(TRenderCommand)
  
  public
    Text : TPropString;               //Text to print
    TextFloatRef : TZPropertyRef;     //Propvalue att printa, en av dessa gäller
    TextArrayRef : pointer;           //DefineArray to print
    X,Y,Scale : single;
    Align : (alCenter,alLeft);
    CharX,CharY,CharRotate,CharScale : single;
    CharI : integer;
    RenderCharExpression : TZExpressionPropValue;
    FloatMultiply : single;  //Multiplicera floatref innan print, för att visa decimaltal
    UseModelSpace : boolean;
    StretchY : single;
    procedure Execute; override;
    procedure ResetGpuResources; override;
    
  end;*/
}
