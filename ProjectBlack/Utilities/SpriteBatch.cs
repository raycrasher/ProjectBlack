using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace SFML.Utils
{
    public class SpriteBatch
    {
        Vertex[] vertices;
        uint count;
        RenderStates states;
        RenderTarget rt;

        public SpriteBatch(RenderTarget rt, int numSprites = 1024)
        {
            states = RenderStates.Default;
            vertices = new Vertex[numSprites * 4];
            this.rt = rt;
        }

        public void Display(RenderStates states)
        {
            if (count == 0) return;
            rt.Draw(vertices, 0, count * 4, PrimitiveType.Quads, states);
        }
        public void Display(Texture texture)
        {
            states = RenderStates.Default;
            states.Texture = texture;
            Display(states);
        }

        public void Flush()
        {
            count = 0;
        }

        public void Draw(IEnumerable<Sprite> sprites)
        {
            foreach (var s in sprites)
                Draw(s);
        }

        public void Draw(Sprite sprite)
        {
            Draw(sprite.Position, sprite.TextureRect, sprite.Color, sprite.Scale, sprite.Origin, sprite.Rotation);
        }
        //const float PI = 3.14159265f;

        public void Draw(Vector2f position, IntRect rec, Color color, Vector2f scale, Vector2f origin, float rotation = 0)
        {
            if (count >= (vertices.Length / 4))
                Array.Resize<Vertex>(ref vertices, vertices.Length * 2);

            rotation = rotation * (float)Math.PI / 180;
            var sin = (float)Math.Sin(rotation);
            var cos = (float)Math.Cos(rotation);

            origin.X *= scale.X;
            origin.Y *= scale.Y;
            scale.X *= rec.Width;
            scale.Y *= rec.Height;

            Vertex v = new Vertex();
            v.Color = color;

            float pX, pY;

            pX = -origin.X;
            pY = -origin.Y;
            v.Position.X = pX * cos - pY * sin + position.X;
            v.Position.Y = pX * sin + pY * cos + position.Y;
            v.TexCoords.X = rec.Left;
            v.TexCoords.Y = rec.Top;
            vertices[count * 4 + 0] = v;

            pX += scale.X;
            v.Position.X = pX * cos - pY * sin + position.X;
            v.Position.Y = pX * sin + pY * cos + position.Y;
            v.TexCoords.X += rec.Width;
            vertices[count * 4 + 1] = v;

            pY += scale.Y;
            v.Position.X = pX * cos - pY * sin + position.X;
            v.Position.Y = pX * sin + pY * cos + position.Y;
            v.TexCoords.Y += rec.Height;
            vertices[count * 4 + 2] = v;

            pX -= scale.X;
            v.Position.X = pX * cos - pY * sin + position.X;
            v.Position.Y = pX * sin + pY * cos + position.Y;
            v.TexCoords.X -= rec.Width;
            vertices[count * 4 + 3] = v;

            count++;
        }
    }
}