using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class TileMap
    {
        public string Filename; 

        public class JsonTileObject {
            public string Object;
            public int Weight;
            public int MinCount, MaxCount;
        }

        public class JsonTile {
            public int TileId;
            public List<JsonTileObject> Objects;
            public string Tags;
            public int Weight;
        }

        public class JsonLevel
        {
            public string ImageFile;
            public int Level;
        }

        public class JsonTileDefinition {
            public List<JsonLevel> Levels;
            public Dictionary<Color, JsonTile> Tiles; // global to all floors
        }

        public JsonTileDefinition JsonData;

        public TileMap(string jsonFilename)
        {
            JsonData = Utilities.JsonUtilities.LoadJson<JsonTileDefinition>(jsonFilename);
            Filename = jsonFilename;
            Construct();
        }

        private void Construct()
        {
            foreach (var floor in JsonData.Levels) {
                var img = new Image(floor.ImageFile);
                for (uint y = 0; y < img.Size.Y; y++) {
                    for (uint x = 0; x < img.Size.X; x++) {
                        var color = img.GetPixel(x, y);

                        JsonTile tile;

                        if (!JsonData.Tiles.TryGetValue(color, out tile)) {
                            Console.WriteLine("WARNING: unable to find color {0} in map definition {1}, image {2}.", color, Filename, floor.ImageFile);
                            continue;
                        }
                        // TODO: Construct tile here
                        
                    }
                }
            }
        }
    }
}
