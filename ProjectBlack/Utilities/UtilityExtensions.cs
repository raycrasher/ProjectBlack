using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public static class UtilityExtensions
    {
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Game.Rng.Next());
        }

        public static IEnumerator<T> ToCircular<T>(this IEnumerator<T> e)
        {
            return new CircularEnumerator<T>(e);
        }

        public static Color ToColor(this string s) {
            return int.Parse(s.Replace("#", ""), System.Globalization.NumberStyles.HexNumber).ToColorRGBA();
        }

        public static string ToString(this Color c) {
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", c.R, c.G, c.B, c.A);
        }

        public static Color ToColorRGBA(this int rgba) {
            return new Color
            {
                R = (byte)(rgba & 0x000000FF),
                G = (byte)((rgba & 0x0000FF00) >> 8),
                B = (byte)((rgba & 0x00FF0000) >> 16),
                A = (byte)((rgba & 0xFF000000) >> 24)
            };
        }



        public static float Clamp(this float value, float min, float max) {
            return value >= min ? (value <= max ? value : max) : min;
        }

        public static bool IsPOD(this Type t)
        {
            if (
                   t == typeof(int)
                || t == typeof(float)
                || t == typeof(double)
                || t == typeof(string)
                || t == typeof(char)
                || t == typeof(short)
                || t == typeof(long)
                // || t == typeof(Color)
                // || t == typeof(Vector3i)
                // || t == typeof(Vector2i)
                ) return true;
            else return false;
        }

        public static Vector2 ToPhysics(this Vector2f v) {
            return new Vector2(v.X * Game.PhysicsScale, v.Y * Game.PhysicsScale);
        }

        public static Vector2f ToSfml(this Vector2 v)
        {
            return new Vector2f(v.X / Game.PhysicsScale, v.Y / Game.PhysicsScale);
        }

        public static float ToRadians(this float degrees) {
            return degrees * 0.0174532925f;
        }

        public static float ToDegrees(this float radians)
        {
            return radians * 57.2957795f;
        }
    }
}
