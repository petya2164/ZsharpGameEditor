using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ZGE.Components
{
    struct Vbo
    {
        public uint VertexBufferID;
        public uint ColorBufferID;
        public uint TexCoordBufferID;
        public uint NormalBufferID;
        public uint ElementBufferID;
        public int NumElements;
    }

    public class Mesh: ZContent
    {
        Vbo vbo = new Vbo();


        /// <summary>
        /// Generate a VertexBuffer for each of Color, Normal, TextureCoordinate, Vertex, and Indices
        /// </summary>
        public void CreateVBO(Shape shape)
        {
            // GL.DeleteBuffers for all non-zero buffers
            if (vbo.VertexBufferID != 0) GL.DeleteBuffers(1, ref vbo.VertexBufferID); 
            if (vbo.ElementBufferID != 0) GL.DeleteBuffers(1, ref vbo.ElementBufferID); 
            if (vbo.TexCoordBufferID != 0) GL.DeleteBuffers(1, ref vbo.TexCoordBufferID);
            if (vbo.NormalBufferID != 0) GL.DeleteBuffers(1, ref vbo.NormalBufferID);
            if (vbo.ColorBufferID != 0) GL.DeleteBuffers(1, ref vbo.ColorBufferID);
            vbo = new Vbo();

            if (shape.Vertices == null) return;
            if (shape.Indices == null) return;

            int bufferSize;

            // Color Array Buffer
            if (shape.Colors != null)
            {
                // Generate Array Buffer Id
                GL.GenBuffers(1, out vbo.ColorBufferID);
                // Bind current context to Array Buffer ID
                GL.BindBuffer(BufferTarget.ARRAY_BUFFER, vbo.ColorBufferID);
                // Send data to buffer
                GL.BufferData(BufferTarget.ARRAY_BUFFER, (IntPtr) (shape.Colors.Length * sizeof(int)), shape.Colors, BufferUsageHint.STATIC_DRAW);
                // Validate that the buffer is the correct size
                GL.GetBufferParameter(BufferTarget.ARRAY_BUFFER, BufferParameterName.BUFFER_SIZE, out bufferSize);
                if (shape.Colors.Length * sizeof(int) != bufferSize)
                    throw new ApplicationException("Vertex array not uploaded correctly");
                // Clear the buffer Binding
                GL.BindBuffer(BufferTarget.ARRAY_BUFFER, 0);
            }

            // Normal Array Buffer
            if (shape.Normals != null)
            {
                // Generate Array Buffer Id
                GL.GenBuffers(1, out vbo.NormalBufferID);
                // Bind current context to Array Buffer ID
                GL.BindBuffer(BufferTarget.ARRAY_BUFFER, vbo.NormalBufferID);
                // Send data to buffer
                GL.BufferData(BufferTarget.ARRAY_BUFFER, (IntPtr) (shape.Normals.Length * Vector3.SizeInBytes), shape.Normals, BufferUsageHint.STATIC_DRAW);
                // Validate that the buffer is the correct size
                GL.GetBufferParameter(BufferTarget.ARRAY_BUFFER, BufferParameterName.BUFFER_SIZE, out bufferSize);
                if (shape.Normals.Length * Vector3.SizeInBytes != bufferSize)
                    throw new ApplicationException("Normal array not uploaded correctly");
                // Clear the buffer Binding
                GL.BindBuffer(BufferTarget.ARRAY_BUFFER, 0);
            }

            // TexCoord Array Buffer
            if (shape.Texcoords != null)
            {
                // Generate Array Buffer Id
                GL.GenBuffers(1, out vbo.TexCoordBufferID);
                // Bind current context to Array Buffer ID
                GL.BindBuffer(BufferTarget.ARRAY_BUFFER, vbo.TexCoordBufferID);
                // Send data to buffer
                GL.BufferData(BufferTarget.ARRAY_BUFFER, (IntPtr) (shape.Texcoords.Length * Vector2.SizeInBytes), shape.Texcoords, BufferUsageHint.STATIC_DRAW);
                // Validate that the buffer is the correct size
                GL.GetBufferParameter(BufferTarget.ARRAY_BUFFER, BufferParameterName.BUFFER_SIZE, out bufferSize);
                if (shape.Texcoords.Length * Vector2.SizeInBytes != bufferSize)
                    throw new ApplicationException("TexCoord array not uploaded correctly");
                // Clear the buffer Binding
                GL.BindBuffer(BufferTarget.ARRAY_BUFFER, 0);
            }

            // Vertex Array Buffer
            {
                // Generate Array Buffer Id
                GL.GenBuffers(1, out vbo.VertexBufferID);
                // Bind current context to Array Buffer ID
                GL.BindBuffer(BufferTarget.ARRAY_BUFFER, vbo.VertexBufferID);
                // Send data to buffer
                GL.BufferData(BufferTarget.ARRAY_BUFFER, (IntPtr) (shape.Vertices.Length * Vector3.SizeInBytes), shape.Vertices, BufferUsageHint.STATIC_DRAW);
                // Validate that the buffer is the correct size
                GL.GetBufferParameter(BufferTarget.ARRAY_BUFFER, BufferParameterName.BUFFER_SIZE, out bufferSize);
                if (shape.Vertices.Length * Vector3.SizeInBytes != bufferSize)
                    throw new ApplicationException("Vertex array not uploaded correctly");
                // Clear the buffer Binding
                GL.BindBuffer(BufferTarget.ARRAY_BUFFER, 0);
            }

            // Element Array Buffer
            {
                // Generate Array Buffer Id
                GL.GenBuffers(1, out vbo.ElementBufferID);
                // Bind current context to Array Buffer ID
                GL.BindBuffer(BufferTarget.ELEMENT_ARRAY_BUFFER, vbo.ElementBufferID);
                // Send data to buffer
                GL.BufferData(BufferTarget.ELEMENT_ARRAY_BUFFER, (IntPtr) (shape.Indices.Length * sizeof(int)), shape.Indices, BufferUsageHint.STATIC_DRAW);
                // Validate that the buffer is the correct size
                GL.GetBufferParameter(BufferTarget.ELEMENT_ARRAY_BUFFER, BufferParameterName.BUFFER_SIZE, out bufferSize);
                if (shape.Indices.Length * sizeof(int) != bufferSize)
                    throw new ApplicationException("Element array not uploaded correctly");
                // Clear the buffer Binding
                GL.BindBuffer(BufferTarget.ELEMENT_ARRAY_BUFFER, 0);
            }

            // Store the number of elements for the DrawElements call
            vbo.NumElements = shape.Indices.Length;            
        }

        public void Render()
        {
            if (vbo.VertexBufferID == 0) return;
            if (vbo.ElementBufferID == 0) return;
            
            // Push current Array Buffer state so we can restore it later
            GL.PushClientAttrib(ClientAttribMask.CLIENT_VERTEX_ARRAY_BIT);
            

            if (GL.IsEnabled(EnableCap.LIGHTING))
            {
                // Normal Array Buffer
                if (vbo.NormalBufferID != 0)
                {
                    // Bind to the Array Buffer ID
                    GL.BindBuffer(BufferTarget.ARRAY_BUFFER, vbo.NormalBufferID);
                    // Set the Pointer to the current bound array describing how the data ia stored
                    GL.NormalPointer(NormalPointerType.FLOAT, Vector3.SizeInBytes, IntPtr.Zero);
                    // Enable the client state so it will use this array buffer pointer
                    GL.EnableClientState(ArrayCap.NORMAL_ARRAY);
                }
            }
            else
            {
                // Color Array Buffer (Colors not used when lighting is enabled)
                if (vbo.ColorBufferID != 0)
                {
                    // Bind to the Array Buffer ID
                    GL.BindBuffer(BufferTarget.ARRAY_BUFFER, vbo.ColorBufferID);
                    // Set the Pointer to the current bound array describing how the data ia stored
                    GL.ColorPointer(4, ColorPointerType.UNSIGNED_BYTE, sizeof(int), IntPtr.Zero);
                    // Enable the client state so it will use this array buffer pointer
                    GL.EnableClientState(ArrayCap.COLOR_ARRAY);
                }
            }

            // Texture Array Buffer
            if (GL.IsEnabled(EnableCap.TEXTURE_2D))
            {
                if (vbo.TexCoordBufferID != 0)
                {
                    // Bind to the Array Buffer ID
                    GL.BindBuffer(BufferTarget.ARRAY_BUFFER, vbo.TexCoordBufferID);
                    // Set the Pointer to the current bound array describing how the data ia stored
                    GL.TexCoordPointer(2, TexCoordPointerType.FLOAT, Vector2.SizeInBytes, IntPtr.Zero);
                    // Enable the client state so it will use this array buffer pointer
                    GL.EnableClientState(ArrayCap.TEXTURE_COORD_ARRAY);
                }
            }

            // Vertex Array Buffer
            
            // Bind to the Array Buffer ID
            GL.BindBuffer(BufferTarget.ARRAY_BUFFER, vbo.VertexBufferID);
            // Set the Pointer to the current bound array describing how the data ia stored
            GL.VertexPointer(3, VertexPointerType.FLOAT, Vector3.SizeInBytes, IntPtr.Zero);
            // Enable the client state so it will use this array buffer pointer
            GL.EnableClientState(ArrayCap.VERTEX_ARRAY);
            

            // Element Array Buffer
            
            // Bind to the Array Buffer ID
            GL.BindBuffer(BufferTarget.ELEMENT_ARRAY_BUFFER, vbo.ElementBufferID);
            // Draw the elements in the element array buffer
            // Draws up items in the Color, Vertex, TexCoordinate, and Normal Buffers using indices in the ElementArrayBuffer
            GL.DrawElements(BeginMode.TRIANGLES, vbo.NumElements, DrawElementsType.UNSIGNED_INT, IntPtr.Zero);
            // Could also call GL.DrawArrays which would ignore the ElementArrayBuffer and just use primitives
            // Of course we would have to reorder our data to be in the correct primitive order
            
            // Restore the state
            GL.PopClientAttrib();
        }
    }
}
