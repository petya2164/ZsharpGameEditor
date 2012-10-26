using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using OpenTK.Input;

namespace ZGE.Components
{
    [HideComponent]
    public abstract class Camera : ZComponent
    {
        [Browsable(false)]        
        public Matrix4 ProjectionMatrix;
        [Browsable(false)] 
        public Matrix4 ViewMatrix;

        public Vector3 Position;
        public Vector3 Target;
        public Vector3 UpVector;
        public float ClipNear;
        public float ClipFar;

        public Camera()
        {
            Position = new Vector3(0, 0, 5);
            Target = new Vector3(0, 0, 0);
            UpVector = Vector3.UnitY;
            ClipNear = 0.1f;
            ClipFar = 1000.0f;
        }        

        public void Apply()
        {
            ApplyProjectionMatrix();
            ApplyViewMatrix();
        }

        public void Apply(ref Matrix4 pickMatrix)
        {
            ApplyProjectionMatrix(ref pickMatrix);
            ApplyViewMatrix();
        }        

        public virtual void ApplyProjectionMatrix()
        {
            CalculateProjectionMatrix();
            GL.MatrixMode(MatrixMode.PROJECTION);
            GL.LoadMatrix(ref ProjectionMatrix);
        }

        public virtual void ApplyProjectionMatrix(ref Matrix4 pickMatrix)
        {
            CalculateProjectionMatrix();
            Matrix4 result = ProjectionMatrix * pickMatrix;
            GL.MatrixMode(MatrixMode.PROJECTION);
            GL.LoadMatrix(ref result);
        }

        public virtual void ApplyViewMatrix()
        {
            CalculateViewMatrix();
            GL.MatrixMode(MatrixMode.MODELVIEW);
            GL.LoadMatrix(ref ViewMatrix);
        }

        public abstract void CalculateProjectionMatrix();
        public abstract void CalculateViewMatrix();


        public virtual bool MouseDown(MouseDescriptor e) { return false; }
        public virtual bool MouseUp(MouseDescriptor e) { return false; }
        public virtual bool MouseMove(MouseDescriptor e) { return false; }
        public virtual bool MouseWheel(MouseDescriptor e) { return false; }
    }

    public class ProjectiveCamera : Camera
    {
        public float FOV = MathHelper.PiOver4;

        public ProjectiveCamera()
        {            
        }

        public override void CalculateProjectionMatrix()
        {
            ProjectionMatrix =
                Matrix4.CreatePerspectiveFieldOfView(FOV, App.AspectRatio, ClipNear, ClipFar);            
        }

        public override void CalculateViewMatrix()
        {
            ViewMatrix = Matrix4.LookAt(Position, Target, UpVector);           
        }
    }

    public class OrthoCamera : Camera
    {
        public float OrthoZoom = 1.0f;

        public OrthoCamera()
        {           
        }

        public override void CalculateProjectionMatrix()
        {
            float h = 1.0f / OrthoZoom;
            float w = h * App.AspectRatio;
            ProjectionMatrix = Matrix4.CreateOrthographic(w, h, ClipNear, ClipFar);           
        }
        public override void CalculateViewMatrix()
        {
            ViewMatrix = Matrix4.LookAt(Position, Target, UpVector);           
        }
    }

    public class InteractiveCamera : ProjectiveCamera
    {
        public float RotationSpeed = 0.5f;
        public float PanSpeed = 1.5f;
        public float ZoomSpeed = 0.5f;
        Vector3 startVector;
        Vector3 startEyeVector;
        //Quaternion lastRot;
        Vector2 startPos;

        public InteractiveCamera()
        {            
        }

