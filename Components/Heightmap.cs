using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using OpenTK;

namespace ZGE.Components
{
    public class Heightmap : ContentLike, INeedRefresh
    {
        private bool initialized = false;
        public string FileName;

        [Browsable(false)]
        public float[,] data;
        [ReadOnlyAttribute(true)]
        public int Width;
        [ReadOnlyAttribute(true)]
        public int Height;
        
        public delegate void RefreshDelegate();
        [Browsable(false)]
        public RefreshDelegate OnRefresh;

        public Heightmap()
        {
        }

        public void Refresh()
        {
            initialized = false;
            // Also notify subscribed MeshProducers
            if (OnRefresh != null) OnRefresh();
        }

        public void Prepare()
        {
            if (initialized) return;

            initialized = true;
            if (FileName == null || FileName.Length == 0) return;

            using (Bitmap bmp = (Bitmap) Image.FromFile(App.AssetsPath + FileName))
            {
                Console.WriteLine("Heightmap loaded: {0}", App.AssetsPath + FileName);
                Width = bmp.Width;
                Height = bmp.Height;
                data = new float[Width, Height];
                for (int i = 0; i < Width; i++)
                    for (int j = 0; j < Height; j++)
                    {
                        data[i, j] = bmp.GetPixel(i, j).GetBrightness();
                    }                
            }
        }

        // x and y should be in [-1, 1]
        public float GetHeight(float x, float y)
        {
            if (data == null) return 0.0f;
            int i = (int)(Width * (x + 1.0f) / 2.0f);
            if (i > Width-1) i = Width-1;
            if (i < 0) i = 0;

            int j = (int)(Height * (y + 1.0f) / 2.0f);
            if (j > Height) j = Height;
            if (j < 0) j = 0;

            return data[i, j];            
        }
    }

    public class MeshHeightmap : MeshProducer
    {
        public Heightmap Heightmap;        

        public override void ProduceOutput(ZContent content)
        {
            if (Heightmap == null) return;
            Heightmap.OnRefresh -= Refresh; //Avoid double subscription
            Heightmap.OnRefresh += Refresh;

            Shape shape = new Shape();

            Heightmap.Prepare();
            int w = Heightmap.Width;
            int h = Heightmap.Height;
            float[,] hm = Heightmap.data;            

            //Create a simple 2d-grid, and scale it up to [-1, 1]
            shape.MakeNet(w - 2, h - 2);
            shape.Scale(new Vector3(2, 2, 1));
            shape.ApplyHeightMap(hm, w, h);

            shape.Scale(Scale);
            shape.ComputeNormals();

            Mesh mesh = content as Mesh;
            mesh.CreateVBO(shape);
            
        }
    }
}
