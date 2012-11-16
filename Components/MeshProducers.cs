using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using System.Drawing;
using System.ComponentModel;

namespace ZGE.Components
{
    [HideComponent]
    public abstract class MeshProducer : ZContentProducer
    {
        public Vector3 Scale;

        public MeshProducer(ZComponent parent)
            : base(parent)
        {
            Scale = Vector3.One;
        }
    }

    public class MeshBox : MeshProducer
    {
        public bool Grid2DOnly;
        public int XCount;
        public int YCount;

        public MeshBox(ZComponent parent): base(parent) {}

        public override void ProduceOutput(ZContent content)
        {
            Shape shape = new Shape();

            if (Grid2DOnly)
            {
                //Create a simple 2d-grid
                shape.MakeNet(XCount, YCount);
                shape.Scale(new Vector3(2, 2, 1));
            }
            else
            {
                Shape temp = new Shape();
                temp.MakeNet(XCount, YCount);

                shape.CreateData(temp.Vertices.Length * 6,
                    (temp.Indices.Length * 6) / 3, true, false);

                int vertexOffset = 0;
                int indexOffset = 0;

                // MakeNet makes a network from -0.5 to 0.5
                // Increase to -1 .. 1, and move forward towards the camera

                //Default matrix
                Matrix4 mx = Matrix4.Scale(2, 2, 1) * Matrix4.CreateTranslation(0, 0, 1);

                //Sides
                for (int i = 0; i < 4; i++)
                {
                    Matrix4 m = mx * Matrix4.CreateRotationY(i * MathHelper.PiOver2);
                    shape.CopyMeshWithTransform(temp, m, vertexOffset, indexOffset);
                    vertexOffset += temp.Vertices.Length;
                    indexOffset += temp.Indices.Length;
                }

                //Top and bottom
                for (int i = 0; i < 2; i++)
                {
                    Matrix4 m = mx * Matrix4.CreateRotationX((-1.0f + i * 2) * MathHelper.PiOver2);
                    shape.CopyMeshWithTransform(temp, m, vertexOffset, indexOffset);
                    vertexOffset += temp.Vertices.Length;
                    indexOffset += temp.Indices.Length;
                }
            }

            shape.Scale(Scale);
            shape.ComputeNormals();

            Mesh mesh = content as Mesh;
            mesh.CreateVBO(shape);
        }
    }

    public class MeshSphere : MeshProducer
    {
        public int ZSamples;
        public int RadialSamples;

        public MeshSphere(ZComponent parent): base(parent) {}

        public override void ProduceOutput(ZContent content)
        {
            const float Radius = 1.0f;
            if (ZSamples <= 2 || RadialSamples <= 2) return;

            Shape shape = new Shape();

            int ZSm1 = ZSamples - 1;
            int ZSm2 = ZSamples - 2;
            int ZSm3 = ZSamples - 3;

            int RSp1 = RadialSamples + 1;
            int VQuantity = ZSm2 * RSp1 + 2;
            int TQuantity = 2 * ZSm2 * RadialSamples;
            shape.CreateData(VQuantity, TQuantity, false, false);

            // generate geometry
            float InvRS = 1.0f / RadialSamples;
            float ZFactor = 2.0f / ZSm1;

            // Generate points on the unit circle to be used in computing the shape
            // points on a cylinder slice.
            var afSin = new float[RSp1];
            var afCos = new float[RSp1];

            for (int r = 0; r <= RadialSamples - 1; r++)
            {
                float angle = (MathHelper.TwoPi) * InvRS * r;
                afCos[r] = (float) Math.Cos(angle);
                afSin[r] = (float) Math.Sin(angle);
            }

            afSin[RadialSamples] = afSin[0];
            afCos[RadialSamples] = afCos[0];

            // generate the cylinder itself
            int i = 0;
            for (int z = 1; z <= ZSm1 - 1; z++)
            {
                float ZFraction = -1.0f + ZFactor * z;  // in (-1,1)
                float fZ = Radius * ZFraction;

                // compute center of slice
                Vector3 SliceCenter = new Vector3(0.0f, 0.0f, fZ);

                // compute radius of slice
                float SliceRadius = (float) Math.Sqrt(Math.Abs(Radius * Radius - fZ * fZ));

                // compute slice vertices with duplication at end point
                int save = i;
                for (int r = 0; r <= RadialSamples - 1; r++)
                {
                    // RadialFraction = R*InvRS;  // in [0,1)
                    Vector3 radial = new Vector3(afCos[r], afSin[r], 0.0f);
                    shape.Vertices[i] = SliceCenter + SliceRadius * radial;
                    Vector3.Normalize(ref shape.Vertices[i], out shape.Normals[i]);
                    i++;
                }
                shape.Vertices[i] = shape.Vertices[save];
                shape.Normals[i] = shape.Normals[save];

                i++;
            }

            // south pole
            shape.Vertices[i] = -Radius * Vector3.UnitZ;
            shape.Normals[i] = -1.0f * Vector3.UnitZ;

            i++;

            // north pole
            shape.Vertices[i] = Radius * Vector3.UnitZ;
            shape.Normals[i] = Vector3.UnitZ;

            //  Assert( i == VQuantity );

            // generate connectivity
            int idx = 0;
            int zstart = 0;
            for (int z = 0; z <= ZSm3 - 1; z++)
            {
                int i0 = zstart;
                int i1 = i0 + 1;
                zstart += RSp1;
                int i2 = zstart;
                int i3 = i2 + 1;
                for (i = 0; i <= RadialSamples - 1; i++)
                {
                    shape.Indices[idx + 0] = i0; i0++;
                    shape.Indices[idx + 1] = i1;
                    shape.Indices[idx + 2] = i2;
                    shape.Indices[idx + 3] = i1; i1++;
                    shape.Indices[idx + 4] = i3; i3++;
                    shape.Indices[idx + 5] = i2; i2++;
                    idx += 6;
                }
            }

            // south pole triangles
            int VQm2 = VQuantity - 2;
            for (i = 0; i <= RadialSamples - 1; i++)
            {
                shape.Indices[idx + 0] = i;
                shape.Indices[idx + 1] = VQm2;
                shape.Indices[idx + 2] = i + 1;
                idx += 3;
            }

            // north pole triangles
            int VQm1 = VQuantity - 1;
            int offset = ZSm3 * RSp1;
            for (i = 0; i <= RadialSamples - 1; i++)
            {
                shape.Indices[idx + 0] = VQm1;
                shape.Indices[idx + 1] = i + offset;
                shape.Indices[idx + 2] = i + 1 + offset;
                idx += 3;
            }

            //  assert( aiLocalIndex == m_aiIndex + 3*iTQuantity );


            shape.Scale(Scale);
            Mesh mesh = content as Mesh;
            mesh.CreateVBO(shape);
        }
    }    
}
