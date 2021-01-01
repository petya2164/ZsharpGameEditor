#region --- License ---

/* Copyright (c) 2006, 2007 Stefanos Apostolopoulos
 * See license.txt for license info
 */

#endregion --- License ---

using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;
using System.Drawing;

using OpenTK;

namespace ZGE.Components
{
    [HideComponent]
    public class Shape
    {
        private Vector3[] vertices, normals;
        private Vector2[] texcoords;
        private int[] indices;
        private int[] colors;

        //         static uint ToRgba(Color color)
        //         {
        //             return (uint) color.A << 24 | (uint) color.B << 16 | (uint) color.G << 8 | (uint) color.R;
        //         }

        public static int ToRgba(Color c)
        {
            return (int) ((c.A << 24) | (c.B << 16) | (c.G << 8) | c.R);
        }

        public Vector3[] Vertices
        {
            get { return vertices; }
            protected set
            {
                vertices = value;
            }
        }

        public Vector3[] Normals
        {
            get { return normals; }
            protected set
            {
                normals = value;
            }
        }

        public Vector2[] Texcoords
        {
            get { return texcoords; }
            protected set
            {
                texcoords = value;
            }
        }

        public int[] Indices
        {
            get { return indices; }
            protected set
            {
                indices = value;
            }
        }

        public int[] Colors
        {
            get { return colors; }
            protected set
            {
                colors = value;
            }
        }

        public void CreateData(int vertCount, int triangleCount, bool includeTexcoords, bool includeColors)
        {
            vertices = new Vector3[vertCount];
            normals = new Vector3[vertCount];
            indices = new int[3 * triangleCount];
            if (includeTexcoords)
                texcoords = new Vector2[vertCount];
            if (includeColors)
                colors = new int[vertCount];
        }

        public void CreateColors()
        {
            //A color for each vertex
            colors = new int[vertices.Length];
        }

        public void ComputeNormals()
        {
            //if (Style!=msTris) return;

            //One normal for each vertex
            normals = new Vector3[vertices.Length];

            int i = 0;
            for (i = 0; i < indices.Length / 3; i++)
            {
                int i0 = indices[i * 3];
                int i1 = indices[i * 3 + 1];
                int i2 = indices[i * 3 + 2];

                Vector3 v0 = vertices[i0];
                Vector3 v1 = vertices[i1];
                Vector3 v2 = vertices[i2];

                // Calc normal vector for this face
                // The normal is facing upwards for CCW triangles
                Vector3 normal = Vector3.Cross(v1 - v0, v2 - v0);
                // Accumulate normals at all 3 vertices of this face
                normals[i0].Add(normal);
                normals[i1].Add(normal);
                normals[i2].Add(normal);
            }


            //Normalize
            for (i = 0; i < normals.Length; i++)
                normals[i].Normalize();
        }

        public void MakeNet(int xCount, int yCount)
        {
            /*var
              VertCount,TriCount : integer;

              XStep,YStep,CurX,CurY : single;
              Ind : PMeshVertexIndex;

              CurI,X,Y : integer;*/

            int vertCount = (2 + xCount) * (2 + yCount);
            int triCount = 2 * ((xCount + 1) * (yCount + 1));
            CreateData(vertCount, triCount, true, false);

            float xStep = 1.0f / (xCount + 1);
            float yStep = 1.0f / (yCount + 1);

            //Generate vertices and texcoords
            int i = 0;
            int x, y;
            float curY = -0.5f;
            for (y = 0; y <= yCount + 1; y++)
            {
                float curX = -0.5f;
                for (x = 0; x <= xCount + 1; x++)
                {
                    //Vertex interval -0.5 .. 0.5
                    vertices[i] = new Vector3(curX, curY, 0);
                    //Texcoords interval 1..0
                    texcoords[i] = new Vector2(curX + 0.5f, 1.0f - (0.5f - curY));

                    curX = curX + xStep;
                    i++;
                }
                curY = curY + yStep;
            }

            //Generate two triangles for each quad in net
            //CCW direction
            i = 0;
            int idx = 0;
            for (y = 0; y <= yCount; y++)
            {
                for (x = 0; x <= xCount; x++)
                {
                    indices[idx + 0] = i;
                    indices[idx + 1] = i + 1;
                    indices[idx + 2] = i + 2 + xCount;
                    indices[idx + 3] = i + 1;
                    indices[idx + 4] = i + 3 + xCount;
                    indices[idx + 5] = i + 2 + xCount;
                    idx += 6;
                    i++;
                }
                i++;
            }

            /*
                  curx=0
                  xstep=1/xcount
                  while(cury<1)
                    while(curx<1)
                      addVertex(curx,cury)
                  create indices
                    tri1 is v1,v2,v3
                    tri2 is v2,v4,v3
            */
            ComputeNormals();
        }

        public void Scale(Vector3 scale)
        {
            if (scale == Vector3.One) return;

            int i;
            for (i = 0; i < vertices.Length; i++)
                vertices[i].Scale(ref scale);


            if (normals != null)
            {
                for (i = 0; i < normals.Length; i++)
                {
                    normals[i].Scale(ref scale);
                    normals[i].Normalize();
                }
            }
        }

        public void CopyMeshWithTransform(Shape source, Matrix4 mx, int vertexOffset, int indexOffset)
        {
            int i;
            int vx = vertexOffset;
            int ix = indexOffset;
            for (i = 0; i < source.vertices.Length; i++)
            {
                Vector3.Transform(ref source.vertices[i], ref mx, out vertices[vx]);
                vx++;
            }

            for (i = 0; i < source.indices.Length; i++)
            {
                indices[ix] = source.indices[i] + vertexOffset;
                ix++;
            }

            if (texcoords != null && source.texcoords != null)
            {
                vx = vertexOffset;
                for (i = 0; i < source.texcoords.Length; i++)
                {
                    texcoords[vx] = source.texcoords[i];
                    vx++;
                }
            }
        }

        public void ApplyHeightMap(float[,] hm, int width, int height)
        {
            if (vertices == null) return;

            int xCount = width - 2;
            int yCount = height - 2;

            int i = 0;
            int x, y;
            for (y = 0; y <= yCount + 1; y++)
            {
                for (x = 0; x <= xCount + 1; x++)
                {
                    //Vertex interval -0.5 .. 0.5
                    vertices[i].Z = hm[x,y];
                    i++;
                }
            }
        }

    }
}
