using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectBlack
{
    [Serializable]
    public struct Vector3i
    {
        public int X, Y, Z;

        public Vector3i(int x, int y, int z)
        {
            X = x; Y = y; Z = z;
        }

        public Vector3i(string str) {
            str = str.Replace("[", "").Replace("]", "").Trim();
            var arr = str.Split(' ', ',');
            if (arr.Length < 3) throw new ArgumentException();
            X = Convert.ToInt32(arr[0].Trim());
            Y = Convert.ToInt32(arr[1].Trim());
            Z = Convert.ToInt32(arr[2].Trim());
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector3i)) return false;
            var v = (Vector3i)obj;
            if (v == null) return false;
            return X==v.X && Y==v.Y && Z==v.Z;
        }

        public override int GetHashCode()
        {
            const int h1 = 73856093, h2 = 19999999, h3 = 83492791;
            return ((X * h1) ^ (Y * h2) ^ (Z * h3)) % (1 << 20);
        }

        public static bool operator ==(Vector3i a, Vector3i b) { return a.X == b.X && a.Y == b.Y && a.Z == b.Z; }
        public static bool operator !=(Vector3i a, Vector3i b) { return a.X != b.X || a.Y != b.Y || a.Z == b.Z; }

        public static Vector3i operator +(Vector3i a, Vector3i b) { return new Vector3i(a.X + b.X, a.Y + b.Y, a.Z + b.Z); }
        public static Vector3i operator -(Vector3i a, Vector3i b) { return new Vector3i(a.X - b.X, a.Y - b.Y, a.Z - b.Z); }
        public static Vector3i operator *(Vector3i a, Vector3i b) { return new Vector3i(a.X * b.X, a.Y * b.Y, a.Z * b.Z); }
        public static Vector3i operator /(Vector3i a, Vector3i b) { return new Vector3i(a.X / b.X, a.Y / b.Y, a.Z / b.Z); }

        public static Vector3i operator +(Vector3i a, int b) { return new Vector3i(a.X + b, a.Y + b, a.Z + b); }
        public static Vector3i operator -(Vector3i a, int b) { return new Vector3i(a.X - b, a.Y - b, a.Z - b); }
        public static Vector3i operator *(Vector3i a, int b) { return new Vector3i(a.X * b, a.Y * b, a.Z * b); }
        public static Vector3i operator /(Vector3i a, int b) { return new Vector3i(a.X / b, a.Y / b, a.Z / b); }

        public float Length
        {
            get { return Distance(Zero, this); }
        }

        public static float Distance(Vector3i a, Vector3i b)
        {
            return (float)Math.Sqrt(Distance2(a, b));
        }

        public static float Distance2(Vector3i a, Vector3i b)
        {
            return (b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y) + (b.Z - a.Z) * (b.Z - a.Z);
        }

        public long Hash 
        {
            get { return X + Y << 20 + Z << 40; }
        }

        public static Vector3i FromHash(long h)
        {
            Vector3i v;
            v.Z = (int)((h & 0x0FFFFF0000000000) >> 40);
            v.Y = (int)((h & 0x000000FFFFF00000) >> 20);
            v.X = (int)((h & 0x00000000000FFFFF) >> 20);

            return v;
        }

        public override string ToString()
        {
            return string.Format("[ {0}, {1}, {2} ]", X, Y, Z);
        }


        public readonly static Vector3i Zero = new Vector3i(0, 0, 0);
        public readonly static Vector3i Up = new Vector3i(0, 0, 1);
        public readonly static Vector3i Down = new Vector3i(0, 0, -1);
        public readonly static Vector3i West = new Vector3i(-1, 0, 0);
        public readonly static Vector3i East = new Vector3i(1, 0, 0);
        public readonly static Vector3i North = new Vector3i(0, 1, 0);
        public readonly static Vector3i South = new Vector3i(0, -1, 0);
        public readonly static Vector3i NorthEast = North+East;
        public readonly static Vector3i NorthWest = North+West;
        public readonly static Vector3i SouthEast = South+East;
        public readonly static Vector3i SouthWest = South+West;
        public readonly static Vector3i DownNorth = Down+North;
        public readonly static Vector3i DownEast = Down+East;
        public readonly static Vector3i DownSouth = Down+South;
        public readonly static Vector3i DownWest = Down+West;
        public readonly static Vector3i DownNorthEast = Down+North+East;
        public readonly static Vector3i DownSouthEast = Down+South+East;
        public readonly static Vector3i DownSouthWest = Down+South+West;
        public readonly static Vector3i DownNorthWest = Down+North+West;
        public readonly static Vector3i UpNorth = Up+North;
        public readonly static Vector3i UpEast = Up+East;
        public readonly static Vector3i UpSouth = Up+South;
        public readonly static Vector3i UpWest = Up+West;
        public readonly static Vector3i UpNorthEast = Up+North+East;
        public readonly static Vector3i UpSouthEast = Up+South+East;
        public readonly static Vector3i UpSouthWest = Up+South+West;
        public readonly static Vector3i UpNorthWest = Up+North+West;

    }


    public class Vector3iJsonSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var v = (Vector3i)value;
            serializer.Serialize(writer, v.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            return new Vector3i(jsonObject.Value<string>());
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
