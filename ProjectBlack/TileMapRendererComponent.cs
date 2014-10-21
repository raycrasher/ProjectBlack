using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class TileRendererComponent : Component
    {
        public TileMapComponent TileData;
        public Transformable Transform;
        public SFML.Utils.MapRenderer MapRenderer;

        private VertexArray _vertices;

        public override void Start()
        {
            base.Start();
        }

        public void Render() {
            int index = 0;
            for (int z = 0; z < TileData.Size.X; z++)
            {
                for (int y = 0; y < TileData.Size.Y; y++)
                {
                    for (int x = 0; x < TileData.Size.Z; x++)
                    {
                        var tile = TileData.Tiles[x, y, z];
                        if (tile == null) continue;
                        DrawTile(tile, index, new Vector3i(x,y,z));
                        index += 4;
                    }
                }
            }
        }

        public void Render(Vector3i v) { 
        
        }


        public static void DrawTile(Tile spr, int index, Vector3i pos)
        {

        }
    }
}
