using FarseerPhysics.Dynamics;
using Newtonsoft.Json;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBlack
{
    public class Tile
    {
        public bool HasFloor;
        public bool IsSolid;
        public int TileTypeIndex;
        public float Damage;

        [JsonIgnore, NonSerialized]
        public Fixture Fixture;
        [JsonIgnore]
        public TileType TileType { 
            get { return TileType.Types[TileTypeIndex]; } 
        }
        [JsonIgnore, NonSerialized]
        public Sprite Sprite;
    }
}