        public override bool MouseDown(MouseDescriptor e) 
        {
            if (e[MouseButton.Middle])
            {
                //Console.WriteLine("Start Panning - X: {0} Y: {1}", e.X, e.Y);
                startPos = new Vector2((float) e.X, (float) e.Y);
                return true;
            }
            if (e[MouseButton.Right])
            {
                //Console.WriteLine("Start Rotating - X: {0} Y: {1}", e.X, e.Y);
                startVector = MapToSphere((float)e.X, (float)e.Y);
                startEyeVector = Position - Target;
                //startPos = new Vector2((float) e.X, (float) e.Y);
                return true;
            }
            return false;
        }
        public override bool MouseUp(MouseDescriptor e) 
        {
            if (e[MouseButton.Middle])
            {
                //Console.WriteLine("End Panning - X: {0} Y: {1}", e.X, e.Y);
                return true;
            }
            if (e[MouseButton.Right])
            {
                //Console.WriteLine("End Rotating - X: {0} Y: {1}", e.X, e.Y);
                return true;
            }
            return false;
        }
        public override bool MouseMove(MouseDescriptor e) 
        {
            if (e[MouseButton.Middle])
            {
                //Console.WriteLine("Panning - X: {0} Y: {1}", e.X, e.Y);
                Vector2 newPos = new Vector2((float) e.X, (float) e.Y);
                PanTarget(newPos);                
                return true;
            }
            if (e[MouseButton.Right])
            {
                //Console.WriteLine("Rotating - X: {0} Y: {1}", e.X, e.Y);
                RotateWithQuaternion((float)e.X, (float)e.Y);
                //Vector2 newPos = new Vector2((float) e.X, (float) e.Y);
                //RotateAroundUpVector(newPos);
                //startPos = newPos;
                return true;
            }

            return false;
        }
        public override bool MouseWheel(MouseDescriptor e) 
        {
            //Console.WriteLine("Mouse wheel delta: " + e.WheelDelta.ToString());
            Vector3 eyeVector = Position - Target;
            float len = eyeVector.Length;
            len -= ZoomSpeed * e.WheelDelta * 0.001f * len;
            eyeVector.Normalize();            
            Position = Target + eyeVector * len;
            return true;
        }

        public void PanTarget(Vector2 newPos)
        {
            // Nothing to do - the two vectors are the same
            if (startPos == newPos) return;

            float hor_offset = -(newPos.X - startPos.X) / 100.0f * PanSpeed;
            float ver_offset = -(newPos.Y - startPos.Y) / 100.0f * PanSpeed;
            Matrix4 ivm = Matrix4.Invert(ViewMatrix);
            Vector3 right = new Vector3(ivm.Row0);
            Vector3 front = Vector3.Cross(right, UpVector);
            right.Normalize();
            front.Normalize();
            //eyeVector = Vector3.TransformVector(eyeVector, Matrix4.CreateFromAxisAngle(UpVector, -hor_angle));
            Target += right * hor_offset;
            Position += right * hor_offset;
            Target += front * ver_offset;
            Position += front * ver_offset;

            startPos = newPos;
        }

        public void RotateAroundUpVector(Vector2 newPos)
        {
            // Nothing to do - the two vectors are the same
            if (startPos == newPos) return;

            float hor_angle = MathHelper.DegreesToRadians((newPos.X - startPos.X) / 5.0f);
            Vector3 eyeVector = Position - Target;
            float len = eyeVector.Length;
            eyeVector.Normalize();            
            eyeVector = Vector3.TransformVector(eyeVector, Matrix4.CreateFromAxisAngle(UpVector, -hor_angle));
            Position = Target + eyeVector * len;

            //  Compute the cross product of the begin and end vectors.
            /*Vector3 cross = Vector3.Cross(startVector, vec);

            //  Is the perpendicular length essentially non-zero?
            if (cross.Length > 1.0e-5f)
            {
                //Console.WriteLine("Cross: "+cross.ToString());
                //  The quaternion is the transform.
                float angle = 0.2f * (float) Math.Acos(Math.Min(1.0f, Vector3.Dot(startVector, vec)));
                //float angle = Vector3.CalculateAngle(startVector, vec);
                //Quaternion quat = Quaternion.FromAxisAngle(cross, angle);

                //Quaternion quat = new Quaternion(cross, Vector3.Dot(startVector, vec));                
                //return new float[] { cross.X, cross.Y, cross.Z, startVector.ScalarProduct(currentVector) };

                Vector3 axisInWorldCoord = Vector3.TransformVector(cross, Matrix4.Invert(ViewMatrix));
                Quaternion quat = Quaternion.FromAxisAngle(axisInWorldCoord, -angle);                
            }*/
        }

