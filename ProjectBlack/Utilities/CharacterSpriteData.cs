using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public enum AnimationType
    {
        Forward, Reverse, LoopingForward, LoopingReverse, PingPongForward, PingPongReverse
    }

    public class CharacterSpriteData
    {
        public string TextureId;
        public string Name;

        [JsonIgnore]
        public SFML.Graphics.Texture Texture;

        public List<SpriteData> Sprites = new List<SpriteData>();
        public List<Animation> Animations = new List<Animation>();


        public class Animation
        {
            public string Name;
            public List<Frame> Frames = new List<Frame>();
            public AnimationType Type = AnimationType.LoopingForward;
        }

        public class Frame
        {
            public string SpriteId;
            public float Seconds;

            [JsonIgnore]
            public SFML.Graphics.Sprite Sprite;
        }

        public class SpriteData
        {
            public string Name;
            public string SpriteId;
            public int X, Y, Width, Height;
            public float OriginX, OriginY;

            [JsonIgnore]
            public SFML.Graphics.Sprite Sprite;
        }

        public static CharacterSpriteData Load(string jsonData)
        {
            var data = JsonConvert.DeserializeObject<CharacterSpriteData>(jsonData);
            data.LoadTexturesAndSprites();
            return data;
        }

        public static CharacterSpriteData LoadFromFile(string filename) {
            var data = Utilities.JsonUtilities.LoadJson<CharacterSpriteData>(filename);
            data.LoadTexturesAndSprites();
            return data;
        }

        private void LoadTexturesAndSprites()
        {
            Texture = Graphics.Textures[TextureId];
            foreach (var spr in Sprites)
            {
                spr.Sprite = new SFML.Graphics.Sprite(Texture, new SFML.Graphics.IntRect(spr.X, spr.Y, spr.Width, spr.Height));
            }

            var spriteMap = Sprites.ToDictionary(k => k.SpriteId, v => v.Sprite);

            foreach (var anim in Animations)
            {
                foreach (var frames in anim.Frames)
                {
                    frames.Sprite = spriteMap[frames.SpriteId];
                }
            }
        }
    }
}
