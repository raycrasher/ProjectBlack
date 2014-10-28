using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace ProjectBlack.Utilities
{
    public class LibRocketRenderInterface: LibRocketNet.RenderInterface
    {
        class Geometry : IDisposable
        {
            public uint VertexID, IndexID;
            public int NumVertices;
            public SFML.Graphics.Texture Texture;

            ~Geometry() {
                Dispose();
            }

            public void Dispose() {
                if (VertexID != 0) GL.DeleteBuffer(VertexID);
                if (IndexID != 0) GL.DeleteBuffer(IndexID);
                VertexID = 0;
                IndexID = 0;
            }
        }


        Dictionary<IntPtr, Geometry> Geometries = new Dictionary<IntPtr, Geometry>();
        Dictionary<IntPtr, SFML.Graphics.Texture> Textures = new Dictionary<IntPtr, SFML.Graphics.Texture>();
        SFML.Graphics.RenderTexture RenderTexture;
        SFML.Graphics.View ScissorView, DefaultView;


        public LibRocketRenderInterface(SFML.Graphics.RenderTexture RenderTexture)
        {
            this.RenderTexture = RenderTexture;
        }


        public unsafe override IntPtr CompileGeometry(LibRocketNet.Vertex* vertices, int num_vertices, int* indices, int num_indices, IntPtr texture)
        {
            var geom = new Geometry();
            GL.GenBuffers(1, out geom.VertexID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, geom.VertexID);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(sizeof(LibRocketNet.Vertex) * num_vertices), new IntPtr(vertices), BufferUsageHint.StaticDraw);

            GL.GenBuffers(1, out geom.IndexID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, geom.VertexID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, new IntPtr(sizeof(int)), new IntPtr(indices), BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            geom.Texture = Textures[texture];

            var ptr=new IntPtr(geom.GetHashCode());
            Geometries[ptr] = geom;

            return ptr;
        }

        public override void EnableScissorRegion(bool enable)
        {
            if (enable)
                GL.Enable(EnableCap.ScissorTest);
            else
                GL.Disable(EnableCap.ScissorTest);
        }

        public unsafe override bool GenerateTexture(ref IntPtr texture_handle, byte* source, LibRocketNet.Vector2i dimensions)
        {
            byte[] arr = new byte[sizeof(SFML.Graphics.Color) * dimensions.X * dimensions.Y];
            
            System.Runtime.InteropServices.Marshal.Copy(new IntPtr(source), arr, 0, arr.Length);
            var image=new SFML.Graphics.Image((uint)dimensions.X, (uint)dimensions.Y, arr);
            var texture = new SFML.Graphics.Texture(image);
            texture_handle = new IntPtr(texture.GetHashCode());
            Textures[texture_handle] = texture;
            image.Dispose();
            return true;
        }




        public override bool LoadTexture(ref IntPtr texture_handle, ref LibRocketNet.Vector2i texture_dimensions, string source)
        {
            try
            {
                var texture = new SFML.Graphics.Texture(source);
                texture_handle = new IntPtr(texture.GetHashCode());
                Textures[texture_handle] = texture;
            }
            catch (SFML.LoadingFailedException) {
                return false;
            }
            return true;
        }

        public override void Release()
        {
            Geometries.Clear();
            Textures.Clear();
        }

        public override void ReleaseCompiledGeometry(IntPtr geometry)
        {
            var geom = Geometries[geometry];
            geom.Dispose();
            Geometries.Remove(geometry);
        }

        public override void ReleaseTexture(IntPtr texture)
        {
            Textures.Remove(texture);
        }

        public unsafe override void RenderCompiledGeometry(IntPtr geometry, LibRocketNet.Vector2f translation)
        {
            var geom = Geometries[geometry];
            RenderTexture.SetActive(true);
            RenderTexture.PushGLStates();
            
            GL.PushMatrix();
            GL.Translate(translation.X, translation.Y, 0);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Enable(EnableCap.ColorArray);
            GL.Enable(EnableCap.TextureCoordArray);
            GL.Enable(EnableCap.VertexArray);

            var texture = geom.Texture;
            SFML.Graphics.Texture.Bind(texture);

            GL.BindBuffer(BufferTarget.ArrayBuffer, geom.VertexID);
            GL.VertexPointer(2, VertexPointerType.Float, sizeof(LibRocketNet.Vertex), 0);
            GL.ColorPointer(4, ColorPointerType.UnsignedByte, sizeof(LibRocketNet.Vertex), sizeof(LibRocketNet.Vector2f));
            GL.VertexPointer(2, VertexPointerType.Float, sizeof(LibRocketNet.Vertex), 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, geom.IndexID);
            GL.DrawElements(BeginMode.Triangles, geom.NumVertices, DrawElementsType.UnsignedInt, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.Disable(EnableCap.ColorArray);
            GL.Disable(EnableCap.TextureCoordArray);
            GL.Disable(EnableCap.VertexArray);

            GL.PopMatrix();

            RenderTexture.PopGLStates();
        }

        public unsafe override void RenderGeometry(LibRocketNet.Vertex* vertices, int num_vertices, int* indices, int num_indices, IntPtr texture, LibRocketNet.Vector2f translation)
        {
            RenderTexture.SetActive(true);
            RenderTexture.PushGLStates();
            GL.PushMatrix();
            GL.Translate(translation.X,translation.Y,0);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.VertexPointer(2, VertexPointerType.Float, sizeof(LibRocketNet.Vertex), 0);
            GL.ColorPointer(4, ColorPointerType.UnsignedByte, sizeof(LibRocketNet.Vertex), sizeof(LibRocketNet.Vector2f));
            GL.VertexPointer(2, VertexPointerType.Float, sizeof(LibRocketNet.Vertex), 0);

            if (texture != IntPtr.Zero)
            {
                // bind texture
                var tex = Textures[texture];
                SFML.Graphics.Texture.Bind(tex);
                GL.Enable(EnableCap.Texture2D);
                GL.TexCoordPointer(2, TexCoordPointerType.Float, sizeof(LibRocketNet.Vertex), sizeof(LibRocketNet.Vector2f) + sizeof(LibRocketNet.Color));
            }
            else
            {
                GL.Disable(EnableCap.Texture2D);
                GL.DisableClientState(ArrayCap.ColorArray);
            }
            GL.DrawElements(PrimitiveType.Triangles, num_indices, DrawElementsType.UnsignedInt, new IntPtr(indices));
            GL.PopMatrix();
            RenderTexture.PopGLStates();
        }


        public override void SetScissorRegion(int x, int y, int width, int height) {
            GL.Scissor(x, (int) RenderTexture.Size.Y - (y + height), width, height);
        }
    }
}