        public Vector3 MapToSphere(float x, float y)
        {
            Vector3 ret;            

            // Map the mouse coordinates from the range of [0...width), [0...height) to [-1...1], [1...-1]
            // Y-axis is flipped in OpenGL
            float scaledX = (2.0f * x / (App.CurrentWidth - 1.0f) - 1.0f);
            float scaledY = -(2.0f * y / (App.CurrentHeight - 1.0f) - 1.0f);

            //Console.WriteLine("Scaled - X: {0} Y: {1}", scaledX, scaledY);

            //  Get square of length of vector to point from centre.
            float length = scaledX * scaledX + scaledY * scaledY;

            //  Are we outside the sphere?
            if (length > 1.0f)
            {
                //  Get normalising factor.
                float norm = 1.0f / (float) Math.Sqrt(length);
                //  Return normalised vector, a point on the sphere.
                ret = new Vector3(scaledX * norm, scaledY * norm, 0);
            }
            else
            {
                //  Return a vector to a point mapped on the sphere.
                ret = new Vector3(scaledX, scaledY, (float) Math.Sqrt(1.0f - length));
            }
            //Console.WriteLine("MapToSphere - X: {0} Y: {1} Z: {2}", ret.X, ret.Y, ret.Z);
            return ret;
        }

        public void RotateWithQuaternion(float x, float y)
        {        
            //  Map the current vector.
            Vector3 vec = MapToSphere(x, y);

            // Nothing to do - the two vectors are the same
            if (startVector == vec) return;

            //  Compute the cross product of the begin and end vectors.
            Vector3 cross = Vector3.Cross(startVector, vec);

            //  Is the perpendicular length essentially non-zero?
            if (cross.Length > 1.0e-5f)
            {
                //Console.WriteLine("Cross: "+cross.ToString());
                //  The quaternion is the transform.
                float angle = RotationSpeed*(float)Math.Acos(Math.Min(1.0f,Vector3.Dot(startVector, vec)));
                //float angle = Vector3.CalculateAngle(startVector, vec);
                //Quaternion quat = Quaternion.FromAxisAngle(cross, angle);
                
                //Quaternion quat = new Quaternion(cross, Vector3.Dot(startVector, vec));                
                //return new float[] { cross.X, cross.Y, cross.Z, startVector.ScalarProduct(currentVector) };

                //Vector3 axisInWorldCoord = Vector3.TransformVector(cross, Matrix4.Invert(ViewMatrix));
                //Quaternion quat = Quaternion.FromAxisAngle(axisInWorldCoord, -angle);
                Quaternion quat = Quaternion.FromAxisAngle(cross, -angle);

                Vector3 eyeVector = Position - Target;
                //float len = eyeVector.Length;
                //eyeVector.Normalize();
                eyeVector = Vector3.Transform(startEyeVector, quat);
               // eyeVector = Vector3.Transform(eyeVector, Matrix4.CreateFromAxisAngle(axisInWorldCoord, -angle));
                Position = Target + eyeVector;

                //startVector = vec;
            }                    
        }
    }

