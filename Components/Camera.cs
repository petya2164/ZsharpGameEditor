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

    public class InteractiveCamera : ProjectiveCamera, INeedRefresh
    {
        public MouseButton PanButton = MouseButton.Middle;
        public MouseButton RotateButton = MouseButton.Right;        

        public float RotationSpeed = 1.0f;
        public float PanSpeed = 1.5f;
        public float ZoomSpeed = 0.5f;
        Vector3 startVector;
        //Vector3 defaultEyeVector = new Vector3(0,0,1);
        //Vector3 defaultUpVector = new Vector3(0,1,0);
        //Quaternion lastRot = Quaternion.Identity;
        //Quaternion currentRot = Quaternion.Identity;
        Vector2 startPos;
        //public Vector3 ReferenceUpVector = new Vector3(0, 0, 1);
        Vector2 panStartPos;

        public InteractiveCamera()
        {            
        }

        public void Refresh()
        {
            // The accumulated rotation becomes invalid if the camera coords are changed manually
            //currentRot = Quaternion.Identity;
        }

        public override bool MouseDown(MouseDescriptor e) 
        {
            if (e[PanButton])
            {
                //Console.WriteLine("Start Panning - X: {0} Y: {1}", e.X, e.Y);
                panStartPos = new Vector2((float) e.X, (float) e.Y);
                return true;
            }
            if (e[RotateButton])
            {
                //Console.WriteLine("Start Rotating - X: {0} Y: {1}", e.X, e.Y);
                startVector = MapToSphere((float)e.X, (float)e.Y);
                //startEyeVector = Position - Target;
                /*lastRot = currentRot;
                // Calculate the current rotation for the first time
                if (currentRot == Quaternion.Identity)
                {
                    Vector3 eyeVector = Position - Target;                    
                    eyeVector.Normalize();
                    //  Compute the cross product of the default and current eye vectors.
                    Vector3 cross = Vector3.Cross(defaultEyeVector, eyeVector);

                    //  Is the perpendicular length essentially non-zero?
                    if (cross.Length > 1.0e-5f)
                    {
                        float angle = (float) Math.Acos(Vector3.Dot(defaultEyeVector, eyeVector));
                        // Calculate rotation relative to the default eye vector (0,0,1)
                        lastRot = Quaternion.FromAxisAngle(cross, angle);
                    }
                }*/
                startPos = new Vector2((float) e.X, (float) e.Y);
                return true;
            }
            return false;
        }
        public override bool MouseUp(MouseDescriptor e) 
        {
            if (e[PanButton])
            {
                //Console.WriteLine("End Panning - X: {0} Y: {1}", e.X, e.Y);
                return true;
            }
            if (e[RotateButton])
            {
                //Console.WriteLine("End Rotating - X: {0} Y: {1}", e.X, e.Y);
                return true;
            }
            return false;
        }
        public override bool MouseMove(MouseDescriptor e) 
        {
            if (e[PanButton])
            {
                //Console.WriteLine("Panning - X: {0} Y: {1}", e.X, e.Y);
                Vector2 newPos = new Vector2((float) e.X, (float) e.Y);
                PanTarget(newPos);
                panStartPos = newPos;
                return true;
            }
            if (e[RotateButton])
            {
                //Console.WriteLine("Rotating - X: {0} Y: {1}", e.X, e.Y);
                //RotateWithQuaternion((float)e.X, (float)e.Y);
                Vector2 newPos = new Vector2((float) e.X, (float) e.Y);
                RotateAroundUpVector(newPos);
                startPos = newPos;                
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
            if (panStartPos == newPos) return;

            float hor_offset = -(newPos.X - panStartPos.X) / 100.0f * PanSpeed;
            float ver_offset = -(newPos.Y - panStartPos.Y) / 100.0f * PanSpeed;
            Matrix4 ivm = Matrix4.Invert(ViewMatrix);
            Vector3 right = new Vector3(ivm.Row0);
            Vector3 front = Vector3.Cross(right, UpVector);
            right.Normalize();
            front.Normalize();
            if (Position.Z < 0) ver_offset = -ver_offset;
            
            Target += right * hor_offset;
            Position += right * hor_offset;
            Target += front * ver_offset;
            Position += front * ver_offset;            
        }

        public void RotateAroundUpVector(Vector2 newPos)
        {
            // Nothing to do - the two vectors are the same
            if (startPos == newPos) return;

            Vector3 eyeVector = Position - Target;
            float len = eyeVector.Length;  // We want to keep the length
            eyeVector.Normalize();

            float ver_angle = RotationSpeed * MathHelper.DegreesToRadians((newPos.Y - startPos.Y) / 5.0f);
            Vector3 right = -Vector3.Cross(eyeVector, UpVector);
            //Matrix4 ivm = Matrix4.Invert(ViewMatrix);
            //Vector3 right = new Vector3(ivm.Row0);
            //Vector3 up = new Vector3(ivm.Row1);
            //Vector3 front = Vector3.Cross(right, UpVector);
            right.Normalize();
            float angle = Vector3.CalculateAngle(eyeVector, UpVector);
            if (float.IsNaN(angle)) return;
            if (ver_angle > angle) return;
            //if (angle > MathHelper.PiOver2 && -ver_angle > MathHelper.Pi - angle) return;
            if (ver_angle < 0 && angle - ver_angle > MathHelper.Pi) return;

            eyeVector = Vector3.TransformVector(eyeVector, Matrix4.CreateFromAxisAngle(right, -ver_angle));            

            float hor_angle = RotationSpeed * MathHelper.DegreesToRadians((newPos.X - startPos.X) / 5.0f);
            eyeVector = Vector3.TransformVector(eyeVector, Matrix4.CreateFromAxisAngle(UpVector, -hor_angle));
            Position = Target + eyeVector * len;

            //Vector3 newRight = Vector3.Cross(-eyeVector, ReferenceUpVector);
            //UpVector = Vector3.Cross(newRight, -eyeVector);

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
                //float angle = RotationSpeed*(float)Math.Acos(Math.Min(1.0f,Vector3.Dot(startVector, vec)));
                
                float angle = RotationSpeed * Vector3.CalculateAngle(startVector, vec);
                if (float.IsNaN(angle)) return;
                
                //Quaternion quat = new Quaternion(cross, Vector3.Dot(startVector, vec));
                //return new float[] { cross.X, cross.Y, cross.Z, startVector.ScalarProduct(currentVector) }; 

                Vector3 axisInWorldCoord = Vector3.TransformVector(cross, Matrix4.Invert(ViewMatrix));
                
                Quaternion quat = Quaternion.FromAxisAngle(axisInWorldCoord, -angle);
                // Calculate rotation relative to the start vector
                //Quaternion quat = Quaternion.FromAxisAngle(cross, -angle);

                Vector3 eyeVector = Position - Target;
                //float len = eyeVector.Length; //keep the length
                //eyeVector.Normalize();
                // Accumulate last Rotation into this One
                //currentRot = lastRot * quat;
                // Apply the accumulated rotation to the default eye vector
                //eyeVector = Vector3.Transform(defaultEyeVector, currentRot);
                //UpVector = Vector3.Transform(defaultUpVector, currentRot);
               // eyeVector = Vector3.Transform(eyeVector, Matrix4.CreateFromAxisAngle(axisInWorldCoord, -angle));
                eyeVector = Vector3.Transform(eyeVector, quat);
                Position = Target + eyeVector;

                startVector = vec;
            }                    
        }        
    }    
}
