using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Components
{
    

    public class CharacterSpriteComponent : DrawableRendererComponent
    {
        public CharacterSpriteData SpriteData;

        public CharacterSpriteComponent(CharacterSpriteData data) : base(Game.RenderWindow, null) {
            SpriteData = data;
        }

        public string Animation { 
            get { return _anim != null ? _anim.Name : null; }
            set { _anim = SpriteData.Animations.First(s => s.Name == value); }
        }

        private CharacterSpriteData.Animation _anim;

        public void Play() {
            
        }

        public void StopAnimation() { 
        }

        protected override void Draw()
        {
 	         base.Draw();
        }

        public int CurrentFrame { get; set; }

        public override void Start()
        {
            base.Start();
        }
    }
}