    /*public class ArcBall
    {
        private float adjustWidth = 1.0f;
        private float adjustHeight = 1.0f;
        private Vertex startVector = new Vertex(0, 0, 0);
        private Vertex currentVector = new Vertex(0, 0, 0);

        Matrix transformMatrix = new Matrix(4, 4);
        Matrix lastRotationMatrix = new Matrix(3, 3);
        Matrix thisRotationMatrix = new Matrix(3, 3);

        /// <summary>
        /// Initializes a new instance of the <see cref="PerspectiveCamera"/> class.
        /// </summary>
        public ArcBall()
        {
            //  Set the identity matrices.
            transformMatrix.SetIdentity();
            lastRotationMatrix.SetIdentity();
            thisRotationMatrix.SetIdentity();
        }

        /// <summary>
        /// This is the class' main function, to override this function and perform a 
        /// perspective transformation.
        /// </summary>
        public void TransformMatrix(OpenGL gl)
        {
            gl.MultMatrix(transformMatrix.AsColumnMajorArray);
        }

        public void MouseDown(int x, int y)
        {
            //  Map the start vertex.
            MapToSphere((float) x, (float) y, out startVector);
        }

        public void MouseMove(int x, int y)
        {
            //  todo need solid tuple types.
            //  Calculate the quaternion.
            float[] quaternion = CalculateQuaternion(x, y);

            thisRotationMatrix = Matrix3fSetRotationFromQuat4f(quaternion);
            thisRotationMatrix = thisRotationMatrix * lastRotationMatrix;
            Matrix4fSetRotationFromMatrix3f(ref transformMatrix, thisRotationMatrix);          // Set Our Final Transform's Rotation From This One
        }

        public void MouseUp(int x, int y)
        {
            lastRotationMatrix.FromOtherMatrix(thisRotationMatrix, 3, 3);
            thisRotationMatrix.SetIdentity();
            //Matrix4fSetRotationFromMatrix3f(ref transformMatrix, thisRotationMatrix);          // Set Our Final Transform's Rotation From This One
        }

        private Matrix Matrix3fSetRotationFromQuat4f(float[] q1)
        {
            float n, s;
            float xs, ys, zs;
            float wx, wy, wz;
            float xx, xy, xz;
            float yy, yz, zz;
            n = (q1[0] * q1[0]) + (q1[1] * q1[1]) + (q1[2] * q1[2]) + (q1[3] * q1[3]);
            s = (n > 0.0f) ? (2.0f / n) : 0.0f;

            xs = q1[0] * s; ys = q1[1] * s; zs = q1[2] * s;
            wx = q1[3] * xs; wy = q1[3] * ys; wz = q1[3] * zs;
            xx = q1[0] * xs; xy = q1[0] * ys; xz = q1[0] * zs;
            yy = q1[1] * ys; yz = q1[1] * zs; zz = q1[2] * zs;

            Matrix matrix = new Matrix(3, 3);

            matrix[0, 0] = 1.0f - (yy + zz); matrix[1, 0] = xy - wz; matrix[2, 0] = xz + wy;
            matrix[0, 1] = xy + wz; matrix[1, 1] = 1.0f - (xx + zz); matrix[2, 1] = yz - wx;
            matrix[0, 2] = xz - wy; matrix[1, 2] = yz + wx; matrix[2, 2] = 1.0f - (xx + yy);

            return matrix;
        }

        private void Matrix4fSetRotationFromMatrix3f(ref Matrix transform, Matrix matrix)
        {
            float scale = transform.TempSVD();
            transform.FromOtherMatrix(matrix, 3, 3);
            transform.Multiply(scale, 3, 3);
        }

        private float[] CalculateQuaternion(int x, int y)
        {
            //  Map the current vector.
            MapToSphere((float) x, (float) y, out currentVector);

            //  Compute the cross product of the begin and end vectors.
            Vertex cross = startVector.VectorProduct(currentVector);

            //  Is the perpendicular length essentially non-zero?
            if (cross.Magnitude() > 1.0e-5)
            {
                //  The quaternion is the transform.
                return new float[] { cross.X, cross.Y, cross.Z, startVector.ScalarProduct(currentVector) };
            }
            else
            {
                //  Begin and end coincide, return identity.
                return new float[] { 0, 0, 0, 0 };
            }
        }

        private void MapToSphere(float x, float y, out Vertex newVector)
        {
            float scaledX = x * adjustWidth - 1.0f;
            float scaledY = 1.0f - y * adjustHeight;

            //  Get square of length of vector to point from centre.
            float length = scaledX * scaledX + scaledY * scaledY;

            //  Are we outside the sphere?
            if (length > 1.0f)
            {
                //  Get normalising factor.
                float norm = 1.0f / (float) Math.Sqrt(length);

                //  Return normalised vector, a point on the sphere.
                newVector = new Vertex(-scaledX * norm, 0, scaledY * norm);
            }
            else
            {
                //  Return a vector to a point mapped inside the sphere.
                newVector = new Vertex(-scaledX, (float) Math.Sqrt(1.0f - length), scaledY);
            }
        }

        public void SetBounds(float width, float height)
        {
            //  Set the adjust width and height.
            adjustWidth = 1.0f / ((width - 1.0f) * 0.5f);
            adjustHeight = 1.0f / ((height - 1.0f) * 0.5f);
        }        
    }*/
}
