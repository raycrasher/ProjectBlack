using FarseerPhysics.Dynamics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class TileMapComponent : Component
    {
        public struct TileTuple {
            public Vector3i Position;
            public Tile Tile;
        }

        public Vector3i Size;
        public Tile[, ,] Tiles;

        public IEnumerable<TileTuple> EnumerateBox(Vector3i a, Vector3i b, bool includeNull=true) { 
            int sx = Math.Sign(b.X-a.X);
            int sy = Math.Sign(b.Y-a.Y);
            int sz = Math.Sign(b.Z-a.Z);
            if(sx==0) sx=1;
            if(sy==0) sy=1;
            if(sz==0) sz=1;

            int x=a.X, y=a.Y, z=a.Z;

            do {
                do {
                    do {
                        var tile=Tiles[x,y,z];
                        if(tile==null && !includeNull) continue;
                        yield return new TileTuple { Position = new Vector3i(x, y, z), Tile = tile };
                        z += sz;
                    } while (z != b.Z);
                    y += b.Y;
                } while (y != b.Y);
                x += b.X;
            } while (x != b.X);
        }

        public void UpdateTiles(IEnumerable<Vector3i> positions) {
            if (OnUpdateTiles == null) return;
            OnUpdateTiles(from p in positions
                          let tile = Tiles[p.X, p.Y, p.Z]
                          where tile != null
                          select new TileTuple { Tile = tile, Position = p });
        }

        public void UpdateTiles(IEnumerable<TileTuple> tiles)
        {
            if (OnUpdateTiles == null) return;
            OnUpdateTiles(tiles);
        }

        public event Action<IEnumerable<TileTuple>> OnUpdateTiles;
    }
}
