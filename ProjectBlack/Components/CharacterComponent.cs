using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Components
{

    public class CharacterComponent : Component
    {
        public CharacterSpriteComponent Sprite;

        public override void Start()
        {
            Sprite = GetComponent<CharacterSpriteComponent>();
            base.Start();
        }
    }
}
